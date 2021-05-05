using Exchange.Application.Commom;
using Exchange.Domain;
using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces;
using Exchange.Domain.Interfaces.Repository;
using Exchange.Domain.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Application
{
    public class SegmentService : ServiceBase<Segment>, ISegmentService
    {
        #region [ Constructor ]

        public SegmentService(ISegmentRepository repository) : base(repository)
        {
            _segmentRepository = repository;
        }

        #endregion

        #region [ Members ]

        private readonly ISegmentRepository _segmentRepository;

        #endregion

        #region [ Methods ]

        public async Task<List<Segment>> FindAll()
        {
            var segments = await _segmentRepository.FindAll();

            return segments;
        }

        public async override Task<long> Insert(Segment entity)
        {
            if (entity != null)
            {
                if (entity.Validate())
                {

                    return await base.Insert(entity);

                }
                else
                {
                    throw new ExchangeException(entity.Errors);
                }
            }
            else
            {
                throw new ExchangeException(new ExchangeExceptionType(ErrorCode.AWE003_ObjectIsNull, "Objeto nulo"));
            }
        }


        public async override Task<bool> Update(Segment entity)
        {
            if (entity != null)
            {
                if (entity.Validate())
                {
                    var segment = await Find(entity.Id);
                    if (segment != null)
                    {
                        segment.Rate = entity.Rate;
                        return await base.Update(segment);
                    }
                    else
                    {
                        throw new ExchangeException(new ExchangeExceptionType(ErrorCode.AWE001_FieldIsEmpty, "Objeto não encontrado"));
                    }
                }
                else
                {
                    throw new ExchangeException(entity.Errors);
                }
            }
            else
            {
                throw new ExchangeException(new ExchangeExceptionType(ErrorCode.AWE003_ObjectIsNull, "objeto nulo"));
            }
        }

        public async Task<decimal> GetSegmentRate(int id)
        {
            Segment segment = await _segmentRepository.Find(id);

            return segment.Rate;
        }

        #endregion
    }
}
