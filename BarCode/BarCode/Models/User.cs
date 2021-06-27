using System;
using System.Collections.Generic;
using System.Text;

namespace BarCode.Models
{
    class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User()
        {

        }
        public User (string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

    }
}
