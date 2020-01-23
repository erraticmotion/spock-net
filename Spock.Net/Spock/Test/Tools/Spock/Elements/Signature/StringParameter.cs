// <copyright file="StringParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;

    internal class StringParameter : ArgumentBase
    {
        public StringParameter(string value, MethodArgType placement)
            : base(placement)
        {
            this.Value = value.TrimStart('\'').TrimEnd('\'');
        }

        public override Type Type => typeof(string);

        public override object Value { get; }
    }
}