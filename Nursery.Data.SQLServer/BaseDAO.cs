using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Nursery.Data.SQLServer
{
    public class BaseDAO
    {
        protected static SqlConnection connection;
        protected static SqlCommand command;
        protected static SqlDataReader reader;

        public BaseDAO() 
        {
            try {
                ServiceLocator Service = ServiceLocator.getInstance();
                connection = (SqlConnection) Service.getConnection();
            } 
            catch (Exception ex) 
            {
                Console.Write(ex.StackTrace);
            }
        }

        public void disconnect(SqlConnection connection, SqlDataReader reader, SqlCommand command)
        {
            try{
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }

                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }

                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            } catch (Exception ex){
                Console.Write(ex.StackTrace);
            }
        }

    }
}
