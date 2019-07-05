using Common.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper.Exceptions.Business
{
    public abstract class BaseValidationException : Exception
    {
        public string UserMessage { get; private set; }
        //public BaseValidationException(ExceptionType type): base(type.ToString() + ">>>")
        //{
        //}

        public BaseValidationException(ExceptionType type, string message, string userMessage) : base(type.ToString() + ">>>" + message)
        {
            UserMessage = userMessage;
        }

        public BaseValidationException(ExceptionType type, string message, Exception inner, string userMessage) : base(type.ToString() + ">>>" + message, inner)
        {
            UserMessage = userMessage;
        }
    }
}
