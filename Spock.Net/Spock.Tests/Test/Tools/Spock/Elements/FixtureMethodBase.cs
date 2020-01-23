// <copyright file="FixtureMethodBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using System.Linq;
    using Fixtures;
    using FluentAssertions;
    using StateVerification;

    public abstract class FixtureMethodBase : GivenWhenThen<IFixtureMethods>
    {
        /// <summary>
        /// Extension point for sub-classes to vary the test runner.
        /// </summary>
        protected abstract TestRunner WithTestRunner();

        protected IFixtureMethod FixtureResult { get; private set; }

        /// <summary>
        /// Act on the software/system under test.
        /// </summary>
        /// <param name="sut">The System/Software under Test.</param>
        protected override void When(IFixtureMethods sut)
        {
            this.FixtureResult = sut.ElementAt(0);
        }

        /// <summary>
        /// Shows this instance.
        /// </summary>
        [Then]
        public void Show()
        {
            this.FixtureResult.Syntax().ForIndex((i, s) => Console.WriteLine(i + " " + s));
        }

        /// <summary>
        /// Given should be.
        /// </summary>
        [Then]
        public virtual void GivenShouldBe()
        {
            this.FixtureResult.HasGiven.Should().BeFalse();
        }

        /// <summary>
        /// When should be.
        /// </summary>
        [Then]
        public virtual void WhenShouldBe()
        {
            this.FixtureResult.HasWhen.Should().BeFalse();
        }

        /// <summary>
        /// Then the should be.
        /// </summary>
        [Then]
        public virtual void ThenShouldBe()
        {
            this.FixtureResult.HasThen.Should().BeFalse();
        }

        protected virtual void Syntax(
            int index,
            string expected,
            StateVerificationStringOption option = StateVerificationStringOption.Exact,
            string because = "")
        {
            var item = this.FixtureResult.Syntax()[index];
            var comparer = StateVerificationString.Create(option, item);
            comparer.Compare(expected, because);
        }
    }
}