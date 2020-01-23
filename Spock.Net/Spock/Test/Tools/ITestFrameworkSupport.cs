// <copyright file="ITestFrameworkSupport.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    internal interface ITestFrameworkSupport
    {
        bool Supported { get; }

        string Value { get; }
    }
}