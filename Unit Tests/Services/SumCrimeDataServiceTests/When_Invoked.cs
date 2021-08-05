using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using PoliceUk.Entities.StreetLevel;
using Shouldly;
using WPCRecruitmentTestApp.Core.Interfaces.Entities;

namespace Unit_Tests.Services.SumCrimeDataServiceTests
{
    // ReSharper disable once InconsistentNaming
    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category( "Services" )]
    public class When_Invoked : Given_A_SumCrimeDataService
    {
        private Task< IEnumerable< ICrimeSumDisplayValue > > _task;
        private IEnumerable< ICrimeSumDisplayValue > _result;
        private ICrimeSumDisplayValue _entity1;
        private ICrimeSumDisplayValue _entity2;
        private IEnumerable< Crime > _crimeData;
        private const string Cat1 = "cat1";
        private const string Cat2 = "cat2";

        protected override void Because()
        {
            _entity1 = Substitute.For< ICrimeSumDisplayValue >();
            _entity2 = Substitute.For< ICrimeSumDisplayValue >();

            _crimeData = new List< Crime >() {new Crime() {Category = Cat1}, new Crime() {Category = Cat1}, new Crime() {Category = Cat2}};

            MockEntityFactory.CreateCrimeSumDisplayValueEntity()
                .Returns( _entity1, _entity2 );

            _task = SUT.ExecuteAsync( _crimeData );
            _task.Wait();
            _result = _task.Result;
        }

        [Test]
        public void Then_Result_Entities_Should_Be_Expected()
        {
            _result.SequenceEqual( new List< ICrimeSumDisplayValue >() {_entity1, _entity2} )
                .ShouldBeTrue();
        }

        [Test]
        public void Then_Entity_1_Sum_Should_Be_Expected()
        {
            _entity1.SumTotal.ShouldBe( 2 );
        }

        [Test]
        public void Then_Entity_2_Sum_Should_Be_Expected()
        {
            _entity2.SumTotal.ShouldBe( 1 );
        }

        [Test]
        public void Then_Entity_1_Cat_Should_Be_Expected()
        {
            _entity1.CrimeCategory.ShouldBe( Cat1 );
        }

        [Test]
        public void Then_Entity_2_Cat_Should_Be_Expected()
        {
            _entity2.CrimeCategory.ShouldBe(Cat2);
        }
    }
}