using Common.Helper.Enums;
using System;

namespace Common.Helper.Exceptions.Business
{
    public class ValidationException_DuplicateEntity : BaseValidationException
    {
        public ValidationException_DuplicateEntity(string message, string property, string userMessage) : base(ExceptionType.DuplicateEntity , message, userMessage)
        {
        }

        public ValidationException_DuplicateEntity(string message, Exception inner, string property, string userMessage) : base(ExceptionType.DuplicateEntity, message, inner, userMessage)
        {
        }
    }
}
