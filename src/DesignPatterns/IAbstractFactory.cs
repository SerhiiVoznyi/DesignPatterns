//   Copyright © 2021 Serhii Voznyi and open source community
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
    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide an interface for creating families of related objects.
    /// </summary>
    public interface IAbstractFactory
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects].
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="operationData">The operation data.</param>
        TResult Create<TResult, TInput>(TInput operationData);
    }

    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide an interface for creating families of related objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IAbstractFactory<out TResult>
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects].
        /// </summary>
        TResult Create();
    }

    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide an interface for creating families of related objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    public interface IAbstractFactory<out TResult, in TInput>
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects].
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        TResult Create(TInput operationData);
    }
}
