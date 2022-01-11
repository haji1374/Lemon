using System;

namespace Portal.Domain.Common
{
    public class Money
    {
        // public Money()
        // {

        // }

        public Money(int value)
        {
            if (value < 0)
            {
                throw new Exception("Value can not lower than 0");
            }
            Value = value;
        }

        public int Value { get; private set; }
    }
}