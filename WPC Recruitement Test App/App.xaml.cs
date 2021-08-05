using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WPCRecruitmentTestApp.Infrastructure;

namespace WPCRecruitmentTestApp
{
    /// <summary>
    ///     Interaction logic for App.xaml.
    /// </summary>
    /// <seealso cref="T:System.Windows.Application"/>
    /// <seealso cref="T:System.IDisposable"/>
    [ExcludeFromCodeCoverage]
    public partial class App : IDisposable
    {
        #region Fields

        /// <summary>
        ///     The bootstrapper.
        /// </summary>
        private Bootstrapper _bootstrapper;

        #endregion

        #region Other Members

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        ///     Raises the unobserved task exception event.
        /// </summary>
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        private void OnTaskSchedulerUnobservedTaskException(
            object sender,
            UnobservedTaskExceptionEventArgs e )
        {
            ReportUnhandledException( "TaskScheduler", e.Exception );
        }

        /// <summary>
        ///     Raises the unhandled exception event.
        /// </summary>
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        private void OnAppDomainUnhandledException(
            object sender,
            UnhandledExceptionEventArgs e )
        {
            ReportUnhandledException( "AppDomain", e.ExceptionObject as Exception );
        }

        /// <summary>
        ///     Raises the dispatcher unhandled exception event.
        /// </summary>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        private void OnDispatcherUnhandledException(
            object sender,
            DispatcherUnhandledExceptionEventArgs e )
        {
            ReportUnhandledException( "Dispatcher", e.Exception );
        }

        /// <inheritdoc/>
        protected override void OnStartup(
            StartupEventArgs e )
        {
            base.OnStartup( e );

            if ( Dispatcher != null )
            {
                Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            }

            AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;
            TaskScheduler.UnobservedTaskException += OnTaskSchedulerUnobservedTaskException;

            _bootstrapper = new Bootstrapper( e );
            _bootstrapper.Run( this );
        }

        /// <inheritdoc/>
        protected override void OnExit(
            ExitEventArgs e )
        {
            base.OnExit( e );
            _bootstrapper.Dispose();
        }

        /// <summary>
        ///     Reports unhandled exception.
        /// </summary>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /// <param name="source">       Source for the. </param>
        /// <param name="exception">    The exception. </param>
        private void ReportUnhandledException(
            string source,
            Exception exception )
        {
            Environment.Exit( 1 );
        }

        /// <summary>
        ///     Releases the unmanaged resources used by the ABD.aVDSController.Shell.Infrastructure.App and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">    True to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected virtual void Dispose(
            bool disposing )
        {
            if ( disposing )
            {
                _bootstrapper?.Dispose();
            }
        }

        #endregion
    }
}