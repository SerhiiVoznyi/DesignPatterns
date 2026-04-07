namespace DesignPatterns.Tests.Examples
{
    using DesignPatterns.Implementation;

    public class PositiveNumberHandler : ChainOfResponsibilityBase<string, int>
    {
        public override string Handle(int operationData)
        {
            if (operationData > 0)
                return "Positive";

            if (Next != null)
                return Next.Handle(operationData);

            return "Unknown";
        }
    }

    public class NegativeNumberHandler : ChainOfResponsibilityBase<string, int>
    {
        public override string Handle(int operationData)
        {
            if (operationData < 0)
                return "Negative";

            if (Next != null)
                return Next.Handle(operationData);

            return "Unknown";
        }
    }

    public class ZeroNumberHandler : ChainOfResponsibilityBase<string, int>
    {
        public override string Handle(int operationData)
        {
            if (operationData == 0)
                return "Zero";

            if (Next != null)
                return Next.Handle(operationData);

            return "Unknown";
        }
    }
}
