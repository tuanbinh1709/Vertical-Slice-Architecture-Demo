namespace Refactor.PaymentGate.Api.Abstractions;

public static class EnumUtilities
{
    public static IEnumerable<string> GetEnumNames<TEnum>()
        where TEnum : Enum
    {
        return Enum.GetNames(typeof(TEnum));
    }

    public static IEnumerable<string> GetEnumNames<TType>(this TType type)
        where TType : Enum
    {
        return Enum.GetNames(type.GetType());
    }

    public static HashSet<string> GetNamesOf<TType>()
        where TType : Enum
    {
        return [.. Enum.GetNames(typeof(TType))];
    }

    public static int LongestOf<TType>()
        where TType : Enum
    {
        return Enum.GetNames(typeof(TType)).Max(x => x.Length);
    }
}
