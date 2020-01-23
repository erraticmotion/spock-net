// <copyright file="MethodArgType.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// A method can take any number of <c>parameters</c>, and each parameter is of a specific
    /// type. The values that the caller supplies for parameters are called the <c>arguments</c>;
    /// every argument must correspond to a particular parameter.
    /// </summary>
    public enum MethodArgType
    {
        /// <summary>
        /// Indicates that this is a parameter value. It has a type and a name.
        /// </summary>
        Parameter,

        /// <summary>
        /// Indicates that this is an argument value. It has a type and a value.
        /// </summary>
        Argument
    }
}