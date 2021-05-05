using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces.Commom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Domain.Interfaces
{
    public interface ISegmentService : IServices<Segment>
    {
        Task<List<Segment>> FindAll();

        Task<decimal> GetSegmentRate(int id);
    }
}
