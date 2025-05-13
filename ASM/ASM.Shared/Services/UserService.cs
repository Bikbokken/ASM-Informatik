using ASM.Shared.Models;
using ASM.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.Shared.Services
{
    public class UserService
    {
        private readonly UserRepository _repo;

        public UserService(UserRepository repo)
        {
            _repo = repo;
        }

        public Task<List<User>> GetAllAsync() => _repo.GetAllAsync();

        public Task<User?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<User> CreateAsync(User user) => _repo.CreateAsync(user);

        public Task<bool> UpdateAsync(User user) => _repo.UpdateAsync(user);

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
