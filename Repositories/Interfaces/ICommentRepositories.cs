using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICommentRepositories
    {
        Task AddComment(Comment cmnt);
        Task DeleteComment(Comment cmnt);
        Task<IEnumerable<Comment>> GetAllComments(bool v);
        Task<Comment> GetCommentById(int id, bool v);
        Task UpdateComment (Comment cmnt);
    }
}
