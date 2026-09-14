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

namespace DesignPatterns;

/// <summary>
///     The classic interface for the Builder design pattern, which separates the construction of a complex
///     object from its representation so that the same construction process can produce different results.
/// </summary>
/// <typeparam name="TResult">The type of object this builder produces.</typeparam>
public interface IBuilder<out TResult>
{
    /// <summary>
    ///     Builds the object described by the current builder state.
    /// </summary>
    /// <returns>The constructed <typeparamref name="TResult" /> instance.</returns>
    TResult Build();
}

/// <summary>
///     A variation of the Builder design pattern that describes the object under construction as an ordered
///     invocation list of mutations applied to a <typeparamref name="TResult" /> instance when
///     <see cref="IBuilder{TResult}.Build" /> is called.
/// </summary>
/// <typeparam name="TResult">The type of object this builder produces.</typeparam>
/// <seealso cref="DesignPatterns.IBuilder{TResult}" />
public interface IDistributiveBuilder<out TResult> : IBuilder<TResult>
{
    /// <summary>
    ///     Appends a mutation to the invocation list. Exceptions thrown by the mutation propagate out of
    ///     <see cref="IBuilder{TResult}.Build" />; use <see cref="AddMutation(Action{TResult},bool)" /> to add
    ///     a mutation that may fail without aborting the build.
    /// </summary>
    /// <param name="mutation">The <see cref="Action{TResult}" /> to apply to the object under construction.</param>
    /// <returns>The current builder instance for fluent chaining.</returns>
    IDistributiveBuilder<TResult> AddMutation(Action<TResult> mutation);

    /// <summary>
    ///     Appends a mutation to the invocation list, optionally tolerating a mutation that throws.
    /// </summary>
    /// <param name="mutation">The <see cref="Action{TResult}" /> to apply to the object under construction.</param>
    /// <param name="safely">
    ///     When <c>true</c>, a mutation that throws is skipped entirely and the remaining mutations still run,
    ///     leaving the built object free of its partial side effects. When <c>false</c>, the exception propagates
    ///     out of <see cref="IBuilder{TResult}.Build" /> and the build is aborted.
    /// </param>
    /// <returns>The current builder instance for fluent chaining.</returns>
    IDistributiveBuilder<TResult> AddMutation(Action<TResult> mutation, bool safely);
}
