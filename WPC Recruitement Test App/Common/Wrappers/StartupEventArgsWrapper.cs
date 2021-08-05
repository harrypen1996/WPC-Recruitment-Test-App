using System;
using System.Windows;
using JetBrains.Annotations;
using WPCRecruitmentTestApp.Core.Interfaces.Wrappers;

namespace WPCRecruitmentTestApp.Common.Wrappers
{
    /// <summary>
    ///     A startup event arguments wrapper.
    /// </summary>
    /// <seealso cref="T:ABD.aVDSRealtimeUtilityApp.Core.Interfaces.Wrappers.IStartupEventArgs"/>
    public class StartupEventArgsWrapper : IStartupEventArgs
    {
        #region Fields

        /// <summary>
        ///     Startup event information.
        /// </summary>
        private readonly StartupEventArgs _startupEventArgs;

        #endregion

        #region Properties and Indexers

        /// <inheritdoc/>
        public string[] Args => _startupEventArgs.Args;

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are null. </exception>
        /// <param name="startupEventArgs"> Startup event information. This cannot be null. </param>
        public StartupEventArgsWrapper(
            [NotNull] StartupEventArgs startupEventArgs )
        {
            _startupEventArgs = startupEventArgs ?? throw new ArgumentNullException( nameof(startupEventArgs) );
        }

        #endregion
    }
}