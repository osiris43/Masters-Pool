using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace MastersPool.Data.Interfaces
{
    public interface ISessionRepository
    {
        void SubmitChanges();
        void Save<TEntity>(TEntity entity) where TEntity : class;
        TEntity SelectSingle<TEntity>(Func<TEntity, bool> criteria) where TEntity : class;
        List<TEntity> Select<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        List<TEntity> Select<TEntity>() where TEntity : class;
    }
}
