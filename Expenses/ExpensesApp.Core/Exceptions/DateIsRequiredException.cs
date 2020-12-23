using System;

namespace ExpensesApp.Core.Exceptions
{
    public class DateIsRequiredException : Exception
    {
        public DateIsRequiredException()
        {
        }

        public DateIsRequiredException(string message)
            : base(message)
        {
        }

        public DateIsRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
