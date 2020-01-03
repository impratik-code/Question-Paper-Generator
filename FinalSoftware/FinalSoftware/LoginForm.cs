using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace FinalSoftware
{
    public partial class LoginForm : Form
    {
        string constring;
        public LoginForm()
        {
            InitializeComponent();
        }


        private void loginsigninbtn_Click_1(object sender, EventArgs e)
        {
            if (txtidlogin.Text.Equals("") || txtpasslogin.Text.Equals(""))
            {
                MessageBox.Show("Please enter your user id and password !!!");

            }
            else
            {
                if (bunifuCheckbox1.Checked == true)
                {
                    Properties.Settings.Default.Username = txtidlogin.Text;
                    Properties.Settings.Default.Password = txtpasslogin.Text;
                    Properties.Settings.Default.Save();
                }



                constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                //SqlCommand cmd = new SqlCommand("select username,pass from signup");



                SqlCommand cmd = new SqlCommand("select username,password from SignUp where username='" + txtidlogin.Text + "' and password='" + txtpasslogin.Text + " '", con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();



                if (dr.Read() == true)
                {



                    if (txtidlogin.Text.Equals(dr[0].ToString()) && txtpasslogin.Text.Equals(dr[1].ToString()))
                    {

                         this.Hide();

                        dashboard d = new dashboard(txtidlogin.Text);
                         d.ShowDialog();



                    }


                    dr.Close();
                    con.Close();
                }

                else
                {
                    MessageBox.Show("Invalid Id or Password");

                }

            }
        }

        private void loginsignuplbl_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SignUp s = new SignUp();

             s.ShowDialog();
        }

        private void loginMinimizebtn_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void loginClosebtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            txtidlogin.Text = Properties.Settings.Default.Username.ToString();
            txtpasslogin.Text = Properties.Settings.Default.Password.ToString();



            if (txtidlogin.Text != "" && txtpasslogin.Text != "")
            {
                bunifuCheckbox1.Checked = true;
            }
        }

        private void txtpasslogin_OnValueChanged_1(object sender, EventArgs e)
        {
            txtpasslogin.isPassword = true;
        }









    }
}
