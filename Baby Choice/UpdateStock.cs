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
    public partial class UpdateStock : Form
    {
        public UpdateStock()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void quantityUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
           // MySqlConnection myConn;
            int productCode;
            int price;

            productCode = int.Parse(codeTxtBox.Text);        
            price = int.Parse(priceTxtBox.Text);
            
            try
            {
                string query;
                string connectionstring = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                MySqlConnection myConn = new MySqlConnection(connectionstring);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                query = "UPDATE baby_choice.product SET Selling_Price='" + price + "' where product_code = " + productCode + "";
                MySqlCommand cmd = new MySqlCommand(query, myConn);
                cmd.ExecuteReader();
                
              


                new MainForm().Show();
                this.Hide();
           //     MySqlCommand cmd = new MySqlCommand(query, myConn);
            //    MySqlDataReader reader;
           //     cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateStock_Load(object sender, EventArgs e)
        {
            
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }
    }
}
