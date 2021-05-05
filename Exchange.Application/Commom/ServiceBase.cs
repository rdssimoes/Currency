using Exchange.Domain;
using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces.Commom;
using Exchange.Domain.Interfaces.Repository;
using Exchange.Domain.Validation;
using System.Threading.Tasks;

namespace Exchange.Application.Commom
{
    public class ServiceBase<TEntity> : IServices<TEntity> where TEntity : EntityBase
    {
        #region [ Constructor ]

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        private readonly IRepository<TEntity> _repository;

        public virtual async Task<bool> Delete(long Id)
        {
            return await _repository.Delete(Id);
        }

        public virtual async Task<TEntity> Find(int Id)
        {
            return await _repository.Find(Id);
        }

        public virtual async Task<long> Insert(TEntity entity)
        {
            if (entity != null)
            {
                if (entity.Validate())
                {
                    return await _repository.Insert(entity);
                }
                else
                {
                    throw new ExchangeException(entity.Errors);
                }
            }
            else
            {
                throw new ExchangeException(new ExchangeExceptionType(ErrorCode.AWE003_ObjectIsNull, "Erro objeto nulo"));
            }
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            if (entity.Validate())
            {
                return await _repository.Update(entity);
            }
            else
            {
                throw new ExchangeException(entity.Errors);
            }
        }
    }
}
