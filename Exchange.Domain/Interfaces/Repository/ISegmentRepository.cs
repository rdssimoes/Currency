using Exchange.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Domain.Interfaces.Repository
{
    public interface ISegmentRepository : IRepository<Segment>
    {
        Task<List<Segment>> FindAll();
    }
}
