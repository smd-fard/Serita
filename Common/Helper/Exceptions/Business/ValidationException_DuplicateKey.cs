using Common.Helper.Enums;
using System;

namespace Common.Helper.Exceptions.Business
{
    public class ValidationException_DuplicateKey : BaseValidationException
    {
        public ValidationException_DuplicateKey(string message, string userMessage) : base(ExceptionType.DuplicateKey, message, userMessage)
        {
        }

        public ValidationException_DuplicateKey(string message, Exception inner, string userMessage) : base(ExceptionType.DuplicateKey, message, inner, userMessage)
        {
        }
    }
}
