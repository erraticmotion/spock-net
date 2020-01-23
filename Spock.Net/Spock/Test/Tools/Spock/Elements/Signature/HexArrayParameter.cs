// <copyright file="HexArrayParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    internal class HexArrayParameter : Parameter<byte[]>
    {
        public HexArrayParameter(string value)
            : base(value)
        {
        }

        public override byte[] Get(string value)
        {
            return value.ToLiteralBytes();
        }
    }
}