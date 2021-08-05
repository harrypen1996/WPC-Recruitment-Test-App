using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using JetBrains.Annotations;
using PoliceUk.Entities.StreetLevel;
using WPCRecruitmentTestApp.Core.Constants;
using WPCRecruitmentTestApp.Core.Interfaces.Entities;
using WPCRecruitmentTestApp.Core.Interfaces.Factories;
using WPCRecruitmentTestApp.Core.Interfaces.Services;
using WPCRecruitmentTestApp.Core.Interfaces.ViewModels;

namespace WPCRecruitmentTestApp.Common.ViewModels
{
    /// <summary>
    ///     A ViewModel for the shell.
    /// </summary>
    /// <seealso cref="ViewModelBase"/>
    /// <seealso cref="IShellViewModel"/>
    public class ShellViewModel : ViewModelBase, IShellViewModel
    {
        #region Fields

        /// <summary>
        ///     (Immutable) information describing the get crime.
        /// </summary>
        [NotNull] private readonly IGetCrimeData _getCrimeData;

        /// <summary>
        ///     (Immutable) the police uk factory.
        /// </summary>
        [NotNull] private readonly IPoliceUkFactory _policeUkFactory;

        /// <summary>
        ///     (Immutable) the crime last updated.
        /// </summary>
        [NotNull] private readonly ICrimeLastUpdated _crimeLastUpdated;

        /// <summary>
        ///     (Immutable) information describing the sum crime.
        /// </summary>
        [NotNull] private readonly ISumCrimeData _sumCrimeData;

        /// <summary>
        ///     (Immutable) the latest crime data date time.
        /// </summary>
        private DateTime _latestCrimeDataDateTime;

        #endregion

        #region Properties and Indexers

        /// <inheritdoc/>
        public double Longitude
        {
            get => GetValue< double >();
            set => SetValue( value, () => { IsSafeToSearch = ValidateInputs(); } );
        }

        /// <inheritdoc/>
        public bool IsSafeToSearch
        {
            get => GetValue< bool >();
            set => SetValue( value );
        }

        /// <inheritdoc/>
        public string WindowTitle => GeneralConstants.WindowName;

        /// <inheritdoc/>
        public double Latitude
        {
            get => GetValue< double >();
            set => SetValue( value, () => { IsSafeToSearch = ValidateInputs(); } );
        }

        /// <inheritdoc/>
        public ObservableCollection< Crime > CrimesCollection { get; set; }

        /// <inheritdoc/>
        public ObservableCollection< ICrimeSumDisplayValue > SumCrimeData { get; set; }

        /// <inheritdoc/>
        public DateTime SelectedDateTime
        {
            get => GetValue< DateTime >();
            set => SetValue( value, () => { IsSafeToSearch = ValidateInputs(); } );
        }

        /// <inheritdoc/>
        public bool IsInitialised { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are null. </exception>
        /// <param name="getCrimeData">     (Immutable) information describing the get crime. </param>
        /// <param name="policeUkFactory">  The police uk factory. This cannot be null. </param>
        /// <param name="crimeLastUpdated"> (Immutable) the crime last updated. </param>
        /// <param name="sumCrimeData">     Information describing the sum crime. This cannot be null. </param>
        public ShellViewModel(
            [NotNull] IGetCrimeData getCrimeData,
            [NotNull] IPoliceUkFactory policeUkFactory,
            [NotNull] ICrimeLastUpdated crimeLastUpdated,
            [NotNull] ISumCrimeData sumCrimeData )
        {
            _getCrimeData = getCrimeData ?? throw new ArgumentNullException( nameof(getCrimeData) );
            _policeUkFactory = policeUkFactory ?? throw new ArgumentNullException( nameof(policeUkFactory) );
            _crimeLastUpdated = crimeLastUpdated ?? throw new ArgumentNullException( nameof(crimeLastUpdated) );
            _sumCrimeData = sumCrimeData ?? throw new ArgumentNullException( nameof(sumCrimeData) );

            CrimesCollection = new ObservableCollection< Crime >();
            SumCrimeData = new ObservableCollection< ICrimeSumDisplayValue >();
        }

        #endregion

        #region Interface Implementations

        /// <inheritdoc/>
        [Command]
        public async void SearchForCrimesAsync()
        {
            var geoPosition = _policeUkFactory.CreateGeoPosition( Latitude, Longitude );

            var result = await _getCrimeData.ExecuteAsync( geoPosition, SelectedDateTime );

            ParseCrimeData( result );
        }

        /// <inheritdoc/>
        public void Initialise()
        {
            if ( IsInitialised ) return;

            Latitude = 51.5074; // some random initial start values
            Longitude = 0.1278; //          " "

            var crimeLastUpdatedTask = _crimeLastUpdated.ExecuteAsync();
            crimeLastUpdatedTask.Wait();

            _latestCrimeDataDateTime = crimeLastUpdatedTask.Result;
            SelectedDateTime = _latestCrimeDataDateTime;

            IsInitialised = true;
        }

        #endregion

        #region Other Members

        /// <summary>
        ///     Validates the time.
        /// </summary>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        private bool ValidateDateTime()
        {
            return SelectedDateTime <= _latestCrimeDataDateTime;
        }

        /// <summary>
        ///     Parse crime data.
        /// </summary>
        /// <param name="result">   The result. </param>
        private async void ParseCrimeData(
            [NotNull] IEnumerable< Crime > result )
        {
            if ( result == null ) throw new ArgumentNullException( nameof(result) );

            CrimesCollection.Clear();
            foreach ( var crime in result )
            {
                CrimesCollection.Add( crime );
            }

            SumCrimeData.Clear();

            var sumCrimeData = await _sumCrimeData.ExecuteAsync( result );
            foreach ( var displayValue in sumCrimeData )
            {
                SumCrimeData.Add( displayValue );
            }
        }

        /// <summary>
        ///     Validates the inputs.
        /// </summary>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        private bool ValidateInputs()
        {
            var isValid = ValidateDateTime()
                          && ValidateLatitude()
                          && ValidateLongitude();
            return isValid;
        }

        /// <summary>
        ///     Validates the latitude.
        /// </summary>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        private bool ValidateLatitude()
        {
            return Latitude > GeneralConstants.MinLatitude && Latitude < GeneralConstants.MaxLatitude;
        }

        /// <summary>
        ///     Validates the longitude.
        /// </summary>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        private bool ValidateLongitude()
        {
            return Longitude > GeneralConstants.MinLongitude && Longitude < GeneralConstants.MaxLongitude;
        }

        #endregion
    }
}