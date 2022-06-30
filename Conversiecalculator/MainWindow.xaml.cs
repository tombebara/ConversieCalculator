namespace Conversiecalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void convertInput_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            conversionResult.Text = "Geconverteerd";
        }
    }
}