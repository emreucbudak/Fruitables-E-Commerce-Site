using Entities.Exceptions;
using Entities.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _mng;

        public UserManager(IRepositoryManager mng)
        {
            _mng = mng;
        }

        public async Task DeleteUser(int user)
        {
            var x = await GetUserById(user);
            await _mng.userRepositories.DeleteUser(x);
            _mng.Save();

        }

        public async Task<IEnumerable<User>> GetAllUsers(bool v)
        {
            return await _mng.userRepositories.GetAllUsers(v);
        }

        public async Task<User> GetUserById(int id)
        {
            var x =  await _mng.userRepositories.GetUsers(id,false);
            if (x == null)
            {
                throw new UserNotFoundExceptions(id);
            }
            return x;
        }

        public async Task RegisterUser(User user)
        {
            await _mng.userRepositories.AddUser(user);
            _mng.Save();
        }

        public async Task UpdateUser(int id ,User user)
        {
            var x = await GetUserById(id);
            x.Email = user.Email;
            x.Name = user.Name;
            x.Password = user.Password;
            await _mng.userRepositories.UpdateUser(x);
            _mng.Save();
        }
    }
}
