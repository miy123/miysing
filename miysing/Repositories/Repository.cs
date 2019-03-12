using Microsoft.EntityFrameworkCore;
using miysing.Models;
using miysing.Repositories.Interface;
using miysing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eip.Models.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public event OnDbChange DbChangeHandle;
        protected readonly MiySongDbContext Context;
        private readonly DbSet<TEntity> _entities;

        public Repository(MiySongDbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAllList()
        {
            return _entities.ToList();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public Result Add(TEntity entity)
        {
            var result = new Result(false);
            if (entity == null)
                return result;

            _entities.Add(entity);
            if (SaveChangeLogs().Success)
                result.Message = "新增成功";
            else
                result.Message = "新增失敗";
            return result;
        }

        public Result AddRange(IEnumerable<TEntity> entities)
        {
            var result = new Result(false);
            if (entities == null)
                return result;

            _entities.AddRange(entities);
            if (SaveChangeLogs().Success)
                result.Message = "新增成功";
            else
                result.Message = "新增失敗";
            return result;
        }

        public Result Remove(TEntity entity)
        {
            var result = new Result(false);
            if (entity == null)
                return result;

            _entities.Remove(entity);
            if (SaveChangeLogs().Success)
                result.Message = "刪除成功";
            else
                result.Message = "刪除失敗";
            return result;
        }

        public Result RemoveRange(IEnumerable<TEntity> entities)
        {
            var result = new Result(false);
            if (entities == null)
                return result;

            _entities.RemoveRange(entities);
            if (SaveChangeLogs().Success)
                result.Message = "刪除成功";
            else
                result.Message = "刪除失敗";
            return result;
        }

        public Result Update(TEntity entities)
        {
            Result result = new Result(false);
            if (entities == null)
                return result;

            Context.Entry(entities).State = EntityState.Modified;
            if (SaveChangeLogs().Success)
                result.Message = "編輯成功";
            else
                result.Message = "編輯失敗";
            return result;
        }

        protected Result SaveChangeLogs()
        {
            Result result = new Result(false);
            try
            {
                Context.SaveChanges();
                result.Success = true;
                DbChangeHandle?.Invoke(this, null);
            }
            catch (Exception ex)
            {
                result.ExceptionString = ex.Message;
                result.Exception = ex;
            }
            return result;
        }
    }
}
