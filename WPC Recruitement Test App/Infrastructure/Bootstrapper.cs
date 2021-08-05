using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Ninject;
using Ninject.Extensions.Conventions;
using WPCRecruitmentTestApp.Common.Views;
using WPCRecruitmentTestApp.Core.Interfaces.ViewModels;

namespace WPCRecruitmentTestApp.Infrastructure
{
    /// <summary>
    ///     Application Bootstrapper.
    /// </summary>
    /// <seealso cref="T:System.IDisposable"/>
    [ExcludeFromCodeCoverage]
    public class Bootstrapper : IDisposable
    {
        #region Static and constant fields
        
        /// <summary>
        ///     The assembly prefix.
        /// </summary>
        private static readonly string[] AssemblyPrefix = new[]
        {
            "System*",
            "WPCRecruitmentTestApp*",
            "PoliceUK*",
        };

        #endregion

        #region Fields

        /// <summary>
        ///     The kernel.
        /// </summary>
        private readonly IKernel _kernel;

        /// <summary>
        ///     The transients.
        /// </summary>
        private readonly IList< string > _transients;

        /// <summary>
        ///     The singletons.
        /// </summary>
        private readonly IList< string > _singletons;

        #endregion

        #region Properties and Indexers

        /// <summary>
        ///     Gets or sets the startup event arguments.
        /// </summary>
        /// <value>
        ///     The startup event arguments.
        /// </value>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public static StartupEventArgs StartupEventArgs { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="e">    Startup event information. </param>
        public Bootstrapper(
            StartupEventArgs e )
        {
            _transients = new List< string >
            {
                "Client",
                "Entity",
                "Facade",
                "Formatter",
                "Handler",
                "Model",
                "Geoposition",
                "Service",
                "View",
                "Wrapper",
            };

            _singletons = new List< string >
            {
                "Singleton",
            };

            StartupEventArgs = e;

            _kernel = new StandardKernel();

            _kernel.Bind(
                x => x
                    .FromAssembliesMatching( AssemblyPrefix )
                    .SelectAllInterfaces()
                    .EndingWith( "Factory" )
                    .BindToFactory()
            );

            ConfigureKernel();
        }

        #endregion

        #region Interface Implementations

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        #endregion

        #region Other Members

        /// <summary>
        ///     Releases the unmanaged resources used by the ABD.aVDSController.Common.Validators.PlatformSafetySystemNotSetValidator and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">    True to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected virtual void Dispose(
            bool disposing )
        {
            if ( disposing )
            {
                _kernel?.Dispose();
            }
        }

        /// <summary>
        ///     Configure the kernel.
        /// </summary>
        private void ConfigureKernel()
        {
            try
            {
                _kernel.Bind(
                    x =>
                    {
                        x.FromAssembliesMatching( AssemblyPrefix )
                            .Select( FilterSingletons )
                            .BindAllInterfaces()
                            .Configure( b => b.InSingletonScope() );
                    } );

                _kernel.Bind(
                    x => x.FromAssembliesMatching( AssemblyPrefix )
                        .Select( FilterTransients )
                        .BindAllInterfaces()
                        .Configure( b => b.InTransientScope() ) );

                _kernel.Bind(
                    x => x.FromAssembliesMatching( AssemblyPrefix )
                        .SelectAllClasses()
                        .EndingWith( "Threaded" )
                        .BindAllInterfaces()
                        .Configure( b => b.InThreadScope() ) );
            }
            catch ( Exception )
            {
                Environment.Exit( 1 );
            }
        }

        /// <summary>
        ///     Filter transients.
        /// </summary>
        /// <param name="arg">  The argument. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        private bool FilterTransients(
            Type arg )
        {
            var result = false;

            foreach ( var transient in _transients )
            {
                result = result || arg.IsClass && arg.Name
                             .EndsWith( transient );
            }

            return result;
        }

        /// <summary>
        ///     Filter singletons.
        /// </summary>
        /// <param name="arg">  The argument. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        private bool FilterSingletons(
            Type arg )
        {
            var result = false;

            foreach ( var singleton in _singletons )
            {
                result = result || arg.IsClass && arg.Name
                             .EndsWith( singleton );
            }

            return result;
        }

        /// <summary>
        ///     Runs the given application.
        /// </summary>
        /// <param name="app">  The application. </param>
        public void Run(
            App app )
        {
            try
            {
                var shellViewModel = _kernel.Get< IShellViewModel >();
                var shellView = _kernel.Get< ShellView >();
                shellView.DataContext = shellViewModel;

                app.MainWindow = shellView;

                app.MainWindow.Show();
                app.MainWindow.Activate();
            }
            catch ( Exception )
            {
                Environment.Exit( 1 );
            }
        }

        #endregion
    }
}