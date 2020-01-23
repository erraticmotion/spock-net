// <copyright file="SpockCollection.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class SpockCollection<T> : ISpockElements<T>
        where T : class
    {
        private IList<T> items;

        public SpockCollection(IList<T> items)
        {
            this.items = items;
        }

        public SpockCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        protected SpockCollection()
        {
        }

        public T this[int index] => this.items.ElementAtOrDefault(index);

        public void AddRange(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                this.items.Add(value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        protected void AddContainer(IList<T> value)
        {
            this.items = value;
        }
    }
}