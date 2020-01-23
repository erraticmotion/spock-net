// <copyright file="IParameterCore.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    internal interface IParameterCore<out T>
    {
        T Get(string value);

        string Input { get; }
    }
}