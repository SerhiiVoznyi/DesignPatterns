namespace DesignPatterns.Tests.Examples;

public class CompositeLeaf : CompositeBase
{
    public string Name { get; }

    public CompositeLeaf(string name)
    {
        Name = name;
    }
}
