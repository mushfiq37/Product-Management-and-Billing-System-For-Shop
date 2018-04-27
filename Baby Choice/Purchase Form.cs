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
    public partial class Purchase_Form : Form
    {
        static int i;
        int[] txt = new int[100];

        public Purchase_Form()
        {
            InitializeComponent();
        }

        private void Purchase_Form_Load(object sender, EventArgs e)
        {
          //  i = 1;
            global.bill = 0;
         /*   for (int j = 0; j < global.countProduct; j++)
            {
                TextBox tb = new TextBox();
                Label lb = new Label();
                lb.Text = "Product Code: ";

                Point p = new Point(30 + i, 40 * i);
                lb.Location = p;
                this.Controls.Add(lb);

                Point p1 = new Point(140+i,40*i);
                tb.Location = p1;
                this.Controls.Add(tb);

                txt[i] = tb.Text;

                i++;
            }*/

            if (global.countProduct == 1)
            {
                lb1.Show();
                txt1.Show();
            }
            else if (global.countProduct == 2)
            {
                lb1.Show();
                txt1.Show();
                lb2.Show();
                txt2.Show();
            }
            else if (global.countProduct == 3)
            {
                lb1.Show();
                txt1.Show();
                lb2.Show();
                txt2.Show();
                lb3.Show();
                txt3.Show();
            }
            else if (global.countProduct == 4)
            {
                lb1.Show();
                txt1.Show();
                lb2.Show();
                txt2.Show();
                lb3.Show();
                txt3.Show();
                lb4.Show();
                txt4.Show();
            }
            else if (global.countProduct == 5)
            {
                lb1.Show();
                txt1.Show();
                lb2.Show();
                txt2.Show();
                lb3.Show();
                txt3.Show();
                lb4.Show();
                txt4.Show();
                lb5.Show();
                txt5.Show();
            }
            else if (global.countProduct == 6)
            {
                lb1.Show();
                txt1.Show();
                lb2.Show();
                txt2.Show();
                lb3.Show();
                txt3.Show();
                lb4.Show();
                txt4.Show();
                lb5.Show();
                txt5.Show();
                lb6.Show();
                txt6.Show();
            }
            else if (global.countProduct == 7)
            {
                lb1.Show();
                txt1.Show();
                lb2.Show();
                txt2.Show();
                lb3.Show();
                txt3.Show();
                lb4.Show();
                txt4.Show();
                lb5.Show();
                txt5.Show();
                lb6.Show();
                txt6.Show();
                lb7.Show();
                txt7.Show();
            }
            else if (global.countProduct == 7)
            {
                lb1.Show();
                txt1.Show();
                lb2.Show();
                txt2.Show();
                lb3.Show();
                txt3.Show();
                lb4.Show();
                txt4.Show();
                lb5.Show();
                txt5.Show();
                lb6.Show();
                txt6.Show();
                lb7.Show();
                txt7.Show();
                lb8.Show();
                txt8.Show();
            }


        }

        private void backButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Close();
        }

        private void billButton_Click(object sender, EventArgs e)
        {
            try
            {
                int sum = 0, price, buyingPrice, a;
             //   double vat, b;

                if (global.countProduct == 1)
                {
                    txt[1] = int.Parse(txt1.Text);
                    global.soldProduct = txt[1].ToString("");
                }
                else if (global.countProduct == 2)
                {
                    txt[1] = int.Parse(txt1.Text);
                    txt[2] = int.Parse(txt2.Text);
                    global.soldProduct = txt[1].ToString("")+","+txt[2].ToString("");
                }
                else if (global.countProduct == 3)
                {
                    txt[1] = int.Parse(txt1.Text);
                    txt[2] = int.Parse(txt2.Text);
                    txt[3] = int.Parse(txt3.Text);
                    global.soldProduct = txt[1].ToString("") + "," + txt[2].ToString("")+","+txt[3].ToString("");
                }
                else if (global.countProduct == 4)
                {
                    txt[1] = int.Parse(txt1.Text);
                    txt[2] = int.Parse(txt2.Text);
                    txt[3] = int.Parse(txt3.Text);
                    txt[4] = int.Parse(txt4.Text);
                    global.soldProduct = txt[1].ToString("") + "," + txt[2].ToString("") + "," + txt[3].ToString("")+","+txt[4].ToString("");
                }
                else if (global.countProduct == 5)
                {
                    txt[1] = int.Parse(txt1.Text);
                    txt[2] = int.Parse(txt2.Text);
                    txt[3] = int.Parse(txt3.Text);
                    txt[4] = int.Parse(txt4.Text);
                    txt[5] = int.Parse(txt5.Text);
                    global.soldProduct = txt[1].ToString("") + "," + txt[2].ToString("") + "," + txt[3].ToString("") + "," + txt[4].ToString("")+","+txt[5].ToString("");
                }
                else if (global.countProduct == 6)
                {
                    txt[1] = int.Parse(txt1.Text);
                    txt[2] = int.Parse(txt2.Text);
                    txt[3] = int.Parse(txt3.Text);
                    txt[4] = int.Parse(txt4.Text);
                    txt[5] = int.Parse(txt5.Text);
                    txt[6] = int.Parse(txt6.Text);
                    global.soldProduct = txt[1].ToString("") + "," + txt[2].ToString("") + "," + txt[3].ToString("") + "," + txt[4].ToString("") + "," + txt[5].ToString("")+","+txt[6].ToString("");
                }
                else if (global.countProduct == 7)
                {
                    txt[1] = int.Parse(txt1.Text);
                    txt[2] = int.Parse(txt2.Text);
                    txt[3] = int.Parse(txt3.Text);
                    txt[4] = int.Parse(txt4.Text);
                    txt[5] = int.Parse(txt5.Text);
                    txt[6] = int.Parse(txt6.Text);
                    txt[7] = int.Parse(txt7.Text);
                    global.soldProduct = txt[1].ToString("") + "," + txt[2].ToString("") + "," + txt[3].ToString("") + "," + txt[4].ToString("") + "," + txt[5].ToString("")+","+txt[6].ToString("")+","+txt[7].ToString("");
                }
                else if (global.countProduct == 8)
                {
                    txt[1] = int.Parse(txt1.Text);
                    txt[2] = int.Parse(txt2.Text);
                    txt[3] = int.Parse(txt3.Text);
                    txt[4] = int.Parse(txt4.Text);
                    txt[5] = int.Parse(txt5.Text);
                    txt[6] = int.Parse(txt6.Text);
                    txt[7] = int.Parse(txt7.Text);
                    txt[8] = int.Parse(txt8.Text);
                    global.soldProduct = txt[1].ToString("") + "," + txt[2].ToString("") + "," + txt[3].ToString("") + "," + txt[4].ToString("") + "," + txt[5].ToString("")+","+txt[6].ToString("")+","+txt[7].ToString("")+","+txt[8].ToString("");
                }


                string connectionString = "datasource = localhost; port = 3306; username = mushfiq; password = 140237";

                for (i = 1; i <= global.countProduct; i++)
                {
                    using (MySqlConnection connDataBase = new MySqlConnection(connectionString))
                    {
                        connDataBase.Open();
                        string query = "SELECT Selling_Price from `baby_choice`.`product` where product_code= " + txt[i] + "";
                        MySqlCommand cmd = new MySqlCommand(query, connDataBase);
                        price = (int)cmd.ExecuteScalar();
                        sum += price;

                        string query2 = "SELECT Buying_Cost from `baby_choice`.`product` where product_code= " + txt[i] + "";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connDataBase);
                        buyingPrice = (int)cmd2.ExecuteScalar();
                        global.totalBuy += buyingPrice;

                        string query1 = "DELETE FROM `baby_choice`.`product` where product_code="+txt[i]+"";
                        MySqlCommand cmd1 = new MySqlCommand(query1, connDataBase);
                        cmd1.ExecuteReader();
                        connDataBase.Close();
                    }

                }

                global.total = sum + (sum * 0.05);
           //     global.totalBuy = buyingPrice;

              //  MessageBox.Show("Total: " + global.total);
                global.bill = 1;
                new MainForm().Show();
                this.Hide();
            }
            catch (Exception ex)
            {

            }

        }

        public double bill(int s)
        {
            global.total = s + (s * 0.05);
            return global.total;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
