namespace WPCRecruitmentTestApp.Core.Interfaces.Wrappers
{
    /// <summary>
    ///     Interface for startup event arguments.
    /// </summary>
    public interface IStartupEventArgs
    {
        #region Properties and Indexers

        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        string[] Args { get; }

        #endregion
    }
}