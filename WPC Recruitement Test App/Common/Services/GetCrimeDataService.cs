using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PoliceUk;
using PoliceUk.Entities.StreetLevel;
using WPCRecruitmentTestApp.Core.Interfaces.Services;

namespace WPCRecruitmentTestApp.Common.Services
{
    /// <summary>
    ///     A service for accessing get crime data information.
    /// </summary>
    /// <seealso cref="IGetCrimeData"/>
    public class GetCrimeDataService : IGetCrimeData
    {
        #region Fields

        /// <summary>
        ///     (Immutable) the police uk client.
        /// </summary>
        [NotNull] private readonly IPoliceUkClient _policeUkClient;

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are null. </exception>
        /// <param name="policeUkClient">   (Immutable) the police uk client. </param>
        public GetCrimeDataService(
            [NotNull] IPoliceUkClient policeUkClient )
        {
            _policeUkClient = policeUkClient ?? throw new ArgumentNullException( nameof(policeUkClient) );
        }

        #endregion

        #region Interface Implementations

        /// <inheritdoc/>
        public Task< IEnumerable< Crime > > ExecuteAsync(
            IGeoposition geoPosition,
            DateTime dateTime )
        {
            return Task.Run(
                () =>
                {
                    var streetLevelCrimes = _policeUkClient.StreetLevelCrimes( geoPosition, dateTime );

                    return streetLevelCrimes?.Crimes;
                } );
        }

        #endregion
    }
}