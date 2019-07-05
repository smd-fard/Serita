using Common.Helper.Enums;
using System;

namespace Common.Helper.Exceptions.Business
{
    public class ValidationException_InvalidForeignKey : BaseValidationException
    {
        public ValidationException_InvalidForeignKey(string message, string userMessage) : base(ExceptionType.InvalidForeignReferenceKey, message, userMessage)
        {
        }

        public ValidationException_InvalidForeignKey(string message, Exception inner, string userMessage) : base(ExceptionType.InvalidForeignReferenceKey, message, inner, userMessage)
        {
        }
    }
}
