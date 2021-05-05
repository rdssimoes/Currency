using Exchange.Domain.Entities;
using System.Threading.Tasks;

namespace Exchange.Domain.Interfaces
{
    public interface IRateService
    {
        Task<Rate> Convert(Rate rat, ISegmentService segmentService);
    }
}