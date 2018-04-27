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
    public partial class Search_Result : Form
    {
        public Search_Result()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();

        }

        private void Search_Result_Load(object sender, EventArgs e)
        {
            if (global.searchCat == 1)
            {
                String ctgr = global.cat;
                String brnd = global.brand;
                String ag = global.age;

                string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                string query = "select product_code,Selling_Price from baby_choice.product where Age = '"+ag+"' and Reference_id =(select ref_id from baby_choice.reference where cat_id=(select Category_ID from baby_choice.category where Category='"+ctgr+"' ) and brand_id=(select Brand_Id from baby_choice.brand where Brand='"+brnd+"')) ";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        searchGridView.DataSource = ds.Tables[0];
                    }
                }

            }
            else
            {

                Int32 match = global.search;
                string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";
                string query = "select Age,Selling_Price from baby_choice.product where product_code = " + match + "";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        searchGridView.DataSource = ds.Tables[0];
                    }
                }
            }
        }
    }
}
