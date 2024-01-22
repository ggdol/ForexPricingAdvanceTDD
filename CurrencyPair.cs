using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexPricing;

public struct CurrencyPair
{
    public Currency BasCurrency { get; }
    public Currency QuotCurrency { get; }

    private CurrencyPair(Currency basCurrency, Currency quotCurrency)
    {
        BasCurrency = basCurrency;
        QuotCurrency = quotCurrency;
    }

    public static CurrencyPair Creat(string basCurrency, string quotCurrency)
    {
        return new CurrencyPair(
            Currency.Create(basCurrency), Currency.Create(quotCurrency));
    }

    public override string ToString()
    {
        return $"{BasCurrency}/{QuotCurrency}";

    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is CurrencyPair currencyPair && this == currencyPair;
    }

    public static bool operator ==(CurrencyPair pair1, CurrencyPair pair2)
    {
        return pair1.BasCurrency == pair2.BasCurrency &&
               pair1.QuotCurrency == pair2.QuotCurrency;
    }


    public static bool operator !=(CurrencyPair currency1, CurrencyPair currency2)
    {

        return !(currency1 == currency2);
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }


}

