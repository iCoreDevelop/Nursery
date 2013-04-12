using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Nursery.Data.MySQL
{
    public class ServiceLocator
    {
        private static volatile ServiceLocator instance;
        private static object syncRoot = new Object();
        protected MySqlConnection connection;

        private ServiceLocator()
        {
            loadServices();
        }

        public static ServiceLocator getInstance()
        {
            if (instance == null) 
            {
               lock (syncRoot) 
               {
                  if (instance == null) 
                     instance = new ServiceLocator();
               }
            }
            return instance;
        }

        private void loadServices()
        {
            try
            {
                connection = new MySqlConnection(global::Nursery.Data.MySQL.Properties.Settings.Default.ConnectionString);
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

    }
}
