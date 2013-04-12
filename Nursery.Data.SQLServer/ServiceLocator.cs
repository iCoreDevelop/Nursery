using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Nursery.Data.SQLServer
{
    public class ServiceLocator
    {
        private static volatile ServiceLocator instance;
        private static object syncRoot = new Object();
        protected SqlConnection connection;

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
                connection = new SqlConnection(global::Nursery.Data.SQLServer.Properties.Settings.Default.ConnectionString);
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        public SqlConnection getConnection()
        {
            return connection;
        }

    }
}
