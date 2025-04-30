using ASM.Shared.Models;
using ASM.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Services
{
    public class AssetService
    {
        private readonly AssetRepository _repository;

        public AssetService(AssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AssetCategory>> GetCategoriesAsync()
        {
            return await _repository.GetCategoriesAsync();
        }

        public async Task<List<Asset>> GetFilteredAssetsAsync(string? status, int? categoryId)
        {
            var allAssets = await _repository.GetAllAssetsAsync();

            return allAssets
                .Where(a =>
                    (string.IsNullOrEmpty(status) || a.CurrentStatus == status) &&
                    (!categoryId.HasValue || a.CategoryId == categoryId))
                .ToList();
        }


        public Task<Asset> GetAssetAsync(int id) => _repository.GetByIdAsync(id);

        public Task UpdateAssetAsync(Asset asset) => _repository.UpdateAsync(asset);
        public Task CreateAssetAsync(Asset asset) // ← New method
        {
            return _repository.CreateAsync(asset);
        }

    }

}
