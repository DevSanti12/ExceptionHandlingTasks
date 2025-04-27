using System;

namespace Task2;

public partial class NumberParser
{
    private static long CustomConvert(string stringValue, long number)
    {
        foreach (var x in stringValue)
        {
            switch (x)
            {
                case '0':
                    number = (number * 10);
                    break;
                case '1':
                    number = (number * 10) + 1;
                    break;
                case '2':
                    number = (number * 10) + 2;
                    break;
                case '3':
                    number = (number * 10) + 3;
                    break;
                case '4':
                    number = (number * 10) + 4;
                    break;
                case '5':
                    number = (number * 10) + 5;
                    break;
                case '6':
                    number = (number * 10) + 6;
                    break;
                case '7':
                    number = (number * 10) + 7;
                    break;
                case '8':
                    number = (number * 10) + 8;
                    break;
                case '9':
                    number = (number * 10) + 9;
                    break;
                default:
                    throw new FormatException();
            }
        }
        return number;
    }
    private static string CheckSign(string stringValue, ref int sign)
    {
        if (stringValue[0] == '-')
        {
            sign = -1;
            stringValue = stringValue.Substring(1);
        }
        else if (stringValue[0] == '+')
        {
            stringValue = stringValue.Substring(1);
        }
        return stringValue;
    }
}




