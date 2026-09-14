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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatterns.Concurrent;

/// <summary>
///     Asynchronous counterpart of the Chain of Responsibility behavioral design pattern, which lets you pass
///     requests along a chain of handlers. Upon receiving a request, each handler decides either to process the
///     request or to pass it to the next handler in the chain.
/// </summary>
/// <typeparam name="TResult">The type produced by handling an operation.</typeparam>
/// <typeparam name="TOperation">The type of request passed along the chain.</typeparam>
public interface IChainOfResponsibility<TResult, TOperation>
{
    /// <summary>
    ///     Replaces the current successor in the chain (each handler has at most one next link).
    ///     To extend the chain, register the next handler on the handler instance returned by <see cref="AddNextHandler{TImplementation}" />.
    /// </summary>
    /// <typeparam name="TImplementation">The concrete handler type being registered.</typeparam>
    /// <param name="nextHandler">The handler that becomes the successor of this one.</param>
    void RegisterNext<TImplementation>(TImplementation nextHandler)
        where TImplementation : IChainOfResponsibility<TResult, TOperation>;

    /// <summary>
    ///     Asynchronously handles the operation, or delegates it to the successor when this handler is not
    ///     responsible for it.
    /// </summary>
    /// <param name="operationData">The request to process.</param>
    /// <returns>A task that produces the result of the handler that processed the request.</returns>
    Task<TResult> HandleAsync(TOperation operationData);

    /// <summary>
    ///     Gets the types of the handlers that form the chain, starting at this handler.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}" /> of the <see cref="Type" /> of each link from this handler onwards.</returns>
    IEnumerable<Type> GetChainLinksTypes();

    /// <summary>
    ///     Registers the next handler in the execution chain and returns it, so that further links can be
    ///     appended from the new tail.
    /// </summary>
    /// <typeparam name="TImplementation">The concrete handler type being registered.</typeparam>
    /// <param name="nextHandler">The handler that becomes the successor of this one.</param>
    /// <returns>The just registered handler passed as input parameter to the method.</returns>
    TImplementation AddNextHandler<TImplementation>(TImplementation nextHandler)
        where TImplementation : IChainOfResponsibility<TResult, TOperation>;
}
