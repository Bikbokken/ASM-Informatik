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

        public Task<List<Location>> GetAllAsync() => _repo.GetAllAsync();
    }

}
