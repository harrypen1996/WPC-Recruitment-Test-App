namespace WPCRecruitmentTestApp.Core.Interfaces.Entities
{
    /// <summary>
    ///     Interface for crime sum display value.
    /// </summary>
    public interface ICrimeSumDisplayValue
    {
        #region Properties and Indexers

        /// <summary>
        ///     Gets or sets the category the crime belongs to.
        /// </summary>
        /// <value>
        ///     The crime category.
        /// </value>
        string CrimeCategory { get; set; }

        /// <summary>
        ///     Gets or sets the sum total.
        /// </summary>
        /// <value>
        ///     The total number of total.
        /// </value>
        int SumTotal { get; set; }

        #endregion
    }
}