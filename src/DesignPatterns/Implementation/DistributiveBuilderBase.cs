// SPDX-License-Identifier: Apache-2.0
// Copyright © 2020-2026 Serhii Voznyi and Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//     http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace DesignPatterns.Implementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Base implementation of <see cref="IDistributiveBuilder{TResult}"/>.
    /// Collects mutations and applies them to a new <typeparamref name="TResult"/> on <see cref="Build"/>.
    /// </summary>
    /// <typeparam name="TResult">The result type to build.</typeparam>
    /// <remarks>
    /// A mutation marked as <c>isSafe=true</c> is executed inside a try/catch.
    /// If it throws, the exception is swallowed and the mutation is skipped.
    /// Non-safe mutations propagate their exceptions.
    /// This type is not thread-safe.
    /// </remarks>
    public class DistributiveBuilderBase<TResult> : IDistributiveBuilder<TResult> where TResult : new()
    {
        private readonly List<(Action<TResult> Action, bool IsSafe)> _mutations = new();

        /// <summary>
        /// Adds a mutation to be applied during <see cref="Build"/>.
        /// </summary>
        /// <param name="mutation">An action that mutates a <typeparamref name="TResult"/> instance.</param>
        /// <returns>This builder instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="mutation"/> is <c>null</c>.</exception>
        public virtual IDistributiveBuilder<TResult> AddMutation(Action<TResult> mutation) =>
            AddMutation(mutation, isSafe: false);

        /// <summary>
        /// Adds a mutation to be applied during <see cref="Build"/>.
        /// </summary>
        /// <param name="mutation">An action that mutates a <typeparamref name="TResult"/> instance.</param>
        /// <param name="isSafe">
        /// When <c>true</c>, exceptions thrown by <paramref name="mutation"/> are swallowed and the mutation is skipped.
        /// When <c>false</c>, exceptions propagate to the caller of <see cref="Build"/>.
        /// </param>
        /// <returns>This builder instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="mutation"/> is <c>null</c>.</exception>
        public virtual IDistributiveBuilder<TResult> AddMutation(Action<TResult> mutation, bool isSafe)
        {
            if (mutation is null) throw new ArgumentNullException(nameof(mutation));
            _mutations.Add((mutation, isSafe));
            return this;
        }

        /// <summary>
        /// Clears all queued mutations.
        /// </summary>
        /// <returns>This builder instance for chaining.</returns>
        public virtual IDistributiveBuilder<TResult> Clear()
        {
            _mutations.Clear();
            return this;
        }

        /// <summary>
        /// Builds a new <typeparamref name="TResult"/> by applying queued mutations.
        /// </summary>
        /// <returns>A fully constructed <typeparamref name="TResult"/>.</returns>
        /// <exception cref="Exception">
        /// Re-throws any exception produced by a non-safe mutation.
        /// </exception>
        public virtual TResult Build()
        {
            var result = CreateInstance();
            var probe = CreateInstance();

            foreach (var (action, isSafe) in _mutations)
            {
                try
                {
                    // Validate on a separate instance to detect failures without corrupting the result.
                    action.Invoke(probe);

                    // Apply only if the probe succeeded.
                    action.Invoke(result);
                }
                catch (Exception) when (isSafe)
                {
                    // Skip this mutation when marked safe.
                }
            }

            return result;
        }

        /// <summary>
        /// Factory method for creating new instances of <typeparamref name="TResult"/>.
        /// Override to customize instantiation.
        /// </summary>
        protected virtual TResult CreateInstance() => new TResult();
    }
}