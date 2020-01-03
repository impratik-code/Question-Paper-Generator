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
    public partial class Question_Paper : Form
    {
        string constring;
        public Question_Paper()
        {
            InitializeComponent();
        }

        private void Question_Paper_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            QuestionReport cryrpt = new QuestionReport();
            constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter sda = new SqlDataAdapter("select * from lastquest", con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "lastquest");
            cryrpt.Load(@"C:\Users\pratik\Documents\Visual Studio 2010\Projects\QuestionPaperGenerater\QuestionPaperGenerater\QuestionReport.rpt");
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void Question_Paper_FormClosed(object sender, FormClosedEventArgs e)
        {
            constring = "Data Source=VIREN-PC\\SQLEXPRESS;Initial Catalog=QPGenerator;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("truncate table lastquest", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
