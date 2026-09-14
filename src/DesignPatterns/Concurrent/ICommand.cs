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
///     Asynchronous counterpart of the Command behavioral design pattern, which converts requests
///     or simple operations into objects, so that they can be parameterized, queued or logged.
/// </summary>
public interface ICommand
{
    /// <summary>
    ///     Asynchronously executes the request encapsulated by this command.
    /// </summary>
    /// <returns>A task that completes when the execution has finished.</returns>
    Task ExecuteAsync();
}

/// <summary>
///     Asynchronous counterpart of the Command behavioral design pattern, which converts requests
///     or simple operations into objects, so that they can be parameterized, queued or logged.
/// </summary>
/// <typeparam name="TResult">The type produced by executing this command.</typeparam>
public interface ICommand<TResult>
{
    /// <summary>
    ///     Asynchronously executes the request encapsulated by this command.
    /// </summary>
    /// <returns>A task that produces the result of the execution.</returns>
    Task<TResult> ExecuteAsync();
}

/// <summary>
///     Asynchronous counterpart of the Command behavioral design pattern, which converts requests
///     or simple operations into objects, so that they can be parameterized, queued or logged.
/// </summary>
/// <typeparam name="TResult">The type produced by executing this command.</typeparam>
/// <typeparam name="TExecutor">The type of the receiver the command acts upon.</typeparam>
public interface ICommand<TResult, in TExecutor>
{
    /// <summary>
    ///     Asynchronously executes the request encapsulated by this command against the supplied executor.
    /// </summary>
    /// <param name="executor">The receiver this command depends on to carry out the request.</param>
    /// <returns>A task that produces the result of the execution.</returns>
    Task<TResult> ExecuteAsync(TExecutor executor);
}
