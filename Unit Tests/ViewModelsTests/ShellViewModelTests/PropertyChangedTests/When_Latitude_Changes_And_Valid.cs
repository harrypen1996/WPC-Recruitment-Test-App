using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Shouldly;

namespace Unit_Tests.ViewModelsTests.ShellViewModelTests.PropertyChangedTests
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "ViewModels" )]
    public class When_Latitude_Changes_And_Valid : Given_A_ShellViewModel
    {
        protected override void Because()
        {
            SUT.Longitude = 0;
            SUT.SelectedDateTime = new DateTime( 1, 1, 1 );

            SUT.Latitude = 20;
        }

        [Test]
        public void Then_IsSafeToSearch_Should_Be_Valid()
        {
            SUT.IsSafeToSearch.ShouldBeTrue();
        }
    }
}
