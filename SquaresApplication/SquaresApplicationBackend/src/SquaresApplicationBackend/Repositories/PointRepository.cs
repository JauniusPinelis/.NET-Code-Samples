using Microsoft.EntityFrameworkCore;
using SquaresApplicationBackend.Api.Data;
using SquaresApplicationBackend.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresApplicationBackend.Api.Repositories
{
    public class PointRepository
    {
        private DataContext _context;

        public PointRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PointEntity> GetByIdAsync(int id)
        {
            return await _context.Points.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PointEntity>> GetAllAsync()
        {
            return await _context.Points.ToListAsync();
        }

        public async Task CreateAsync(PointEntity point)
        {
            _context.Add(point);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(PointEntity point)
        {
            _context.Remove(point);
            await _context.SaveChangesAsync();
        }
    }
}
