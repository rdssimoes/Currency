using Dapper.FluentMap.Dommel.Mapping;
using Exchange.Domain.Entities;

namespace Exchange.Repository.DapperMap
{
    public class CountryMap : DommelEntityMap<Country>
    {
        public CountryMap()
        {
            ToTable("Country");

            Map(x => x.IsValid).Ignore();
        }
    }
}
