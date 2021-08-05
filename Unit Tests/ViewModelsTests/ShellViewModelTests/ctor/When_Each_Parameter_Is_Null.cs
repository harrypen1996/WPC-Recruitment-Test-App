using System;
using System.Diagnostics.CodeAnalysis;
using Ninject;
using NUnit.Framework;
using Shouldly;
using WPCRecruitmentTestApp.Common.ViewModels;
using WPCRecruitmentTestApp.Core.Interfaces.Factories;
using WPCRecruitmentTestApp.Core.Interfaces.Services;

namespace Unit_Tests.ViewModelsTests.ShellViewModelTests.Ctor
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "ViewModels" )]
    public class When_Each_Parameter_Is_Null : Given_A_ShellViewModel
    {
        [TestCase( typeof( IGetCrimeData ) )]
        [TestCase( typeof( IPoliceUkFactory ) )]
        [TestCase( typeof( ICrimeLastUpdated ) )]
        [TestCase( typeof( ISumCrimeData ) )]
        public void Then_An_ArgumentNullException_Should_Be_Thrown(
            Type parameter )
        {
            MockingKernel.RebindToNull( parameter );

            Should.Throw< ArgumentNullException >(
                () => SUT =
                          new ShellViewModel(
                              MockingKernel.Get< IGetCrimeData >(),
                              MockingKernel.Get< IPoliceUkFactory >(),
                              MockingKernel.Get< ICrimeLastUpdated >(),
                              MockingKernel.Get< ISumCrimeData >()
                          ) );
        }
    }
}