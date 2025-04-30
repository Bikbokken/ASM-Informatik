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
    public class AssetCategoryRepository
    {
        private readonly AppDbContext _context;

        public AssetCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<AssetCategory>> GetAllAsync()
        {
            return _context.AssetCategories
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }

}
