using System;

namespace AsposeExample
{
    public class CustomException : Exception
    {
        private Exception customInnerException;

        public CustomException(Exception customInnerException)
        {
            this.customInnerException = customInnerException;
        }
    }
}
