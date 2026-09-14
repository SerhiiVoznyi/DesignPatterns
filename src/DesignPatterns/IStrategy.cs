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
///     Strategy is a behavioral design pattern that turns a set of behaviors into objects
///     and makes them interchangeable inside the original context object.
/// </summary>
public interface IStrategy
{
    /// <summary>
    ///     Executes the algorithm encapsulated in this strategy instance.
    /// </summary>
    void Execute();
}

/// <summary>
///     Strategy is a behavioral design pattern that turns a set of behaviors into objects
///     and makes them interchangeable inside the original context object.
/// </summary>
/// <typeparam name="TResult">The type produced by the algorithm.</typeparam>
public interface IStrategy<out TResult>
{
    /// <summary>
    ///     Executes the algorithm encapsulated in this strategy instance.
    /// </summary>
    /// <returns>The result of the algorithm.</returns>
    TResult Execute();
}

/// <summary>
///     Strategy is a behavioral design pattern that turns a set of behaviors into objects
///     and makes them interchangeable inside the original context object.
/// </summary>
/// <typeparam name="TResult">The type produced by the algorithm.</typeparam>
/// <typeparam name="TData">The type of input the algorithm operates on.</typeparam>
public interface IStrategy<out TResult, in TData>
{
    /// <summary>
    ///     Executes the algorithm encapsulated in this strategy instance over the supplied input.
    /// </summary>
    /// <param name="data">The input the algorithm operates on.</param>
    /// <returns>The result of the algorithm.</returns>
    TResult Execute(TData data);
}
