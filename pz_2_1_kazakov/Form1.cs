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
using MaterialSkin;
using MaterialSkin.Controls;


namespace pz_2_1_kazakov
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int selectedRow;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.materialTableAdapter.Fill(this.orenmetDataSet.Material);
            this.clientsTableAdapter.Fill(this.orenmetDataSet.Clients);
            string connectionString = @"Data Source=192.168.147.69\MSSQL2;Initial Catalog=A7agro;Persist Security Info=True;User ID=pk;Password=1";
            string sql = "SELECT * From Organization";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0];

            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            orenmetDataSet.Clients.Rows.Add(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);
            dataGridView1.DataSource = orenmetDataSet.Clients;
            clientsTableAdapter.Update(orenmetDataSet.Clients);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
            newDataRow.Cells[1].Value = textBox2.Text;
            newDataRow.Cells[2].Value = textBox3.Text;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {


        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
            {
                selectedRow = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(selectedRow);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if
                        (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox10.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
    
    }

        private void button12_Click(object sender, EventArgs e)
        {
            clientsBindingSource.Filter = "Full_name   =\'" + textBox11.Text + "\'";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

            string fileCSV = "";
            for (int f = 0; f < dataGridView1.ColumnCount; f++)
            {
                fileCSV += (dataGridView1.Columns[f].HeaderText + ";");
            }
            fileCSV += "\t\n";
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    fileCSV += (dataGridView1[j, i].Value).ToString() + ";";
                }
                fileCSV += "\t\n";
            }
            StreamWriter wr = new StreamWriter(@"C:\Users\kazakov.ad1231\Desktop\orenmet.csv", false);
            wr.Write(fileCSV);
            wr.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();

            PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\kazakov.ad1231\Desktop\pdforenmet.pdf", FileMode.Create));

            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            PdfPTable table = new PdfPTable(dataGridView1.ColumnCount);
            for (int f = 0; f < dataGridView1.ColumnCount; f++)
            {
                table.AddCell(new Phrase((dataGridView1.Columns[f].HeaderText).ToString(), font));
            }
            for (int t = 0; t < dataGridView1.ColumnCount; t++)
            {
                for (int m = 0; m < dataGridView1.ColumnCount; m++)
                {
                    table.AddCell(new Phrase((dataGridView1[m, t].Value).ToString(), font));
                }

            }
            doc.Add(table);
            doc.Close();

            MessageBox.Show("Pdf-документ сохранен");
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
    


