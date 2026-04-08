using DesignPatterns.Tests.Examples;
using Shouldly;
using Xunit;

namespace DesignPatterns.Tests;

public class BridgeTests
{
    [Fact]
    public void Draw_Should_DelegateToSvgImplementor()
    {
        var bridge = new CircleBridge(new SvgRenderEngine(), radius: 5);

        var output = bridge.Draw();

        output.ShouldBe("<circle r=\"5\" />");
    }

    [Fact]
    public void Draw_Should_UseDifferentImplementor_WhenEngineChanges()
    {
        var svg = new CircleBridge(new SvgRenderEngine(), 2);
        var canvas = new CircleBridge(new CanvasRenderEngine(), 2);

        svg.Draw().ShouldContain("<circle");
        canvas.Draw().ShouldContain("canvas.drawCircle");
    }
}
