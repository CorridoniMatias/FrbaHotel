using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class QueryBuilder
    {

        public enum QueryBuilderType
        {
            SELECT, INSERT, UPDATE, DELETE
        }

        private readonly string queryBase = string.Empty;

        private string fields = string.Empty, table = string.Empty;

        private List<string> filters = new List<string>();
        private List<string> joins = new List<string>();
        private List<string> values = new List<string>();

        /// <summary>
        /// ej:
        /// string t = new FilterQueryBuilder().Select("1,2,3").Table("user").AddLike("nombre", "ju").AddEquals("id", "32").Build();
        /// </summary>
        public QueryBuilder(QueryBuilderType type)
        {
            switch (type)
            {
                case QueryBuilderType.SELECT:
                    queryBase = "SELECT fields FROM table join filter";
                    break;
                case QueryBuilderType.UPDATE:
                    queryBase = "UPDATE table SET fields filter";
                    break;
                case QueryBuilderType.DELETE:
                    queryBase = "DELETE FROM table filter";
                    break;
                case QueryBuilderType.INSERT:
                    queryBase = "INSERT INTO table (fields) VALUES news";
                    break;

            }
        }

        public QueryBuilder AddValues(params string[] fields)
        {
            values.Add(
                        "(" + string.Join(",",
                                        fields.ToList().Select(f => "'" + f + "'")
                                        ) + ")");
            return this;
        }

        public QueryBuilder ClearFilters()
        {
            filters.Clear();
            return this;
        }

        public QueryBuilder AddJoin(string joinStatement)
        {
            this.joins.Add(joinStatement);
            return this;
        }

        public QueryBuilder Fields(string whatToSelect)
        {
            fields = whatToSelect;
            return this;
        }

        public QueryBuilder Table(string table)
        {
            this.table = table;
            return this;
        }

        public QueryBuilder AddLike(string field, string value)
        {
            filters.Add(field + " LIKE '%" + value + "%'");
            return this;
        }

        public QueryBuilder AddEquals(string field, string value)
        {
            filters.Add(field + " = '" + value + "'");
            return this;
        }

        public string Build()
        {
            string final = queryBase.Replace("fields", fields);

            final = final.Replace("table", table);

            if(filters.Count > 0)
                final = final.Replace("filter", "WHERE " + String.Join(" AND ", filters.ToArray()));
            else
                final = final.Replace("filter", "");

            if (joins.Count > 0)
                final = final.Replace("join", String.Join(" ", joins));
            else
                final = final.Replace("join", "");

            if (values.Count > 0)
                final = final.Replace("news", String.Join(",", values));
            else
                final = final.Replace("news", "");

            return final;
        }
    }

    public static class DBHandler
    {

        private static void Command(string commandText, List<SqlParameter> param, Action<SqlCommand> runner, CommandType type = CommandType.Text)
        {
            using (SqlConnection connection = new SqlConnection("Database=GD1C2018;Server=.\\SQLSERVER2012;User id=gdHotel2018;Password=gd2018;connect timeout = 30"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                                                            commandText,
                                                            connection) { CommandType = type })
                {
                    if (param != null)
                        param.ForEach(p => command.Parameters.Add(p));

                    runner(command);
                }
            }
        }

        private static void Procedure(string procedure, List<SqlParameter> param, Action<SqlCommand> runner)
        {
            Command(procedure, param, runner, CommandType.StoredProcedure);
        }

        /// <summary>
        ///  ejemplo : 
        ///  
        /// var t = DBHandler.Query("SELECT * FROM MATOTA.Usuario");
        ///
        /// MessageBox.Show(t.First()["username"].ToString()); esto muestra el username de la primera fila traida.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns>Dictionary as ResultSet. Cada indice del list es un row traido, cada valor del list es un dictionary con el valor del row entero.</returns>
        public static List<Dictionary<string, object>> Query(string query, List<SqlParameter> param = null)
        {
            List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();
            Command(query, param, (command) =>
            {
                GetResultSet(command, ref ret);
            });

            return ret;
        }

        /// <summary>
        /// Hace query y devuelve el row affected count.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int QueryRowCount(string query, List<SqlParameter> param = null)
        {
            int ret = -1;
            Command(query, param, (command) =>
            {
                ret = command.ExecuteNonQuery();
            });

            return ret;
        }

        public static int QueryScalar(string query, List<SqlParameter> param = null)
        {
            int ret = -1;
            Command(query, param, (command) =>
            {
                ret = Convert.ToInt32(command.ExecuteScalar());
            });

            return ret;
        }

        public static int SPWithValue(string procedure, List<SqlParameter> param = null)
        {
            int retval = 0;

            Procedure(procedure, param, (command) =>
            {

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
            Procedure(procedure, param, (command) =>
            {

                GetResultSet(command, ref ret);
            });

            return ret;       
        }
        public static DataTable QueryForComboBox(string query, List<SqlParameter> param = null)
        {
            var tabla = new DataTable();
            Command(query, param, (command) =>
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    tabla.Load(reader);
                }
            });
            return tabla;
        }

        private static void GetResultSet(SqlCommand command, ref List<Dictionary<string, object>> set)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    set.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));

            }
        }
    }
}
