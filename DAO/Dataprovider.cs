using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace quanlyquancafe.DTO
{
    public class DataProvider
    {
        private static DataProvider instance;
        private string connectionStr = ConfigurationManager.ConnectionStrings["phanmemquanly"].ConnectionString;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
        }

        private DataProvider() { }

        private void AddParameters(SqlCommand command, string query, object[] parameter)
        {
            if (parameter != null)
            {
                string[] listPara = query.Split(
                    new char[] { ' ', ',', '(', ')', '\n', '\t', '=', '<', '>' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.StartsWith("@"))
                    {
                        if (i < parameter.Length)
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                        else break;
                    }
                }
            }
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameters(command, query, parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameters(command, query, parameter);

                data = command.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameters(command, query, parameter);

                data = command.ExecuteScalar();
                connection.Close();
            }

            return data;
        }
    }
}
