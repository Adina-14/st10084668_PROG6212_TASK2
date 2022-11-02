using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10084668_TimeManagementApp.Model
{
    public class SelfStudyContext : DbContext
    {
        //pass the selfstudy class as a dbset
        public DbSet<SelfStudy> SelfStudies{ get; set; }
    }
}
