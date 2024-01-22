using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexPricing;

/*public interface ISpotRateService
{
    SpotRate GetSpotRate(CurrencyPair currencyPair);

    IEnumerable<(string, string)> SupportedCurrencyPairs { get; }
}
*/

public interface ISpotRateService
{
    SpotRate GetSpotRate(CurrencyPair currencyPair);

    IEnumerable<CurrencyPair> SupportedCurrencyPairs { get; }
}