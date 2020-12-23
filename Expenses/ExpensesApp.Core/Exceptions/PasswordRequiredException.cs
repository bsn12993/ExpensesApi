using System;

namespace ExpensesApp.Core.Exceptions
{
    public class PasswordRequiredException : Exception
    {
        public PasswordRequiredException()
        {
        }

        public PasswordRequiredException(string message)
            : base(message)
        {
        }

        public PasswordRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
