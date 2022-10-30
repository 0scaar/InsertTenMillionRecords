using Microsoft.Data.SqlClient;
using System.Data;

namespace TemMillionsRecords.Code
{
    public class InefficientCode
    {
        public static void InsertData(string route)
        {
            using (var connection = new SqlConnection(Data.connString))
            {
                using (var command = new SqlCommand(Data.procedure, connection))
                {
                    DataTable dt = GetData(route);
                    command.CommandType = CommandType.StoredProcedure;

                    var param = command.Parameters.AddWithValue(Data.parameterProcedure, dt);
                    param.SqlDbType = SqlDbType.Structured;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private static DataTable GetData(string route)
        {
            var dt = new DataTable();

            dt.Columns.Add("record", typeof(string));

            StreamReader? _FileReader = null;

            try
            {
                _FileReader = new StreamReader(route);

                while (!_FileReader.EndOfStream)
                {
                    dt.Rows.Add(_FileReader.ReadLine());
                }
            }
            finally
            {
                _FileReader?.Close();
            }

            return dt;
        }
    }
}
