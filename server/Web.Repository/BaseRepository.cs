using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web.Repository.Interfaces;

namespace Web.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private EntityEntry<TEntity> NewMethod(TEntity model)
        {
            return _context.Entry(model);
        }


        #region methods

        public List<TEntity> GetAll()
        {
            try
            {
                return DbSet.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity Create(TEntity model)
        {
            try
            {
                DbSet.Add(model);
                Save();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(TEntity model)
        {
            try
            {
                EntityEntry<TEntity> entry = NewMethod(model);

                DbSet.Attach(model);

                entry.State = EntityState.Modified;

                return Save() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(TEntity model)
        {
            try
            {
                DbSet.Remove(model);
                Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity? Find(params object[] Keys)
        {
            try
            {
                return DbSet.Find(Keys);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity? Find(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(where);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public void Dispose()
        {
            try
            {
                if (_context != null)
                    _context.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
