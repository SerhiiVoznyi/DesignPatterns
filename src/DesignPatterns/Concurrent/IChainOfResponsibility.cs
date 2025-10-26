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
using System.Threading;

namespace DesignPatterns.Concurrent
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Asynchronous <b>Chain of Responsibility</b>: passes a request along a chain of handlers.
    /// Each handler can either process the request or forward it to the next handler.
    /// </summary>
    /// <typeparam name="TResult">The result produced by a handler.</typeparam>
    /// <typeparam name="TOperation">The operation type handled by the chain.</typeparam>
    public interface IChainOfResponsibility<TResult, TOperation>
    {
        /// <summary>
        /// Registers the next.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="nextHandler">The next handler.</param>
        void RegisterNext<TImplementation>(TImplementation nextHandler)
            where TImplementation : IChainOfResponsibility<TResult, TOperation>;

        /// <summary>
        /// Handles the request asynchronously or forwards it to the next handler.
        /// </summary>
        /// <param name="operationData">The request to handle.</param>
        /// <param name="cancellationToken">A token to observe while waiting for completion.</param>
        /// <returns>
        /// A task that represents the asynchronous operation and yields the <typeparamref name="TResult"/>.
        /// </returns>
        Task<TResult> HandleAsync(TOperation operationData, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the chain links types from current point.
        /// </summary>
        /// <returns>IEnumerable collection of System.Types.</returns>
        IEnumerable<Type> GetChainLinksTypes();

        /// <summary>
        ///     Register next handler in the execution chain and returns itself.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="nextHandler">The next handler.</param>
        /// <returns>Just registered handler passed as input parameter to the method.</returns>
        TImplementation AddNextHandler<TImplementation>(TImplementation nextHandler)
            where TImplementation : IChainOfResponsibility<TResult, TOperation>;
    }
}
