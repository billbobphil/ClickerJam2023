namespace Utilities
{
    public class StaticHelpers
    {
        public static string FormatMoney(ulong money)
        {
            return $"${money:n0}";
        }
    }
}