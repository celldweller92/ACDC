using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Account
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Account1
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
    }
    public class Login
    {
        public string user { get; set; }
        public string pass { get; set; }

    }
}
