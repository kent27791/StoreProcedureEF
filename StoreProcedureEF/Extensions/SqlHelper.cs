using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using StoreProcedureEF.Common;
using System.Data.Entity.Infrastructure;

namespace StoreProcedureEF.Extensions
{
    public static class SqlHelper
    {
        public static Tuple<string, object[], string> PrepareArguments(string storedProcedure, object parameters)
        {
            var parameterNames = new List<string>();
            var parameterParameters = new List<object>();
            var key = storedProcedure;
            if (parameters != null)
            {
                foreach (PropertyInfo propertyInfo in parameters.GetType().GetProperties())
                {
                    string name = "@" + propertyInfo.Name;
                    object value = propertyInfo.GetValue(parameters, null);
                    //Create key = name + value
                    key += string.Format("/{0}-{1}", name, value);
                    //Check OUT parameter
                    var checkDirection = name.IndexOf("_OUT");
                    if (checkDirection > 0)
                    {
                        var directionParameter = name.Substring(checkDirection + 1);
                        var paremeterName = name.Substring(0, checkDirection);
                        parameterNames.Add(paremeterName + " " + directionParameter);
                        parameterParameters.Add(new SqlParameter(paremeterName, value ?? DBNull.Value) { Direction = ParameterDirection.Output });
                    }
                    else
                    {
                        parameterNames.Add(name);
                        parameterParameters.Add(new SqlParameter(name, value ?? DBNull.Value));
                    }
                }
            }

            if (parameterNames.Count > 0)
                storedProcedure += " " + string.Join(", ", parameterNames);

            return new Tuple<string, object[], string>(storedProcedure, parameterParameters.ToArray(), key);
        }

        public static DbRawSqlQuery<T> ExecuteSqlCommand<T>(this DbContext context, SqlRequest sqlRequest) where T : class
        {
            try
            {
                var arguments = PrepareArguments(sqlRequest.CommandName.ToString(), sqlRequest.CommandParams);
                var results = context.Database.SqlQuery<T>(arguments.Item1, arguments.Item2);
                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
