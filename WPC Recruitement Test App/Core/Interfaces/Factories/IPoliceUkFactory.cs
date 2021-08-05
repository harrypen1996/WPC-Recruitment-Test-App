using PoliceUk;

namespace WPCRecruitmentTestApp.Core.Interfaces.Factories
{
    /// <summary>
    ///     Interface for police uk factory.
    /// </summary>
    public interface IPoliceUkFactory
    {
        /// <summary>
        ///     Creates geo position.
        /// </summary>
        /// <param name="latitude">     The latitude. </param>
        /// <param name="longitude">    The longitude. </param>
        /// <returns>
        ///     The new geo position.
        /// </returns>
        IGeoposition CreateGeoPosition(
            double latitude,
            double longitude );
    }
}