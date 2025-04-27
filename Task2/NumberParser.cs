using System;

namespace Task2
{
    public partial class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            long number = 0;
            var sign = 1;

            // Main checks
            if (stringValue == null) 
                throw new ArgumentNullException();

            stringValue = stringValue.Trim(); //Remove whitespaces
            if (stringValue.Length == 0) 
                throw new FormatException();

            // Conversion logic
            stringValue = CheckSign(stringValue, ref sign);
            long result = CustomConvert(stringValue, number) * sign;
            
            //Before returning, check if the result overflowed
            if (result > 2147483647 || result < -2147483648) throw new OverflowException();
            return (int)result;
        }
    }
}