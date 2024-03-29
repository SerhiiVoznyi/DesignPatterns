﻿//   Developed and Supported in 2024 by Serhii Voznyi and open source community
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
namespace DesignPatterns.Concurrent
{
    using System.Threading.Tasks;

    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance asynchronously.
        /// </summary>
        Task ExecuteAsync();
    }

    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IStrategy<TResult>
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance asynchronously.
        /// </summary>
        Task<TResult> Execute();
    }

    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    public interface IStrategy<TResult, in TData>
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance asynchronously.
        /// </summary>
        /// <param name="data">The data.</param>
        Task<TResult> Execute(TData data);
    }
}
