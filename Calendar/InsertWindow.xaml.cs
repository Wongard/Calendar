using System.Windows;


namespace Calendar
{
    public partial class InsertWindow : Window
    {
        CalendarContext context = new CalendarContext();
        public InsertWindow()
        {
            InitializeComponent();
        }
        /*   =============================================
         *   ============== BUTTONS ======================
         *  ============================================== */

        private void btnAdd_Clik(object sender, RoutedEventArgs e)
        {
            string dana = hourBox.Text;
            Reminder reminder = new Reminder()
            {
                title = titleBox.Text,
                place = placeBox.Text,
                note = noteBox.Text,
                day = dayBox.Text,
                hour = int.Parse(hourBox.Text),
                minute = int.Parse(minuteBox.Text)
            };
            context.Reminders.Add(reminder);
            context.SaveChanges();
            this.Hide();
        }
    }
}
