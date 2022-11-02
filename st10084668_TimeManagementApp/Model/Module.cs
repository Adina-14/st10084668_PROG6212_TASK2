using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10084668_TimeManagementApp.Model
{
     public class Module
    {
        
        [Key] //columns-->moduleID(pk),username,moduleCode,moduleName,credits...
        public int moduleID { get; set; }
        public string username { get; set; }
        public string moduleCode { get; set; }
        public string moduleName { get; set; }
        public int credits { get; set; }
        public int classHrsPerWeek { get; set; }
        public int weeksInSemester { get; set; }
        public DateTime startDate { get; set; }
        public int selfStudyHrs { get; set; }

       
    }
}
