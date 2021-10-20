// <copyright file="SimpleCalculatorControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace APIMATICCalculator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using APIMATICCalculator.Standard;
    using APIMATICCalculator.Standard.Controllers;
    using APIMATICCalculator.Standard.Exceptions;
    using APIMATICCalculator.Standard.Http.Client;
    using APIMATICCalculator.Standard.Http.Response;
    using APIMATICCalculator.Standard.Utilities;
    using APIMATICCalculator.Tests.Helpers;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;

    /// <summary>
    /// SimpleCalculatorControllerTest.
    /// </summary>
    [TestFixture]
    public class SimpleCalculatorControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private SimpleCalculatorController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.SimpleCalculatorController;
        }

        /// <summary>
        /// Check if multiplication works.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestMultiply()
        {
            // Parameters for the API call
            var operation = (Standard.Models.OperationTypeEnum)Enum.Parse(typeof(Standard.Models.OperationTypeEnum), "MULTIPLY");
            var x = 4;
            var y = 5;
            Standard.Models.GetCalculateInput input = new Standard.Models.GetCalculateInput(operation, x, y);

            // Perform API call
            double result = 0;
            try
            {
                result = await this.controller.GetCalculateAsync(input);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.AreEqual(20, result, AssertPrecision, "Response should match expected value");
        }

        /// <summary>
        /// Check if the endpoint returns correct sum for any two points.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSum()
        {
            // Parameters for the API call
            var operation = (Standard.Models.OperationTypeEnum)Enum.Parse(typeof(Standard.Models.OperationTypeEnum), "SUM");
            var x = 34;
            var y = 22;
            Standard.Models.GetCalculateInput input = new Standard.Models.GetCalculateInput(operation, x, y);

            // Perform API call
            double result = 0;
            try
            {
                result = await this.controller.GetCalculateAsync(input);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.AreEqual(56, result, AssertPrecision, "Response should match expected value");
        }
    }
}