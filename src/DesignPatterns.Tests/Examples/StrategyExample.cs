namespace DesignPatterns.Tests.Examples
{
    public class UpperCaseStrategy : IStrategy<string, string>
    {
        public string Execute(string data)
        {
            return data.ToUpperInvariant();
        }
    }

    public class LowerCaseStrategy : IStrategy<string, string>
    {
        public string Execute(string data)
        {
            return data.ToLowerInvariant();
        }
    }
}
