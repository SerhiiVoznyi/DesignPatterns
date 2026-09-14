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

namespace DesignPatterns.Implementation;

/// <summary>
///     The base implementation of Chain Of Responsibility.
/// </summary>
/// <typeparam name="TResult">The type produced by handling an operation.</typeparam>
/// <typeparam name="TOperation">The type of request passed along the chain.</typeparam>
/// <seealso cref="DesignPatterns.IChainOfResponsibility{TResult, TOperation}" />
public abstract class ChainOfResponsibilityBase<TResult, TOperation>
    : IChainOfResponsibility<TResult, TOperation>
{
    /// <summary>
    ///     The next handler in the chain.
    /// </summary>
    protected IChainOfResponsibility<TResult, TOperation>? Next;

    /// <inheritdoc />
    public virtual IEnumerable<Type> GetChainLinksTypes()
    {
        List<Type> result = [GetType()];

        if (Next is not null) result.AddRange(Next.GetChainLinksTypes());

        return result;
    }

    /// <inheritdoc />
    public abstract TResult Handle(TOperation operationData);

    /// <inheritdoc />
    public virtual void RegisterNext<TImplementationType>(TImplementationType nextHandler)
        where TImplementationType : IChainOfResponsibility<TResult, TOperation>
    {
        Next = nextHandler;
    }

    /// <inheritdoc />
    public virtual TImplementation AddNextHandler<TImplementation>(TImplementation nextHandler)
        where TImplementation : IChainOfResponsibility<TResult, TOperation>
    {
        RegisterNext(nextHandler);
        return nextHandler;
    }
}
