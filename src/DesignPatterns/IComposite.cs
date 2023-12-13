//   Developed and Supported in 2024 by Serhii Voznyi and open source community
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

        protected CompositeBase()
        {
            CompositionTree = new List<IComposite>();
        }

        public virtual void Add(IComposite component)
        {
            CompositionTree.Add(component);
        }

        public virtual void Remove(IComposite component)
        {
            CompositionTree.Remove(component);
        }

        public virtual void Clear()
        {
            CompositionTree.Clear();
        }

        public virtual bool IsComposite()
        {
            return CompositionTree.Any();
        }
    }
}
