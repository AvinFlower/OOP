using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_for_the_tour
{
    public class Admin : Entity
    {
        public string login {  get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public void Add(string login, string password, string name)
        {
            this.login = login;
            this.password = password;
            this.name = name;
        }
    }
}
