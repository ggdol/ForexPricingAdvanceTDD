using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexPricing;

public struct Currency
{
    public string IsoCodeAlpha { get; }
    private Currency(string isoCodeAlpha)
    {
        IsoCodeAlpha = isoCodeAlpha;
    }

    public static Currency Create(string isoCodeAlpha)
    {

        return new Currency(isoCodeAlpha);

    }

    public override string ToString()
    {
        return IsoCodeAlpha;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is Currency currency && this == currency;
    }

    public static bool operator ==(Currency currency1, Currency currency2)
    {
        return currency1.IsoCodeAlpha == currency2.IsoCodeAlpha;
    }

    public static bool operator !=(Currency currency1, Currency currency2)
    {

        return !(currency1 == currency2);
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}
