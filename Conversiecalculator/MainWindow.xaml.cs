using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace Conversiecalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();

        //double InputValues = 0;
        //string FromValues = "";
        //string ToValues = "";
        //double Results = 0;


        public MainWindow()
        {
            InitializeComponent();
            BindValues();
            BindConversions();
        }

        public void DbConnect()
        {
            string connectionString;
            SqlConnection con;

            connectionString = @"Data Source=DESKTOP-BRHFHS4;Initial Catalog=Conversies;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
        }

        private void BindConversions()
        {
            DbConnect();
            DataTable history = new DataTable();
            DataColumn InputValues = new DataColumn("InputValues", typeof(double));
            DataColumn FromValues = new DataColumn("FromValues", typeof(string));
            DataColumn ToValues = new DataColumn("ToValues", typeof(string));
            DataColumn Results = new DataColumn("Results", typeof(double));
            DataRow firstRow = history.NewRow();
            firstRow[0] = 1;
            firstRow[1] = 2;
            firstRow[2] = 3;
            firstRow[3] = 4;
            cmd = new SqlCommand("SELECT Id, InputValues, FromValues, ToValues, Results FROM ConversieHistory", con);
            cmd.CommandType = CommandType.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(history);
            con.Close();


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
            dtValues.Rows.Add("EUR", 2);
            dtValues.Rows.Add("USD", 3);
            dtValues.Rows.Add("POUND", 6);


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
            double ConvertedValue;

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
                ConvertedValue = double.Parse(UserInputValue.Text);
                ConversionResult.Content = CmbToValue.Text + " " + ConvertedValue.ToString("N2");
            }
            //fills
            else
            {
                ConvertedValue = (double.Parse(CmbFromValue.SelectedValue.ToString()) *
                    double.Parse(UserInputValue.Text)) /
                    double.Parse(CmbToValue.SelectedValue.ToString());

                ConversionResult.Content = ConvertedValue.ToString("N2") + " " + CmbToValue.Text;
                //double InputValues = double.Parse(UserInputValue.Text);
                //string FromValues = CmbFromValue.Text;
                //string ToValues = CmbToValue.Text;
                //double Results = ConvertedValue;

                DbConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO [ConversieHistory](InputValues, FromValue, ToValues, Results) " +
                    "VALUES (@UserInputValue, @CmbFromValue, @CmbToValue, @ConvertedValue)";
                cmd.Parameters.AddWithValue("@UserInputValue", UserInputValue.Text);
            }


        }

        //clears all fields on click and calls the method ClearControls()
        private void ResetConversion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClearControls();
        }


        private void NumbersOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SwapCmbValues_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        //
        private void ClearControls()
        {
            ConversionResult.Content = "";
            UserInputValue.Text = string.Empty;
            if (CmbFromValue.Items.Count > 0)
                CmbToValue.SelectedIndex = 0;
            if (CmbToValue.Items.Count > 0)
                CmbFromValue.SelectedIndex = 0;
            UserInputValue.Focus();
        }

        private void DeleteHistory_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}