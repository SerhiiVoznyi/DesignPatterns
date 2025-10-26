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
    /// Defines the asynchronous <b>Strategy</b> — a behavioral design pattern
    /// that encapsulates algorithms within interchangeable strategy objects,
    /// allowing dynamic behavior changes at runtime.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// Executes the algorithm encapsulated in this strategy instance asynchronously.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>A task that represents the asynchronous execution.</returns>
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Defines the asynchronous <b>Strategy</b> that produces a result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the strategy.</typeparam>
    public interface IStrategy<TResult>
    {
        /// <summary>
        /// Executes the algorithm encapsulated in this strategy instance asynchronously and returns a result.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous execution and yields the <typeparamref name="TResult"/>.
        /// </returns>
        Task<TResult> ExecuteAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Defines the asynchronous <b>Strategy</b> that operates on input data and produces a result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the strategy.</typeparam>
    /// <typeparam name="TData">The type of the input data consumed by the strategy.</typeparam>
    public interface IStrategy<TResult, in TData>
    {
        /// <summary>
        /// Executes the algorithm encapsulated in this strategy instance asynchronously using the provided data.
        /// </summary>
        /// <param name="data">The input data for the strategy.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous execution and yields the <typeparamref name="TResult"/>.
        /// </returns>
        Task<TResult> ExecuteAsync(TData data, CancellationToken cancellationToken = default);
    }
}
