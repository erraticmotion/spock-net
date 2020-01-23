﻿// <copyright file="GenericParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;

    internal class GenericParameter : ArgumentBase
    {
        public GenericParameter(MethodArgType placement, Type type, object value)
            : base(placement)
        {
            this.Type = type;
            this.Value = value;
        }

        public override Type Type { get; }

        public override object Value { get; }
    }
}