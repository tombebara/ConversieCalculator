using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
namespace Conversiecalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataRow dr;

        public MainWindow()
        {
            InitializeComponent();
            BindValues();
        }

        public void FillHistory()
        {
            using (var db = new Model1())
            {
                //Read

                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("Invoer", typeof(double));
                dt.Columns.Add("Van", typeof(string));
                dt.Columns.Add("Naar", typeof(string));
                dt.Columns.Add("Resultaat", typeof(double));
                int i = 0;
                var query = from p in db.ConversieHistory
                            orderby p.Id
                            select p;
                foreach (var item in query)
                {
                    dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    dt.Rows[i][0] = item.InputValues;
                    dt.Rows[i][1] = item.FromValues;
                    dt.Rows[i][2] = item.ToValues;
                    dt.Rows[i][3] = item.Results;
                    i++;
                }
                DgHistory.ItemsSource = dt.DefaultView;
            }
        }

        public void DeleteConversionHistory()
        {
            using (var db = new Model1())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [ConversieHistory]");
            }
        }

        //Displays combobox items in a new datatable
        private void BindValues()
        {
            //Creates new datatable
            DataTable dtValues = new DataTable();

            //Adds collumn in the datatable
            dtValues.Columns.Add("Text");
            dtValues.Columns.Add("Value");

            //Add rows in the datatable with text and value
            dtValues.Rows.Add("Selecteer", 0);
            dtValues.Rows.Add("EUR", 1);
            dtValues.Rows.Add("USD", 1.03);
            dtValues.Rows.Add("POUND", 0.86);
            dtValues.Rows.Add("LIR", 17.46);
            dtValues.Rows.Add("KROON", 10.79);


            CmbFromValue.ItemsSource = dtValues.DefaultView;
            CmbFromValue.DisplayMemberPath = "Text";
            CmbFromValue.SelectedValuePath = "Value";
            CmbFromValue.SelectedIndex = 0;

            CmbToValue.ItemsSource = dtValues.DefaultView;
            CmbToValue.DisplayMemberPath = "Text";
            CmbToValue.SelectedValuePath = "Value";
            CmbToValue.SelectedIndex = 0;
        }



        private void ConvertInput_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Creates the variable as ConvertedValue with double datatype to store currency converted value
            double convertedValue;

            //Check if the amount textbox  is null or blank
            if (UserInputValue == null || UserInputValue.Text.Trim() == "")
            {
                MessageBox.Show("Vul een getal in", "Foute invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                //After clicking on messagebox OK set focus on amount textbox
                UserInputValue.Focus();
                return;
            }
            //Checks if a correct item from the ToComboBox is selected
            else if (CmbFromValue.SelectedIndex == 0 || CmbFromValue.SelectedValue == null)
            {
                MessageBox.Show("Selecteer juiste conversie van", "Foute invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                CmbFromValue.Focus();
                return;
            }
            //Checks if a correct item from the ToComboBox is selected
            else if (CmbToValue.SelectedIndex == 0 || CmbToValue.SelectedValue == null)
            {
                MessageBox.Show("Selecteer juiste conversie naar", "Foute invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                CmbToValue.Focus();
                return;
            }

            //Checks if the from and to Cmb are the same so no conversion happens and fills ConvertedValue
            if (CmbFromValue.Text == CmbToValue.Text)
            {
                convertedValue = double.Parse(UserInputValue.Text);
                ConversionResult.Content = CmbToValue.Text + " " + convertedValue.ToString("N2");
            }
            //fills
            else
            {
                convertedValue = (double.Parse(CmbFromValue.SelectedValue.ToString()) *
                    double.Parse(UserInputValue.Text)) /
                    double.Parse(CmbToValue.SelectedValue.ToString());

                ConversionResult.Content = convertedValue.ToString("N2") + " " + CmbToValue.Text;
                string FromValues = CmbFromValue.Text;
                string ToValues = CmbToValue.Text;
                convertedValue = System.Math.Round(convertedValue, 2);
                double Results = convertedValue;
                double InputValues = double.Parse(UserInputValue.Text);

                using (var db = new Model1())
                {
                    //Create
                    var FValue = FromValues;
                    var TValue = ToValues;
                    var Result = Results;
                    var IValue = InputValues;

                    var FromV = new ConversieHistory { InputValues = IValue, ToValues = TValue, Results = Result, FromValues = FValue };
                    db.ConversieHistory.Add(FromV);
                    db.SaveChanges();
                }
                FillHistory();
            }

            // from id input results to
        }

        private void ResetConversion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClearControls();
        }

        //restricts the user input to numbers and dots only.
        private void NumbersOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+[.]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SwapCmbValues_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int indexFrom = CmbFromValue.SelectedIndex;
            int indexTo = CmbToValue.SelectedIndex;
            CmbToValue.SelectedIndex = indexFrom;
            CmbFromValue.SelectedIndex = indexTo;
        }

        //clears every field and sets combobox to default selected index
        private void ClearControls()
        {
            ConversionResult.Content = "";
            UserInputValue.Text = string.Empty;
            if (CmbFromValue.Items.Count > 0)
                CmbToValue.SelectedIndex = default;
            if (CmbToValue.Items.Count > 0)
                CmbFromValue.SelectedIndex = default;
            UserInputValue.Focus();
        }

        private void DgConversionHistory_Loaded(object sender, RoutedEventArgs e)
        {
            FillHistory();
        }

        private void DgHistory_Loaded(object sender, RoutedEventArgs e)
        {
            FillHistory();
        }

        private void DgConversionHistory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void DeleteHistory_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Wil je de conversiegeschiedenis verwijderen?",
            "Verwijderen?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                DeleteConversionHistory();
                FillHistory();
            }
            else if (result == MessageBoxResult.No)
            {
                return;
            }
        }

        private void SwapCmbValues_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {

        }
    }
}