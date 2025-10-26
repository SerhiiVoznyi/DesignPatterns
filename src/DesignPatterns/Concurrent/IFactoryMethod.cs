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
    /// Defines the asynchronous <b>Factory Method</b> — a creational design pattern
    /// that provides an interface for creating an object while allowing subclasses
    /// to alter the type of objects that will be created.
    /// </summary>
    /// <typeparam name="TResult">The type of the object to be created.</typeparam>
    public interface IFactoryMethod<TResult>
    {
        /// <summary>
        /// Asynchronously creates and returns a new instance of <typeparamref name="TResult"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous creation operation.
        /// The task result contains the created <typeparamref name="TResult"/> instance.
        /// </returns>
        Task<TResult> InstantiateAsync(CancellationToken cancellationToken = default);
    }
}