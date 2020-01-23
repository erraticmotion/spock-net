// <copyright file="NumericNull.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;

    internal class NumericNull : ArgumentBase
    {
        public NumericNull()
            : base(MethodArgType.Argument)
        {
        }

        public override Type Type => typeof(int?);

        public override object Value => null;
    }
}