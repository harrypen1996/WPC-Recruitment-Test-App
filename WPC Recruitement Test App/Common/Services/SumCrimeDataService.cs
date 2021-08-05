using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Ninject.Infrastructure.Language;
using PoliceUk.Entities.StreetLevel;
using WPCRecruitmentTestApp.Core.Interfaces.Entities;
using WPCRecruitmentTestApp.Core.Interfaces.Factories;
using WPCRecruitmentTestApp.Core.Interfaces.Services;

namespace WPCRecruitmentTestApp.Common.Services
{
    /// <summary>
    ///     A service for accessing sum crime data information.
    /// </summary>
    /// <seealso cref="ISumCrimeData"/>
    public class SumCrimeDataService : ISumCrimeData
    {
        #region Fields

        /// <summary>
        ///     (Immutable) the entity factory.
        /// </summary>
        [NotNull] private readonly IEntityFactory _entityFactory;

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are null. </exception>
        /// <param name="entityFactory">    (Immutable) the entity factory. </param>
        public SumCrimeDataService(
            [NotNull] IEntityFactory entityFactory )
        {
            _entityFactory = entityFactory ?? throw new ArgumentNullException( nameof(entityFactory) );
        }

        #endregion

        #region Interface Implementations

        /// <inheritdoc/>
        public Task< IEnumerable< ICrimeSumDisplayValue > > ExecuteAsync(
            IEnumerable< Crime > crimeData )
        {
            return Task.Run(
                () =>
                {
                    var categoryDictionary = new Dictionary< string, ICrimeSumDisplayValue >();

                    foreach ( var crime in crimeData )
                    {
                        var success = categoryDictionary.TryAdd( crime.Category, null );

                        if ( success )
                        {
                            var entity = _entityFactory.CreateCrimeSumDisplayValueEntity();
                            entity.CrimeCategory = crime.Category;

                            categoryDictionary[ crime.Category ] = entity;
                        }

                        categoryDictionary[ crime.Category ]
                            .SumTotal += 1;
                    }

                    var resultList = categoryDictionary.Values.ToEnumerable();

                    return resultList;
                } );
        }

        #endregion
    }
}