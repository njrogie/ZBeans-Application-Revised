using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ZBeansApplication.Data.ScheduleClasses;
namespace ZBeansApplication.Models
{
    public class WeekScheduleModel
    {
        // Create 7 Days
        public List<ScheduleDay> Week = new List<ScheduleDay>(7);

        // We need to create an additional enum because our week starts on monday.
        public enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        private DateTime todayUTC = DateTime.Now;
        private DateTime todayEST;
        public string WeekOfString;

        public WeekScheduleModel()
        {
            CreateTodayString();

            for (int i = 0; i < Week.Capacity; i++)
            {
                Week.Add(new ScheduleDay());
            }

            BlockDefaultSlots(11, 44);


        }

        public void CreateTodayString()
        {
            DateTime BeginningOfWeek;
            // Save the EST Time.
            if(DateTime.Now.IsDaylightSavingTime())
            {
                todayEST = todayUTC.Subtract(TimeSpan.FromHours(4));
            }

            else
            {
                todayEST = todayUTC.Subtract(TimeSpan.FromHours(5));
            }


            // Get the index of the current Weekday
            string weekday = todayEST.DayOfWeek.ToString();
            int DaysSinceMonday = -1;
            for(int i = 0; i < Enum.GetNames(typeof(Days)).Length; i++)
            {
                if(Enum.GetNames(typeof(Days))[i].Contains(weekday))
                {
                    DaysSinceMonday = i;
                }
            }

            BeginningOfWeek = todayEST.Subtract(TimeSpan.FromDays(DaysSinceMonday));

            WeekOfString = "Week of " + BeginningOfWeek.DayOfWeek.ToString() + ", " + BeginningOfWeek.ToString(@"MM\/dd\/yyyy") + " (EST)";


           

        }

        /// <summary>
        /// Blocks the commonly "not worked" times each week.
        /// </summary>
        /// <param name="startIndex">The index corresponding to the start of the "not worked" times.</param>
        /// <param name="endIndex">The index corresponding to the end of the "not worked" times.</param>
        public void BlockDefaultSlots(int startIndex, int endIndex)
        {

            //Initialize the Week
            for (int i = 0; i < Week.Capacity; i++)
            {
                for (int j = 0; j < Week[i].HalfHourSlots.Count; j++)
                {
                    //If earlier than 5:30 and later than 10:00, block the time slots. Applies to all days.
                    if (j < startIndex || j >= endIndex)
                    {
                        Week[i].BlockTimeSlot(j);
                    }
                }
            }
        }

        /// <summary>
        /// Lets the caller know if the row corresponding to a given index should be rendered on the site.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Boolean representing whether or not a "time" should be rendered for a week.</returns>
        public bool ShouldRender(int index)
        {
            //By default, render the row.
            int validCount = 0;
            foreach(var Day in Week)
            {
                if (Day.HalfHourSlots[index].validTimeSlot)
                {
                    validCount++;
                }
            }
            return validCount > 0;
        }

        public static WeekScheduleModel CreateFromSource()
        {
            /*
             * We are going to have to create a weekschedule from a database at some point.
             * TODO: after database creation, get this set up.
             * 
             */

            WeekScheduleModel temp = new WeekScheduleModel();
            return temp;
        }
        

    }
}
