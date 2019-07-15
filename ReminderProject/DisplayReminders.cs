using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderProject
{
    class DisplayReminders
    {
        private string _displayBorderBig = "--------------------";
        private string _displayBorderSmall = "----------";

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

        public void DisplayWeekWithRem()
        {
        }
    }
}
