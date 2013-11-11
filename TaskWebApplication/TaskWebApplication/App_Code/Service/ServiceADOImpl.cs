using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TaskWebApplication.Service
{
    public abstract class ServiceADOImpl
    {
        /// <summary>
        /// This method opens a connection to the database.
        /// </summary>
        /// <returns>the connection to the database.</returns>
        SqlConnection GetConnection()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["taskManagement"].ConnectionString;
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

        protected Object create(Object obj)
        {
            return obj;
        }

        private SqlDataReader read(SqlConnection conn, Object[] args)
        {
            Object id = args[0];
            String tableName = args[1].ToString();
            SqlDataReader reader = null;
            string SqlQuery = "select * from " + tableName + " where id = '" + id.ToString() + "'";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            reader = cmd.ExecuteReader();         
            return reader;
        }

        protected SqlDataReader read(Object id, String tableName)
        {
            Object[] args = new Object[2];
            object[0] = id;
            object[1] = tableName;
            return (SqlDataReader) executeCommand(read, args);
        }

        protected Object update(Object obj)
        {
            return obj;
        }

        protected Object delete(Object obj)
        {
            return obj;
        }

    }
}