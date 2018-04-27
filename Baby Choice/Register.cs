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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void registerButon_Click(object sender, EventArgs e)
        {
            string name = null;
            string pass = null;
            string masterPass = "HMR";

            if (userNameText.Text == "" || passText.Text == "")
                MessageBox.Show("One of the required field is null...");

            else if (passText.TextLength < 4)
                MessageBox.Show("Use atleast 4 digits as Password...");

            else if (masterText.Text == masterPass)
            {
                name = userNameText.Text;
                pass = passText.Text;
                MySqlConnection myConn;

                try
                {
                    string connectionString = "datasource=localhost;port=3306;username=mushfiq;password=140237;";
                    myConn = new MySqlConnection(connectionString);

                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = new MySqlCommand("select * baby_choice.login", myConn);
                    MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    string qurey = "INSERT INTO `baby_choice`.`login` (`user_name`, `password`) VALUES ('" + name + "', md5('" + pass + "'));";
                    MySqlCommand cmd = new MySqlCommand(qurey, myConn);

                    cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

                MessageBox.Show("Successfully Registered...");
                new MainForm().Show();
                this.Hide();

             }

             else
             {
               MessageBox.Show("Enter Master key!!!!");
             }
        }
    }
}
