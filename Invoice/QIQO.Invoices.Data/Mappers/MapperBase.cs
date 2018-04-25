using System;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class MapperBase
    {
        public SqlParameter GetOutParam() => new SqlParameter()
        {
            ParameterName = "@key",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };

        public SqlParameter GetIdentityOutParam() =>
            // for the output param guid or the current id
            new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Output
            };

        public SqlParameter BuildParam(string parameterName, object value) => new SqlParameter(parameterName, value);

        protected T NullCheck<T>(object checkValue)
        {
            T outValue;
            if (checkValue == DBNull.Value)
                outValue = default(T);
            else
                outValue = (T)checkValue;
            return outValue;
        }
    }
}
