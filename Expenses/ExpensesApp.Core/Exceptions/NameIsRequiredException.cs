using System;

namespace ExpensesApp.Core.Exceptions
{
    public class NameIsRequiredException : Exception
    {
        public NameIsRequiredException()
        {
        }

        public NameIsRequiredException(string message)
            : base(message)
        {
        }

        public NameIsRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
