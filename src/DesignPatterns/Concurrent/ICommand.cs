// SPDX-License-Identifier: Apache-2.0
// Developed and Supported in 2020-2026 by Serhii Voznyi and open source community
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//     http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
namespace DesignPatterns.Concurrent
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the asynchronous <b>Command</b> — a behavioral design pattern
    /// that encapsulates a request as an object, allowing parameterization,
    /// queuing, and deferred or remote execution.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command asynchronously.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Defines the asynchronous <b>Command</b> that returns a result upon execution.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the command.</typeparam>
    public interface ICommand<TResult>
    {
        /// <summary>
        /// Executes the command asynchronously and returns the result.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation and yields the <typeparamref name="TResult"/>.
        /// </returns>
        Task<TResult> ExecuteAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Defines the asynchronous <b>Command</b> that depends on an external executor or context.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the command.</typeparam>
    /// <typeparam name="TExecutor">The type of the executor or context required to execute the command.</typeparam>
    public interface ICommand<TResult, in TExecutor>
    {
        /// <summary>
        /// Executes the command asynchronously using the specified executor or context.
        /// </summary>
        /// <param name="executor">The executor or context used to run the command.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation and yields the <typeparamref name="TResult"/>.
        /// </returns>
        Task<TResult> ExecuteAsync(TExecutor executor, CancellationToken cancellationToken = default);
    }
}
