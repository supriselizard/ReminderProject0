﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderProject
{
    public class ReminderDbManager
    {
        public List<Reminder> ReminderDatabase { get; private set; } = new List<Reminder>();

        public void AddReminder(Reminder reminder)
        {
            ReminderDatabase.Add(reminder);
        }

        // Useless, doesn't take in multiple reminders in a single day
        public List<Reminder> RemindersInCurrentWeek()
        {
            // index for RemInWeek and DaysThisWeek 
            // represents the days in the week
            // meaning index 0 is Sunday, 1 is Monday, etc.
            var RemInWeek = new List<Reminder>(7);
            var DaysThisWeek = new List<DateTime>(7);

            // Assume Monday is Today
            var sundayDateTime = DateTime.Today;
            var today = sundayDateTime.DayOfWeek;

            for (int i = (int)today; i > 0; i--)
            {
                sundayDateTime.AddDays(-1);
            }
            for (int i = 0; i < 7; i++)
            {
                DaysThisWeek[i] = sundayDateTime.AddDays(i);
            }

            foreach (var reminder in ReminderDatabase)
            {
                for (int i = 0; i < 7; ++i)
                {
                    if (reminder.DateDue.Date == DaysThisWeek[i].Date)
                        RemInWeek[i] = reminder;
                }
            }

            return RemInWeek;
        }

        public List<List<Reminder>> RemindersIn7Days()
        {
            var RemsInWeek = new List<List<Reminder>>(7);
            for (int i = 0; i < RemsInWeek.Capacity; ++i)
            {
                RemsInWeek.Add(new List<Reminder>());
            }

            foreach (var reminder in ReminderDatabase)
            {
                for (int i = 0; i < 7; ++i)
                {
                    if (reminder.DateDue.Date == DateTime.Today.AddDays(i))
                    {
                        RemsInWeek[i].Add(reminder);
                    }
                }
            }

            return RemsInWeek;
        }

        public List<List<Reminder>> RemInMonth()
        {
            var NumOfDaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var RemsInMonth = new List<List<Reminder>>(NumOfDaysInMonth);
            var DaysInMonth = new List<DateTime>(NumOfDaysInMonth);

            for (int i = 0; i < NumOfDaysInMonth; ++i)
                RemsInMonth.Add(new List<Reminder>());
            for (int i = 0; i < NumOfDaysInMonth; ++i)
                DaysInMonth.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, i + 1));

            foreach (var reminder in ReminderDatabase)
            {
                for (int i = 0; i < NumOfDaysInMonth; ++i)
                    if (reminder.DateDue.Date == DaysInMonth[i].Date)
                        RemsInMonth[i].Add(reminder);
            }

            return RemsInMonth;
        }
    }
}
