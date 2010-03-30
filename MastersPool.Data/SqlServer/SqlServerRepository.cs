using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MastersPool.Data.Interfaces;
using System.Linq.Expressions;

namespace MastersPool.Data.SqlServer
{
    public class SqlSessionRepository : ISessionRepository
    {
        public SqlSessionRepository(string connection)
        {
            this.database = new Database(connection);
        }
        void ISessionRepository.Save<TEntity>(TEntity entity)
        {
            this.database.GetTable<TEntity>().InsertOnSubmit(entity);
        }

        void ISessionRepository.SubmitChanges()
        {
            this.database.SubmitChanges();
        }

        TEntity ISessionRepository.SelectSingle<TEntity>(Func<TEntity, bool> criteria)
        {
            return this.database.GetTable<TEntity>().FirstOrDefault(criteria);
        }

        List<TEntity> ISessionRepository.Select<TEntity>()
        {
            return this.database.GetTable<TEntity>().Where(o => true).ToList();
        }

        List<TEntity> ISessionRepository.Select<TEntity>(Expression<Func<TEntity, bool>> criteria)
        {
            return this.database.GetTable<TEntity>().Where(criteria).ToList();
        }

        Database database = null;
    }
}
