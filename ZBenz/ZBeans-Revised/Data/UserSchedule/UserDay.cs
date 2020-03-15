using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ZBeansApplication.Data.ScheduleInterfaces;

namespace ZBeansApplication.Data.UserSchedule
{
    public class UserDay : IDay
    {
        List<bool> AvailabilityTimeSlots = new List<bool>(48);

        public UserDay()
        {
            for(int i = 0; i < AvailabilityTimeSlots.Capacity; i++)
            {
                AvailabilityTimeSlots.Add(false);
            }
        }

        bool Preferred = false;


        public void ParseAvailibility(string inputString)
        {
            // string 
            string[] timeSpans = inputString.Split(';');

            
        }



    }
}
