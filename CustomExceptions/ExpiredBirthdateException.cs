using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Kharchenko.CustomExceptions
{
    class ExpiredBirthdateException : Exception
    {
        public ExpiredBirthdateException(DateTime date)
        {
            Date = date;
            Message = $"Picked date: {date} from the too far past.";
        }
        public DateTime Date { get; }
        public override string Message { get; }
    }
}
