using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BarsContext : IDb<Bar, int>
    {
        private SigmaBarRatingDbContext _dbContext;

        public BarsContext(SigmaBarRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Bar item)
        {
            try
            {
                _dbContext.Bars.Add(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int key)
        {
            try
            {
                _dbContext.Bars.Remove(await ReadAsync(key));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Bar>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Bar> query = _dbContext.Bars;

                if (useNavigationalProperties)
                {
                    query = query.Include(b => b.Reviews)
                            .ThenInclude(r => r.Bar)
                            .Include(b => b.Users)
                            .ThenInclude(u => u.Bars);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Bar> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Bar> query = _dbContext.Bars;

                if (useNavigationalProperties)
                {
                    query = query.Include(b => b.Reviews)
                             .ThenInclude(r => r.Bar)
                             .Include(b => b.Users)
                             .ThenInclude(u => u.Bars);
                }

                return await query.FirstOrDefaultAsync(u => u.Id == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Bar item)
        {
            try
            {
                _dbContext.Bars.Update(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
