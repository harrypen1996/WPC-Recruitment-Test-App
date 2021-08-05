using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Shouldly;

namespace Unit_Tests.ViewModelsTests.ShellViewModelTests.Constructor
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "ViewModels" )]
    public class When_Each_Parameter_Is_Valid : Given_A_ShellViewModel
    {
        [Test]
        public void Then_SUT_Should_Not_Be_Null()
        {
            SUT.ShouldNotBeNull();
        }
    }
}