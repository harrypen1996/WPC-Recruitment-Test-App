using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Ninject;
using Ninject.MockingKernel.NSubstitute;
using NUnit.Framework;

namespace Unit_Tests
{
    /// <summary>
    ///     A base unit test context of type T.
    /// </summary>
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    /// <seealso cref="T:BaseUnitTests.BaseUnitTestContext"/>
    [ExcludeFromCodeCoverage]
    public abstract class BaseUnitTestContext< T > : BaseUnitTestContext
    {
        #region Fields

        /// <summary>
        ///     The sut.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected T SUT;

        /// <summary>
        ///     The failed constructor sut.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected T FailedConstructorSUT;

        #endregion
    }

    /// <summary>
    ///     A base unit test context.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class BaseUnitTestContext
    {
        #region Static and constant fields

        /// <summary>
        ///     The integration.
        /// </summary>
        protected const string Integration = "Integration";

        /// <summary>
        ///     The view models.
        /// </summary>
        protected const string ViewModels = "ViewModels";

        /// <summary>
        ///     The services.
        /// </summary>
        protected const string Services = "Services";

        #endregion

        #region Fields

        /// <summary>
        ///     The mocking kernel.
        /// </summary>
        protected NSubstituteMockingKernel MockingKernel;

        #endregion

        #region Properties and Indexers

        /// <summary>
        ///     Gets the get disposable stub class.
        /// </summary>
        ///
        /// <value>
        ///     The get disposable stub class.
        /// </value>
        protected DisposableStubClass GetDisposableStubClass => new DisposableStubClass();

        #endregion

        #region Other Members

        /// <summary>
        ///     Sets up the test.
        /// </summary>
        [SetUp]
        [DebuggerStepThrough]
        public void SetUp()
        {
            MockingKernel = new NSubstituteMockingKernel(
                new NinjectSettings
                {
                    AllowNullInjection = true,
                    LoadExtensions = false
                } );
            SetContext();
            Because();
        }

        /// <summary>
        ///     Tear down this test instance.
        /// </summary>
        [TearDown]
        [DebuggerStepThrough]
        public void Teardown()
        {
            Cleanup();
        }

        /// <summary>
        ///     Determine the 'because' clause.
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void Because() { }

        /// <summary>
        ///     Cleanup this test instance.
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void Cleanup() { }

        /// <summary>
        ///     Sets the test context.
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void SetContext() { }

        #endregion

        /// <summary>
        ///     A disposable stub class.
        /// </summary>
        ///
        /// <seealso cref="T:System.IDisposable"/>
        protected class DisposableStubClass : IDisposable
        {
            #region Interface Implementations

            /// <inheritdoc/>
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}