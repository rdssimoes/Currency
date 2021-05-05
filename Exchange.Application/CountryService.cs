using Exchange.Application.Commom;
using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces;
using Exchange.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Application
{
    public class CountryService : ServiceBase<Country>, ICountryService
    {
        #region [ Constructor ]

        public CountryService(ICountryRepository repository) : base(repository)
        {
            _countryRepository = repository;
        }

        #endregion

        #region [ Members ]

        private readonly ICountryRepository _countryRepository;

        #endregion

        #region [ Methods ]

        public async Task<List<Country>> FindAll()
        {
            var accounts = await _countryRepository.FindAll();

            return accounts;
        }

        #endregion
    }
}
