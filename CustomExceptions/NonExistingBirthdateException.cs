using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Kharchenko.CustomExceptions
{
    class NonExistingBirthdateException : Exception
    {
        public NonExistingBirthdateException(DateTime date)
        {
            Date = date;
            Message = $"Picked date: {date} from the future.";
        }
        public DateTime Date { get; }
        public override string Message { get; }
    }
}
