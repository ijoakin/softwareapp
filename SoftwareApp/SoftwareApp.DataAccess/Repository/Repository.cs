using Microsoft.EntityFrameworkCore;
using SoftwareApp.Entities;
using SoftwareApp.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareApp.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private DbContext context;
        private DbSet<TEntity> DbSet;

        public Repository(SoftwareDBContext _context)
        {
            context = _context;
            this.DbSet = this.context.Set<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            IQueryable<TEntity> query = this.DbSet;
            return query.ToList();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = this.DbSet;
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            IQueryable<TEntity> query = this.DbSet;
            return await query.Where(x=>x.id == id).FirstOrDefaultAsync();
        }        

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await this.GetByIdAsync(id);
                if (entity != null)
                {
                    this.DbSet.Remove(entity);
                    this.context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TEntity GetById(int id)
        {
            IQueryable<TEntity> query = this.DbSet;
            return query.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<TEntity> GetQuery()
        {
            IQueryable<TEntity> query = this.DbSet;
            return query;
        }

        public async Task<IQueryable<TEntity>> GetQueryAsync()
        {
            var query = await this.DbSet.ToListAsync();
            return query.AsQueryable();
        }

        public bool Insert(TEntity entity)
        {
            try
            {
                this.DbSet.Add(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = this.GetById(id);
                this.DbSet.Remove(entity);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Save(TEntity entity)
        {
            try
            {
                if (entity.id != 0)
                {
                    //this.context.Entry(entity).State = EntityState.Detached;
                    //var e = this.DbSet.Where(x => x.Id == entity.Id).FirstOrDefault();
                    this.DbSet.Update(entity);
                }
                else
                    this.DbSet.Add(entity);

                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public async Task<bool> SaveAsync(TEntity entity)
        {
            try
            {
                if (entity.id != 0)
                {
                    //this.context.Entry(entity).State = EntityState.Detached;
                    //var e = this.DbSet.Where(x => x.Id == entity.Id).FirstOrDefault();
                    this.DbSet.Update(entity);
                }
                else
                    this.DbSet.Add(entity);

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
