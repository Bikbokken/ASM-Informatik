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
    public class LocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Location>> GetAllAsync()
        {
            return _context.Locations
                .OrderBy(l => l.Name)
                .ToListAsync();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            return await _context.Locations
                .FirstOrDefaultAsync(l => l.Id == id);  // Fetch the location by Id
        }


        public async Task<Location> CreateAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;  // Return the created entity (including its generated Id)
        }


        public async Task UpdateAsync(Location location)
        {
            var existing = await _context.Locations.FindAsync(location.Id);
            if (existing != null)
            {
                existing.Name = location.Name;
                existing.Address = location.Address;
                // Add other property updates as needed

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }

}
