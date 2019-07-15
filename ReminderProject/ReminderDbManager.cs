using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderProject
{
    class ReminderDbManager
    {
        private List<Reminder> ReminderDatabase = new List<Reminder>();

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
            var DaysInWeek = new List<List<Reminder>>(7);
            for (int i = 0; i < DaysInWeek.Capacity; ++i)
            {
                DaysInWeek.Add(new List<Reminder>());
            }

            foreach (var reminder in ReminderDatabase)
            {
                for (int i = 0; i < 7; ++i)
                {
                    if (reminder.DateDue.Date == DateTime.Today.AddDays(i))
                    {
                        DaysInWeek[i].Add(reminder);
                    }
                }
            }

            return DaysInWeek;
        }
    }
}
