using CurrencyConverters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Services
{
    public class NumberToCurrencyTextService : IConvertNumberToCurrencyText
    {
        private readonly ISettingsForNumberToText Settings;

        public NumberToCurrencyTextService(ISettingsForNumberToText settings)
        {
            Settings = settings;
        }

        public string GetTextRepresentation(decimal number, ICurrencyInfo currencyInfo)
        {
            if (number > Settings.MAX_VALUE)
                throw new ArgumentException($"Number has to be lower than or equal to {Settings.MAX_VALUE}");
            if (number < Settings.MIN_VALUE)
                throw new ArgumentException($"Number has to be greater than or equal to {Settings.MIN_VALUE}");
            if ((int)number - number < -0.99M)
                throw new ArgumentException($"Number has to have at most {Settings.MAX_DECIMAL_PLACES} decimal places");

            StringBuilder sb = new StringBuilder();

            int integerPart = (int)number;
            int remainingIntegerPart = integerPart;
            int powerLevel = (int)Math.Floor(Math.Log10((double)Settings.MAX_VALUE) + 1) - 3;
            while (powerLevel > 0)
            {
                int currentPart = remainingIntegerPart / (int)Math.Pow(10, powerLevel);
                if(currentPart > 0)
                    sb.Append($"{ConvertPartLowerThanThousand(currentPart)} {Settings.POWERS_REPRESENTATIONS[powerLevel / 3]} ");
                remainingIntegerPart -= currentPart * (int)Math.Pow(10, powerLevel);
                powerLevel -= 3;
            }

            if (remainingIntegerPart > 1 || (remainingIntegerPart == 0 && number < 1))
                sb.Append($"{ConvertPartLowerThanThousand(remainingIntegerPart)} {currencyInfo.WholesName}{Settings.PLURAL_SUFFIX} ");
            else if (remainingIntegerPart == 1)
                sb.Append($"{ConvertPartLowerThanThousand(remainingIntegerPart)} {currencyInfo.WholesName} ");

            int decimalPartAsInt = (int)((number - integerPart) * 100);
            if (decimalPartAsInt > 1)
                sb.Append($"and {ConvertPartLowerThanThousand(decimalPartAsInt)} {currencyInfo.FractionalsName}{Settings.PLURAL_SUFFIX} ");
            else if (decimalPartAsInt == 1)
                sb.Append($"and {ConvertPartLowerThanThousand(decimalPartAsInt)} {currencyInfo.FractionalsName} ");

            return sb.ToString().Trim();
        }

        private string ConvertPartLowerThanThousand(int number)
        {
            if (number >= 1000)
                throw new ArgumentException("Converted part has to be lower than 1000");

            StringBuilder sb = new StringBuilder();
            int hundredsPart = number / 100;
            if(hundredsPart > 0)
                sb.Append($"{Settings.BASIC_REPRESENTATIONS[hundredsPart]} {Settings.HUNDRED_REPRESENTATION} ");

            int remainingPart = number % 100;
            if (remainingPart < 20)
            {
                sb.Append(Settings.BASIC_REPRESENTATIONS[remainingPart]);
                return sb.ToString();
            }
            sb.Append(Settings.TENS_REPRESENTATIONS[remainingPart / 10]);
            remainingPart %= 10;
            if (remainingPart > 0)
                sb.Append($"-{ Settings.BASIC_REPRESENTATIONS[remainingPart]}");
            return sb.ToString();

        }
    }
}
