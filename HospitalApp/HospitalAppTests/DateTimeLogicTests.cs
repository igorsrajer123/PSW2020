using HospitalApp.DateTimeLogic;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HospitalAppTests
{
    public class DateTimeLogicTests
    {
        private DateLogic _dateLogic = new DateLogic();

        [Fact]
        public void Get_working_days()
        {
            DateTime[] myWorkingDays = EstablishWorkingDays();

            DateTime[] workingDays = _dateLogic.GetWorkingDays();

            workingDays.ShouldBeEquivalentTo(myWorkingDays);
        }

        [Fact]
        public void Get_working_hours()
        {
            DateTime[] myWorkingHours = EstablishWorkingHours();

            DateTime[] workingHours = _dateLogic.GetWorkingHours();

            workingHours.ShouldBeEquivalentTo(myWorkingHours);
        }

        [Fact]
        public void Discard_random_times()
        {
            DateTime[] workingHours = EstablishRandomHours();

            DateTime[] myWorkingHours = _dateLogic.DiscardRandomHours();

            workingHours.Length.ShouldBeEquivalentTo(myWorkingHours.Length);
        }

        [Fact]
        public void Discard_random_times_string()
        {
            string[] hours = EstablishRandomHoursString();

            string[] myHours = _dateLogic.DiscardRandomHoursString();

            hours.Length.ShouldBeEquivalentTo(myHours.Length);
        }

        private DateTime[] EstablishWorkingDays()
        {
            List<DateTime> workingDays = new List<DateTime>();

            for (var date = DateTime.Today; date < DateTime.Now.AddDays(180); date = date.AddHours(1))
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    workingDays.Add(date);

            return workingDays.ToArray();
        }

        private DateTime[] EstablishWorkingHours()
        {
            DateTime[] dateTime = EstablishWorkingDays();
            List<DateTime> myHours = new List<DateTime>();

            for (DateTime date = dateTime[0]; date <= dateTime[dateTime.Length - 1]; date = date.AddHours(1))
                if (date.TimeOfDay < TimeSpan.Parse("17:00") && date.TimeOfDay >= TimeSpan.Parse("10:00"))
                    myHours.Add(date);

            return myHours.ToArray();
        }

        private DateTime[] EstablishRandomHours()
        {
            Random random = new Random();

            return EstablishWorkingHours().Except(EstablishWorkingHours().OrderBy(x => random.Next()).Take(1200).ToArray()).ToArray();
        }

        private string[] EstablishRandomHoursString()
        {
            List<string> myDates = new List<string>();

            for (int i = 0; i < EstablishRandomHours().Length; i++)
                myDates.Add(EstablishRandomHours()[i].ToString("yyyy-MM-dd hh tt"));

            return myDates.ToArray();
        }
    }
}
