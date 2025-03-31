using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class UserValidationException : ValidationResultExceptions
    {
        public List<string> ErrorMessages { get; }

        public UserValidationException(List<string> errors)
            : base($"{string.Join("\r\n", errors)} \n hatalarından dolayı Kaydolma başarısız!")
        {
            ErrorMessages = errors;
        }
    }
}

