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
namespace DesignPatterns;

/// <summary>
///     Parameterized object creation. The name follows GoF <em>Abstract Factory</em> because the interface
///     abstracts creation behind a single entry point; the generic shape also supports classic
///     <em>families</em> when your implementation returns related products consistently.
/// </summary>
/// <remarks>
///     <para>
///         In the Gang of Four book, an <strong>Abstract Factory</strong> exposes <em>several</em> factory methods,
///         each creating a different kind of product from the <em>same family</em> (e.g. <c>CreateButton()</c>,
///         <c>CreateScrollBar()</c> for a given UI theme). That model is expressed in C# most clearly as an interface
///         with multiple operations, one per product role—not only as a single generic <c>Create&lt;TResult, TInput&gt;</c>.
///     </para>
///     <para>
///         The non-generic <see cref="IAbstractFactory.Create{TResult,TInput}" /> method is a
///         <strong>type-parameterized factory</strong>: the caller chooses <c>TResult</c> and supplies <c>TInput</c>.
///         Use it when you want one abstraction for creation with flexible type parameters. When you need the
///         textbook “family of related objects,” prefer an interface with explicit members per product type (or
///         <see cref="IAbstractFactory{TResult,TInput}" /> for one product role at a time) so related creations stay
///         obvious at compile time.
///     </para>
/// </remarks>
public interface IAbstractFactory
{
    /// <summary>
    ///     Creates a <typeparamref name="TResult" /> instance using <paramref name="operationData" />.
    /// </summary>
    /// <typeparam name="TResult">The type of object to create.</typeparam>
    /// <typeparam name="TInput">The input type for the creation request.</typeparam>
    /// <param name="operationData">Data consumed by the factory implementation.</param>
    TResult Create<TResult, TInput>(TInput operationData);
}

/// <summary>
///     Creates instances of <typeparamref name="TResult" /> with no input (see also <see cref="IAbstractFactory{TResult,TInput}" />).
/// </summary>
/// <remarks>
///     For a full GoF-style <em>family</em>, define a dedicated interface with one method per product role
///     so consumers see all related creations together.
/// </remarks>
/// <typeparam name="TResult">The type of the result.</typeparam>
public interface IAbstractFactory<out TResult>
{
    /// <summary>
    ///     Creates an instance of <typeparamref name="TResult" />.
    /// </summary>
    TResult Create();
}

/// <summary>
///     Creates instances of <typeparamref name="TResult" /> from <typeparamref name="TInput" />.
/// </summary>
/// <remarks>
///     This shape models one product role per factory abstraction; combine multiple such interfaces—or one interface
///     with several methods—to express a coordinated family of related objects.
/// </remarks>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <typeparam name="TInput">The type of the input.</typeparam>
public interface IAbstractFactory<out TResult, in TInput>
{
    /// <summary>
    ///     Creates an instance of <typeparamref name="TResult" /> using <paramref name="operationData" />.
    /// </summary>
    /// <param name="operationData">The operation data.</param>
    TResult Create(TInput operationData);
}
