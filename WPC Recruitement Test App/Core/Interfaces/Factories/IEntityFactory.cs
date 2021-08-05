using WPCRecruitmentTestApp.Core.Interfaces.Entities;

namespace WPCRecruitmentTestApp.Core.Interfaces.Factories
{
    /// <summary>
    ///     Interface for entity factory.
    /// </summary>
    public interface IEntityFactory
    {
        #region Other Members

        /// <summary>
        ///     Creates crime sum display value entity.
        /// </summary>
        /// <returns>
        ///     The new crime sum display value entity.
        /// </returns>
        ICrimeSumDisplayValue CreateCrimeSumDisplayValueEntity();

        #endregion
    }
}