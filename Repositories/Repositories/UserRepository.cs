using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepositories
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddUser(User user)
        {
            await Add(user);
        }

        public async Task DeleteUser(User user)
        {
            await Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<User> GetUsers(int id, bool v)
        {
            return await GetById(b => b.UserID == id, v);
        }

        public async Task UpdateUser(User user)
        {
            await Update(user);
        }
    }
}
