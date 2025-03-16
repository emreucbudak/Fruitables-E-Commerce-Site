using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CommentNotFoundExceptions : NotFoundExceptions
    {
        public CommentNotFoundExceptions(int id) : base($"{id} ' e sahip Yorum bulunamadı!")
        {
        }
    }
}
