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
    public partial class SignUp : Form
    {
        string constring, pass, user;
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private bool isValidated()
        {
            if (txtname.Text == "")
            {
                validationMessage(txtname, "User name is required!!!");
                return false;
            }
            if (txtpass.Text == "")
            {
                validationMessage(txtpass, "Password is required!!!");
                return false;
            }
            else if (txtcnf.Text == "")
            {
                validationMessage(txtcnf, "Re-Enter password is required!!!");
                return false;
            }
            else if (txtpass.Text != txtcnf.Text)
            {
                validationMessage(txtcnf, "Passwords does not match!!!");
                return false;
            }

            return true;
        }

        private void validationMessage(Control ctrl, string validationMessage)
        {
            ctrl.BackColor = Color.LightPink;
            ctrl.Focus();
            MessageBox.Show(validationMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void signupbtn_Click(object sender, EventArgs e)
        {
            if (isValidated() == true)
            {
                user = txtname.Text;
                pass = txtpass.Text;

                constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();

                SqlCommand cmd2 = new SqlCommand("select username from SignUp where username='" + txtname.Text + "'", con);
                SqlDataReader dr = cmd2.ExecuteReader();

                //con.Close();
                if (dr.Read() == true)
                {
                    MessageBox.Show("Username is taken , please enter another user name!!!");
                }
                else
                {
                    dr.Close();
                    SqlCommand cmd = new SqlCommand("insert into SignUp values('" + user + "','" + pass + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data inserted successfully!!!");

                    this.Hide();
                    LoginForm f = new LoginForm();
                    f.ShowDialog();

                }
            }
        }

        private void signinlbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm f = new LoginForm();
            f.ShowDialog();
        }

        private void signupClosebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signupMinimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtpass_OnValueChanged(object sender, EventArgs e)
        {
            txtpass.isPassword = true;
        }

        private void txtcnf_OnValueChanged(object sender, EventArgs e)
        {
            txtcnf.isPassword = true;
        }

      

        
    }
}
