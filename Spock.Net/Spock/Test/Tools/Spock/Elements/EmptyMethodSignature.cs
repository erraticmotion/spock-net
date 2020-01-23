// <copyright file="EmptyMethodSignature.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using System.Collections.Generic;

    internal class EmptyMethodSignature : IMethodSignature
    {
        public EmptyMethodSignature()
        {
            this.Arguments = new List<IMethodArgument>();
        }

        public IEnumerable<IMethodArgument> Arguments { get; }

        public override string ToString()
        {
            return "()";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.ToString();
        }
    }
}