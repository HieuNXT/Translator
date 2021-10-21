using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dictionary
{
    public partial class Form1 : Form
    {
        string @ta;
        int imgindex;
        static SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = Dic");
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list();
        }
        void list()
        {
            SqlDataAdapter a = new SqlDataAdapter("Select ta from dict ", sqlConnection);
            DataTable dataTable = new DataTable();
            a.Fill(dataTable);

            listBox1.DataSource = dataTable;
            listBox1.DisplayMember = "ta";
            listBox1.ValueMember = "ta";
        }
        void list2()
        {
            SqlDataAdapter a = new SqlDataAdapter("Select ta from dict where ta like '" + textBox1.Text + "'", sqlConnection);
            DataTable dataTable = new DataTable();
            a.Fill(dataTable);

            listBox2.DataSource = dataTable;
            listBox2.DisplayMember = "ta";
            listBox2.ValueMember = "ta";
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox14.Text = (((DataRowView)listBox1.SelectedItem).Row[0]).ToString();
            if (listBox2.Items.Contains(listBox1.SelectedItem.ToString()))
            {
            }
            else
            {
                listBox2.Items.Add(textBox14.Text);
            }
            string qr = "Select   tv, typeTv, meanTa, meanTv, typeTa, pic1, pic2, pic3, pic4, pic5, pronounTa, pronounTv from dict where ta = '" + textBox14.Text + "'";
            SqlDataAdapter a = new SqlDataAdapter(qr, sqlConnection);
            DataTable dataTable = new DataTable();
            a.Fill(dataTable);

            textBox7.Text = Convert.ToString(dataTable.Rows[0]["tv"]);
            textBox5.Text = Convert.ToString(dataTable.Rows[0]["typeTv"]);
            textBox3.Text = Convert.ToString(dataTable.Rows[0]["meanTa"]);
            textBox2.Text = Convert.ToString(dataTable.Rows[0]["meanTv"]);
            textBox4.Text = Convert.ToString(dataTable.Rows[0]["typeTa"]);
            textBox8.Text = Convert.ToString(dataTable.Rows[0]["pic1"]);
            textBox11.Text = Convert.ToString(dataTable.Rows[0]["pic2"]);
            textBox10.Text = Convert.ToString(dataTable.Rows[0]["pic3"]);
            textBox15.Text = Convert.ToString(dataTable.Rows[0]["pic4"]);
            textBox9.Text = Convert.ToString(dataTable.Rows[0]["pic5"]);
            textBox13.Text = Convert.ToString(dataTable.Rows[0]["pronounTa"]);
            textBox12.Text = Convert.ToString(dataTable.Rows[0]["pronounTv"]);

            p4.ImageLocation = textBox8.Text;
            p5.ImageLocation = textBox11.Text;
            p3.ImageLocation = textBox10.Text;
            p1.ImageLocation = textBox15.Text;
            p2.ImageLocation = textBox9.Text;

            if (textBox10.Text == null)
            {
                p3.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
            if (textBox8.Text == null)
            {
                p4.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
            if (textBox15.Text == null)
            {
                p1.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
            if (textBox9.Text == null)
            {
                p2.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
            if (textBox11.Text == null)
            {
                p5.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            player.URL = textBox13.Text;
            player.controls.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            player.URL = textBox12.Text;
            player.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                

                int index = listBox1.FindString(textBox1.Text);

                if (index < 0)
                {
                    MessageBox.Show("Item not found.");
                    textBox1.Text = String.Empty;
                }
                else
                {
                    listBox1.SelectedIndex = index;
                }
            
        }
    }
}
