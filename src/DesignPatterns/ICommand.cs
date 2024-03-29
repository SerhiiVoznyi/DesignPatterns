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
namespace DesignPatterns
{
    /// <summary>
    ///     Command is behavioral [Design Pattern] that converts requests
    ///     or simple operations into objects.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     Executes this command.
        /// </summary>
        void Execute();
    }

    /// <summary>
    ///     Command is behavioral [Design Pattern] that converts requests
    ///     or simple operations into objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface ICommand<out TResult>
    {
        /// <summary>
        ///     Executes this command.
        /// </summary>
        TResult Execute();
    }

    /// <summary>
    ///     Command is behavioral [Design Pattern] that converts requests
    ///     or simple operations into objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TExecutor">The type of the executor.</typeparam>
    public interface ICommand<out TResult, in TExecutor>
    {
        /// <summary>
        ///     Executes this command.
        /// </summary>
        /// <param name="executor">The executor on which depends this command.</param>
        TResult Execute(TExecutor executor);
    }
}