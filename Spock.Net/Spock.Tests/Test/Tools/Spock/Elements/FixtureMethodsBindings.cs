// <copyright file="FixtureMethodsBindings.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using Builders;
    using Fixtures.Containers;
    using Gherkin;
    using Gherkin.Builders;

    /// <summary>
    /// Declares the bindings to use when creating instances of the <see cref="FixtureMethods"/>
    /// type when using the <see cref="FixtureBuilder.Build"/> member.
    /// </summary>
    public class FixtureMethodsBindings : IFixtureBindings
    {
        private readonly TestRunner testRunner;

        /// <summary>
        /// Initializes a new instance of the <see cref="FixtureMethodsBindings"/> class.
        /// </summary>
        public FixtureMethodsBindings()
            : this(TestRunner.NUnit)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixtureMethodsBindings"/> class.
        /// </summary>
        /// <param name="testRunner">The test runner.</param>
        public FixtureMethodsBindings(TestRunner testRunner)
        {
            this.testRunner = testRunner;
        }

        /// <summary>
        /// Loads the specified bindings into the kernel.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public void Load(IFixtureKernel kernel)
        {
// ReSharper disable once RedundantBoolCompare
            kernel.Bind(TestDouble.Stub<ISpockOptions>(o => o.TestRunner == this.testRunner && o.SetIgnore == true));
            kernel.BindDummy<IFixtureInvariants>();
            kernel.BindDummy<IGherkinBlock>();

            kernel.Bind<IMethods, ScenarioMethods>();
            kernel.Bind<IBuilder<IFixtureMethods>, FixtureMethodBuilder>();

            kernel.Bind(ctx => ctx.Get<FixtureMethodBuilder>().Build());
        }
    }
}