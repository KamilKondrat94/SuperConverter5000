using CurrencyConverters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Currencies
{
    public class Dollar : ICurrencyInfo
    {
        public string DecimalSeparator => ",";
        public string HundredsSeparator => " ";
        public string WholesName => "dollar";
        public string FractionalsName => "cent";
        public string Name => "The United States dollar";
    }
}
