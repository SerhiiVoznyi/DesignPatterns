namespace DesignPatterns
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Composite is a structural [Design Pattern] that allows composing objects into a tree-like structure
    /// and work with the it as if it was a singular object.
    /// </summary>
    public interface IComposite
    {
        /// <summary>
        /// Adds the specified component into internal composition tree.
        /// </summary>
        /// <param name="component">The component.</param>
        void Add(IComposite component);

        /// <summary>
        /// Removes the specified component from internal composition tree.
        /// </summary>
        /// <param name="component">The component.</param>
        void Remove(IComposite component);

        /// <summary>
        /// Clears this internal composition tree.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines whether this instance is composite.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has components in internal composition tree; otherwise, <c>false</c>.
        /// </returns>
        bool IsComposite();
    }

    /// <summary>
    /// The base implementation of the Composite [Design Pattern].
    /// </summary>
    /// <seealso cref="DesignPatterns.IComposite" />
    public abstract class CompositeBase : IComposite
    {
        protected readonly List<IComposite> CompositionTree;

        protected CompositeBase() => this.CompositionTree = new List<IComposite>();

        public virtual void Add(IComposite component)
        {
            this.CompositionTree.Add(component);
        }

        public virtual void Remove(IComposite component)
        {
            this.CompositionTree.Remove(component);
        }

        public virtual void Clear()
        {
            this.CompositionTree.Clear();
        }

        public virtual bool IsComposite() => this.CompositionTree.Any();
    }
}
