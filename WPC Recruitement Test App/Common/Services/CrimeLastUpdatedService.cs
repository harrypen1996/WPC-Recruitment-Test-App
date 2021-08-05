using System;
using System.Threading.Tasks;
using PoliceUk;
using WPCRecruitmentTestApp.Core.Interfaces.Services;

namespace WPCRecruitmentTestApp.Common.Services
{
    /// <summary>
    ///     A service for accessing crime last updated information.
    /// </summary>
    /// <seealso cref="ICrimeLastUpdated"/>
    public class CrimeLastUpdatedService : ICrimeLastUpdated
    {
        #region Interface Implementations

        /// <inheritdoc/>
        public Task< DateTime > ExecuteAsync()
        {
            return Task.Run(
                () =>
                {
                    var client = new PoliceUkClient();
                    return client.LastUpdated();
                } );
        }

        #endregion
    }
}