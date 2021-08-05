using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Shouldly;

namespace Unit_Tests.Services.SumCrimeDataServiceTests.ctor
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "Services" )]
    public class When_Each_Parameter_Is_Valid : Given_A_SumCrimeDataService
    {
        [Test]
        public void Then_SUT_Should_Not_Be_Null()
        {
            SUT.ShouldNotBeNull();
        }
    }
}