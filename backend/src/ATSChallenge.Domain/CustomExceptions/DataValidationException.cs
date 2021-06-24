using System;

namespace ATSChallenge.Domain.CustomExceptions
{
    public class DataValidationException : Exception
    {
        public DataValidationException(string message) : base(message) { }
    }
}
