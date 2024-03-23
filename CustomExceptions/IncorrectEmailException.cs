using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Kharchenko.CustomExceptions
{
    class IncorrectEmailException : Exception
    {

        public IncorrectEmailException(string email, string message)
        {
            Email = email;
            Message = $"Incorrect email: {email}. {message}";
        }
        public string Email { get; }
        public override string Message { get; }
    }
}
