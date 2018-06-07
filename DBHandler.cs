using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public static class DBHandler
    {

        private static void Procedure(string procedure, List<SqlParameter> param, Action<SqlCommand> runner)
        {
            using (SqlConnection connection = new SqlConnection("Database=GD1C2018;Server=.\\SQLSERVER2012;User id=gdHotel2018;Password=gd2018;connect timeout = 30"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                                                            procedure,
                                                            connection) { CommandType = CommandType.StoredProcedure })
                {
                    if (param != null)
                        param.ForEach(p => command.Parameters.Add(p));

                    runner(command);
                }
            }
        }

        public static int SPWithValue(string procedure, List<SqlParameter> param = null)
        {
            int retval = 0;

            Procedure(procedure, param, (command) => {

                var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();
                retval = (int)returnParameter.Value;
            
            });

            return retval;
        }

        public static List<Dictionary<string, object>> SPWithResultSet(string procedure, List<SqlParameter> param = null)
        {
            List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();
            Procedure(procedure, param, (command) => {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        ret.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));

                }
            });

            return ret;       
        }
    }
}
