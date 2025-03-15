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

        public async Task DeleteCommentFromService(Comment comment)
        {
            await _rp.ICommentRepositories.DeleteComment(comment);
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
            await _rp.ICommentRepositories.UpdateComment(comment);
            _rp.Save();
        }
    }
}
