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
///     Define an interface for creating an object, but let subclasses decide which class to instantiate.
///     Factory Method lets a class defer instantiation to subclasses.
/// </summary>
/// <typeparam name="TResult">The type of object the factory method creates.</typeparam>
public interface IFactoryMethod<out TResult>
{
    /// <summary>
    ///     Creates a new <typeparamref name="TResult" /> instance, letting the implementation decide
    ///     which concrete type to instantiate.
    /// </summary>
    /// <returns>The newly created <typeparamref name="TResult" /> instance.</returns>
    TResult Instantiate();
}
