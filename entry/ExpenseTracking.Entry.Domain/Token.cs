using System;

namespace ExpenseTracking.Entry.Domain
{
    /// <summary>
    /// Represents non empty "sane" text value
    /// </summary>
    public class Token
    {
        private readonly string myName;

        public Token(string name)
        {
            string trimed = name.Trim();
            if (string.IsNullOrEmpty(trimed))
            {
                throw new ArgumentException("Value cannot be empty");
            }
            myName = trimed;
        }
        public override string ToString() => myName;

        public static implicit operator string(Token c) => c.myName;
        public static implicit operator Token(string s) => new Token(s);
    }
}