using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using PoliceUk;
using PoliceUk.Entities.StreetLevel;
using Shouldly;

namespace Unit_Tests.ViewModelsTests.ShellViewModelTests.CommandTests
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "ViewModels" )]
    public class When_Search_Invoked : Given_A_ShellViewModel
    {
        private double ExpectedLongitude = 10;
        private double ExpectedLatitude = 20;
        private readonly DateTime _expectedDateTime = new DateTime( 1,1,1 );
        private IGeoposition _expectedGeoPosition;
        private IEnumerable< Crime > _expectedCrimeData;
        private const string _catagory1 = "hello";
        private const string _catagory2 = "there";
        private Crime _crime1;
        private Crime _crime2;
        

        protected override void Because()
        {
            SUT.Latitude = ExpectedLatitude;
            SUT.Longitude = ExpectedLongitude;
            SUT.SelectedDateTime = _expectedDateTime;

            _crime1 = new Crime() { Category = _catagory1 };
            _crime2 = new Crime() {Category = _catagory2};

            _expectedCrimeData = new List< Crime >() {_crime1, _crime2};

            _expectedGeoPosition = Substitute.For< IGeoposition >();

            MockPoliceUkFactory.CreateGeoPosition( ExpectedLatitude, ExpectedLongitude )
                .Returns( _expectedGeoPosition );

            MockGetCrimeData.ExecuteAsync( _expectedGeoPosition, _expectedDateTime )
                .Returns( _expectedCrimeData );

            SUT.SearchForCrimesAsync();
        }

        [Test]
        public void Then_Crime_Data_Should_Be_Expected()
        {
            SUT.CrimesCollection.ShouldBe( _expectedCrimeData );
        }
    }
}
