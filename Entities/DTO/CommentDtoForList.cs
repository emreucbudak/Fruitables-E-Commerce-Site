using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public sealed record CommentDtoForList : CommentDtoForManipulation
    {
        public DateTime Date { get; init; }
        public string UserName { get; init; }
        public int ProductId { get; init; }
        public string ProductName { get; init; }
    }
}
