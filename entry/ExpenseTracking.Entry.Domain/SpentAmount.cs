using System;

namespace ExpenseTracking.Entry.Domain
{
    /// <summary>
    /// Represents spent amount of money
    /// </summary>
    public class SpentAmount
    {
        private decimal myAmount;

        public SpentAmount(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be more than zero");
            }
            myAmount = value;
        }

        public static implicit operator decimal(SpentAmount a) => a.myAmount;
        public static implicit operator SpentAmount(decimal d) => new SpentAmount(d);
    }
}