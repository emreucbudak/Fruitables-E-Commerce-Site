using AutoMapper;
using Entities.DTO;
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
        private readonly IMapper _mp;

        public UserManager(IRepositoryManager mng, IMapper map)
        {
            _mng = mng;
            _mp = map;
        }

        public async Task<User> CheckUserFromService(int id, bool v)
        {
            var x = await _mng.userRepositories.CheckUser(id,v);
            if ( x ==  null)
            {
                throw new UserNotFoundExceptions(id);
                
            }
            return x;
        }

        public async Task DeleteUser(int user)
        {
            var x = await CheckUserFromService(user,false);
            await _mng.userRepositories.DeleteUser(x);
            _mng.Save();

        }

        public async Task<IEnumerable<UserDtoForList>> GetAllUsers(bool v)
        {
            return await _mng.userRepositories.GetAllUsers(v);
        }

        public async Task<UserDtoForList> GetUserById(int id)
        {
            var x =  await _mng.userRepositories.GetUsers(id,false);
            if (x == null)
            {
                throw new UserNotFoundExceptions(id);
            }
            return x;
        }

        public async Task RegisterUser(UserDtoForInsert user)
        {
            var x = _mp.Map<User>(user);
            await _mng.userRepositories.AddUser(x);
            _mng.Save();
        }

        public async Task UpdateUser(int id ,UserDtoForUpdate user)
        {
            var x = await CheckUserFromService(id,false);
            x.Email = user.Email;
            x.Name = user.Name;
            x.Password = user.Password;
            x.ProfilePhoto = user.ProfilePhoto;
            await _mng.userRepositories.UpdateUser(x);
            _mng.Save();
        }
    }
}
