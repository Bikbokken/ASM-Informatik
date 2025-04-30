using ASM.Shared.Models;
using ASM.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Repositories
{
    public class AssetRepository
    {
        private readonly AppDbContext _db;

        public AssetRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task<List<AssetCategory>> GetCategoriesAsync()
        {
            return _db.AssetCategories.OrderBy(c => c.Name).ToListAsync();
        }

        public Task<List<Asset>> GetAllAssetsAsync()
        {
            return _db.Assets
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.ResponsibleUser)
                .ToListAsync();
        }
        public async Task<Asset> GetByIdAsync(int id)
        {
            return await _db.Assets
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.ResponsibleUser)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Asset asset)
        {
            _db.Assets.Update(asset);
            await _db.SaveChangesAsync();
        }

        public async Task CreateAsync(Asset asset) // ← New method
        {
            await _db.Assets.AddAsync(asset);
            await _db.SaveChangesAsync();
        }
    }

}
