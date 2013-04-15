using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nursery.Entity
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Status2 { get; set; }


        public void Dispose()
        {
            ID = 0;
            UserName = "";
            Password = "";
            Status = "Inactivo";
        }
    }
}
