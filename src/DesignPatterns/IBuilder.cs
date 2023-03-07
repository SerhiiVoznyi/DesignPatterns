//   Copyright © 2023 Serhii Voznyi and open source community
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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The classic interface for the [Builder] Design Pattern.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilder<out TResult>
    {
        /// <summary>
        /// Builds a object.
        /// </summary>
        TResult Build();
    }

    /// <summary>
    /// The Distributive Builder Interface represents modified for
    /// the [Builder] Design Pattern interface
    /// with possibility to have ordered invocation list of mutations over target <see cref="TResult">type</see>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="DesignPatterns.IBuilder{TResult}" />
    public interface IDistributiveBuilder<out TResult> : IBuilder<TResult>
    {
        /// <summary>
        /// Adds a mutation function to invocation list.
        /// </summary>
        /// <param name="mutation">The mutation faction <see cref="Func{TResult}"/>.</param>
        IDistributiveBuilder<TResult> AddMutation(Action<TResult> mutation);

        /// <summary>
        /// Adds the mutation.
        /// </summary>
        /// <param name="mutation">The mutation.</param>
        /// <param name="safely">if set to <c>true</c> [prevent execution if mutation throws an exception without interruption of execution of mutation chain]</param>
        /// <returns></returns>
        IDistributiveBuilder<TResult> AddMutation(Action<TResult> mutation, bool safely);
    }

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
