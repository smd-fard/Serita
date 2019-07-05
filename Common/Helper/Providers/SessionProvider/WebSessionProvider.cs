using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Common.Helper.Providers.SessionProvider
{
    public class WebSessionProvider : ISessionProvider
    {
        private int _languageId = 1;
        public int LanguageId { get => _languageId; set => _languageId = value; }
    }
}
