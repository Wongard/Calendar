using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calendar
{
    public partial class UpdateWindow : Window
    {
        CalendarContext context = new CalendarContext();
        int id;
        Reminder reminderUpdate;
        public UpdateWindow(int reminderID)
        {
            InitializeComponent();
            id = reminderID;

            reminderUpdate = (from r in context.Reminders
                                     where r.ID == id
                                     select r).Single();
            titleBox.Text = reminderUpdate.title;
            dayBox.SelectedValue = reminderUpdate.day;
            placeBox.Text = reminderUpdate.place;
            noteBox.Text = reminderUpdate.note;
            
        }
        /*   =============================================
         *   ============== BUTTONS ======================
         *  ============================================== */
        private void btnOK_Clik(object sender, RoutedEventArgs e)
        {
            context.Entry(reminderUpdate).Entity.title = titleBox.Text;
            context.Entry(reminderUpdate).Entity.place = placeBox.Text;
            context.Entry(reminderUpdate).Entity.note = noteBox.Text;
            context.Entry(reminderUpdate).Entity.day = dayBox.Text;
            context.Entry(reminderUpdate).Entity.hour = int.Parse(hourBox.Text);
            context.Entry(reminderUpdate).Entity.minute = int.Parse(minuteBox.Text);
            context.SaveChanges();
            this.Hide();
        }
    }

}
