using NUnit.Framework;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Context.SimpleInjector.Tests
{
    public class MyAppBootstrapperTest
    {
        [Test]
        public void Container_Never_ContainsDiagnosticWarnings()
        {
            //// Arrange
            //var container = Bootstrapper.GetInitializedContainer();

            //container.Verify(VerificationOption.VerifyOnly);

            //// Assert
            //var results = Analyzer.Analyze(container);

            //Assert.IsFalse(results.Any(), Environment.NewLine +
            //    string.Join(Environment.NewLine,
            //        from result in results
            //        select result.Description));
        }
    }
}
