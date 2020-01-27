using CurrencyConverters.Currencies;
using CurrencyConverters.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Converters
{
    public class DollarNumberToTextConverter : IConvertCurrencyRepresentation<Dollar>
    {
        private readonly IConvertNumberToCurrencyText ValueToTextConverter;

        public DollarNumberToTextConverter(IConvertNumberToCurrencyText converter)
        {
            ValueToTextConverter = converter;
        }

        public Dollar Currency => new Dollar();

        public string Convert(string numericRepresentation)
        {
            numericRepresentation = numericRepresentation.Replace(Currency.DecimalSeparator, ".").Replace(Currency.HundredsSeparator, "");
            var parsed = decimal.TryParse(numericRepresentation, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value);
            if (!parsed)
                throw new ArgumentException("Could not parse entered value");
            string textRepresentation = ValueToTextConverter.GetTextRepresentation(value, Currency);
            return textRepresentation;
        }
    }
}
