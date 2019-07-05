using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper.Validations
{
    public interface IValidationDictionary
    {
        void AddError(string key, string errorMessage);
        bool IsValid { get; }
        Dictionary<string, string> GetErrors { get; }
    }
}
