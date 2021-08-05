using System.Collections.Generic;
using System.Threading.Tasks;
using PoliceUk.Entities.StreetLevel;
using WPCRecruitmentTestApp.Core.Interfaces.Entities;

namespace WPCRecruitmentTestApp.Core.Interfaces.Services
{
    /// <summary>
    ///     Interface for sum crime data.
    /// </summary>
    public interface ISumCrimeData
    {
        #region Other Members

        /// <summary>
        ///     Executes the 'asynchronous' operation.
        /// </summary>
        /// <param name="crimeData">    Information describing the crime. </param>
        /// <returns>
        ///     The execute.
        /// </returns>
        Task< IEnumerable< ICrimeSumDisplayValue > > ExecuteAsync(
            IEnumerable< Crime > crimeData );

        #endregion
    }
}