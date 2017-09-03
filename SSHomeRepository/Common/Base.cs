using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SSHomeCommon.Helpers;
using SSHomeRepositoryTypes;

namespace SSHomeRepository
{
    public partial class BaseRepository : IDisposable
    {
        #region class members

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        #endregion class members

        #region constructor
        // constructor
        internal BaseRepository()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SSHomeConnectionString"].ConnectionString);
        }

        #endregion constructor

        #region getter setters

        // get set connection object
        public IDbConnection Connection
        {
            get { return _connection; }
            protected set { _connection = value; }
        }

        // get set transaction object
        public IDbTransaction Transaction
        {
            get { return _transaction; }
            set
            {
                _transaction = value;
                if (_transaction != null)
                    _connection = _transaction.Connection;
            }
        }

        #endregion getter setters

        #region Transaction Related Methods


        // begin transaction
        public IDbTransaction BeginTransaction()
        {
            OpenConnection();
            _transaction = _connection.BeginTransaction(); // begin actual dbconnection transaction
            return _transaction;
        }

        // begin transaction with isolation level
        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            OpenConnection();
            _transaction = _connection.BeginTransaction(isolationLevel);
            return _transaction;
        }


        #endregion Transaction Related Methods

        #region return results using Raw Sql Execution using Dapper also used for most CRUD operations in the project

        // wrapper to execute parameterised sql using dapper internally it uses dapper execute method
        public int Execute(
            string sql, // sql to execute
            dynamic param = null, // parameters to pass 
            IDbTransaction transaction = null, // transaction object if any
            int? commandTimeout = null,
            CommandType? commandType = null
            )
        {
            if (transaction == null) transaction = _transaction;
            OpenConnection();
            try
            {
                // dapper execute
                return SqlMapper.Execute(
                    _connection,
                    sql,
                    param,
                    transaction,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                transaction.Rollback();
                return -1;
            }
            finally
            {
                //CloseConnection();
            }
        }


        #endregion Raw Sql Execution using Dapper

        #region Dapper Query Wrapper


        // returns list of dynamic objects
        public IEnumerable<dynamic> Query(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
            {
                transaction = _transaction;
            }

            OpenConnection();

            try
            {
                return SqlMapper.Query(
                    _connection,
                    sql,
                    param,
                    transaction,
                    buffered,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                return null;
            }
            finally
            {
                //if (buffered)
                CloseConnection();
            }
        }

        // returns list of T
        public IEnumerable<T> Query<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
            {
                transaction = _transaction;
            }

            try
            {
                OpenConnection();

                return SqlMapper.Query<T>(
                    _connection,
                    sql,
                    param,
                    transaction,
                    buffered,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                return null;
            }
            finally
            {
                //if (buffered)
                CloseConnection();
            }
        }

        // return list of TReturn by passing 2 objects using split on
        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null) transaction = _transaction;
            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TReturn>(
                    _connection,
                    sql,
                    map,
                    param,
                    transaction,
                    buffered,
                    splitOn,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                return null;
            }
            finally
            {
                //if (buffered)
                CloseConnection();
            }
        }

        // return list of TReturn by passing 3 objects using split on
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null) transaction = _transaction;
            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TReturn>(
                    _connection,
                    sql,
                    map,
                    param,
                    transaction,
                    buffered,
                    splitOn,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                return null;
            }
            finally
            {
                //if (buffered)
                CloseConnection();
            }
        }

        // return list of TReturn by passing 4 objects using split on
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null) transaction = _transaction;
            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TReturn>(
                    _connection,
                    sql,
                    map,
                    param,
                    transaction,
                    buffered,
                    splitOn,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                return null;
            }
            finally
            {
                //if (buffered)
                CloseConnection();
            }
        }

        // return list of TReturn by passing 5 objects using split on
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null) transaction = _transaction;
            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
                    _connection,
                    sql,
                    map,
                    param,
                    transaction,
                    buffered,
                    splitOn,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                return null;
            }
            finally
            {
                //if (buffered)
                CloseConnection();
            }
        }

        // return list of TReturn by passing 6 objects using split on
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null) transaction = _transaction;
            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
                    _connection,
                    sql,
                    map,
                    param,
                    transaction,
                    buffered,
                    splitOn,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                return null;
            }
            finally
            {
                //if (buffered)
                //    CloseConnection();
            }
        }

        // return list of TReturn by passing 7 objects using split on
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null) transaction = _transaction;
            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
                    _connection,
                    sql,
                    map,
                    param,
                    transaction,
                    buffered,
                    splitOn,
                    commandTimeout,
                    commandType
                    );
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                return null;
            }
            finally
            {
                //if (buffered)
                CloseConnection();
            }
        }


        #endregion Dapper Query Wrapper

        #region Dapper Multiple Query Wrapper 

        // query multiple returns grid reader which u can den use to  extract multiple lists of T
        public SqlMapper.GridReader QueryMultiple(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null) transaction = _transaction;
            OpenConnection();
            return SqlMapper.QueryMultiple(
                _connection,
                sql,
                param,
                transaction,
                commandTimeout,
                commandType
                );
        }

        #endregion Dapper Multiple Query Wrapper

        #region private supporting methods

        protected void OpenConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        protected void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
            }
        }

        #endregion private supporting methods

        // dispose
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
            _transaction = null;
            _connection = null;
        }
    }
}
