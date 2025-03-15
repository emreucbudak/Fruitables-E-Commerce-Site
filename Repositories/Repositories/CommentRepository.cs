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
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepositories
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddComment(Comment cmnt)
        {
            await Add(cmnt);

        }

        public async Task DeleteComment(Comment cmnt)
        {
            await Delete(cmnt);
        }

        public async Task<IEnumerable<Comment>> GetAllComments(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Comment> GetCommentById(int id, bool v)
        {
            return await GetById(b=>b.Id == id, v);
        }

        public async Task UpdateComment(Comment cmnt)
        {
            await Update(cmnt);
        }
    }
}
