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
namespace DesignPatterns
{
    /// <summary>
    /// Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.
    /// Co-opt one instance of a class for use as a breeder of all future instances.
    /// The [new] operator considered harmful.
    /// </summary>
    /// <typeparam name="TThis">The type of this object.</typeparam>
    public interface IPrototype<out TThis>
    {
        TThis Clone();
    }
}
