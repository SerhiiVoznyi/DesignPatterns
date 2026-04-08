namespace DesignPatterns.Tests.Examples;

/// <summary>
///     Implementor hierarchy: concrete rendering backends (Bridge "implementation" side).
/// </summary>
public interface IRenderEngine
{
    string RenderCircle(int radius);
}

public sealed class SvgRenderEngine : IRenderEngine
{
    public string RenderCircle(int radius) => $"<circle r=\"{radius}\" />";
}

public sealed class CanvasRenderEngine : IRenderEngine
{
    public string RenderCircle(int radius) => $"canvas.drawCircle(radius: {radius})";
}

/// <summary>
///     Abstraction: shape logic delegates drawing to <see cref="IBridge{TImplementation}.Implementer" />.
///     Refined abstractions can vary (e.g. different shapes) while <see cref="IRenderEngine" /> variants stay independent.
/// </summary>
public sealed class CircleBridge : IBridge<IRenderEngine>
{
    public CircleBridge(IRenderEngine implementer, int radius)
    {
        Implementer = implementer;
        Radius = radius;
    }

    public IRenderEngine Implementer { get; }

    public int Radius { get; }

    /// <summary>
    ///     Operation on the abstraction forwards to the implementor—two hierarchies evolve independently.
    /// </summary>
    public string Draw() => Implementer.RenderCircle(Radius);
}
