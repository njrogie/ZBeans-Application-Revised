using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZBeansApplication.Data.ScheduleInterfaces;
using ZBeansApplication.Models;

namespace ZBeansApplication.Data.ScheduleClasses
{
    public class TimeSlot : ITimeSlot
    {

        public bool validTimeSlot { get; set; } = true;
        public List<User> employees = new List<User>(0);

        public TimeSlot()
        {
            employees = new List<User>();
        }

        public void setValidity(bool value)
        {
            validTimeSlot = value;
        }
          
        public void AddEmployee(User user)
        {
            employees.Add(user);
        }

        public void RemoveEmployee(User user)
        {
            employees.Remove(user);
        }

    }
}
