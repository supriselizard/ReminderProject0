using System;
using System.Collections.Generic;

namespace ReminderProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var Display = new DisplayReminders();
            var DbManager = new ReminderDbManager();

            int input;
            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine($"1: Add a Reminder, there are {DbManager.ReminderDatabase.Count} Reminder(s) in storage.");
                Console.WriteLine("2: Display a single Reminder.");
                Console.WriteLine("3: Display the Reminders in the next 7 days.");
                Console.WriteLine("4: Display the Reminders in the current month.");
                Console.WriteLine("5: Delete a Reminder");
                Console.WriteLine("6: Exit the Program.");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());

                    if (input < 0 || input > 6)
                        throw new InvalidOperationException();
                }
                catch
                {
                    Console.WriteLine("Your Input is Invalid, Please Try Again");
                    continue;
                }


                switch (input)
                {
                    case (int)ChoicesEnum.AddAReminder:

                        int minute, hour, day, month, year;
                        string name, desc;

                        while (true)
                        {
                            //NAME
                            Console.WriteLine("Please enter in the title of your Reminder");
                            name = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Invalid Name, please try again.");
                                continue;
                            }
                            break;
                        }

                        while (true)
                        {
                            //MINUTE
                            Console.WriteLine("Please enter in the minute in the hour that the Reminer is due");

                            try
                            {
                                minute = Convert.ToInt32(Console.ReadLine());
                                if (minute < 0 || minute > 59)
                                    throw new InvalidOperationException();
                            }
                            catch
                            {
                                Console.WriteLine("Your Input is Invalid, Please Try Again");
                                continue;
                            }
                            break;
                        }

                        while (true)
                        {
                            //HOUR
                            Console.WriteLine("Please enter in the hour that the Reminer is due (24-hour format)");

                            try
                            {
                                hour = Convert.ToInt32(Console.ReadLine());
                                if (hour < 0 || hour > 23)
                                    throw new InvalidOperationException();
                            }
                            catch
                            {
                                Console.WriteLine("Your Input is Invalid, Please Try Again");
                                continue;
                            }
                            break;
                        }

                        while (true)
                        {
                            //MONTH
                            Console.WriteLine("Please enter in the number of the month that the Reminer is due");

                            try
                            {
                                month = Convert.ToInt32(Console.ReadLine());
                                if (month < 0 || month > 12)
                                    throw new InvalidOperationException();
                            }
                            catch
                            {
                                Console.WriteLine("Your Input is Invalid, Please Try Again");
                                continue;
                            }
                            break;
                        }

                        while (true)
                        {
                            //YEAR
                            Console.WriteLine("Please enter in the year that the Reminer is due");

                            try
                            {
                                year = Convert.ToInt32(Console.ReadLine());
                                if (year < DateTime.Now.Year)
                                    throw new InvalidOperationException();
                            }
                            catch
                            {
                                Console.WriteLine("Your Input is Invalid, Please Try Again");
                                continue;
                            }
                            break;
                        }

                        while (true)
                        {
                            //DAY
                            Console.WriteLine("Please enter in the day that the Reminer is due");

                            try
                            {
                                day = Convert.ToInt32(Console.ReadLine());
                                if (day < 0 || day > DateTime.DaysInMonth(year, month))
                                    throw new InvalidOperationException();
                            }
                            catch
                            {
                                Console.WriteLine("Your Input is Invalid, Please Try Again");
                                continue;
                            }
                            break;
                        }

                        Console.WriteLine("Please enter in a small description of your Reminder.");
                        desc = Console.ReadLine();

                        var newRem = new Reminder(new DateTime(year, month, day, hour, minute, 0), name);
                        if (!string.IsNullOrWhiteSpace(desc))
                            newRem.ReminderDesc = desc;

                        DbManager.AddReminder(newRem);

                        Console.WriteLine("Your Reminder has been added.");
                        break;


                    case (int)ChoicesEnum.DisplaySingleRem:

                        if (DbManager.ReminderDatabase.Count < 1)
                        {
                            Console.WriteLine("You cannot view Reminders, when there are no Reminders in the database.");
                            break;
                        }

                        while (true)
                        {
                            int choice;
                            Console.WriteLine("Which Reminder do you want to display?");
                            for (int i = 0; i < DbManager.ReminderDatabase.Count; ++i)
                            {
                                Console.WriteLine($"{i + 1}: {DbManager.ReminderDatabase[i].ReminderName}");
                            }

                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                                if (choice < 0 || choice > DbManager.ReminderDatabase.Count)
                                    throw new InvalidOperationException();
                            }
                            catch
                            {
                                Console.WriteLine("Your Input is Invalid, Please Try Again");
                                continue;
                            }

                            Display.DisplayReminder(DbManager.ReminderDatabase[choice - 1]);
                            break;
                        }
                        break;

                    case (int)ChoicesEnum.DisplayWeekAhead:

                        Display.DisplayWeekWithRem(DbManager.RemindersIn7Days());
                        break;

                    case (int)ChoicesEnum.DisplayMonth:

                        Display.DisplayMonthWithRems(DbManager.RemInMonth());
                        break;

                    case (int)ChoicesEnum.DeleteReminder:

                        if (DbManager.ReminderDatabase.Count < 1)
                        {
                            Console.WriteLine("You cannot delete any Reminders, when there are no Reminders in the database.");
                            break;
                        }

                        while (true)
                        {
                            int choice;
                            Console.WriteLine("Which Reminder do you want to delete?");
                            for (int i = 0; i < DbManager.ReminderDatabase.Count; ++i)
                            {
                                Console.WriteLine($"{i + 1}: {DbManager.ReminderDatabase[i].ReminderName}");
                            }

                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                                if (choice < 0 || choice > DbManager.ReminderDatabase.Count)
                                    throw new InvalidOperationException();
                            }
                            catch
                            {
                                Console.WriteLine("Your Input is Invalid, Please Try Again");
                                continue;
                            }

                            DbManager.DeleteReminder(DbManager.ReminderDatabase[choice - 1]);
                            DbManager.ReminderDatabase.Remove(DbManager.ReminderDatabase[choice - 1]);
                            break;
                        }
                        break;

                    case (int)ChoicesEnum.Exit:
                        break;


                    default:

                        Console.WriteLine("Invalid Choice.");
                        break;
                }
                if (input == (int)ChoicesEnum.Exit)
                    break;
            }
        }
    }
}
