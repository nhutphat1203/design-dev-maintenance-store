using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CuahangNongduoc.Utils.Logger;
using System.Data.Common;
using System.Data.OleDb;
using System.ComponentModel.Design;

namespace CuahangNongduoc.DataAccess
{
    public class DataAccessObj : DataTable, IDataAccessObj<SqlCommand>
    {
        private static readonly ILogger _logger = new Logger<DataAccessObj>();
        private SqlCommand _command;
        private SqlConnection _connection;
        private SqlDataAdapter _dataAdapter;

        public SqlCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }


        public DataAccessObj()
        {
        }
        ~DataAccessObj()
        {
            CloseConnection();
            _logger.Debug("Destroyed DataAccessObj");
        }

        public bool OpenConnection()
        {
            try
            {
                if (_connection == null)
                    _connection = new SqlConnection(Connection.ConnectionString);

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                _connection.Close();
                _logger.Error("Error opening database connection", ex);
                return false;
            }

        }
        public void CloseConnection()
        {
            _connection.Close();
        }

        public void Execute(SqlCommand command)
        {
            OpenConnection();
            _command = command;
            try
            {

                _command.Connection = _connection;

                _dataAdapter = new SqlDataAdapter();
                _dataAdapter.SelectCommand = _command;

                this.Clear();
                _dataAdapter.Fill(this);

            }
            catch (Exception ex)
            {
                _logger.Error("Error executing command", ex);
            }
        }
        public int ExecuteNoneQuery()
        {
            int result = 0;
            SqlTransaction tr = null;
            try
            {
                tr = _connection.BeginTransaction();

                _command.Connection = _connection;
                _command.Transaction = tr;

                _dataAdapter = new SqlDataAdapter();
                _dataAdapter.SelectCommand = _command;

                var builder = new SqlCommandBuilder(_dataAdapter);

                result = _dataAdapter.Update(this);


                tr.Commit();

            }
            catch (Exception ex)
            {
                if (tr != null) tr.Rollback();
                _logger.Error("Error executing non-query command", ex);

            }
            return result;
        }

        public int ExecuteNoneQuery(SqlCommand command)
        {

            int result = 0;
            SqlTransaction tr = null;

            try
            {
                tr = _connection.BeginTransaction();

                command.Connection = _connection;
                command.Transaction = tr;

                result = command.ExecuteNonQuery();

                this.AcceptChanges();

                tr.Commit();

            }
            catch (Exception ex)
            {
                if (tr != null) tr.Rollback();
                _logger.Error("Error executing non-query command", ex);
                throw;
            }
            return result;

        }

        public T ExecuteScalar<T>(SqlCommand command)
        {
            T result = default(T);
            SqlTransaction tr = null;

            try
            {
                tr = _connection.BeginTransaction();

                command.Connection = _connection;
                command.Transaction = tr;

                object scalarValue = command.ExecuteScalar();

                if (scalarValue == DBNull.Value || scalarValue == null)
                {
                    result = default(T);
                }
                else
                {
                    result = (T)Convert.ChangeType(scalarValue, typeof(T));
                }

                this.AcceptChanges();
                tr.Commit();
            }
            catch (Exception ex)
            {
                if (tr != null) tr.Rollback();
                _logger.Error("Error executing scalar command", ex);
                throw;
            }

            return result;
        }


    }
}
