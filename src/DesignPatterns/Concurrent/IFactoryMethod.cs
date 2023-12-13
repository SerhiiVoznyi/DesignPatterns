//   Developed and Supported in 2024 by Serhii Voznyi and open source community
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
    /// Define an interface for creating an object, but let subclasses decide which class to instantiate.
    /// Factory Method lets a class defer instantiation to subclasses.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IFactoryMethod<TResult>
    {
        /// <summary>
        /// Instantiates this object asynchronously
        /// <see>
        ///     <cref>{TResult}</cref>
        /// </see>
        /// </summary>
        Task<TResult> InstantiateAsync();
    }
}
