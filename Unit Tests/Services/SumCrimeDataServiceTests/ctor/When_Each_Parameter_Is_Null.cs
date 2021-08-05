using System;
using System.Diagnostics.CodeAnalysis;
using Ninject;
using NUnit.Framework;
using Shouldly;
using WPCRecruitmentTestApp.Common.Services;
using WPCRecruitmentTestApp.Core.Interfaces.Factories;

namespace Unit_Tests.Services.SumCrimeDataServiceTests.ctor
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "Services" )]
    public class When_Each_Parameter_Is_Null : Given_A_SumCrimeDataService
    {
        [TestCase( typeof( IEntityFactory ) )]
        public void Then_An_ArgumentNullException_Should_Be_Thrown(
            Type parameter )
        {
            MockingKernel.RebindToNull( parameter );

            Should.Throw< ArgumentNullException >(
                () => SUT =
                          new SumCrimeDataService(
                              MockingKernel.Get< IEntityFactory >()
                          ) );
        }
    }
}