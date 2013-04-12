using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Nursery.Data.MySQL
{
    public class BaseDAO
    {
        protected static MySqlConnection connection;
        protected static MySqlCommand command;
        protected static MySqlDataReader reader;

        public BaseDAO() 
        {
            try {
                ServiceLocator Service = ServiceLocator.getInstance();
                connection = (MySqlConnection)Service.getConnection();
            } 
            catch (Exception ex) 
            {
                Console.Write(ex.StackTrace);
            }
        }

        public void disconnect(MySqlConnection connection, MySqlDataReader reader, MySqlCommand command)
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
