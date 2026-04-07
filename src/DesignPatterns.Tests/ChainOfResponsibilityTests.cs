namespace DesignPatterns.Tests
{
    using DesignPatterns.Tests.Examples;
    using Shouldly;
    using System.Linq;
    using Xunit;

    public class ChainOfResponsibilityTests
    {
        [Fact]
        public void Handle_Should_ReturnCorrectResult_WhenFirstHandlerMatches()
        {
            var handler = new PositiveNumberHandler();

            var result = handler.Handle(5);

            result.ShouldBe("Positive");
        }

        [Fact]
        public void Handle_Should_DelegateToNextHandler()
        {
            var positiveHandler = new PositiveNumberHandler();
            positiveHandler.AddNextHandler(new NegativeNumberHandler());

            var result = positiveHandler.Handle(-3);

            result.ShouldBe("Negative");
        }

        [Fact]
        public void Handle_Should_TraverseFullChain()
        {
            var positiveHandler = new PositiveNumberHandler();
            var negativeHandler = positiveHandler.AddNextHandler(new NegativeNumberHandler());
            negativeHandler.AddNextHandler(new ZeroNumberHandler());

            positiveHandler.Handle(10).ShouldBe("Positive");
            positiveHandler.Handle(-1).ShouldBe("Negative");
            positiveHandler.Handle(0).ShouldBe("Zero");
        }

        [Fact]
        public void Handle_Should_ReturnDefault_WhenNoHandlerMatches()
        {
            var zeroHandler = new ZeroNumberHandler();

            var result = zeroHandler.Handle(5);

            result.ShouldBe("Unknown");
        }

        [Fact]
        public void GetChainLinksTypes_Should_ReturnAllHandlerTypes()
        {
            var positiveHandler = new PositiveNumberHandler();
            var negativeHandler = positiveHandler.AddNextHandler(new NegativeNumberHandler());
            negativeHandler.AddNextHandler(new ZeroNumberHandler());

            var types = positiveHandler.GetChainLinksTypes().ToList();

            types.Count.ShouldBe(3);
            types[0].ShouldBe(typeof(PositiveNumberHandler));
            types[1].ShouldBe(typeof(NegativeNumberHandler));
            types[2].ShouldBe(typeof(ZeroNumberHandler));
        }

        [Fact]
        public void GetChainLinksTypes_Should_ReturnSingleType_WhenNoNextHandler()
        {
            var handler = new PositiveNumberHandler();

            var types = handler.GetChainLinksTypes().ToList();

            types.Count.ShouldBe(1);
            types[0].ShouldBe(typeof(PositiveNumberHandler));
        }

        [Fact]
        public void RegisterNext_Should_ReplaceExistingNextHandler()
        {
            var handler = new PositiveNumberHandler();
            handler.RegisterNext(new NegativeNumberHandler());
            handler.RegisterNext(new ZeroNumberHandler());

            var types = handler.GetChainLinksTypes().ToList();

            types.Count.ShouldBe(2);
            types[1].ShouldBe(typeof(ZeroNumberHandler));
        }

        [Fact]
        public void AddNextHandler_Should_ReturnRegisteredHandler()
        {
            var handler = new PositiveNumberHandler();

            var next = handler.AddNextHandler(new NegativeNumberHandler());

            next.ShouldBeOfType<NegativeNumberHandler>();
        }
    }
}
