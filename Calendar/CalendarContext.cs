using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;

namespace Calendar
{
    public class CalendarContext : DbContext
    {
        // Your context has been configured to use a 'CalendarContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Calendar.CalendarContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CalendarContext' 
        // connection string in the application configuration file.
        public CalendarContext() : base("name=CalendarContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Reminder> Reminders { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public bool AddNewReminder(Reminder reminder)
        {
            if (!CheckReminderValues(reminder)) return false;
            using (var context = new CalendarContext())
            {
                context.Reminders.Add(reminder);
                context.SaveChanges();
                return true;
            }
        }
        public bool UpdateReminder(int id, Reminder updatedReminer)
        {
            if (!CheckReminderValues(updatedReminer)) return false;
            using (var context = new CalendarContext())
            {
                Reminder reminder = (from r in context.Reminders
                                where r.ID == id
                                select r).Single();
                context.Entry(reminder).Entity.title = updatedReminer.title;
                context.Entry(reminder).Entity.place = updatedReminer.place;
                context.Entry(reminder).Entity.note = updatedReminer.note;
                context.Entry(reminder).Entity.day = updatedReminer.day;
                context.Entry(reminder).Entity.hour = updatedReminer.hour;
                context.Entry(reminder).Entity.minute = updatedReminer.minute;
                context.SaveChanges();
            }
            return true;
        }
        public bool CheckReminderValues(Reminder reminder)
        {
            if (reminder.title == "") MessageBox.Show("Title cannot be empty!");
            else if (reminder.day == "") MessageBox.Show("You have to choose a day!");
            else if (reminder.hour < 0 || reminder.hour > 23) MessageBox.Show("Hour value must be in range (0-23)");
            else if (reminder.minute < 0 || reminder.minute > 59) MessageBox.Show("Minute value must be in range (0-59)");
            else return true;
            return false;
        }
        public Reminder GetReminderByDay(string day)
        {
            using(var context = new CalendarContext())
            {
                var query = context.Reminders
                    .Where(r => r.title == day)
                    .FirstOrDefault<Reminder>();
                return query;
            }
        }
    }
    public class CalendarDbInitializer : CreateDatabaseIfNotExists<CalendarContext> //DropCreateDatabaseAlways<CalendarContext>
    {
        /*protected override void Seed(CalendarContext context)
        {
            var reminders = new List<Reminder>
            {
                new Reminder() {ID = 1001, title="Silownia", note="Spocimy sie panowie", place="Tam gdzie zawsze",day="Monday"},
                new Reminder() {ID = 1002, title="Jedzenie", note="Am am",day="Friday", hour=12, minute=15},
                new Reminder() {ID = 1003, title="Spanie", note="Rezydent Œpi¹cy", day = "Friday",hour=6,minute=0}
            };
            reminders.ForEach(c => context.Reminders.Add(c));
            context.SaveChanges();
        }*/
    }



    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}