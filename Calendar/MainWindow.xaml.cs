﻿using System;
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
    public partial class MainWindow : Window
    {
        List<String> _days = new List <String> { "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};
        List<Reminder> reminders;
       // List<List<Reminder>> reminders_day;
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
        private void btnInsert_Clik(object sender, RoutedEventArgs e)
        {
            InsertWindow ins_window = new InsertWindow();
            ins_window.ShowDialog();
            Load();
        }

        private void btnRefresh_Clik(object sender, RoutedEventArgs e)
        {
            Load();
        }

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
