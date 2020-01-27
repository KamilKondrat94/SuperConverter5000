using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Interfaces
{
    public interface ICurrencyInfo
    {
        string Name { get; }
        string DecimalSeparator { get; }
        string HundredsSeparator { get; }
        string WholesName { get; }
        string FractionalsName { get; }
    }
}
