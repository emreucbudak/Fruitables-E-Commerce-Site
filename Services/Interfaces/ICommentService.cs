﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICommentService
    {
        Task AddCommentFromService(Comment comment);
        Task DeleteCommentFromService(int comment);
        Task<IEnumerable<Comment>> GetAllComments(bool v);
        Task UpdateCommentFromService(int id , Comment comment);
        Task<Comment> GetCommentById(int id,bool v);
    }
}
