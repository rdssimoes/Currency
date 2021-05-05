using Dapper.Contrib.Extensions;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace Exchange.Repository.DapperMap
{
    public static class DapperMap
    {
        public static void RegisterDapperMapper()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new SegmentMap());
                config.AddMap(new CountryMap());

                config.ForDommel();
            });

            SqlMapperExtensions.TableNameMapper = (type) =>
            {
                // do something here to pluralize the name of the type
                return type.Name;
            };
        }

    }
}
