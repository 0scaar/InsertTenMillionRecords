using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using System.Data;

namespace TemMillionsRecords.Code
{
    public class EfficientCode
    {
        public static void InsertData(string route)
        {
            using (var connection = new SqlConnection(Data.connString))
            {
                using (var command = new SqlCommand(Data.procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parametro = new SqlParameter($"@{Data.parameterProcedure}", SqlDbType.Structured);

                    parametro.TypeName = Data.typeTable;
                    parametro.Value = GetData(route);
                    
                    command.Parameters.Add(parametro);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private static IEnumerable<SqlDataRecord> GetData(string route)
        {
            SqlMetaData[] schema = new SqlMetaData[] { 
                new SqlMetaData("valor", SqlDbType.NVarChar, 100)
            };

            SqlDataRecord _DataRecord = new SqlDataRecord(schema);
            using (StreamReader? reader = new StreamReader(route))
            {
                while (!reader.EndOfStream)
                {
                    _DataRecord.SetString(0, reader.ReadLine());
                    yield return _DataRecord;
                }
            }
        }
    }
}
