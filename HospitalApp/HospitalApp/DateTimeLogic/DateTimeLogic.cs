using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.DateTimeLogic
{
    public class DateLogic
    { 
        public DateTime[] GetWorkingDays()
        {
            List<DateTime> allDates = new List<DateTime>();

            for (DateTime date = DateTime.Today; date <= DateTime.Now.AddDays(180); date = date.AddHours(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    allDates.Add(date);
            }

            return allDates.ToArray();
        }

        public string[] GetWorkingDaysString()
        {
            List<string> allDates = new List<string>();

            for (DateTime date = DateTime.Today; date <= DateTime.Now.AddDays(90); date = date.AddHours(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    allDates.Add(date.ToString("yyyy-MM-dd"));
            }

            return allDates.ToArray();
        }

        public DateTime[] GetWorkingHours()
        {
            DateTime[] dt = GetWorkingDays();
            List<DateTime> myHours = new List<DateTime>();

            for (DateTime date = dt[0]; date <= dt[dt.Length - 1]; date = date.AddHours(1))
            {
                if (date.TimeOfDay < TimeSpan.Parse("17:00") && date.TimeOfDay >= TimeSpan.Parse("10:00"))
                    myHours.Add(date);
            }

            return myHours.ToArray();
        }

        public string[] GetWorkingHoursString()
        {
            DateTime[] dt = GetWorkingDays();
            List<string> allDates = new List<string>();

            for (DateTime date = dt[0]; date <= dt[dt.Length - 1]; date = date.AddHours(1))
            {
                if (date.TimeOfDay < TimeSpan.Parse("17:00") && date.TimeOfDay >= TimeSpan.Parse("10:00"))
                    allDates.Add(date.ToString("yyyy-MM-dd hh tt"));
            }

            return Cropp();
        }

        public string[] Cropp()
        {
            DateTime[] dt = GetWorkingHours();
            List<string> allDates = new List<string>();
            
            for(int i = 2; i < dt.Length; i++)
            {
                allDates.Add(dt[i].ToString("yyyy-MM-dd hh tt"));
            }

            return allDates.ToArray();
        }

        public DateTime[] DiscardRandomTimes()
        {
            DateTime[] dt = GetWorkingHours();
            Random rnd = new Random();
            DateTime[] discard = dt.OrderBy(x => rnd.Next()).Take(1200).ToArray();

            DateTime[] myDates = dt.Except(discard).ToArray();

            return myDates;
        }

        public string[] DiscardRandomTimesString()
        {
            List<string> myDates = new List<string>();
            DateTime[] dt = DiscardRandomTimes();

            for (int i = 0; i < dt.Length; i++)
                myDates.Add(dt[i].ToString("yyyy-MM-dd hh tt"));

            return myDates.ToArray();
        }

        public int GetNumber()
        {
            DateTime[] dt = GetWorkingDays();
            return dt.Length;
        }
    }
}
