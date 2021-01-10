using Core.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DataAccess.Dapper
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IConnectionFactory connectionFactory;

        public Repository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
         
        }

        public TEntity Get(string id)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                return connection.Get<TEntity>(id);
            }
        }

        public TEntity Get(int id)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                return connection.Get<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                return connection.GetAll<TEntity>();
            }
        }

        public long Insert(TEntity entity)
        {
            long identity;

            //using (var transaction = new TransactionScope())
            //{
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                identity = connection.Insert(entity);
            }

            //transaction.Complete();
            return identity;
            //}
        }

        public bool Update(TEntity entity)
        {
            bool isSuccess;

            //using (var transaction = new TransactionScope())
            //{
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                isSuccess = connection.Update(entity);
            }

            //transaction.Complete();
            return isSuccess;
            //}
        }

        public bool Delete(TEntity entity)
        {
            bool isSuccess;

            using (var transaction = new TransactionScope())
            {
                using (var connection = connectionFactory.GetConnection())
                {
                    connection.Open();
                    isSuccess = connection.Delete(entity);
                }

                transaction.Complete();
                return isSuccess;
            }
        }

        public int ExecuteSP(string storedProcedureName, DynamicParameters parameters)
        {
            int affectedRows;
            using (var transaction = new TransactionScope())
            {
                using (var connection = connectionFactory.GetConnection())
                {
                    connection.Open();
                    affectedRows = connection.Execute(
                            storedProcedureName,
                            param: parameters,
                            commandType: CommandType.StoredProcedure);
                }

                transaction.Complete();
                return affectedRows;
            }
        }

        public int ExecuteSql(string sql, DynamicParameters parameters)
        {
            int affectedRows;
            using (var transaction = new TransactionScope())
            {
                using (var connection = connectionFactory.GetConnection())
                {
                    connection.Open();
                    affectedRows = connection.Execute(
                            sql,
                            param: parameters,
                            commandType: CommandType.Text);
                }

                transaction.Complete();
                return affectedRows;
            }
        }

        public IEnumerable<dynamic> QueryBySP(string storedProcedureName, DynamicParameters parameters)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                IEnumerable<dynamic> result = connection.Query(
                        storedProcedureName,
                        param: parameters,
                        commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<dynamic> QueryBySql(string sql, DynamicParameters parameters)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                IEnumerable<dynamic> result = connection.Query(
                        sql,
                        param: parameters,
                        commandType: CommandType.Text);

                return result;
            }
        }

        public IEnumerable<TEntity> GetEntitiesBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (KeyValuePair<string, Tuple<string, DbType, ParameterDirection>> entry in parameters)
            {
                if (entry.Value.Item2 == DbType.Guid)
                {
                    Guid guid = new Guid(entry.Value.Item1);
                    dynamicParameters.Add(entry.Key, guid, DbType.Guid, entry.Value.Item3);
                }
                else
                {
                    dynamicParameters.Add(entry.Key, entry.Value.Item1, entry.Value.Item2, entry.Value.Item3);
                }
            }

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();

                IEnumerable<TEntity> result = connection.Query<TEntity>(
                                        storedProcedureName,
                                        param: dynamicParameters,
                                        commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<TEntity> GetEntitiesBySql(string sql, DynamicParameters parameters)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                IEnumerable<TEntity> result = connection.Query<TEntity>(
                        sql,
                        param: parameters,
                        commandType: CommandType.Text);

                return result;
            }
        }

        public IEnumerable<TEntity> GetEntitiesBySql(string sql)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                IEnumerable<TEntity> result = connection.Query<TEntity>(
                    sql,
                    commandType: CommandType.Text);

                return result;
            }
        }

        public TEntity GetEntityBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (KeyValuePair<string, Tuple<string, DbType, ParameterDirection>> entry in parameters)
            {
                if (entry.Value.Item2 == DbType.Guid)
                {
                    Guid guid = new Guid(entry.Value.Item1);
                    dynamicParameters.Add(entry.Key, guid, DbType.Guid, entry.Value.Item3);
                }
                else
                {
                    dynamicParameters.Add(entry.Key, entry.Value.Item1, entry.Value.Item2, entry.Value.Item3);
                }
            }

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();

                TEntity result = connection.Query<TEntity>(
                    storedProcedureName,
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return result;
            }
        }

        public int ExecuteSPWithOutPut(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            DbType outputType;
            string outputName = "";

            foreach (KeyValuePair<string, Tuple<string, DbType, ParameterDirection>> entry in parameters)
            {
                if (entry.Value.Item2 == DbType.Guid)
                {
                    Guid guid = new Guid(entry.Value.Item1);
                    dynamicParameters.Add(entry.Key, guid, DbType.Guid, entry.Value.Item3);
                }
                else
                {
                    dynamicParameters.Add(entry.Key, entry.Value.Item1, entry.Value.Item2, entry.Value.Item3);
                }

                if (entry.Value.Item3 == ParameterDirection.Output)
                {
                    outputType = entry.Value.Item2;
                    outputName = entry.Key;
                }
            }

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();

                object result = connection.Query<TEntity>(
                    storedProcedureName,
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return dynamicParameters.Get<int>(outputName);
            }
        }

        public int ExecuteSPWithInputOutput(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();
            DbType outputType;
            string outputName = "";

            foreach (KeyValuePair<string, Tuple<string, DbType, ParameterDirection>> entry in parameters)
            {
                if (entry.Value.Item2 == DbType.Guid)
                {
                    Guid guid = new Guid(entry.Value.Item1);
                    dynamicParameters.Add(entry.Key, guid, DbType.Guid, entry.Value.Item3);
                }
                else
                {
                    dynamicParameters.Add(entry.Key, entry.Value.Item1, entry.Value.Item2, entry.Value.Item3);
                }

                if (entry.Value.Item3 == ParameterDirection.Output || entry.Value.Item3 == ParameterDirection.InputOutput)
                {
                    outputType = entry.Value.Item2;
                    outputName = entry.Key;
                }
            }

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();

                object result = connection.Query<TEntity>(
                    storedProcedureName,
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return dynamicParameters.Get<int>(outputName);
            }
        }


        public int Execute(IEnumerable<Action<IDbConnection, IDbTransaction>> actions)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var action in actions)
                        {
                            action(transaction.Connection, transaction);
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                return 0;
            }
        }

        public int ExecuteTns(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        // multiple operations involving cn and tran here

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }

            return 0;
        }

        public bool ExecuteSPWithBooleanInputOutput(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            DbType outputType;
            string outputName = "";

            foreach (KeyValuePair<string, Tuple<string, DbType, ParameterDirection>> entry in parameters)
            {
                if (entry.Value.Item2 == DbType.Guid)
                {
                    Guid guid = new Guid(entry.Value.Item1);
                    dynamicParameters.Add(entry.Key, guid, DbType.Guid, entry.Value.Item3);
                }
                else
                {
                    dynamicParameters.Add(entry.Key, entry.Value.Item1, entry.Value.Item2, entry.Value.Item3);
                }

                if (entry.Value.Item3 == ParameterDirection.Output || entry.Value.Item3 == ParameterDirection.InputOutput)
                {
                    outputType = entry.Value.Item2;
                    outputName = entry.Key;
                }
            }

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();

                object result = connection.Query<TEntity>(
                    storedProcedureName,
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return dynamicParameters.Get<bool>(outputName);
            }
        }

        public void ExecuteSP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (KeyValuePair<string, Tuple<string, DbType, ParameterDirection>> entry in parameters)
            {
                if (entry.Value.Item2 == DbType.Guid)
                {
                    Guid guid = new Guid(entry.Value.Item1);
                    dynamicParameters.Add(entry.Key, guid, DbType.Guid, entry.Value.Item3);
                }
                else
                {
                    dynamicParameters.Add(entry.Key, entry.Value.Item1, entry.Value.Item2, entry.Value.Item3);
                }

            }

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();

                object result = connection.Query<TEntity>(
                    storedProcedureName,
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();


            }
        }

        public IConnectionFactory GetConnectionFactory()
        {
            return connectionFactory;
        }
    }
}
