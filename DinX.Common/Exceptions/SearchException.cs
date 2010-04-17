using System;

namespace DinX.Common.Exceptions
{
    public class SearchException : Exception
    {
        public string ErrorMessage { get; private set; }

        public SearchException(string strMessage)
        {
            this.ErrorMessage = strMessage;
        }
    }
}
