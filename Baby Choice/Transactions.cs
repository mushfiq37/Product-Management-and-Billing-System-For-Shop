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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }
        int a = 0, b = 0, sellingPrice, buyingPrice, total;
        private void backButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            loadPage();
        }

        private void reloadPage_Click(object sender, EventArgs e)
        {

        }

        public void loadPage()
        {   
            
            try
            {
                string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                string query = "SELECT Sold_Product_Code,Cost,Sold_Price,Date FROM `baby_choice`.`check_out`";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        transactionGridView.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            string from = dateTimePicker1.Value.ToString("");
            string to = dateTimePicker2.Value.ToString("");
            a = 1;
            try
            {
                string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                string query = "SELECT Sold_Product_Code,Cost,Sold_Price,Date FROM `baby_choice`.`check_out` where Date Between '"+from+"' and'"+ to+"'";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        transactionGridView.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void resetBttn_Click(object sender, EventArgs e)
        {
            loadPage();
            profitTxt.Text = "";
        }

        private void profitCalc_Click(object sender, EventArgs e)
        {
            
                try
                {
                   
                    for (int i = 0; i < transactionGridView.Rows.Count; ++i)
                    {
                        buyingPrice += Convert.ToInt32(transactionGridView.Rows[i].Cells[1].Value);
                    }

                    for (int i = 0; i < transactionGridView.Rows.Count; ++i)
                    {
                        sellingPrice += Convert.ToInt32(transactionGridView.Rows[i].Cells[2].Value);
                    }
                    total = sellingPrice - buyingPrice;
                    profitTxt.Text = total.ToString("")+" /= ";
                    buyingPrice = 0;
                    sellingPrice = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


        }


    }
}
