using Dommel;
using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        #region [ Constructor ]

        public CountryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Country>> FindAll()
        {
            using IDbConnection conn = Connection;
            var result = await conn.SelectAsync<Country>(x => x.Currency != "");
            return result.ToList();
        }

        #endregion
    }
}
