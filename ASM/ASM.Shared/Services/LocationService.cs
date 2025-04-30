using ASM.Shared.Models;
using ASM.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Services
{
    public class LocationService
    {
        private readonly LocationRepository _repo;

        public LocationService(LocationRepository repo)
        {
            _repo = repo;
        }

        public Task<Location> GetByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);  // Call the repository method
        }

        public Task<List<Location>> GetAllAsync() => _repo.GetAllAsync();

        public Task UpdateAsync(Location location)
        {
            return _repo.UpdateAsync(location);
        }

        public Task DeleteAsync(int id)
        {
            return _repo.DeleteAsync(id);
        }

        public Task<Location> CreateAsync(Location location)
        {
            return _repo.CreateAsync(location);
        }
    }

}
