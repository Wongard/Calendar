using System.Windows;


namespace Calendar
{
    /// <summary>
    /// Allows to insert new reminder into database
    /// </summary>
    public partial class InsertWindow : Window
    {
        CalendarContext context = new CalendarContext();
        /// <summary>
        /// Initialize window components
        /// </summary>
        public InsertWindow()
        {
            InitializeComponent();
        }
        /*   =============================================
         *   ============== BUTTONS ======================
         *  ============================================== */

        /// <summary>
        /// Creates new reminder with box values and tries to add it to database
        /// On succes hides this window
        /// On failure displayes Message Box with the first encountered error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
