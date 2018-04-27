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
    public partial class NewEntry : Form
    {
        public NewEntry()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
  

            string  age, catagory, brand;
            int sellingPrice, buyingCost, quantity, refer = 0, i, productCode;

           // productCode = codeTxtBox.Text;
            Random rnd = new Random();
            age = ageComboBox.Text;
            sellingPrice = int.Parse(sellPriceTxtbox.Text);
            buyingCost = int.Parse(priceTxtBox.Text);
            catagory = catagoryComboBox.Text;
            brand = brandComboBox2.Text;
            quantity = Convert.ToInt32(quantityUpDown.Value);
            productCode = rnd.Next(111111, 999999);

            try
            {
                string connectionstring = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                MySqlConnection myConn = new MySqlConnection(connectionstring);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(myDataAdapter);
             //   myConn.Open();
              
                for (i = 0; i < quantity; i++)
                {
                    myConn.Open();
                    productCode++;

                    string qurey = "INSERT INTO `baby_choice`.`product` (Reference_id, Age, product_code,Buying_Cost,Selling_Price) VALUES ((SELECT ref_id from baby_choice.reference where cat_id=(select Category_ID from baby_choice.category where Category='" + catagory + "' ) and brand_id=(select Brand_ID from baby_choice.brand where Brand='" + brand + "')), '" + age + "', " + productCode + ", " + buyingCost + ", " + sellingPrice + ")";
                    MySqlCommand cmd = new MySqlCommand(qurey, myConn);
                    cmd.ExecuteReader();
                                     
                    myConn.Close();
                }

                MessageBox.Show("Product Code starts from " +(productCode-quantity+1)+"  to  "+productCode);
                new MainForm().Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            catagoryComboBox.Text = "";
            brandComboBox2.Text = "";
            quantityUpDown.Value = 0;
            ageComboBox.Text = "";
            priceTxtBox.Text = "";
            sellPriceTxtbox.Text = "";
        }

        private void NewEntry_Load(object sender, EventArgs e)
        {
            categoryCombo();
            brandCombo();
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
                    catagoryComboBox.Items.Add(reader.GetString("Category"));
                    catComboBox1.Items.Add(reader.GetString("Category"));
   
                }

            }
            catch (Exception ex)
            {

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
                    brandComboBox2.Items.Add(reader.GetString("Brand"));
                    brndComboBox.Items.Add(reader.GetString("Brand"));
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void catagoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void addCat_Click(object sender, EventArgs e)
        {
            string category, query1;

            category = catTextBox.Text;
            if (category == "")
            {
                MessageBox.Show("Select Category first...");
            }
            else
            {
                try
                {
                    string connectionstring = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                    MySqlConnection myConn = new MySqlConnection(connectionstring);

                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //     myDataAdapter.SelectCommand = new MySqlCommand("select * baby_choice.product", myConn);
                    MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    query1 = "INSERT INTO `baby_choice`.`category` (Category) VALUES ('" + category + "')";
                    MySqlCommand cmd = new MySqlCommand(query1, myConn);
                    cmd.ExecuteReader();
                    MessageBox.Show("Category added into the database....");
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void addBrand_Click(object sender, EventArgs e)
        {
            string brand1, query2;

            brand1 = brndTextBox.Text;

            if (brand1 == "")
            {
                MessageBox.Show("Select Brand first...");
            }
            else
            {
                try
                {
                    string connectionstring = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                    MySqlConnection myConn = new MySqlConnection(connectionstring);

                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //     myDataAdapter.SelectCommand = new MySqlCommand("select * baby_choice.product", myConn);
                    MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    query2 = "INSERT INTO baby_choice.brand (Brand) VALUES ('" + brand1 + "')";
                    MySqlCommand cmd = new MySqlCommand(query2, myConn);
                    cmd.ExecuteReader();
                    MessageBox.Show("Brand added into the database....");

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void addBoth_Click(object sender, EventArgs e)
        {
            string brand2, query3, category1;

            category1 = catComboBox1.Text;
            brand2 = brndComboBox.Text;

            try
            {
                string connectionstring = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                MySqlConnection myConn = new MySqlConnection(connectionstring);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                query3 = "INSERT INTO `baby_choice`.`reference` (cat_id,brand_id) VALUES ((select Category_ID from `baby_choice`.`category` where Category = '"+category1+"'),(select Brand_ID from `baby_choice`.`brand` where Brand = '"+brand2+"'))";
                MySqlCommand cmd = new MySqlCommand(query3, myConn);
                cmd.ExecuteReader();
                MessageBox.Show("Reference added into the database....");

            }
            catch (Exception ex)
            {

            }
        }


    }
}
