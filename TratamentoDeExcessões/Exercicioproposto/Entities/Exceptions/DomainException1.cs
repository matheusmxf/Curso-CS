using System;

namespace Course.Entities.Exceptions1
{
    class DomainException1 : ApplicationException
    {
        public DomainException1(string message) : base(message)
        {
        }
    }
}