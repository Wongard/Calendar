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
            int tmp;
            if (!(int.TryParse(hourBox.Text, out tmp) || int.TryParse(hourBox.Text, out tmp)))
            {
                MessageBox.Show("Time value cannot be empty!");
                return;
            }
            Reminder reminder = new Reminder()
            {
                title = titleBox.Text,
                place = placeBox.Text,
                note = noteBox.Text,
                day = dayBox.Text,
                hour = int.Parse(hourBox.Text),
                minute = int.Parse(minuteBox.Text)
            };
            if(context.AddNewReminder(reminder)) this.Hide();            
        }
    }
}
