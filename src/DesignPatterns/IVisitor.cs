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
///     The element side of the Visitor design pattern: an acceptor takes a visitor and dispatches
///     back to it, so that the visitor can run its behavior against this concrete element type.
/// </summary>
public interface IAcceptor
{
    /// <summary>
    ///     Accepts the specified visitor and dispatches this element to it.
    /// </summary>
    /// <param name="visitor">The visitor whose behavior is applied to this element.</param>
    void Accept(IVisitor visitor);
}

/// <summary>
///     The element side of the Visitor design pattern: an acceptor takes a visitor and dispatches
///     back to it, so that the visitor can run its behavior against this concrete element type.
/// </summary>
/// <typeparam name="TResult">The type returned by the visit operation.</typeparam>
public interface IAcceptor<TResult>
{
    /// <summary>
    ///     Accepts the specified visitor and dispatches this element to it.
    /// </summary>
    /// <param name="visitor">The visitor whose behavior is applied to this element.</param>
    /// <returns>The result produced by the visitor for this element.</returns>
    TResult Accept(IVisitor<TResult> visitor);
}

/// <summary>
///     Visitor is a behavioral design pattern that allows adding
///     new behaviors to an existing class hierarchy without altering
///     any existing code.
/// </summary>
public interface IVisitor
{
    /// <summary>
    ///     Runs this visitor's behavior against the specified acceptor.
    /// </summary>
    /// <param name="acceptor">The element that dispatched itself to this visitor.</param>
    void Visit(IAcceptor acceptor);
}

/// <summary>
///     Visitor is a behavioral design pattern that allows adding
///     new behaviors to an existing class hierarchy without altering
///     any existing code.
/// </summary>
/// <typeparam name="TResult">The type returned by the visit operation.</typeparam>
public interface IVisitor<TResult>
{
    /// <summary>
    ///     Runs this visitor's behavior against the specified acceptor.
    /// </summary>
    /// <param name="acceptor">The element that dispatched itself to this visitor.</param>
    /// <returns>The result produced for the visited element.</returns>
    TResult Visit(IAcceptor<TResult> acceptor);
}
