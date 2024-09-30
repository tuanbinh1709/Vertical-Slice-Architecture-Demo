namespace Refactor.PaymentGate.Api.Abstractions.Constants;

public static partial class Constants
{
    internal static class ColumnType
    {
        internal const string _uniqueIdentifier = nameof(_uniqueIdentifier);
        internal const string _tinyInt = nameof(_tinyInt);
        internal const string _bit = nameof(_bit);
        internal static string DateTime2(int lenght) => $"{nameof(DateTime2)}({lenght})";
        internal static string NChar(int lenght) => $"{nameof(NChar)}({lenght})";
        internal static string VarChar(int lenght) => $"{nameof(VarChar)}({lenght})";
        internal static string Char(int lenght) => $"{nameof(Char)}({lenght})";
        internal static string Binary(int lenght) => $"{nameof(Binary)}({lenght})";
    }
}
