using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace st10084668_TimeManagementApp.Model
{
    public class User
    {
        [Key] //columns --> username(pk),password
        public string username { get; set; }
        public string password { get; set; }

        
    }
}
