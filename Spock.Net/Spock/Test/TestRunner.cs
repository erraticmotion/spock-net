// <copyright file="TestRunner.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test
{
    /// <summary>
    /// Enumerates the types of test runner implementations supported by Spock.
    /// </summary>
    public enum TestRunner
    {
        /// <summary>
        /// Use the NUNit framework.
        /// </summary>
        NUnit,

        /// <summary>
        /// Use the MSTest framework.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        MSTest,

        /// <summary>
        /// Use the XUnit framework.
        /// </summary>
        XUnit
    }
}