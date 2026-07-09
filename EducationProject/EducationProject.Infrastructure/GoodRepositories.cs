using EducationProject.Core.Application.Absractions;
using EducationProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProject.Infrastructure
{
    public class GoodRepositories : IGoodRepositories
    {
        private readonly ApplicationContext _context;
        public GoodRepositories(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Good>> GetAllAsync()
        {
            return await _context.Goods.ToListAsync();
        }

        public async Task<Good?> GetByIdAsync(int id)
        {
            return await _context.Goods.FindAsync(id);
        }

        public async Task<Good> AddAsync(Good good)
        {
            await _context.Goods.AddAsync(good);
            await _context.SaveChangesAsync();
            return good;
        }

        public async Task<Good> UpdateAsync(Good good)
        {
            _context.Goods.Update(good);
            await _context.SaveChangesAsync();
            return good;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var good = await GetByIdAsync(id);
            if (good == null) return false;

            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Good>> SearchByNameAsync(string name)
        {
            return await _context.Goods
                .Where(g => g.Name.Contains(name))
                .ToListAsync();
        }
    }
}
