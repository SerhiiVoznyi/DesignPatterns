﻿//   Developed and Supported in 2025 by Serhii Voznyi and open source community
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
namespace DesignPatterns.Implementation
{
    /// <summary>
    ///     The base implementation of [Singleton] Design pattern.
    /// </summary>
    /// <typeparam name="TThis">The type of the this.</typeparam>
    /// <seealso cref="DesignPatterns.ISingleton{TThis}" />
    public abstract class SingletonBase<TThis> : ISingleton<TThis> where TThis : new()
    {
        private static readonly TThis Instance = new TThis();

        public TThis GetInstance()
        {
            return Instance;
        }
    }
}
