namespace Refactor.PaymentGate.Api.Abstractions;

public static class CoreUtilities
{
    private static readonly Random _random = new();

    public static string GenerateShortGuid()
    {
        return Shorter(Convert.ToBase64String(Guid.NewGuid().ToByteArray())).ToUpper();
        static string Shorter(string base64String)
        {
            base64String = base64String.Split('=')[0];
            base64String = base64String.Replace('+', Convert.ToChar(_random.Next(65, 91)));
            base64String = base64String.Replace('/', Convert.ToChar(_random.Next(65, 91)));
            return base64String;
        }
    }
}
