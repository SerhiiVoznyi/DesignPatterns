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
namespace DesignPatterns.Implementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The base implementation of <see cref="IDistributiveBuilder{TResult}"/> interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="DesignPatterns.IDistributiveBuilder{TResult}" />
    public class DistributiveBuilderBase<TResult> : IDistributiveBuilder<TResult> where TResult : new()
    {
        private readonly List<(Action<TResult> mutation, bool isSafely)> _mutations;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributiveBuilderBase{TResult}"/> class.
        /// </summary>
        public DistributiveBuilderBase()
        {
            _mutations = new List<(Action<TResult> mutation, bool isSafely)>();
        }

        public virtual IDistributiveBuilder<TResult> AddMutation(Action<TResult> mutation)
        {
            _mutations.Add((mutation, false));
            return this;
        }

        public virtual IDistributiveBuilder<TResult> AddMutation(Action<TResult> mutation, bool safely)
        {
            _mutations.Add((mutation, safely));
            return this;
        }

        public virtual TResult Build()
        {
            var result = new TResult();
            var verificationObject = new TResult();

            foreach ((Action<TResult> Mutation, bool IsSafely) candidate in _mutations)
                try
                {
                    candidate.Mutation.Invoke(verificationObject);
                    candidate.Mutation.Invoke(result);
                }
                catch (Exception)
                {
                    if (!candidate.IsSafely) throw;
                }

            return result;
        }
    }
}
