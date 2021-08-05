using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using WPCRecruitmentTestApp.Common.Services;
using WPCRecruitmentTestApp.Core.Interfaces.Factories;
using WPCRecruitmentTestApp.Core.Interfaces.Services;

namespace Unit_Tests.Services.SumCrimeDataServiceTests
{
    [ExcludeFromCodeCoverage]
    // ReSharper disable once InconsistentNaming
    public abstract class Given_A_SumCrimeDataService : BaseUnitTestContext< ISumCrimeData >
    {
        #region Fields

        protected IEntityFactory MockEntityFactory;

        #endregion

        #region Other Members

        protected override void SetContext()
        {
            MockEntityFactory = Substitute.For< IEntityFactory >();
            SUT = new SumCrimeDataService(
                MockEntityFactory );
        }

        #endregion
    }
}