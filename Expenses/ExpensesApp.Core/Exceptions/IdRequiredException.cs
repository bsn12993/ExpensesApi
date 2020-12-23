using System;

namespace ExpensesApp.Core.Exceptions
{
    public class IdRequiredException : Exception
    {
        public IdRequiredException()
        {
        }

        public IdRequiredException(string message)
            : base(message)
        {
        }

        public IdRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
