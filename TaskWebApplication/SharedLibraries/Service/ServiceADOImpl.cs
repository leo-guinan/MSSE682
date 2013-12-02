using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
namespace SharedLibraries.Service
{
    public abstract class ServiceADOImpl
    {

        private String connection;


        protected ServiceADOImpl(String connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// This method opens a connection to the database.
        /// </summary>
        /// <returns>the connection to the database.</returns>
        private SqlConnection GetConnection()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[connection].ConnectionString;
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// This method takes a function as an argument, and takes care of opening and closing the connection around
        /// the method that takes the connection as an argument.
        /// </summary>
        /// <param name="command">A function that returns a boolean and takes an SQLConnection as a parameter.</param>
        /// <returns>the result of the function.</returns>
        protected Object executeCommand(Func<SqlConnection, Object[], Object> command, Object[] args)
        {
            Object result = false;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                result = command(conn, args);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        protected int create(String tableName, Dictionary<String, Object> columnsToValues)
        {
            Object[] args = new Object[2];
            args[0] = tableName;
            args[1] = columnsToValues;
            return (int) executeCommand(create, args);
        }
         
        private Object create(SqlConnection conn, Object[] args)
        {
            String tableName = args[0].ToString();
            Dictionary<String, Object> columnsToValues = (Dictionary<String, Object>)args[1];
            String columns = String.Join(", ", columnsToValues.Keys);
            String[] values = new String[columnsToValues.Count];
            for (int i = 0; i < columnsToValues.Count; ++ i)
            {
                values[i] = "@" + columnsToValues.Keys.ElementAt(i);
            }

            string SqlInsert = "insert into " + tableName + " (" + columns + ") values ("
                + String.Join(",", values) + ");SELECT CAST(scope_identity() AS int)";
            SqlCommand cmd = new SqlCommand(SqlInsert, conn);
            foreach (String key in columnsToValues.Keys)
            {
                Object value = columnsToValues[key] == null ? DBNull.Value : columnsToValues[key];
                cmd.Parameters.AddWithValue("@" + key, value);
            }
            int id = -1;
            try
            {
                id = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return id;
        }

        private DataTable read(SqlConnection conn, Object[] args)
        {
            String tableName = args[0].ToString();
            String keyColumn = args[1].ToString();
            String keyValue = args[2].ToString();
            SqlDataReader reader = null;
            string SqlQuery = "select * from " + tableName + " where " + keyColumn + " = @keyValue";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.AddWithValue("@keyValue", keyValue);
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }

        private DataTable readAll(SqlConnection conn, Object[] args)
        {
            String tableName = args[0].ToString();
            SqlDataReader reader = null;
            string SqlQuery = "select * from " + tableName;
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }

        protected DataTable read(String tableName, String keyColumn, String keyValue)
        {
            Object[] args = new Object[3];
            args[0] = tableName;
            args[1] = keyColumn;
            args[2] = keyValue;
            return (DataTable) executeCommand(read, args);
        }

        protected DataTable readAll(String tableName)
        {
            Object[] args = new Object[3];
            args[0] = tableName;
            return (DataTable)executeCommand(readAll, args);
        }

        protected int update(String tableName, Dictionary<String, Object> columnsToValues, String keyColumn, String keyValue)
        {
            Object[] args = new Object[4];
            args[0] = tableName;
            args[1] = columnsToValues;
            args[2] = keyColumn;
            args[3] = keyValue;
            return (int) executeCommand(update, args);
        }

        private Object update(SqlConnection conn, Object[] args)
        {
            String tableName = args[0].ToString();
            Dictionary<String, Object> columnsToValues = (Dictionary<String, Object>)args[1];
            String keyColumn = args[2].ToString();
            String keyValue = args[3].ToString();            
            String[] columns = new String[columnsToValues.Count];
            for(int i =0; i < columns.Length; i++)
            {
                String key = columnsToValues.ElementAt(i).Key;
                columns[i] = key + "=@" + key; 
            }
            String update = "UPDATE " + tableName + " SET " + String.Join(", ", columns) + " WHERE " + keyColumn + "=" + "@keyValue;";
            SqlCommand cmd = new SqlCommand(update, conn);            
            cmd.Parameters.AddWithValue("@keyValue", keyValue); 
            foreach (String key in columnsToValues.Keys)
            {
                Object value = columnsToValues[key] == null ? DBNull.Value : columnsToValues[key];
                cmd.Parameters.AddWithValue("@" + key, value);
            }
            int numberOfRows = cmd.ExecuteNonQuery();
            return numberOfRows;
        }

        protected int delete(String tableName, String keyColumn, String keyValue)
        {
            Object[] args = new Object[3];
            args[0] = tableName;
            args[1] = keyColumn;
            args[2] = keyValue;
            return (int) executeCommand(delete, args);
        }

        private Object delete(SqlConnection conn, Object[] args)
        {
            String tableName = args[0].ToString();
            String keyColumn = args[1].ToString();
            String keyValue = args[2].ToString();
            String delete = "DELETE FROM " + tableName + " WHERE " + keyColumn + "=@keyValue;";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.AddWithValue("@keyValue", keyValue);
            int numberOfRows = cmd.ExecuteNonQuery();
            return numberOfRows;
        }

    }
}