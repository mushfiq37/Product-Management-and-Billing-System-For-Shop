using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Baby_Choice
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockUpdateButton_Click(object sender, EventArgs e)
        {
            global.stockUpdate = 1;

            if (global.login == 1)
            {
                new UpdateStock().Show();
                this.Hide();
            }
            else
            {
                new Login().Show();
                this.Hide();
            }
        }

        private void stockStatusButton_Click(object sender, EventArgs e)
        {
            global.stockStatus = 1;

            if (global.login == 1)
            {
                new StockStatus().Show();
                this.Hide();
            }
            else
            {
                new Login().Show();
                this.Hide();
            }
        }

        private void transactionButton_Click(object sender, EventArgs e)
        {
            global.transactions = 1;

            if (global.login == 1)
            {
                new Transactions().Show();
                this.Hide();
            }
            else
            {
                new Login().Show();
                this.Hide();
            }
        }

        private void proceedButton_Click(object sender, EventArgs e)
        {
            global.countProduct = Convert.ToInt32(numericUpDown1.Value);
            new Purchase_Form().Show();
            this.Hide();
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            global.stockUpdate = 0;
            global.stockStatus = 0;
            global.transactions = 0;
            global.newEntry = 0;
            global.countProduct = 0;
            global.searchCat = 0;

            categoryCombo();
            brandCombo();

            if (global.bill == 1)
            {
                subTotalTxt.Text = (global.total).ToString("0.00");
            }
            if (global.login == 1)
            {
                logoutButton.Visible = true;
            }

        }

        private void newEntryButton_Click(object sender, EventArgs e)
        {
            global.newEntry = 1;
            if (global.login == 1)
            {
                new NewEntry().Show();
                this.Hide();
            }
            else
            {
                new Login().Show();
                this.Hide();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            global.search = int.Parse(searchTextbox.Text);
            new Search_Result().Show();
            this.Hide();
        }

        public void categoryCombo()
        {
            try
            {
                string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                string query = "select Category from baby_choice.category";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    catagoryCombo.Items.Add(reader.GetString("Category"));
                }

            }
            catch(Exception ex){

            }
        }

        public void brandCombo()
        {
            try
            {
                string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                string query = "select Brand from baby_choice.brand";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    brandCombobox.Items.Add(reader.GetString("Brand"));
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void catagoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            global.searchCat = 1;
            global.cat = catagoryCombo.Text;
            global.brand = brandCombobox.Text;
            global.age = ageComboBox.Text;
            new Search_Result().Show();
            this.Hide();
        }

        double grandTotalAm;

        public double grandTotal(int discount)
        {
            grandTotalAm = global.total - discount;
            return grandTotalAm;   
        }

        private void bttnCheckOut_Click(object sender, EventArgs e)
        {
            int dis, final;
            double sum;
            string date;
            DateTime now = DateTime.Now;
            date = now.ToString();
            dis = int.Parse(discountTxt.Text);
            sum = global.total - dis;
            final = (int)sum;
            totalTxt.Text = final.ToString("0");
            MessageBox.Show("Your Grand Total is: "+ final);

            try
            {
                string connectionstring = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                MySqlConnection myConn = new MySqlConnection(connectionstring);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                string qurey = "INSERT into `baby_choice`.`check_out` (Sold_Product_Code,Cost,Sold_Price,Date) VALUES ('" + global.soldProduct + "',"+global.totalBuy+"," + final + ",'" + date + "')";
                MySqlCommand cmd = new MySqlCommand(qurey, myConn);
                cmd.ExecuteReader();
                myConn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public void reset()
        {
            numericUpDown1.Value = 0;
            subTotalTxt.Text = "";
            discountTxt.Text = "";
            totalTxt.Text = "";
        }

        private void resetBttn_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            global.login = 0;
            logoutButton.Visible = false;
        }

    }
}

public class global
{
    public static Int32 stockUpdate = 0;
    public static Int32 stockStatus = 0;
    public static Int32 transactions = 0;
    public static Int32 newEntry = 0;
    public static Int32 countProduct = 0;
    public static Int32 searchCat = 0;
    public static Int32 search;
    public static Double total;
    public static String cat;
    public static String brand;
    public static String age;
    public static Int32 bill = 0;
    public static String soldProduct;
    public static Int32 login = 0;
    public static Int32 totalBuy = 0;

}
