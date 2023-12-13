//   Developed and Supported in 2024 by Serhii Voznyi and open source community
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
namespace DesignPatterns
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Chain of Responsibility is a behavioral [Design Pattern] that lets you pass requests along a chain of handlers.
    ///     Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in
    ///     the chain.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TOperation">The type of the operation.</typeparam>
    public interface IChainOfResponsibility<TResult, TOperation>
    {
        /// <summary>
        ///     Gets the chain links types from current point.
        /// </summary>
        /// <returns>IEnumerable collection of System.Types.</returns>
        IEnumerable<Type> GetChainLinksTypes();

        /// <summary>
        ///     Method for handling the operation data.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        TResult Handle(TOperation operationData);

        /// <summary>
        ///     Registers the next.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="nextHandler">The next handler.</param>
        void RegisterNext<TImplementation>(TImplementation nextHandler)
            where TImplementation : IChainOfResponsibility<TResult, TOperation>;

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