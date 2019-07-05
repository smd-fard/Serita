using Common.Helper.Enums;
using System;

namespace Common.Helper.Exceptions.Business
{
    public class ValidationException_EntityNotFound : BaseValidationException
    {
        public ValidationException_EntityNotFound(string message, string userMessage) : base(ExceptionType.EntityNotFound, message, userMessage)
        {
        }

        public ValidationException_EntityNotFound(string message, Exception inner, string userMessage) : base(ExceptionType.EntityNotFound, message, inner, userMessage)
        {
        }
    }
}
