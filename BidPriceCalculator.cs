using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexPricing;

public class BidPriceCalculator
{
    public ISpotRateService SpotRateService { get; }
    public decimal MarginPercentage { get; }
    public decimal FixedFee { get; }

    public BidPriceCalculator(ISpotRateService spotRateService, decimal marginPercentage, decimal fixedFee = 0M)
    {
        SpotRateService = spotRateService;
        MarginPercentage = marginPercentage;
        FixedFee = fixedFee;    

    }
    public decimal CalculateBidPrice(string baseCurrency, string quoteCurrency, decimal amount)
    {
        var rate = SpotRateService.GetSpotRate(CurrencyPair.Creat(baseCurrency, quoteCurrency)).Rate;
        if (rate == 0M){
            var listOfSupportedCurrencyPairs = string.Join(", ", 
                SpotRateService.SupportedCurrencyPairs.Select(pair => pair.BasCurrency + "/" + pair.QuotCurrency));
            
            throw new Exception(
                $"Unsupported currency pair: {baseCurrency}/{quoteCurrency}."
                +"Supported currency pairs: "+listOfSupportedCurrencyPairs);
        }
        return rate * (1 + MarginPercentage) * amount+FixedFee;
    }
}
