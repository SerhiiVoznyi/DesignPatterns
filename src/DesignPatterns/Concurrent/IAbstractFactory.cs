//   Developed and Supported in 2025 by Serhii Voznyi and open source community
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
using System.Threading.Tasks;

namespace DesignPatterns.Concurrent;

/// <summary>
///     Asynchronous parameterized object creation. The name follows GoF <em>Abstract Factory</em> because creation
///     is abstracted behind a single entry point; see remarks for how this relates to classic <em>product families</em>.
/// </summary>
/// <remarks>
///     <para>
///         In the Gang of Four book, an <strong>Abstract Factory</strong> exposes several operations that each
///         create a different product from the same <em>family</em>. In C#, that is often modeled as one interface
///         with multiple methods (e.g. <c>CreateButtonAsync()</c>, <c>CreateScrollBarAsync()</c>), not only as
///         <c>CreateAsync&lt;TResult, TInput&gt;</c>.
///     </para>
///     <para>
///         <see cref="IAbstractFactory.CreateAsync{TResult,TInput}" /> is a <strong>type-parameterized async factory</strong>.
///         For textbook families of related objects, prefer explicit methods per product role or coordinated
///         <see cref="IAbstractFactory{TResult,TInput}" /> abstractions.
///     </para>
/// </remarks>
public interface IAbstractFactory
{
    /// <summary>
    ///     Asynchronously creates a <typeparamref name="TResult" /> using <paramref name="operationData" />.
    /// </summary>
    /// <typeparam name="TResult">The type of object to create.</typeparam>
    /// <typeparam name="TInput">The input type for the creation request.</typeparam>
    /// <param name="operationData">Data consumed by the factory implementation.</param>
    Task<TResult> CreateAsync<TResult, TInput>(TInput operationData);
}

/// <summary>
///     Asynchronously creates instances of <typeparamref name="TResult" /> with no input.
/// </summary>
/// <typeparam name="TResult">The type of the result.</typeparam>
public interface IAbstractFactory<TResult>
{
    /// <summary>
    ///     Creates an instance of <typeparamref name="TResult" /> asynchronously.
    /// </summary>
    Task<TResult> CreateAsync();
}

/// <summary>
///     Asynchronously creates instances of <typeparamref name="TResult" /> from <typeparamref name="TInput" />.
/// </summary>
/// <remarks>
///     One product role per interface; combine with other factory interfaces or multiple methods to model a full family.
/// </remarks>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <typeparam name="TInput">The type of the input.</typeparam>
public interface IAbstractFactory<TResult, in TInput>
{
    /// <summary>
    ///     Creates an instance of <typeparamref name="TResult" /> using <paramref name="operationData" />.
    /// </summary>
    /// <param name="operationData">The operation data.</param>
    Task<TResult> CreateAsync(TInput operationData);
}
