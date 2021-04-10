using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private UserContext context;

        //Makes a list that contains all of the Users in the Database
        public List<User> GetAll()
        {
            using (context = new UserContext())
            {
                return context.Users.ToList();
            }
        }
    }
}
