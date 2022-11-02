using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10084668_TimeManagementApp.Model
{
     public class SelfStudy
    {

        [Key]  //columns--> ssID(pk),username, dateOfStudy,moduleCode,hoursWorked
        public int ssID { get; set; }
        public string username { get; set; }    
        public DateTime dateOfStudy { get; set; }   
        public string moduleCode { get; set; }
        public int hoursWorked { get; set; }
        public int workWeek { get; set; }

        
    }
}
