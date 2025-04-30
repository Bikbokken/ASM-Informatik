using ASM.Shared.Models;
using ASM.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Services
{
    public class AssetCategoryService 
    {
        private readonly AssetCategoryRepository _repo;

        public AssetCategoryService(AssetCategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<List<AssetCategory>> GetAllAsync() => _repo.GetAllAsync();
    }
}
