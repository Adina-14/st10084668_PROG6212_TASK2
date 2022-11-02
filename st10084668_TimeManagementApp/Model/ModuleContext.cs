using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10084668_TimeManagementApp.Model
{
    public class ModuleContext: DbContext
    {
        //pass the module class as a dbset
        public DbSet<Module> Modules { get; set; }
    }
}
