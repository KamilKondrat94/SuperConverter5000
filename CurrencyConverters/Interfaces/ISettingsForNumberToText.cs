using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Interfaces
{
    public interface ISettingsForNumberToText
    {
        decimal MAX_VALUE { get; }
        decimal MIN_VALUE { get; }
        int MAX_DECIMAL_PLACES { get; }
        string PLURAL_SUFFIX  { get; }
        string HUNDRED_REPRESENTATION  { get; }
        IReadOnlyList<string> BASIC_REPRESENTATIONS { get; }
        IReadOnlyList<string> TENS_REPRESENTATIONS  { get; }
        IReadOnlyList<string> POWERS_REPRESENTATIONS { get; }
    }
}
