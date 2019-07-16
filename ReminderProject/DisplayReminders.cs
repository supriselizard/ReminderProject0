using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ReminderProject
{
    public class DisplayReminders
    {
        private string _displayBorderBig = "--------------------";
        private string _displayBorderSmall = "----------";
        private string _displayBorderVerySmall = "-----";

        public void DisplayReminder(Reminder reminder)
        {
            Console.WriteLine(_displayBorderBig);
            Console.WriteLine(reminder.ReminderName);
            Console.WriteLine(_displayBorderBig);
            Console.WriteLine("Description :");
            if (!string.IsNullOrWhiteSpace(reminder.ReminderDesc))
            {
                Console.WriteLine(reminder.ReminderDesc);
            }
            else
            {
                Console.WriteLine("No Description");
            }
            Console.WriteLine();
            Console.WriteLine("The task is set to be finished by {0}", reminder.DateDue.ToShortDateString());
        }

        public void DisplayWeekWithRem(List<List<Reminder>> RemsInWeek)
        {
            Console.WriteLine(_displayBorderBig);

            for (int i = 0; i < 7; ++i)
            {
                if (!RemsInWeek[i].Any())
                    continue;

                Console.WriteLine(_displayBorderSmall);
                Console.WriteLine(RemsInWeek[i][0].DateDue.DayOfWeek);

                foreach (var reminder in RemsInWeek[i])
                {
                    Console.WriteLine(_displayBorderVerySmall);
                    Console.WriteLine("Title: " + reminder.ReminderName);
                    Console.WriteLine("Desc: " + reminder.ReminderDesc);
                    Console.WriteLine("DateDue: {0}", reminder.DateDue);
                    Console.WriteLine(_displayBorderVerySmall);
                }

                Console.WriteLine(_displayBorderSmall);
            }

            Console.WriteLine(_displayBorderBig);
        }

        public void DisplayMonthWithRems(List<List<Reminder>> RemsInMonth)
        {
            Console.WriteLine(_displayBorderBig);
            for (int i = 0; i < RemsInMonth.Capacity; ++i)
            {
                if (!RemsInMonth[i].Any())
                    continue;

                Console.WriteLine(_displayBorderSmall);
                Console.WriteLine($"{RemsInMonth[i][0].DateDue.DayOfWeek}, {(MonthsEnum)RemsInMonth[i][0].DateDue.Month} {RemsInMonth[i][0].DateDue.Day}");
                foreach (var reminder in RemsInMonth[i])
                {
                    Console.WriteLine(_displayBorderVerySmall);
                    Console.WriteLine(reminder.ReminderName);
                    Console.WriteLine(reminder.ReminderDesc);
                    Console.WriteLine(_displayBorderVerySmall);
                }
                Console.WriteLine(_displayBorderSmall);
            }
            Console.WriteLine(_displayBorderBig);
        }
    }
}
