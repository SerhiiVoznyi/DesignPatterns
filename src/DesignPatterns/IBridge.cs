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
    /// <summary>
    /// Bridge is a structural design pattern that divides business logic
    /// or huge class into separate class hierarchies that can be developed independently.
    /// </summary>
    public interface IBridge<out TImplementation>
    {
        /// <summary>
        /// Gets the implementation
        /// <see>
        ///     <cref>{TImplementation}</cref>
        /// </see>
        /// for abstraction
        /// <see>
        ///     <cref>{TAbstraction}</cref>
        /// </see>
        /// </summary>
        /// <value>
        /// The implementer.
        /// </value>
        TImplementation Implementer { get; }
    }
}
