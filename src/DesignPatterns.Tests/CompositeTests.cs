namespace DesignPatterns.Tests
{
    using DesignPatterns.Tests.Examples;
    using Shouldly;
    using Xunit;

    public class CompositeTests
    {
        [Fact]
        public void IsComposite_Should_ReturnFalse_WhenEmpty()
        {
            var leaf = new CompositeLeaf("Root");

            leaf.IsComposite().ShouldBeFalse();
        }

        [Fact]
        public void Add_Should_MakeComposite()
        {
            var root = new CompositeLeaf("Root");
            var child = new CompositeLeaf("Child");

            root.Add(child);

            root.IsComposite().ShouldBeTrue();
        }

        [Fact]
        public void Remove_Should_RemoveComponent()
        {
            var root = new CompositeLeaf("Root");
            var child = new CompositeLeaf("Child");

            root.Add(child);
            root.Remove(child);

            root.IsComposite().ShouldBeFalse();
        }

        [Fact]
        public void Clear_Should_RemoveAllComponents()
        {
            var root = new CompositeLeaf("Root");
            root.Add(new CompositeLeaf("Child1"));
            root.Add(new CompositeLeaf("Child2"));
            root.Add(new CompositeLeaf("Child3"));

            root.Clear();

            root.IsComposite().ShouldBeFalse();
        }

        [Fact]
        public void Add_Should_SupportNestedComposites()
        {
            var root = new CompositeLeaf("Root");
            var branch = new CompositeLeaf("Branch");
            var leaf = new CompositeLeaf("Leaf");

            branch.Add(leaf);
            root.Add(branch);

            root.IsComposite().ShouldBeTrue();
            branch.IsComposite().ShouldBeTrue();
            leaf.IsComposite().ShouldBeFalse();
        }
    }
}
