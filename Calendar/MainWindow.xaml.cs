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
using Newtonsoft.Json;
using System.Net;

namespace Calendar
{
    /// <summary>
    /// App's main window opened on start
    /// Shows all reminders from database and weather informations
    /// Allows to open other windows
    /// </summary>
    public partial class MainWindow : Window
    {
        List<String> _days = new List <String> { "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};
        List<Reminder> reminders;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        /// <summary>
        /// Loads reminders from database and shows them on the window below specific day
        /// Reminders are sorted by the time value -> earlier = highier
        /// </summary>
        public void Load()
        {
            using (var context = new CalendarContext())
            {
                foreach (string day in _days)
                {
                    reminders = (from r in context.Reminders
                                 where r.day == day
                                 orderby r.hour,r.minute          
                                 select r).ToList();
                    Loadto(day);
                }
            }
        }
        /// <summary>
        /// Inserts list of reminders to the given day column
        /// </summary>
        /// <param name="day"></param>
        public void Loadto(string day)
        {
            switch(day)
            {
                case "Monday":
                    mondayList.ItemsSource = reminders;
                    break;
                case "Tuesday": 
                    tuesdayList.ItemsSource = reminders;
                    break;
                case "Wednesday": 
                    wednesdayList.ItemsSource = reminders;
                    break;
                case "Thursday":
                    thursdayList.ItemsSource = reminders;
                    break;
                case "Friday":
                    fridayList.ItemsSource = reminders;
                    break;
                case "Saturday":
                    saturdayList.ItemsSource = reminders;
                    break;
                case "Sunday":
                    sundayList.ItemsSource = reminders;
                    break;
            }
        }
        /*   =============================================
         *   ============== BUTTONS ======================
         *  ============================================== */
        /// <summary>
        /// Opens "InsertWindow" window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Clik(object sender, RoutedEventArgs e)
        {
            InsertWindow ins_window = new InsertWindow();
            ins_window.ShowDialog();
            Load();
        }
        /// <summary>
        /// Refreshes the reminders shown on the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Clik(object sender, RoutedEventArgs e)
        {
            Load();
        }
        /// <summary>
        /// Opens "InfoWindow" window and pass the id of selected reminder if any reminder is selected
        /// Does nothing when no reminder is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Clik(object sender, RoutedEventArgs e)
        {
            int id=-1;//(reminderList.SelectedItem as Reminder).ID;
            if (mondayList.SelectedItem != null)         id = (mondayList.SelectedItem as Reminder).ID;
            else if (tuesdayList.SelectedItem != null)   id = (tuesdayList.SelectedItem as Reminder).ID;
            else if (wednesdayList.SelectedItem != null) id = (wednesdayList.SelectedItem as Reminder).ID;
            else if (thursdayList.SelectedItem != null)  id = (thursdayList.SelectedItem as Reminder).ID;
            else if (fridayList.SelectedItem != null)    id = (fridayList.SelectedItem as Reminder).ID;
            else if (saturdayList.SelectedItem != null)  id = (saturdayList.SelectedItem as Reminder).ID;
            else if (sundayList.SelectedItem != null)    id = (sundayList.SelectedItem as Reminder).ID;

            if (id == -1) return;
            InfoWindow inf_window = new InfoWindow(id);
            inf_window.ShowDialog();
            Load();
        }

        string APIkey = "180450b0a1b8191a37027a70e7eeac2f";

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            getWeather();
        }
        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", TBcity.Text, APIkey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                labCondition.Content = Info.weather[0].main;
                labTemp.Content = Info.main.temp;
                labWindspeed.Content = Info.wind.speed.ToString();
                labPressure.Content = Info.main.pressure.ToString();
            }
        }
    }
    
}
