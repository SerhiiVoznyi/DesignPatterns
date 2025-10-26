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
    /// Abstract Factory (asynchronous): defines an interface for creating
    /// families of related objects without specifying their concrete types.
    /// </summary>
    public interface IAbstractFactory
    {
        /// <summary>
        /// Creates an instance of a related object (or family of objects) asynchronously.
        /// </summary>
        /// <typeparam name="TResult">The type produced by the factory.</typeparam>
        /// <typeparam name="TInput">The input type used to drive creation.</typeparam>
        /// <param name="input">Input data used by the factory.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A task that completes with the created <typeparamref name="TResult"/>.</returns>
        Task<TResult> CreateAsync<TResult, TInput>(
            TInput input,
            CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Abstract Factory (asynchronous) for producing a single result type without input.
    /// </summary>
    /// <typeparam name="TResult">The type produced by the factory.</typeparam>
    public interface IAbstractFactory<TResult>
    {
        /// <summary>
        /// Creates an instance asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A task that completes with the created <typeparamref name="TResult"/>.</returns>
        Task<TResult> CreateAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Abstract Factory (asynchronous) for producing a result from an input.
    /// </summary>
    /// <typeparam name="TResult">The type produced by the factory.</typeparam>
    /// <typeparam name="TInput">The input type used to drive creation.</typeparam>
    public interface IAbstractFactory<TResult, in TInput>
    {
        /// <summary>
        /// Creates an instance asynchronously using the provided input.
        /// </summary>
        /// <param name="input">Input data used by the factory.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A task that completes with the created <typeparamref name="TResult"/>.</returns>
        Task<TResult> CreateAsync(TInput input, CancellationToken cancellationToken = default);
    }
}