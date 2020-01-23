// <copyright file="MethodIdentity.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;
    using Elements;
    using Gherkin;

    internal class MethodIdentity : IMethodIdentity
    {
        public MethodIdentity(IGherkinBlock scenario)
        {
            // try and get some kind of test case identifier from the comments
            var maybe = scenario.Comments.Find(GherkinIdRef.ScenarioId);
            this.Id = maybe.HasValue ? maybe.Value.Value : Guid.NewGuid().ToString();
        }

        public IComparable Id { get; }

        public string TestCase => "Scenario Id: " + this.Id;
    }
}