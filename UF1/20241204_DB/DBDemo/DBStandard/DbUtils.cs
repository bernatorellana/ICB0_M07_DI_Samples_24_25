using System;
using System.Data;
using System.Data.Common;

namespace DB
{
    internal class DbUtils
    {
        internal static void createParam(DbCommand consulta, string name, object valor, DbType type)
        {
            var param = consulta.CreateParameter();
            param.ParameterName = name;
            param.Value = valor;
            param.DbType = type;
            consulta.Parameters.Add(param);
        }
    }
}