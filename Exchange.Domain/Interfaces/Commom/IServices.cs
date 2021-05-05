using System.Threading.Tasks;

namespace Exchange.Domain.Interfaces.Commom
{
    public interface IServices<TEntity> where TEntity : class
    {
        Task<TEntity> Find(int id);
        Task<long> Insert(TEntity entity);
        Task<bool> Delete(long id);
        Task<bool> Update(TEntity entity);
    }
}
