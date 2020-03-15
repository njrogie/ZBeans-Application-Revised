using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ZBeansApplication.Data.ScheduleInterfaces;
using ZBeansApplication.Models;

namespace ZBeansApplication.Data.ScheduleClasses
{
    public class ScheduleDay: IDay
    {
        //Index 0: 00:00
        //Index 47: 23:30
        public List<TimeSlot> HalfHourSlots = new List<TimeSlot>(48);

        
        public ScheduleDay()
        {
            for(int i = 0; i < HalfHourSlots.Capacity; i++)
            {
                HalfHourSlots.Add(new TimeSlot());
            }
        }

        public void BlockTimeSlot(int index)
        {
            HalfHourSlots[index].setValidity(false);
        }

        public void OpenTimeSlot(int index)
        {
            HalfHourSlots[index].setValidity(true);
        }

        public void AddEmployeeAtTime(int index, User user)
        {
            HalfHourSlots[index].AddEmployee(user);
        }

        public void RemoveEmployeeAtTime(int index, User user)
        {
            HalfHourSlots[index].RemoveEmployee(user);
        }

    }
}
