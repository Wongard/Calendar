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
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        CalendarContext context = new CalendarContext();
        public InfoWindow(int reminderID)
        {
            InitializeComponent();
            int id = reminderID;

            Reminder reminderInfo = (from r in context.Reminders
                                     where r.ID == id
                                     select r).Single();
            titleBox.Text = reminderInfo.title;
            dateBox.DataContext = reminderInfo.date;
            //int godizna = reminderInfo.date.Year;
            noteBox.Text = reminderInfo.note;
            placeBox.Text = reminderInfo.place;
        }

        private void dateBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
        }
    }
}
