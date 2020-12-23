using System;

namespace ExpensesApp.Core.Exceptions
{
    public class DescriptionIsRequiredException : Exception
    {
        public DescriptionIsRequiredException()
        {
        }

        public DescriptionIsRequiredException(string message)
            : base(message)
        {
        }

        public DescriptionIsRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
