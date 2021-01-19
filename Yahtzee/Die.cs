using System;

namespace Yahtzee
{
    public class Die
    {
        private readonly Random _random;

        public int Value { get; set; }

        public int MaxValue { get; private set; }

        public Die()
            : this(6)
        {
        }

        public Die(int maxValue)
        {
            MaxValue = maxValue;
            _random = new Random(DateTime.Now.Millisecond);

            Roll();
        }

        public int Roll()
        {
            Value = _random.Next(1, MaxValue + 1);
            return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}