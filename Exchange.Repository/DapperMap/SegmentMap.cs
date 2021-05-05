using Dapper.FluentMap.Dommel.Mapping;
using Exchange.Domain.Entities;

namespace Exchange.Repository.DapperMap
{
    public class SegmentMap : DommelEntityMap<Segment>
    {
        public SegmentMap()
        {
            ToTable("Segment");

            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.IsValid).Ignore();
        }
    }
}
