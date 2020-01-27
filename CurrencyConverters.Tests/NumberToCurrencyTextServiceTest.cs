using System;
using System.Collections.Generic;
using CurrencyConverters.Currencies;
using CurrencyConverters.Interfaces;
using CurrencyConverters.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CurrencyConverters.Tests
{
    [TestClass]
    public class NumberToCurrencyTextServiceTest
    {
        [TestMethod]
        public void CanCreateObject()
        {
            var settingsMock = new Mock<ISettingsForNumberToText>();
            var obj = new NumberToCurrencyTextService(settingsMock.Object);

            Assert.IsNotNull(obj);
        }

        [DataTestMethod]
        [DataRow(0, "zero dollars")]
        [DataRow(999999999.99, "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents")]
        public void CanConvertEdgeCases(double value, string expectedResult)
        {
            decimal valueToConvert = (decimal)value; //workaround for MSTest DataRow not accepting decimals
            var settingsMock = new Mock<ISettingsForNumberToText>();
            settingsMock.SetupGet(x => x.BASIC_REPRESENTATIONS).Returns(new List<string> {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            }.AsReadOnly());
            settingsMock.SetupGet(x => x.TENS_REPRESENTATIONS).Returns(new List<string> { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" }.AsReadOnly());
            settingsMock.SetupGet(x => x.POWERS_REPRESENTATIONS).Returns(new List<string> { "", "thousand", "million" }.AsReadOnly());
            settingsMock.SetupGet(x => x.HUNDRED_REPRESENTATION).Returns("hundred");
            settingsMock.SetupGet(x => x.PLURAL_SUFFIX).Returns("s");
            settingsMock.SetupGet(x => x.MAX_VALUE).Returns(999999999.99M);
            settingsMock.SetupGet(x => x.MIN_VALUE).Returns(0);
            settingsMock.SetupGet(x => x.MAX_DECIMAL_PLACES).Returns(2);

            var currencyMock = new Mock<ICurrencyInfo>();
            currencyMock.SetupGet(x => x.WholesName).Returns("dollar");
            currencyMock.SetupGet(x => x.FractionalsName).Returns("cent");

            var obj = new NumberToCurrencyTextService(settingsMock.Object);
            var result = obj.GetTextRepresentation(valueToConvert, currencyMock.Object);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
