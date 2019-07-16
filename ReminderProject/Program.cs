using System;
using System.Collections.Generic;

namespace ReminderProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var DbManger = new ReminderDbManager();
            var Display = new DisplayReminders();
            var PickupBook = new Reminder(new DateTime(2019, 7, 16), "PickupBook");
            var TestReminder = new Reminder(new DateTime(2019, 7, 16), "TestReminder");
            var TestReminder0 = new Reminder(new DateTime(2019, 7, 17), "TestReminder0");
            var DropOffBooks = new Reminder(new DateTime(2019, 7, 23), "DropOffBooks");

            PickupBook.ReminderDesc = "Pickup Ender's Game from Central Library";
            DropOffBooks.ReminderDesc = "Drop Off 'Depth' and 'Doctor Faustus' at the Central Library";
            TestReminder.ReminderDesc = "Test description for TestReminder";
            TestReminder0.ReminderDesc = "Test description for TestRemidner0";

            DbManger.AddReminder(PickupBook);
            DbManger.AddReminder(DropOffBooks);
            DbManger.AddReminder(TestReminder);
            DbManger.AddReminder(TestReminder0);

            //Display.DisplayReminder(PickupBook);
            //Display.DisplayWeekWithRem(DbManger.RemindersIn7Days());
            Display.DisplayMonthWithRems(DbManger.RemInMonth());
        }
    }
}
