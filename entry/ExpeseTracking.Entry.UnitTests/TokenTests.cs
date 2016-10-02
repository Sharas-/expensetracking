using System;
using Xunit;
using ExpenseTracking.Entry.Domain;
    
namespace ExpeseTracking.Entry.UnitTests
{
    public class TokenTests
    {
        [Fact]
        public void token_cannot_be_emtpy()
        {
            Assert.Throws(typeof(ArgumentException), () => new Token(""));
        }

        [Fact]
        public void token_cannot_be_all_whitspace()
        {
            Assert.Throws(typeof(ArgumentException), () => new Token("    "));
        }

        [Fact]
        public void token_is_trimed_when_contains_whitespace_on_ends()
        {
            Assert.Equal("category name", new Token("    category name   "));
        }
    }
}
