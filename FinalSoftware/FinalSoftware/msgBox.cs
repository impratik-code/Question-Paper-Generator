using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalSoftware
{
    public partial class msgBox : Form
    {

        string errormsg;
        public msgBox()
        {
            InitializeComponent();
        }
        public msgBox(string msg)
        {
            InitializeComponent();
            errormsg = msg;
            msgLbl.Text = errormsg;
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
