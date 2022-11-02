using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10084668_TimeManagementApp.Model
{
     public class UserContext : DbContext
    {
        //pass the user class as a dbset
        public DbSet<User> Users { get; set; }
        
        
    }
}
