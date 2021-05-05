using Exchange.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Domain.Interfaces.Repository
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<List<Country>> FindAll();
    }
}
