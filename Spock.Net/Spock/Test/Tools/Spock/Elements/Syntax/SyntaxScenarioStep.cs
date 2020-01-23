// <copyright file="SyntaxScenarioStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
 
    /// <summary>
    /// <c>Conceptual</c>
    /// <para>
    /// For each Step (Given, When, Then, optional, maybe 0 or more) create
    /// an object that is responsible for creating C# code that corresponds
    /// with the step.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Methods.Partial (maybe rename it to be a singular test method) should 
    /// be deleted now. If there are no test cases or doc strings
    /// then just call On{TestMethod} within the public test method. Need to create
    /// a new type that does that (implements this abstraction).
    /// Need to think about how to order the collection of steps so that Givens come
    /// before When's etc.
    /// </remarks>
    internal abstract class SyntaxScenarioStep : ISyntaxScenarioStep
    {
        public static ISyntaxScenarioStepBuilder CreateBuilder => new SyntaxScenarioStepBuilder();

        public abstract string Signature { get; }

        public abstract string CallSyntax { get; }

        public IEnumerable<string> Syntax => this.SyntaxCore();

        protected abstract IEnumerable<string> SyntaxCore();
    }
}