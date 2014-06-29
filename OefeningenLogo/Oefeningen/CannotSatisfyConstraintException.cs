using System;

namespace OefeningenLogo.Oefeningen
{
    public class CannotSatisfyConstraintException : Exception
    {
        public CannotSatisfyConstraintException(string message)
            : base(message)
        {
        }
    }
}