using System;
using System.Collections.Generic;
using System.Data;

namespace Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Get(string id);

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        long Insert(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

        IEnumerable<TEntity> GetEntitiesBySP(string storedProcedureName,
            Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);

        TEntity GetEntityBySP(string storedProcedureName,
            Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);

        IEnumerable<TEntity> GetEntitiesBySql(string sql);
    }
}