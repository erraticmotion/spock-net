// <copyright file="FixtureMethods.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class FixtureMethods : IFixtureMethods
    {
        private readonly IEnumerable<IFixtureMethod> methods;

        public FixtureMethods(IEnumerable<IFixtureMethod> methods)
        {
            this.methods = methods;
        }

        public IFixtureMethod this[int index] => methods.ElementAtOrDefault(index);

        public IEnumerator<IFixtureMethod> GetEnumerator()
        {
            return this.methods.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}