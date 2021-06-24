using System;

namespace ATSChallenge.Domain.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public Guid? Id { get; private set; }

        public NotFoundException(string message, Guid? id = null) : base(message)
        {
            Id = id;
        }
    }
}
