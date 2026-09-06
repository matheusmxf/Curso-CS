using System;

namespace Course.Entities
{
    class OutsurcedEmployee : Employee
    {
        public double AdditionalCharge { get; set; }

        public OutsurcedEmployee()
        {
        }

        public OutsurcedEmployee(string name, int hours, double valuePerHour, double additionalCharge) : base(name, hours, valuePerHour)         
        {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment()
        {
            return base.Payment() + 1.1 * AdditionalCharge;
        }
    }
}