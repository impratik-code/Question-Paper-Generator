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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
namespace FinalSoftware
{
    public partial class QuestionSelection : Form
    {
        string course, semester, subject, constring;
        string exam;
        string questsub;
        string subjectCode;
        string date;
        string time;
        string marks, attempt, dummy;
        int eachque;

        string userLbl;

        public QuestionSelection()
        {
            
        }
        public QuestionSelection(string c1, string c2, string c3, string userlbl)
        {
            InitializeComponent();
            course = c1;
            semester = c2;
            subject = c3;
            userLbl = userlbl;

        }
        private void QuestionSelection_Load(object sender, EventArgs e)
        {
            filler();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            // Display the date as "Mon 27 Feb 2012".  
            dateTimePicker1.FormatCustom = "ddd dd MMM yyyy";


            bunifuCircleProgressbar1.Value = 0;
            bunifuCircleProgressbar1.MaxValue = 300;

        }
        public void filler()
        {

            constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            //SqlCommand cmd = new SqlCommand("select username,pass from signup");


            string query = "select * from " + subject + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();




            while (dr.Read() == true)
            {

                listBox1.SelectionMode = SelectionMode.MultiExtended;
                listBox1.Items.Add(dr[1].ToString());


            }
            dr.Close();
            con.Close();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex.ToString().Equals("-1"))
            {

            }
            else
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
        }


        private bool isValidated()
        {
            if (exam.Equals(""))
            {
                validationMessage(examtxt, "Examination field is required!!!");
                return false;
            }
            if (timetxt1.Text == "")
            {
                validationMessage(timetxt1, "Time field is required!!!");
                return false;
            }
            else if (timetxt2.Text == "")
            {
                validationMessage(timetxt2, "Time field is required!!!");
                return false;
            }
            else if (timetxt1.Text == timetxt2.Text)
            {
                validationMessage(timetxt2, "Invalid Time!!!");
                return false;
            }

            else
            {
                int outBox;
                if (!int.TryParse(timetxt1.Text, out outBox) || !int.TryParse(timetxt2.Text, out outBox))
                {
                    timetxt1.BackColor = Color.LightPink;
                    timetxt1.Focus();
                    timetxt2.BackColor = Color.LightPink;
                    timetxt2.Focus();
                    MessageBox.Show("Time should be an integer!!!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (marks.Equals(""))
            {
                validationMessage(markstxt, "Marks field is required!!!");
                return false;
            }
            else
            {
                int outBox;
                if (!int.TryParse(markstxt.Text, out outBox))
                {
                    validationMessage(markstxt, "Marks should be an integer!!!");
                    return false;
                }
            }

            if (attempt.Equals(""))
            {
                validationMessage(attempttxt, "Attempt field is required!!!");
                return false;
            }
            else
            {
                int outBox;
                if (!int.TryParse(attempttxt.Text, out outBox))
                {
                    validationMessage(attempttxt, "No. of questions to attempt should be an integer!!!");
                    return false;
                }
            }
            return true;
        }


        private void validationMessage(Control ctrl, string validationMessage)
        {
            ctrl.BackColor = Color.LightPink;
            ctrl.Focus();
            MessageBox.Show(validationMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            msgBox m = new msgBox(validationMessage);
            m.Show();
        }

        private void txtchange(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.WhiteSmoke;
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
            {
                msgBox m = new msgBox("Please select a question!!!");
                m.Show();
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (customquetxt.Text == "")
            {
                msgBox m = new msgBox("Please insert a question!!!");
                m.Show();
            }
            else
            {
                listBox2.Items.Add(customquetxt.Text);
                customquetxt.Text = "";
            }
        }

        private void generatebtn_Click(object sender, EventArgs e)
        {
            constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);

            dummy = subject.Remove(7);
            exam = examtxt.Text;
            questsub = subject.Remove(0, 8);
            subjectCode = dummy;
            date = dateTimePicker1.Value.Day.ToString() + "-" + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Year.ToString();
            time = timetxt1.Text + " To " + timetxt2.Text;
            marks = markstxt.Text;
            attempt = attempttxt.Text;



            if (isValidated() == true)
            {
                if (listBox2.Items.Count != 0)
                {
                    bunifuCircleProgressbar1.Visible = true;
                    generatebtn.Visible = false;
                    for (int i = 1; i <= 300; i++)
                    {

                        Thread.Sleep(4);
                        bunifuCircleProgressbar1.Value = i;
                        bunifuCircleProgressbar1.Update();


                    }

                    if (Convert.ToInt32(listBox2.Items.Count) >= Convert.ToInt32(attempt))
                    {

                        eachque = Convert.ToInt32(marks) / Convert.ToInt32(attempt);
                        foreach (string catgry in listBox2.Items)
                        {
                            con.Open();
                            string insertquery = "insert into lastquest values('" + catgry + "','" + exam + "','" + questsub + "','" + subjectCode + "','" + date + "','" + time + "','" + marks + "','" + attempt + "','" + eachque + "')";
                            SqlCommand cmd2 = new SqlCommand(insertquery, con);
                            cmd2.ExecuteNonQuery();
                            con.Close();
                        }

                        Question_Paper qp = new Question_Paper();
                        qp.ShowDialog();
                        generatebtn.Visible = true;
                        bunifuCircleProgressbar1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No. of Questions to attempt cannot be greater than no. of Selected questions.");
                        generatebtn.Visible = true;
                        bunifuCircleProgressbar1.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Plz select some questions!!!");
                    generatebtn.Visible = true;
                    bunifuCircleProgressbar1.Visible = false;
                }
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard d = new dashboard(userLbl);
            d.Show();
        }

    }
}
