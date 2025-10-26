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
    /// Defines the asynchronous <b>Prototype</b> — a creational design pattern that
    /// creates new objects by copying an existing instance, avoiding direct use of the <c>new</c> operator.
    /// </summary>
    /// <typeparam name="TThis">The type of the object implementing this interface.</typeparam>
    public interface IPrototype<TThis>
    {
        /// <summary>
        /// Creates and returns a copy of the current instance asynchronously.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous cloning operation.
        /// The task result contains the cloned <typeparamref name="TThis"/> instance.
        /// </returns>
        Task<TThis> CloneAsync(CancellationToken cancellationToken = default);
    }
}
