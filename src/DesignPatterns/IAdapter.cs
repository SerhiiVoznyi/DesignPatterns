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
namespace DesignPatterns;

/// <summary>
///     Adapter is a structural design pattern which allows incompatible objects to collaborate.
///     The adapter wraps one object and translates calls made against it into the format and interface
///     that the collaborating object understands.
/// </summary>
/// <remarks>
///     This shape is for adapters that are themselves the source: the implementing instance carries the data
///     and converts itself into <typeparamref name="TResult" />. When the source is a separate object handed
///     to the adapter, use <see cref="IAdapter{TSource,TResult}" /> instead.
/// </remarks>
/// <typeparam name="TResult">The type this adapter produces.</typeparam>
public interface IAdapter<out TResult>
{
    /// <summary>
    ///     Adapts this instance to <typeparamref name="TResult" />.
    /// </summary>
    /// <returns>The adapted representation of this instance.</returns>
    TResult Adapt();
}

/// <summary>
///     Adapter is a structural design pattern which allows incompatible objects to collaborate.
///     The adapter wraps one object and translates calls made against it into the format and interface
///     that the collaborating object understands.
/// </summary>
/// <remarks>
///     This shape converts a separate source object. When the adapter itself is the source, use
///     <see cref="IAdapter{TResult}" /> instead.
/// </remarks>
/// <typeparam name="TSource">The type this adapter converts from.</typeparam>
/// <typeparam name="TResult">The type this adapter produces.</typeparam>
public interface IAdapter<in TSource, out TResult>
{
    /// <summary>
    ///     Adapts <paramref name="source" /> to <typeparamref name="TResult" />.
    /// </summary>
    /// <param name="source">The object to adapt.</param>
    /// <returns>The adapted representation of <paramref name="source" />.</returns>
    TResult Adapt(TSource source);
}
