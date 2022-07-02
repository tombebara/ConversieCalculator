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
        Sqlcaller Sqlcaller;

        double InputValues = 0;
        string FromValues = "";
        string ToValues = "";
        double Results = 0;
        private DataRow dr;

        public MainWindow()
        {
            InitializeComponent();
            BindValues();
        }

        public void DbConnect()
        {
            string connectionString;
            SqlConnection con;

            connectionString = @"Data Source=DESKTOP-BRHFHS4;Initial Catalog=Conversies;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
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
                string FromValues = CmbFromValue.Text;
                string ToValues = CmbToValue.Text;
                double Results = ConvertedValue;
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

                    //Read
                    /*DataTable dt = new DataTable();
                    DataRow dr;
                    *//*DataColumn col1 = new DataColumn("InputValues", typeof(double));
                    DataColumn col2 = new DataColumn("ToValues", typeof(string));
                    DataColumn col3 = new DataColumn("Results", typeof(double));
                    DataColumn col4 = new DataColumn("FromValues", typeof(string));*//*
                    dt.Columns.Add("InputValues", typeof(double));
                    dt.Columns.Add("ToValues", typeof(string));
                    dt.Columns.Add("Results", typeof(double));
                    dt.Columns.Add("FromValues", typeof(string));
                    int i = 0;
                    var query = from p in db.ConversieHistory
                                orderby p.Id
                                select p;
                    foreach (var item in query)
                    {
                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        dt.Rows[i][] = item.InputValues;
                        dt.Rows[i][] = item.ToValues;
                        dt.Rows[i][col3] = item.Results;
                        dt.Rows[i][col4] = item.FromValues;
                        i++;
                    }
                    this.DgConversionHistory.DataContext = dt;*/


                }
            }

            // from id input results to
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

        private void DgConversionHistory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}