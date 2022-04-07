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
using System.Diagnostics;

namespace Calendar
{
    public partial class InfoWindow : Window
    {
        CalendarContext context = new CalendarContext();
        Reminder reminderInfo;
        int id;
        public InfoWindow(int reminderID)
        {
            InitializeComponent();
            id = reminderID;
            Load(reminderID);
        }
        public void Load(int reminderID)
        {
            context = new CalendarContext();
            reminderInfo = (from r in context.Reminders
                                     where r.ID == id
                                     select r).Single();
            titleBox.Text = reminderInfo.title;
            if (reminderInfo.minute > 9) dateBox.Text = reminderInfo.hour + ":" + reminderInfo.minute;
            else dateBox.Text = reminderInfo.hour + ":0" + reminderInfo.minute;
            dayBox.Text = reminderInfo.day;
            noteBox.Text = reminderInfo.note;
            placeBox.Text = reminderInfo.place;
        }
            /*   =============================================
             *   ============== BUTTONS ======================
             *  ============================================== */
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow upd_window = new UpdateWindow(id);
            upd_window.ShowDialog();
            Load(id);
        }
        private void btnDelete_Clik(object sender, RoutedEventArgs e)
        {
            context.Reminders.Remove(reminderInfo);
            context.SaveChanges();
            this.Hide();
        }
    }
}
