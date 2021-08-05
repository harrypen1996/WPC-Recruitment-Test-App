using System;
using System.Diagnostics.CodeAnalysis;
using Ninject.MockingKernel.NSubstitute;

namespace Unit_Tests
{
    /// <summary>
    ///     A mocking kernel extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class MockingKernelExtensions
    {
        #region Other Members

        /// <summary>
        ///     A NSubstituteMockingKernel extension method that rebind to null.
        /// </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are null. </exception>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="mockingKernel">    The mockingKernel to act on. </param>
        /// <param name="type">             The type. This cannot be null. </param>
        public static void RebindToNull< T >(
            this NSubstituteMockingKernel mockingKernel,
            [NotNull] T type ) where T : Type
        {
            if ( type is null )
            {
                throw new ArgumentNullException( nameof(type) );
            }

            // ReSharper disable once AssignNullToNotNullAttribute
            mockingKernel
                .Rebind( type )
                .ToConstant( (object) null );
        }

        #endregion Other Members
    }
}