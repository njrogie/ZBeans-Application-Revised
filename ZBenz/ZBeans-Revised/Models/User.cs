using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using static ZBeansApplication.Data.Enums;
using ZBeansApplication.Data.ScheduleInterfaces;

namespace ZBeansApplication.Models
{
    public class User
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 

        [Required]
        public string ID { get; set; } = "-1";
        public string FName { get; set; }
        public string LName { get; set; }
        public bool ServSafe { get; set; } = false;

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string[] DailyAvailibility { get; set; } = new string[7];


        public EmployeeLevel level = EmployeeLevel.Entry;
        //public IWeek WeekSchedule 


        // Populate the data with the username 

        // Returns a "Yes" or "No" for the purposes of data display on the computer side.
        public string ServSafeString()
        {
            if (ServSafe) return "Yes";
            else return "No";
        }

        public void ParseAvailibility()
        {
            foreach(string s in DailyAvailibility)
            {

            }
        }


    }
}
