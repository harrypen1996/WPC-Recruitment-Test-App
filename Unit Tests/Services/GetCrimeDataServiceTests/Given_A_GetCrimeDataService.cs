using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using PoliceUk;
using WPCRecruitmentTestApp.Common.Services;
using WPCRecruitmentTestApp.Core.Interfaces.Services;

namespace Unit_Tests.Services.GetCrimeDataServiceTests
{
    [ExcludeFromCodeCoverage]
    // ReSharper disable once InconsistentNaming
    public abstract class Given_A_GetCrimeDataService : BaseUnitTestContext< IGetCrimeData >
    {
        #region Fields

        protected IPoliceUkClient MockPoliceUkClient;

        #endregion

        #region Other Members

        protected override void SetContext()
        {
            MockPoliceUkClient = Substitute.For< IPoliceUkClient >();

            SUT = new GetCrimeDataService(
                MockPoliceUkClient );
        }

        #endregion
    }
}