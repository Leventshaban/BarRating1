using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReviewsContext : IDb<Review, int>
    {
        private SigmaBarRatingDbContext _dbContext;

        public ReviewsContext(SigmaBarRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Review item)
        {
            try
            {
                _dbContext.Reviews.Add(item);
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
                _dbContext.Reviews.Remove(await ReadAsync(key));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Review>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Review> query = _dbContext.Reviews;

                if (useNavigationalProperties)
                {
                    query = query.Include(r => r.User)
                            .ThenInclude(u => u.Reviews)
                            .Include(r => r.Bar)
                            .ThenInclude(b => b.Reviews);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Review> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Review> query = _dbContext.Reviews;

                if (useNavigationalProperties)
                {
                    query = query.Include(r => r.User)
                            .ThenInclude(u => u.Reviews)
                            .Include(r => r.Bar)
                            .ThenInclude(b => b.Reviews);
                }

                return await query.FirstOrDefaultAsync(u => u.Id == key);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task UpdateAsync(Review item)
        {
            try
            {
                _dbContext.Reviews.Update(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
