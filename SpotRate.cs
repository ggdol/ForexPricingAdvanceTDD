using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexPricing
{
    public class SpotRate
    {

        public Currency BaseCurrency { get; }
        public Currency QuoteCurrency { get; }
        public decimal Rate { get; }
        public DateTime DateTime { get; }
        public CurrencyPair CurrencyPair { get; }
        public DateTime Now { get; }

        public SpotRate(CurrencyPair currencyPair, DateTime dateTime, decimal rate)
        {
            CurrencyPair = currencyPair;
            Rate = rate;
            DateTime = dateTime;
        }

        public override string ToString()
        {
            return $"{DateTime:u} {CurrencyPair}: {Rate}";
            
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is SpotRate spotRate && this == spotRate;
        }

        public static bool operator==(SpotRate rate1, SpotRate rate2)
        {

            return rate1.CurrencyPair == rate2.CurrencyPair
            && rate1.Rate == rate2.Rate
            && rate1.DateTime == rate2.DateTime;
        }

        public static bool operator !=(SpotRate rate1, SpotRate rate2)
        {
            return !(rate1 == rate2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
