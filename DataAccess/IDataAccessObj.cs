using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CuahangNongduoc.DataAccess
{
    public interface IDataAccessObj<DbCommand> where DbCommand : class
    {
        void Execute(DbCommand command);

        int ExecuteNoneQuery();
        int ExecuteNoneQuery(DbCommand command);

        T ExecuteScalar<T>(DbCommand command);


    }
}
