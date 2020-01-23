// <copyright file="Maybe.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System;

    /// <summary>
    /// Martin Fowler's PoEAA Null Object design pattern slightly modified to fit with
    /// the built-in .NET Framework <c>nullable</c> support.
    /// </summary>
    /// <typeparam name="T">The type of object that maybe null or not.</typeparam>
    public sealed class Maybe<T>
        where T : class
    {
        private readonly Tuple<bool, T> container;

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public Maybe(T item)
        {
            this.container = new Tuple<bool, T>(item != null, item);
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Value"/> property is null.
        /// </summary>
        /// <value>
        /// <c>True</c> if this instance has an instance 
        /// of <typeparamref name="T"/> in the <see cref="Value"/> property; 
        /// otherwise, <c>false</c>, indicating the reference is null.
        /// </value>
        public bool HasValue => this.container.Item1;

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>
        /// An object of type <typeparamref name="T"/>.
        /// </value>
        public T Value => this.container.Item2;
    }
}