using System;

namespace ExpensesApp.Core.Exceptions
{
    public class ModelIsNullException : Exception
    {
        public ModelIsNullException()
        {
        }

        public ModelIsNullException(string message)
            : base(message)
        {
        }

        public ModelIsNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
