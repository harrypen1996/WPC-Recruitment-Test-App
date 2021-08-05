using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using WPCRecruitmentTestApp.Common.ViewModels;
using WPCRecruitmentTestApp.Core.Interfaces.Factories;
using WPCRecruitmentTestApp.Core.Interfaces.Services;
using WPCRecruitmentTestApp.Core.Interfaces.ViewModels;

namespace Unit_Tests.ViewModelsTests.ShellViewModelTests
{
    [ExcludeFromCodeCoverage]
    // ReSharper disable once InconsistentNaming
    public abstract class Given_A_ShellViewModel : BaseUnitTestContext< IShellViewModel >
    {
        #region Fields

        protected IGetCrimeData MockGetCrimeData;
        protected IPoliceUkFactory MockPoliceUkFactory;
        protected ICrimeLastUpdated MockCrimeLastUpdated;
        protected ISumCrimeData MockSumCrimeData;

        #endregion

        #region Other Members

        protected override void SetContext()
        {
            MockGetCrimeData = Substitute.For< IGetCrimeData >();
            MockPoliceUkFactory = Substitute.For< IPoliceUkFactory >();
            MockCrimeLastUpdated = Substitute.For< ICrimeLastUpdated >();
            MockSumCrimeData = Substitute.For< ISumCrimeData >();

            SUT = new ShellViewModel(
                MockGetCrimeData,
                MockPoliceUkFactory,
                MockCrimeLastUpdated,
                MockSumCrimeData );
        }

        #endregion
    }
}