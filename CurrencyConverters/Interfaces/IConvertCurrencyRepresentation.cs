using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Interfaces
{
    public interface IConvertCurrencyRepresentation<T> where T : class
    {
        T Currency { get; }
        string Convert(string value);
    }
}
