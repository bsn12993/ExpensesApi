using System;

namespace ExpensesApp.Core.Exceptions
{
    public class EmailRequiredException : Exception
    {
        public EmailRequiredException()
        {
        }

        public EmailRequiredException(string message)
            : base(message)
        {
        }

        public EmailRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
