﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(User user);
        Task DeleteUser(int user);
        Task<IEnumerable<User>> GetAllUsers(bool v);
        Task<User> GetUserById(int id);
        Task UpdateUser(int id , User user);
    }
}
