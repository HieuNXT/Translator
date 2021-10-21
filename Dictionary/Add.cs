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
    public partial class Add : Form
    {
        static SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = Dic");
        public Add()
        {
            InitializeComponent();
        }
        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("addAndedit", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (button1.Text == "Thêm")
                { 
                    cmd.Parameters.AddWithValue("@mode", "add");
                    cmd.Parameters.AddWithValue("@wID", 0);
                    cmd.Parameters.AddWithValue("@tv", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ta", textBox6.Text);
                    cmd.Parameters.AddWithValue("@typeTv", textBox5.Text);
                    cmd.Parameters.AddWithValue("@meanTv", textBox3.Text);
                    cmd.Parameters.AddWithValue("@meanTa", textBox2.Text);
                    cmd.Parameters.AddWithValue("@typeTa", textBox4.Text);
                    cmd.Parameters.AddWithValue("@pic1", textBox9.Text);
                    cmd.Parameters.AddWithValue("@pic2", textBox11.Text);
                    cmd.Parameters.AddWithValue("@pic3", textBox10.Text);
                    cmd.Parameters.AddWithValue("@pic4", textBox7.Text);
                    cmd.Parameters.AddWithValue("@pic5", textBox8.Text);
                    cmd.Parameters.AddWithValue("@pronounTa", textBox12.Text);
                    cmd.Parameters.AddWithValue("@pronounTv", textBox13.Text);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@mode", "Editting");
                    cmd.Parameters.AddWithValue("@wID", textBox14);
                    cmd.Parameters.AddWithValue("@tv", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ta", textBox6.Text);
                    cmd.Parameters.AddWithValue("@typeTv", textBox5.Text);
                    cmd.Parameters.AddWithValue("@meanTv", textBox3.Text);
                    cmd.Parameters.AddWithValue("@meanTa", textBox2.Text);
                    cmd.Parameters.AddWithValue("@typeTa", textBox4.Text);
                    cmd.Parameters.AddWithValue("@pic1", textBox9.Text);
                    cmd.Parameters.AddWithValue("@pic2", textBox11.Text);
                    cmd.Parameters.AddWithValue("@pic3", textBox10.Text);
                    cmd.Parameters.AddWithValue("@pic4", textBox7.Text);
                    cmd.Parameters.AddWithValue("@pic5", textBox8.Text);
                    cmd.Parameters.AddWithValue("@pronounTa", textBox12.Text);
                    cmd.Parameters.AddWithValue("@pronounTv", textBox13.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                sqlConnection.Close();
            }
            FillDataGridView2();
        }
        void FillDataGridView2()
        {
            sqlConnection.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("vas", sqlConnection);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ten", textBox15.Text);
            DataTable dtb = new DataTable();
            sqlDa.Fill(dtb);
            dataGridView1.DataSource = dtb;
            sqlConnection.Close();
        }
        private void Add_Load(object sender, EventArgs e)
        {
            FillDataGridView2();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox9.Text = o.FileName;
                pictureBox3.ImageLocation = o.FileName;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox10.Text = o.FileName;
                pictureBox4.ImageLocation = o.FileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox11.Text = o.FileName;
                pictureBox1.ImageLocation = o.FileName;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = o.FileName;
                pictureBox2.ImageLocation = o.FileName;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = o.FileName;
                pictureBox5.ImageLocation = o.FileName;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            sqlConnection.Open();
            textBox14.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            pictureBox3.Image = Image.FromFile(textBox9.Text);
            pictureBox4.Image = Image.FromFile(textBox10.Text);
            pictureBox1.Image = Image.FromFile(textBox11.Text);
            pictureBox2.Image = Image.FromFile(textBox8.Text);
            pictureBox5.Image = Image.FromFile(textBox7.Text);

            if (textBox9.Text == null)
            {
                pictureBox3.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
            if (textBox10.Text == null)
            {
                pictureBox4.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
            if (textBox11.Text == null)
            {
                pictureBox1.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
            if (textBox8.Text == null)
            {
                pictureBox2.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }
            if (textBox7.Text == null)
            {
                pictureBox5.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            }

            button1.Text = "Cập nhật";
            button2.Enabled = true;

            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("Delete", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@wID", textBox14.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                FillDataGridView2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            pictureBox5.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            pictureBox1.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            pictureBox2.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            pictureBox3.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            pictureBox4.Image = Image.FromFile("T:\\Downloads\\Documents\\12PictureThis-06-mobileMasterAt3x.jpg");
            button1.Text = "Thêm";

            sqlConnection.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Danh từ";
            textBox4.Text = "Noun";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Động từ";
            textBox4.Text = "Verb";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Tính từ";
            textBox4.Text = "Adjective";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Trạng từ";
            textBox4.Text = "Adverb";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Giới từ";
            textBox4.Text = "Prepositions";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Chịu";
            textBox4.Text = ":v";
        }


        private void label5_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox12.Text = o.FileName;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = o.FileName;
            }
        }
    }
}
