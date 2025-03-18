﻿using Entities.Exceptions;
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
    public class CommentService : ICommentService
    {
        private readonly IRepositoryManager _rp;

        public CommentService(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task AddCommentFromService(Comment comment)
        {
            await _rp.ICommentRepositories.AddComment(comment);
            _rp.Save();
        }

        public async Task DeleteCommentFromService(int comment)
        {
            var x = await _rp.ICommentRepositories.GetCommentById(comment,false);
            if (x == null) {
                throw new CommentNotFoundExceptions(comment);
            }
            await _rp.ICommentRepositories.DeleteComment(x);
            _rp.Save();

        }

        public async Task<IEnumerable<Comment>> GetAllComments(bool v)
        {
            return await _rp.ICommentRepositories.GetAllComments(v);
        }

        public async Task<Comment> GetCommentById(int id, bool v)
        {
            return await _rp.ICommentRepositories.GetCommentById(id,v);    
        }

        public async Task UpdateCommentFromService(Comment comment)
        {
            var x = await _rp.ICommentRepositories.GetCommentById(comment.Id, false);
            if (x == null) {
                throw new CommentNotFoundExceptions(comment.Id);
            }
            x.Text = comment.Text;
            x.Ratio = comment.Ratio;
            x.Date = comment.Date;
            await _rp.ICommentRepositories.UpdateComment(x);
            _rp.Save();
            
        }
    }
}
