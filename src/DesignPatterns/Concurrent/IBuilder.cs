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
using System.Threading.Tasks;

namespace DesignPatterns.Concurrent;

/// <summary>
///     Asynchronous counterpart of the classic Builder design pattern, which separates the construction of a
///     complex object from its representation so that the same construction process can produce different results.
/// </summary>
/// <typeparam name="TResult">The type of object this builder produces.</typeparam>
public interface IBuilder<TResult>
{
    /// <summary>
    ///     Asynchronously builds the object described by the current builder state.
    /// </summary>
    /// <returns>A task that produces the constructed <typeparamref name="TResult" /> instance.</returns>
    Task<TResult> BuildAsync();
}
