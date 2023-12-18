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

namespace GridView
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=GridView;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something was wrong, please try again\nErrorTrace:" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=GridView;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO Students VALUES('" + txtName.Text + "','" + txtEmail.Text + "','" + txtPhone.Text + "','" + txtAdress.Text + "',)", connection);
        }
    }
}
