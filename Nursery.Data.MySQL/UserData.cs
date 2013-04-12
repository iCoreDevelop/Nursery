using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Nursery.Entity;

namespace Nursery.Data.MySQL
{
    public class UserData : BaseDAO
    {
        public int ValidateUser(User user)
        {
            int ID = 0;
            try
            {
                string sql = "SELECT ID FROM User WHERE UserName = @UserName AND Password = @Password AND Status = @Status";
                command = new MySqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = sql;
                command.Parameters.AddWithValue("UserName", user.UserName);
                command.Parameters.AddWithValue("Password", user.Password);
                command.Parameters.AddWithValue("Status", user.Status);

                connection.Open();
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = (!reader.IsDBNull(0)) ? reader.GetInt32(0) : 0;
                }

                return ID;
            }
            catch (Exception ex)
            {
                return ID;
            }
            finally
            {
                disconnect(connection, reader, command);
            }
        }
    }
}