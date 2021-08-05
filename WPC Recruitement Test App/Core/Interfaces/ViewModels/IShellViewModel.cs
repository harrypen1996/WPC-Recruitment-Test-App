using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PoliceUk.Entities.StreetLevel;
using WPCRecruitmentTestApp.Core.Interfaces.Entities;

namespace WPCRecruitmentTestApp.Core.Interfaces.ViewModels
{
    /// <summary>
    ///     Interface for shell view model.
    /// </summary>
    public interface IShellViewModel
    {
        #region Properties and Indexers

        /// <summary>
        ///     Gets the window title.
        /// </summary>
        /// <value>
        ///     The window title.
        /// </value>
        string WindowTitle { get; }

        /// <summary>
        ///     Gets the latitude.
        /// </summary>
        /// <value>
        ///     The latitude.
        /// </value>
        double Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude.
        /// </summary>
        /// <value>
        ///     The longitude.
        /// </value>
        double Longitude { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this object is safe to search.
        /// </summary>
        /// <value>
        ///     True if this object is safe to search, false if not.
        /// </value>
        bool IsSafeToSearch { get; }

        /// <summary>
        ///     Gets a collection of crimes.
        /// </summary>
        /// <value>
        ///     A collection of crimes.
        /// </value>
        ObservableCollection< Crime > CrimesCollection { get; }

        /// <summary>
        ///     Gets information describing the sum crime.
        /// </summary>
        /// <value>
        ///     The total number of crime data.
        /// </value>
        ObservableCollection< ICrimeSumDisplayValue > SumCrimeData { get; }

        /// <summary>
        ///     Gets or sets the selected date time.
        /// </summary>
        /// <value>
        ///     The selected date time.
        /// </value>
        DateTime SelectedDateTime { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this object is initialised.
        /// </summary>
        /// <value>
        ///     True if this object is initialised, false if not.
        /// </value>
        bool IsInitialised { get; }

        #endregion

        #region Other Members

        /// <summary>
        ///     Searches for the first crimes asynchronous.
        /// </summary>
        void SearchForCrimesAsync();

        /// <summary>
        ///     Initialises this object.
        /// </summary>
        void Initialise();

        #endregion
    }
}