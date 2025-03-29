using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(UserDtoForInsert user);
        Task DeleteUser(int user);
        Task<IEnumerable<UserDtoForList>> GetAllUsers(bool v);
        Task<UserDtoForList> GetUserById(int id);
        Task UpdateUser(int id , UserDtoForUpdate user);
        Task<User> CheckUserFromService(int id, bool v);
    }
}
