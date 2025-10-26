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
    /// Defines an asynchronous <b>Adapter</b> — a structural design pattern that allows
    /// incompatible interfaces to work together by converting one interface into another expected by the client.
    /// </summary>
    /// <typeparam name="TSource">The input (source) type to be adapted.</typeparam>
    /// <typeparam name="TResult">The target (adapted) type.</typeparam>
    public interface IAdapter<in TSource, TResult>
    {
        /// <summary>
        /// Adapts the specified source object to the target type asynchronously.
        /// </summary>
        /// <param name="source">The source object to adapt.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous adaptation operation.
        /// The task result contains the adapted <typeparamref name="TResult"/> instance.
        /// </returns>
        Task<TResult> AdaptAsync(TSource source, CancellationToken cancellationToken = default);
    }
}
