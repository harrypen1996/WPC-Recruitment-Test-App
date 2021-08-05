using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PoliceUk;
using PoliceUk.Entities.StreetLevel;

namespace WPCRecruitmentTestApp.Core.Interfaces.Services
{
    /// <summary>
    ///     Interface for get crime data.
    /// </summary>
    public interface IGetCrimeData
    {
        #region Other Members

        /// <summary>
        ///     Executes the 'asynchronous' operation.
        /// </summary>
        /// <param name="geoPosition">  The geo position. This cannot be null. </param>
        /// <param name="dateTime">     The date time. </param>
        /// <returns>
        ///     The execute.
        /// </returns>
        Task< IEnumerable< Crime > > ExecuteAsync(
            [NotNull] IGeoposition geoPosition,
            DateTime dateTime );

        #endregion
    }
}