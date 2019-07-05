using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper.Exceptions.Data
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
        }

        public DatabaseException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
