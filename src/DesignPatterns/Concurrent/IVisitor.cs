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
    /// Defines the asynchronous <b>Acceptor</b> interface,
    /// representing the element that accepts a visitor in the <b>Visitor</b> design pattern.
    /// </summary>
    public interface IAcceptor
    {
        /// <summary>
        /// Accepts the specified visitor asynchronously.
        /// </summary>
        /// <param name="visitor">The visitor to accept.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>A task representing the asynchronous accept operation.</returns>
        Task AcceptAsync(IVisitor visitor, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Defines the asynchronous <b>Acceptor</b> interface that returns a result
    /// when visited by a <b>Visitor</b>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the visitor.</typeparam>
    public interface IAcceptor<TResult>
    {
        /// <summary>
        /// Accepts the specified visitor asynchronously and returns a result.
        /// </summary>
        /// <param name="visitor">The visitor to accept.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous accept operation
        /// that yields a <typeparamref name="TResult"/>.
        /// </returns>
        Task<TResult> AcceptAsync(IVisitor<TResult> visitor, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Defines the asynchronous <b>Visitor</b> interface,
    /// representing an operation to be performed on elements of an object structure.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// Visits the specified acceptor asynchronously.
        /// </summary>
        /// <param name="acceptor">The acceptor to visit.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>A task representing the asynchronous visit operation.</returns>
        Task VisitAsync(IAcceptor acceptor, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Defines the asynchronous <b>Visitor</b> interface
    /// that performs an operation and returns a result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the visitor.</typeparam>
    public interface IVisitor<TResult>
    {
        /// <summary>
        /// Visits the specified acceptor asynchronously and returns a result.
        /// </summary>
        /// <param name="acceptor">The acceptor to visit.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous visit operation
        /// that yields a <typeparamref name="TResult"/>.
        /// </returns>
        Task<TResult> VisitAsync(IAcceptor<TResult> acceptor, CancellationToken cancellationToken = default);
    }
}
