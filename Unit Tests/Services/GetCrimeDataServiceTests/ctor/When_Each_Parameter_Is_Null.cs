using System;
using System.Diagnostics.CodeAnalysis;
using Ninject;
using NUnit.Framework;
using PoliceUk;
using Shouldly;
using WPCRecruitmentTestApp.Common.Services;

namespace Unit_Tests.Services.GetCrimeDataServiceTests.ctor
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "Services" )]
    public class When_Each_Parameter_Is_Null : Given_A_GetCrimeDataService
    {
        [TestCase( typeof( IPoliceUkClient ) )]
        public void Then_An_ArgumentNullException_Should_Be_Thrown(
            Type parameter )
        {
            MockingKernel.RebindToNull( parameter );

            Should.Throw< ArgumentNullException >(
                () => SUT =
                          new GetCrimeDataService(
                              MockingKernel.Get< IPoliceUkClient >()
                          ) );
        }
    }
}