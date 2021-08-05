using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using PoliceUk;
using PoliceUk.Entities.StreetLevel;
using Shouldly;

namespace Unit_Tests.Services.GetCrimeDataServiceTests
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "Services" )]
    public class When_Invoked : Given_A_GetCrimeDataService
    {
        private Task< IEnumerable< Crime > > _task;
        private IEnumerable< Crime > _result;
        private IGeoposition _geoPosition;
        private readonly DateTime _expectedDateTime = new DateTime( 1, 1, 1 );
        private StreetLevelCrimeResults _expectedStreetLevelCrimeResults;
        private IEnumerable< Crime > _expectedCrimeData;

        protected override void Because()
        {
            _geoPosition = Substitute.For< IGeoposition >();
            _expectedCrimeData = new List< Crime >() {new Crime()};
            _expectedStreetLevelCrimeResults = new StreetLevelCrimeResults() {Crimes = _expectedCrimeData};

            MockPoliceUkClient.StreetLevelCrimes( _geoPosition, _expectedDateTime )
                .Returns( _expectedStreetLevelCrimeResults );

            _task = SUT.ExecuteAsync( _geoPosition, _expectedDateTime );
            _task.Wait();

            _result = _task.Result;
        }

        [Test]
        public void Then_Result_Should_Be_Expected()
        {
            _result.ShouldBe( _expectedCrimeData );
        }
    }
}