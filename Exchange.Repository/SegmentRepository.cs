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
    public class SegmentRepository : BaseRepository<Segment>, ISegmentRepository
    {
        #region [ Constructor ]

        public SegmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Segment>> FindAll()
        {
            using IDbConnection conn = Connection;
            var result = await conn.SelectAsync<Segment>(x => x.Id > 0);
            return result.ToList();
        }

        #endregion
    }
}
