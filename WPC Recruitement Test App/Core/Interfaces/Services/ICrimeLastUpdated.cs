using System;
using System.Threading.Tasks;

namespace WPCRecruitmentTestApp.Core.Interfaces.Services
{
    /// <summary>
    ///     Interface for crime last updated.
    /// </summary>
    public interface ICrimeLastUpdated
    {
        /// <summary>
        ///     Executes the 'asynchronous' operation.
        /// </summary>
        /// <returns>
        ///     A task for latest available crime data.
        /// </returns>
        Task< DateTime > ExecuteAsync();
    }
}