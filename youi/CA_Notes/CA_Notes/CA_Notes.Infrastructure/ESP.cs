using Microsoft.Data.SqlClient;
using System.Data;


namespace CA_Notes.Infrastructure
{
    public class ESP(string _connectionString)
    {

        public DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }


}
