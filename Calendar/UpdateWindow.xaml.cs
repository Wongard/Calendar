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
    /// <summary>
    ///  UpdateWindow allows user to edit chosen reminder
    /// </summary>
    public partial class UpdateWindow : Window
    {
        CalendarContext context = new CalendarContext();
        int id;
        Reminder reminderUpdate;
        /// <summary>
        /// Selects reminder with given id from database 
        /// Fulfills the boxes with attributes of that reminder
        /// Saves edited reminder id in the class for other methods
        /// </summary>
        /// <param name="reminderID">Id of the reminder we want to update</param>
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
            hourBox.Text = Convert.ToString(reminderUpdate.hour);
            minuteBox.Text = Convert.ToString(reminderUpdate.minute);
        }
        /*   =============================================
         *   ============== BUTTONS ======================
         *  ============================================== */

        /// <summary>
        /// Creates new reminder with box values and tries do update edited reminder
        /// On failure displays Message Box with the first encountered error
        /// On success closes this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Clik(object sender, RoutedEventArgs e)
        {
            int tmp;
            if (!(int.TryParse(hourBox.Text, out tmp) || int.TryParse(hourBox.Text, out tmp)))
            {
                MessageBox.Show("Time value cannot be empty!");
                return;
            }
            Reminder updatedReminder = new Reminder()
            {
                title = titleBox.Text,
                place = placeBox.Text,
                note = noteBox.Text,
                day = dayBox.Text,
                hour = int.Parse(hourBox.Text),
                minute = int.Parse(minuteBox.Text)
            };
            if(context.UpdateReminder(reminderUpdate.ID,updatedReminder)) this.Hide();
        }
    }

}
