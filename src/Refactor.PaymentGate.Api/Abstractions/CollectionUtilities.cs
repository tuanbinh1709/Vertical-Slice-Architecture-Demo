using System.Collections.ObjectModel;

namespace Refactor.PaymentGate.Api.Abstractions;

public static class CollectionUtilities
{
    public static IReadOnlyCollection<TValue> AsReadOnlyCollection<TValue>(params TValue[] items)
    {
        return new ReadOnlyCollection<TValue>(items);
    }
}
