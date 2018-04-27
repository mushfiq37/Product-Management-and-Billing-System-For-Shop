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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        string query;
        private void loginButton_Click(object sender, EventArgs e)
        {
            string name = userNametxtbox.Text;
            string pass = passTxtbox.Text;

            if (rememberCheckBox.Checked == true)
            {
                global.login = 1;
                rememberCheckBox.Checked = false;
            }

            string connectionString = "datasource=localhost;port=3306;username=mushfiq;password=140237;";
            MySqlConnection myConn = new MySqlConnection(connectionString);

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
         //   myDataAdapter.SelectCommand = new MySqlCommand("SELECT * FROM baby_Choice.login", myConn);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(myDataAdapter);
            myConn.Open();

            query = "select user_name , password from baby_Choice.login where user_name = '" + name + "' && password = md5('" + pass + "');";
            MySqlCommand cmd = new MySqlCommand(query, myConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                count++;
            }

            if (count == 0)
            {
                MessageBox.Show("Wrong username or password!!!!");
            }
            if (global.stockStatus == 1)
            {
                new StockStatus().Show();
                this.Hide();
            }
            if (global.newEntry == 1)
            {
                new NewEntry().Show();
                this.Hide();
            }
            if (global.stockUpdate == 1)
            {
                new UpdateStock().Show();
                this.Hide();
            }
            if (global.transactions == 1)
            {
                new Transactions().Show();
                this.Hide();
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
           // rememberCheckBox.Enabled = false;
        }

        private void userNametxtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
