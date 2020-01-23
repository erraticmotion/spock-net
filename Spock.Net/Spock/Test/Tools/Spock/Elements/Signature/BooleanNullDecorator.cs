// <copyright file="BooleanNullDecorator.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    internal class BooleanNullDecorator : Parameter<bool?>
    {
        private readonly IParameterCore<bool> core;

        public BooleanNullDecorator(IParameterCore<bool> core)
            : base(core.Input)
        {
            this.core = core;
        }

        public static BooleanNullDecorator True()
        {
            return new BooleanNullDecorator(BooleanParameter.True());
        }

        public static BooleanNullDecorator False()
        {
            return new BooleanNullDecorator(BooleanParameter.False());
        }

        public override bool? Get(string value)
        {
            if (value.Length > 1)
            {
                return this.core.Get(value);
            }

            return null;
        }
    }
}