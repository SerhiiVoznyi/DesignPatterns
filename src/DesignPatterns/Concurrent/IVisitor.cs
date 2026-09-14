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
using System.Threading.Tasks;

namespace DesignPatterns.Concurrent;

/// <summary>
///     The element side of the asynchronous Visitor design pattern: an acceptor takes a visitor and dispatches
///     back to it, so that the visitor can run its behavior against this concrete element type.
/// </summary>
public interface IAcceptor
{
    /// <summary>
    ///     Asynchronously accepts the specified visitor and dispatches this element to it.
    /// </summary>
    /// <param name="visitor">The visitor whose behavior is applied to this element.</param>
    /// <returns>A task that completes when the visitor has finished with this element.</returns>
    Task AcceptAsync(IVisitor visitor);
}

/// <summary>
///     The element side of the asynchronous Visitor design pattern: an acceptor takes a visitor and dispatches
///     back to it, so that the visitor can run its behavior against this concrete element type.
/// </summary>
/// <typeparam name="TResult">The type returned by the visit operation.</typeparam>
public interface IAcceptor<TResult>
{
    /// <summary>
    ///     Asynchronously accepts the specified visitor and dispatches this element to it.
    /// </summary>
    /// <param name="visitor">The visitor whose behavior is applied to this element.</param>
    /// <returns>A task that produces the result the visitor produced for this element.</returns>
    Task<TResult> AcceptAsync(IVisitor<TResult> visitor);
}

/// <summary>
///     Asynchronous counterpart of the Visitor behavioral design pattern, which allows adding
///     new behaviors to an existing class hierarchy without altering any existing code.
/// </summary>
public interface IVisitor
{
    /// <summary>
    ///     Asynchronously runs this visitor's behavior against the specified acceptor.
    /// </summary>
    /// <param name="acceptor">The element that dispatched itself to this visitor.</param>
    /// <returns>A task that completes when the behavior has finished.</returns>
    Task VisitAsync(IAcceptor acceptor);
}

/// <summary>
///     Asynchronous counterpart of the Visitor behavioral design pattern, which allows adding
///     new behaviors to an existing class hierarchy without altering any existing code.
/// </summary>
/// <typeparam name="TResult">The type returned by the visit operation.</typeparam>
public interface IVisitor<TResult>
{
    /// <summary>
    ///     Asynchronously runs this visitor's behavior against the specified acceptor.
    /// </summary>
    /// <param name="acceptor">The element that dispatched itself to this visitor.</param>
    /// <returns>A task that produces the result for the visited element.</returns>
    Task<TResult> VisitAsync(IAcceptor<TResult> acceptor);
}
