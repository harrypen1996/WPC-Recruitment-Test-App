using WPCRecruitmentTestApp.Core.Interfaces.Entities;

namespace WPCRecruitmentTestApp.Common.Entities
{
    /// <summary>
    ///     A crime sum display value entity.
    /// </summary>
    /// <seealso cref="ICrimeSumDisplayValue"/>
    public class CrimeSumDisplayValueEntity : ICrimeSumDisplayValue
    {
        #region Properties and Indexers

        /// <inheritdoc/>
        public string CrimeCategory { get; set; }

        /// <inheritdoc/>
        public int SumTotal { get; set; }

        #endregion
    }
}