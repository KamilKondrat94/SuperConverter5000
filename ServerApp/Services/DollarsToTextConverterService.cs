using CurrencyConverters.Converters;
using CurrencyConverters.Currencies;
using CurrencyConverters.Interfaces;
using CurrencyConverters.Services;
using ServerApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace ServerApp.Services
{
    public class DollarNumericToTextConverterService : IConvertDollarNumericToText
    {
        private readonly ISettingsForNumberToText ConversionSettings;
        private readonly IConvertNumberToCurrencyText ValueToTextConverter;
        private readonly IConvertCurrencyRepresentation<Dollar> CurrencyConverter;

        public DollarNumericToTextConverterService()
        {
            ConversionSettings = new DefaultNumberToTextSettings();
            ValueToTextConverter = new NumberToCurrencyTextService(ConversionSettings);
            CurrencyConverter = new DollarNumberToTextConverter(ValueToTextConverter);
        }
        public string Convert(string value)
        {
            try
            {
                return CurrencyConverter.Convert(value);
            }
            catch (ArgumentException e)
            {
                throw new FaultException(e.Message);
            }
        }
    }
}
