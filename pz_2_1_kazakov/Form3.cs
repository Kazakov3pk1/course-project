using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Security.Cryptography;

namespace pz_2_1_kazakov
{
    public partial class Form3 : Form
    {
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

            {
                SqlConnection con = new SqlConnection(@"Data Source=192.168.147.69\MSSQL2;Initial Catalog=Orenmet;Persist Security Info=True;User ID=pk;Password=1");
                SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From Program Where Login_='"
                    + textBox1.Text + "' and Password_='" +  GetHash(textBox11.Text)  + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    Form f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите отменить вход?", "Отмена", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=192.168.147.69\MSSQL2;Initial Catalog=Orenmet;Persist Security Info=True;User ID=pk;Password=1");
                SqlDataAdapter sda = new SqlDataAdapter($"update Program set Password_='{GetHash(textBox11.Text)}' where Login_ ='{textBox1.Text}'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MessageBox.Show("Пароль хешировался");
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
