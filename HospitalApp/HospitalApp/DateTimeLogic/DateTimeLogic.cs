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
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    allDates.Add(date);

            return allDates.ToArray();
        }

        public DateTime[] GetWorkingHours()
        {
            DateTime[] dt = GetWorkingDays();
            List<DateTime> myHours = new List<DateTime>();

            for (DateTime date = dt[0]; date <= dt[dt.Length - 1]; date = date.AddHours(1))
                if (date.TimeOfDay < TimeSpan.Parse("17:00") && date.TimeOfDay >= TimeSpan.Parse("10:00"))
                    myHours.Add(date);

            return myHours.ToArray();
        }

        public DateTime[] DiscardRandomTimes()
        {
            Random rnd = new Random();
      
            return GetWorkingHours().Except(GetWorkingHours().OrderBy(x => rnd.Next()).Take(1200).ToArray()).ToArray();
        }

        public string[] DiscardRandomTimesString()
        {
            List<string> myDates = new List<string>();

            for (int i = 0; i < DiscardRandomTimes().Length; i++)
                myDates.Add(DiscardRandomTimes()[i].ToString("yyyy-MM-dd hh tt"));

            return myDates.ToArray();
        }
    }
}
