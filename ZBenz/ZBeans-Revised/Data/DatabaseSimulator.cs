using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZBeansApplication.Models;

namespace ZBeansApplication.Data
{
    public static class DatabaseSimulator
    {
        public static List<User> employees = new List<User>();
        static DatabaseSimulator()
        {
            employees.Add(new User() { FName = "Nick", LName = "Rogie", ID = "0", level = Enums.EmployeeLevel.Experienced, ServSafe= true }) ;
            employees.Add(new User() { FName = "Alex", LName = "Frink", ID = "1", level = Enums.EmployeeLevel.Entry, ServSafe = false });
            employees.Add(new User() { FName = "Blair", LName = "Gatland", ID = "2", level = Enums.EmployeeLevel.Manager, ServSafe = true });

            
        }
        
    }
}
