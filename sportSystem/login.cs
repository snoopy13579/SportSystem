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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {*/
                main f2 = new main();
                f2.Show(this);
                this.Visible = false;
            /*}
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
