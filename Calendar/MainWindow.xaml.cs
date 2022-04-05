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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Reminder> reminders;
        public static ListBox lBox;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            using (var context = new CalendarContext())
            {
                reminders = context.Reminders.ToList();
            }
            reminderList.ItemsSource = reminders;
            
            Debug.WriteLine("ELO");
        }
        private void btnShowSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            var cos = (reminderList.SelectedItem as Reminder).title;
            MessageBox.Show(cos);
            //MessageBox.Show(cos);
            //MessageBox.Show((studentList.SelectedItem as Student).StudentName);
        }
        private void btnInsert_Clik(object sender, RoutedEventArgs e)
        {
            InsertWindow ins_window = new InsertWindow();
            ins_window.ShowDialog();
        }

        private void btnRefresh_Clik(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void btnInfo_Clik(object sender, RoutedEventArgs e)
        {
            int id = (reminderList.SelectedItem as Reminder).ID;
            InfoWindow inf_window = new InfoWindow(id);
            inf_window.ShowDialog();
        }
    }
    
}
