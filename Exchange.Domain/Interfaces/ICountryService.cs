using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces.Commom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Domain.Interfaces
{
    public interface ICountryService : IServices<Country>
    {
        Task<List<Country>> FindAll();
    }
}