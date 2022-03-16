using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sportSystem
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            athletesMgr f3 = new athletesMgr();
            f3.Show(this);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login f2 = new login();
            f2.Show(this);
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            athletesMatchMgr f4 = new athletesMatchMgr();
            f4.Show(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkSchedule f5 = new checkSchedule();
            f5.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkGrade f6 = new checkGrade();
            f6.Show(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            eventMgr f7 = new eventMgr();
            f7.Show(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gradeMgr f8 = new gradeMgr();
            f8.Show(this);
        }
    }
}
