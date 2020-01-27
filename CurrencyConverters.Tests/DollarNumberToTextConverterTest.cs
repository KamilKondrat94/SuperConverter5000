using CurrencyConverters.Converters;
using CurrencyConverters.Currencies;
using CurrencyConverters.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Tests
{
    [TestClass]
    public class DollarNumberToTextConverterTest
    {
        [TestMethod]
        public void CanCreateObject()
        {
            var converterService = new Mock<IConvertNumberToCurrencyText>();
            var obj = new DollarNumberToTextConverter(converterService.Object);

            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void CanConvertMinValue()
        {
            string expectedResult = "zero dollars";

            var converterServiceMock = new Mock<IConvertNumberToCurrencyText>();
            converterServiceMock.Setup(x => x.GetTextRepresentation(0, It.IsAny<ICurrencyInfo>())).Returns(expectedResult);

            var obj = new DollarNumberToTextConverter(converterServiceMock.Object);
            string result = obj.Convert("0");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CanConvertMaxValue()
        {
            string expectedResult = "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents";

            var converterServiceMock = new Mock<IConvertNumberToCurrencyText>();
            converterServiceMock.Setup(x => x.GetTextRepresentation(999999999.99M, It.IsAny<ICurrencyInfo>())).Returns(expectedResult);

            var obj = new DollarNumberToTextConverter(converterServiceMock.Object);
            string result = obj.Convert("999 999 999,99");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CanHandleInvalidValue()
        {
            var converterServiceMock = new Mock<IConvertNumberToCurrencyText>();

            var obj = new DollarNumberToTextConverter(converterServiceMock.Object);

            Assert.ThrowsException<ArgumentException>(() => obj.Convert("foo"));
        }
    }
}
