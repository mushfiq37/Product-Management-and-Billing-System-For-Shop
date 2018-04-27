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
    public partial class StockStatus : Form
    {
        public StockStatus()
        {
            InitializeComponent();
        }

        private void StockStatus_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                string query = "SELECT Reference_id,Age,product_code,Buying_Cost,Selling_Price FROM `baby_choice`.`product`";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        productDataGridView.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Int32 search = int.Parse(searchTextbox.Text);

            string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
            string query = "select Age,Selling_Price from baby_choice.product where product_code = " + search + "";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    productDataGridView.DataSource = ds.Tables[0];
                }
            }
        }

        private void reloadPage_Click(object sender, EventArgs e)
        {
            new StockStatus().Show();
            this.Hide();
        }
    }
}
