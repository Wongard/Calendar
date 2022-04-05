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
    /// Logika interakcji dla klasy InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        CalendarContext context = new CalendarContext();
        public InsertWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Clik(object sender, RoutedEventArgs e)
        {
            Reminder reminder = new Reminder()
            {
                title = titleBox.Text,
                place = placeBox.Text,
                note = noteBox.Text,
                date = dateBox.DisplayDate
            };
            context.Reminders.Add(reminder);
            context.SaveChanges();
            this.Hide();
        }
    }
}
