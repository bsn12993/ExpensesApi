using System;

namespace ExpensesApp.Core.Exceptions
{
    public class AmountIsRequiredException : Exception
    {
        public AmountIsRequiredException()
        {
        }

        public AmountIsRequiredException(string message)
            : base(message)
        {
        }

        public AmountIsRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
