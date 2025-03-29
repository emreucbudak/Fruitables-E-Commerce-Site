using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepositories
    {
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<IEnumerable<UserDtoForList>> GetAllUsers(bool v);
        Task<UserDtoForList> GetUsers(int id , bool v);
        Task<User> CheckUser(int id, bool v);
    }
}
