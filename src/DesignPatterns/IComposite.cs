//   Developed and Supported in 2026 by Serhii Voznyi and open source community
//
//     https://www.linkedin.com/in/serhii-voznyi/
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns;

/// <summary>
///     Composite is a structural design pattern that allows composing objects into a tree-like structure
///     and treating the whole tree as if it were a single object.
/// </summary>
public interface IComposite
{
    /// <summary>
    ///     Adds the specified component to the internal composition tree.
    /// </summary>
    /// <param name="component">The child component to attach to this node.</param>
    void Add(IComposite component);

    /// <summary>
    ///     Removes the specified component from the internal composition tree.
    /// </summary>
    /// <param name="component">The child component to detach from this node.</param>
    void Remove(IComposite component);

    /// <summary>
    ///     Removes every component from the internal composition tree of this node.
    /// </summary>
    void Clear();

    /// <summary>
    ///     Determines whether this instance acts as a composite node rather than a leaf.
    /// </summary>
    /// <returns>
    ///     <c>true</c> if this instance has components in its internal composition tree; otherwise, <c>false</c>.
    /// </returns>
    bool IsComposite();
}

/// <summary>
///     The base implementation of the Composite design pattern, backed by an in-memory list of children.
/// </summary>
/// <seealso cref="DesignPatterns.IComposite" />
public abstract class CompositeBase : IComposite
{
    /// <summary>
    ///     The child components attached to this node.
    /// </summary>
    protected readonly List<IComposite> CompositionTree;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CompositeBase" /> class with an empty composition tree.
    /// </summary>
    protected CompositeBase()
    {
        CompositionTree = [];
    }

    /// <inheritdoc />
    public virtual void Add(IComposite component)
    {
        CompositionTree.Add(component);
    }

    /// <inheritdoc />
    public virtual void Remove(IComposite component)
    {
        CompositionTree.Remove(component);
    }

    /// <inheritdoc />
    public virtual void Clear()
    {
        CompositionTree.Clear();
    }

    /// <inheritdoc />
    public virtual bool IsComposite()
    {
        return CompositionTree.Any();
    }
}
