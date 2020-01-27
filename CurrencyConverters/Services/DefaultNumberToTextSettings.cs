using CurrencyConverters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverters.Services
{
    public class DefaultNumberToTextSettings : ISettingsForNumberToText
    {
        public decimal MAX_VALUE => 999999999.99M; // There's a contradiction between limit in task description and one of examples, so I changed it
        public decimal MIN_VALUE => 0; // I had to pick some lower limit, as it was not specified
        public int MAX_DECIMAL_PLACES => 2;

        public string PLURAL_SUFFIX => "s";
        public string HUNDRED_REPRESENTATION => "hundred";
        public IReadOnlyList<string> BASIC_REPRESENTATIONS => new List<string> {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        }.AsReadOnly();
        public IReadOnlyList<string> TENS_REPRESENTATIONS => new List<string> { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" }.AsReadOnly();
        public IReadOnlyList<string> POWERS_REPRESENTATIONS => new List<string> { "", "thousand", "million" }.AsReadOnly();
    }
}
