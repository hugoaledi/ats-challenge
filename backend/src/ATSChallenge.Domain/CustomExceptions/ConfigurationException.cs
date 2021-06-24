using System;

namespace ATSChallenge.Domain.CustomExceptions
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message) : base(message) { }
    }
}
