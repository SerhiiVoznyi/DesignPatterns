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
namespace DesignPatterns;

/// <summary>
///     Bridge is a structural design pattern that divides business logic
///     or a huge class into separate class hierarchies that can be developed independently.
///     This interface represents the abstraction side of the pattern, which delegates its work
///     to an implementor drawn from the second hierarchy.
/// </summary>
/// <typeparam name="TImplementation">The implementor type this abstraction delegates to.</typeparam>
public interface IBridge<out TImplementation>
{
    /// <summary>
    ///     Gets the <typeparamref name="TImplementation" /> implementor for this bridge abstraction.
    /// </summary>
    /// <value>
    ///     The implementor instance that carries out the operations of this abstraction.
    /// </value>
    TImplementation Implementer { get; }
}
