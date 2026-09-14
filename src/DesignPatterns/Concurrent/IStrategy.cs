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
///     Asynchronous counterpart of the Strategy behavioral design pattern, which turns a set of behaviors
///     into objects and makes them interchangeable inside the original context object.
/// </summary>
public interface IStrategy
{
    /// <summary>
    ///     Asynchronously executes the algorithm encapsulated in this strategy instance.
    /// </summary>
    /// <returns>A task that completes when the algorithm has finished.</returns>
    Task ExecuteAsync();
}

/// <summary>
///     Asynchronous counterpart of the Strategy behavioral design pattern, which turns a set of behaviors
///     into objects and makes them interchangeable inside the original context object.
/// </summary>
/// <typeparam name="TResult">The type produced by the algorithm.</typeparam>
public interface IStrategy<TResult>
{
    /// <summary>
    ///     Asynchronously executes the algorithm encapsulated in this strategy instance.
    /// </summary>
    /// <returns>A task that produces the result of the algorithm.</returns>
    Task<TResult> ExecuteAsync();
}

/// <summary>
///     Asynchronous counterpart of the Strategy behavioral design pattern, which turns a set of behaviors
///     into objects and makes them interchangeable inside the original context object.
/// </summary>
/// <typeparam name="TResult">The type produced by the algorithm.</typeparam>
/// <typeparam name="TData">The type of input the algorithm operates on.</typeparam>
public interface IStrategy<TResult, in TData>
{
    /// <summary>
    ///     Asynchronously executes the algorithm encapsulated in this strategy instance over the supplied input.
    /// </summary>
    /// <param name="data">The input the algorithm operates on.</param>
    /// <returns>A task that produces the result of the algorithm.</returns>
    Task<TResult> ExecuteAsync(TData data);
}
