using NetArchTest.Rules;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using System.Reflection;
using Xunit;

namespace Ordering.ArchitectureTests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Ordering.Domain";
        private const string ApplicationNamespace = "Ordering.Application";
        private const string PersistanceNamespace = "Ordering.Persistence";
        private const string PresentationNamespace = "Ordering.Presentation";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = Assembly.GetAssembly(typeof(Order));

            var otherProjects = new[]
            {
                ApplicationNamespace,
                PersistanceNamespace,
                PresentationNamespace
            };


            // Act
            NetArchTest.Rules.TestResult testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            Assert.True(testResult.IsSuccessful);
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects_Except_Domain()
        {
            // Arrange
            var assembly = Assembly.GetAssembly(typeof(Order));

            var otherProjects = new[]
            {
                PersistanceNamespace,
                PresentationNamespace
            };

            // Act
            NetArchTest.Rules.TestResult testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            Assert.True(testResult.IsSuccessful);
        }
    }
}
