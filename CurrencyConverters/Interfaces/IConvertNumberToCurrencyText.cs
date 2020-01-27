using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Interfaces
{
    public interface IConvertNumberToCurrencyText
    {
        string GetTextRepresentation(decimal number, ICurrencyInfo currencyInfo);
    }
}
