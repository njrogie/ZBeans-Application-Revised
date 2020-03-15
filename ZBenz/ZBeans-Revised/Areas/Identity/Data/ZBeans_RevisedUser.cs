using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ZBeans_Revised.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ZBeans_RevisedUser class
    public class ZBeans_RevisedUser : IdentityUser
    {
        public enum EmployeeLevel { Entry, Experienced, Manager };
        [PersonalData]
        public string FName { get; set; }
        [PersonalData]
        public string LName { get; set; }
        [PersonalData]
        public bool ServSafe { get; set; } = false;
        
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string[] DailyAvailibility { get; set; } = new string[7];

        [PersonalData]
        public EmployeeLevel level = EmployeeLevel.Entry;
        //public IWeek WeekSchedule 


        // Populate the data with the username 

        // Returns a "Yes" or "No" for the purposes of data display on the computer side.
        public string ServSafeString()
        {
            if (ServSafe) return "Yes";
            else return "No";
        }
    }
}
