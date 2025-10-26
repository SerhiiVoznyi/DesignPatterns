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
    /// Defines the asynchronous <b>Builder</b> — a creational design pattern
    /// that provides a step-by-step process to construct complex objects.
    /// </summary>
    /// <typeparam name="TResult">The type of object being built.</typeparam>
    public interface IBuilder<TResult>
    {
        /// <summary>
        /// Asynchronously builds and returns an instance of <typeparamref name="TResult"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token that can be used to cancel the build operation.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous build operation.
        /// The task result contains the constructed <typeparamref name="TResult"/> instance.
        /// </returns>
        Task<TResult> BuildAsync(CancellationToken cancellationToken = default);
    }
}
