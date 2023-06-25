using System.Linq.Expressions;

namespace Web.Repository.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        TEntity Create(TEntity model);

        bool Edit(TEntity model);

        void Delete(TEntity model);

        int Save();

        TEntity? Find(params object[] Keys);

        TEntity? Find(Expression<Func<TEntity, bool>> where);

        List<TEntity> GetAll();

    }
}
