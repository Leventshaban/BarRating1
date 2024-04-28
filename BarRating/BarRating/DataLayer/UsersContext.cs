using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UsersContext : IDb<User, int>
    {
        private SigmaBarRatingDbContext _dbContext;

        public UsersContext(SigmaBarRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User item)
        {
            try
            {
                _dbContext.Users.Add(item);
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
                _dbContext.Users.Remove(await ReadAsync(key));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = _dbContext.Users;

                if (useNavigationalProperties)
                {
                    query = query.Include(u => u.Reviews)
                            .ThenInclude(r => r.User)
                            .Include(u => u.Bars)
                            .ThenInclude(b => b.Users);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = _dbContext.Users;

                if (useNavigationalProperties)
                {
                    query = query.Include(u => u.Reviews)
                            .ThenInclude(r => r.User)
                            .Include(u => u.Bars)
                            .ThenInclude(b => b.Users);
                }

                return await query.FirstOrDefaultAsync(u => u.Id == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(User item)
        {
            try
            {
                _dbContext.Users.Update(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

