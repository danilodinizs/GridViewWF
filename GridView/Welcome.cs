﻿using System;
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

        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=GridView;Integrated Security=True");

        public Welcome()
        {
            InitializeComponent();
            GetData();
        }

        void GetData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT FullName, Email, Password, Phone, Address FROM Students", connection);
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
            if (txtName.Text == "" || txtEmail.Text == "" || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please Enter Data for all required fields!");
            }

            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
            }

            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Students VALUES('" + txtName.Text + "','" + txtEmail.Text + "','" + txtPhone.Text + "','" + txtPassword.Text + "','" + txtAdress.Text + "')", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                GetData();
                MessageBox.Show("Data Enter successfully!");
            }
            
        }
    }
}
