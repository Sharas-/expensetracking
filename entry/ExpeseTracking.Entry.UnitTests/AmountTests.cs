using System;
using Xunit;
using ExpenseTracking.Entry.Domain;

namespace ExpeseTracking.Entry.UnitTests
{
    public class AmountTests
    {
        [Fact]
        public void amount_must_be_positive()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new SpentAmount(0));
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new SpentAmount(-11.01M));
        }
    }
}
