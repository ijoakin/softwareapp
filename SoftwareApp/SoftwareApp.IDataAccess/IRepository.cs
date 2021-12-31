using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareApp.IDataAccess
{
    public interface IRepository<TEntity>
    {
        IList<TEntity> GetAll();

        bool Insert(TEntity entity);
        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        IQueryable<TEntity> GetQuery();

        Task<IQueryable<TEntity>> GetQueryAsync();

        Task<IList<TEntity>> GetAllAsync();

        bool Save(TEntity product);
        Task<bool> SaveAsync(TEntity entity);

        bool Delete(int id);

        Task<bool> DeleteAsync(int id);
    }

}
