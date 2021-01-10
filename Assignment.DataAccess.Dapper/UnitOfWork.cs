﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Core.Data;
using Dapper;

namespace DataAccess.Dapper
{
    public abstract class UnitOfWork : IUnitOfWorkAsync
    {
        private IConnectionFactory connectionFactory;

        protected Dictionary<string, dynamic> Repositories;

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
            Repositories = new Dictionary<string, dynamic>();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (Repositories == null)
            {
                Repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;

            if (Repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>)Repositories[type];
            }

            // TODO: Please check this. This might be implemented via DI.
            var repositoryType = typeof(Repository<>);
            Repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), this.connectionFactory));
            return Repositories[type];
        }

        public object GetDataBySql(string sql)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                object result = connection.ExecuteScalar(sql);
                return result;
            }
        }

        public object GetEntitiesBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (KeyValuePair<string, Tuple<string, DbType, ParameterDirection>> entry in parameters)
            {
                dynamicParameters.Add(entry.Key, entry.Value.Item1, entry.Value.Item2, entry.Value.Item3);
            }

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();

                var result = connection.ExecuteReader(
                    storedProcedureName,
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                while (result.Read())
                {
                    return result[0];
                }

                return null;
            }
        }

        public int GetStatusByExecuteSP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (KeyValuePair<string, Tuple<string, DbType, ParameterDirection>> entry in parameters)
            {
                dynamicParameters.Add(entry.Key, entry.Value.Item1, entry.Value.Item2, entry.Value.Item3);
            }

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();

                var result = connection.ExecuteReader(
                    storedProcedureName,
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                while (result.Read())
                {
                    return (int)result[0];
                }

                return -1;
            }
        }

    }
}
