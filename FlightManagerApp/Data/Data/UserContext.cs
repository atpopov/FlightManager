using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("name = UserContext")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
