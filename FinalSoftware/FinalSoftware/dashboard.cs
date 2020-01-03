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
    public partial class dashboard : Form
    {
        string constring;
        string combo1, combo2, combo3;
        public dashboard()
        {
            InitializeComponent();
        }
       
        public dashboard(string welcomeuser)
        {
            InitializeComponent();
            userlbl.Text = welcomeuser + ".";
        }
        private void dashboard_Load(object sender, EventArgs e)
        {

        }




        private void nextbtn_Click(object sender, EventArgs e)
        {
            if (isValidated())
            {
                combo1 = comboBox1.selectedValue.ToString(); ;
                combo2 = comboBox2.selectedValue.ToString();
                combo3 = comboBox3.selectedValue.ToString();
                this.Hide();
                QuestionSelection q = new QuestionSelection(combo1, combo2, combo3, userlbl.Text);
                q.ShowDialog();
            }
        }

        private bool isValidated()
        {
            if (comboBox1.selectedIndex.ToString().Equals("-1"))
            {
                validationMessage(comboBox1, "Course field is required!!!");
                return false;
            }
            if (comboBox2.selectedIndex.ToString().Equals("-1"))
            {
                validationMessage(comboBox2, "Semester field is required!!!");
                return false;
            }
            else if (comboBox3.selectedIndex.ToString().Equals("-1"))
            {
                validationMessage(comboBox3, "Subject field is required!!!");
                return false;
            }

            return true;
        }

        private void validationMessage(Control ctrl, string validationMessage)
        {
            ctrl.BackColor = Color.LightPink;
            ctrl.Focus();
           // msgBox m = new msgBox(validationMessage);
           // m.Show();
        }

        private void comboBox1_onItemSelected(object sender, EventArgs e)
        {
            if (comboBox1.selectedValue.Equals("FYBCA"))
            {

                this.comboBox2.Clear();

                comboBox2.Text = "";
                this.comboBox3.Clear();
                this.comboBox3.Text = "";

                comboBox2.AddItem("SEM I");
                comboBox2.AddItem("SEM II");

            }
            else if (comboBox1.selectedValue.ToString().Equals("SYBCA"))
            {
                this.comboBox2.Clear();
                comboBox2.Text = "";
                this.comboBox3.Clear();
                this.comboBox3.Text = "";
                comboBox2.AddItem("SEM III");
                comboBox2.AddItem("SEM IV");

            }
            else if (comboBox1.selectedValue.ToString().Equals("TYBCA"))
            {
                this.comboBox2.Clear();
                comboBox2.Text = "";
                this.comboBox3.Clear();
                this.comboBox3.Text = "";
                comboBox2.AddItem("SEM V");
                comboBox2.AddItem("SEM VI");

            }
            else
                MessageBox.Show("TTT");
        }

        private void comboBox2_onItemSelected(object sender, EventArgs e)
        {
            if (comboBox1.selectedValue.ToString().Equals("FYBCA") && comboBox2.selectedValue.ToString().Equals("SEM I"))
            {
                this.comboBox3.Clear();
                this.comboBox3.Text = "";

                //code for fetching data into combobox
                constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from FYBCA_SEM1", con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    comboBox3.AddItem(dr[1].ToString());
                }




            }
            else if (comboBox1.selectedValue.ToString().Equals("FYBCA") && comboBox2.selectedValue.ToString().Equals("SEM II"))
            {
                this.comboBox3.Clear();
                this.comboBox3.Text = "";

                constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from FYBCA_SEM2", con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    comboBox3.AddItem(dr[1].ToString());
                }

            }
            else if (comboBox1.selectedValue.ToString().Equals("SYBCA") && comboBox2.selectedValue.ToString().Equals("SEM III"))
            {
                this.comboBox3.Clear();
                this.comboBox3.Text = "";

                constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from SYBCA_SEM3", con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    comboBox3.AddItem(dr[1].ToString());
                }


            }
            else if (comboBox1.selectedValue.ToString().Equals("SYBCA") && comboBox2.selectedValue.ToString().Equals("SEM IV"))
            {
                this.comboBox3.Clear();
                this.comboBox3.Text = "";

                constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from SYBCA_SEM4", con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    comboBox3.AddItem(dr[1].ToString());
                }



            }
            else if (comboBox1.selectedValue.ToString().Equals("TYBCA") && comboBox2.selectedValue.ToString().Equals("SEM V"))
            {
                this.comboBox3.Clear();
                this.comboBox3.Text = "";

                constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from TYBCA_SEM5", con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    comboBox3.AddItem(dr[1].ToString());
                }



            }
            else if (comboBox1.selectedValue.ToString().Equals("TYBCA") && comboBox2.selectedValue.ToString().Equals("SEM VI"))
            {
                this.comboBox3.Clear();
                this.comboBox3.Text = "";

                constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from TYBCA_SEM6", con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    comboBox3.AddItem(dr[1].ToString());
                }

            }
            else
                MessageBox.Show("TTT");
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            this.Hide();
            LoginForm l = new LoginForm();
            l.ShowDialog();
        }

        private void aboutbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            about a = new about(userlbl.Text);
            a.ShowDialog();
        }

        private void dashboardClosebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardMinimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void addquestionbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Question a = new Add_Question(userlbl.Text);
            a.ShowDialog();
        }

        private void comboBox3_onItemSelected(object sender, EventArgs e)
        {

        }

      
    }
}
