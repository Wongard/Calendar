using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Collections.ObjectModel;

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
        public void AddNewReminder(Reminder reminder)
        {
            using(var context = new CalendarContext())
            {
                context.Reminders.Add(reminder);
                context.SaveChanges();
            }
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
    public class CalendarDbInitializer : DropCreateDatabaseAlways<CalendarContext>
    {
        protected override void Seed(CalendarContext context)
        {
            var reminders = new List<Reminder>
            {
                new Reminder() {ID = 1001, title="Silownia", note="Spocimy sie panowie", place="Tam gdzie zawsze", date=DateTime.Now},
                new Reminder() {ID = 1002, title="Jedzenie", note="Am am",date=DateTime.Now}
            };
            reminders.ForEach(c => context.Reminders.Add(c));
            context.SaveChanges();
        }
    }



    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}