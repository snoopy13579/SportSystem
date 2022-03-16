using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sportSystem
{
    public partial class athletesMatchMgr : Form
    {
        string Ano, Eno;

        string connstr = "server=YUAN;database=sportSystem;Trusted_Connection = True";
        public athletesMatchMgr()
        {
            InitializeComponent();
            xiala();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                Ano = textBox1.Text.ToString();
                Eno = comboBox1.Text.ToString();
                
                string sqlCheck = "select * from athletes where Ano='" + Ano + "'";
                SqlCommand scmd_chk = new SqlCommand(sqlCheck, conn);
                SqlDataAdapter sda_chk = new SqlDataAdapter(scmd_chk);
                DataSet ds_chk = new DataSet();
                sda_chk.Fill(ds_chk, "athletes");
                dataGridView1.DataSource = ds_chk.Tables["athletes"];
                
                int val = int.Parse(ds_chk.Tables[0].Rows[0]["Ecount"].ToString());
                if (val >= 3)
                {
                    MessageBox.Show("报名失败，每人最多报3个项目，报名数量达到上限！");
                    return;
                }

                string sql = "insert into grade(Ano,Eno,grade) values ('" + Ano + "','" + Eno + "',null);";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("提交成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //显示所有运动员信息
            string sql_check = "select grade.Ano,grade.Eno,Ename from grade,spevent where grade.Eno=spevent.Eno";
            SqlCommand scmd = new SqlCommand(sql_check, conn);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "grade");
            dataGridView1.DataSource = ds.Tables["grade"];

            int width = this.dataGridView1.Width;
            //求出每一列的header宽度
            int avgWidth = width / ds.Tables["grade"].Columns.Count;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //设置每一列的宽度
                this.dataGridView1.Columns[i].Width = avgWidth;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                Ano = textBox3.Text.ToString();
                Eno = comboBox2.Text.ToString();

                string sql = "delete from grade where Ano='" + Ano + "'and Eno='" + Eno + "';";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                if (textBox3.Text.Trim() == "" || comboBox2.Text.Trim() == "")
                {
                    MessageBox.Show("数据输入有误");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //显示所有运动员信息
            string sql_check = "select grade.Ano,grade.Eno,Ename from grade,spevent where grade.Eno=spevent.Eno";
            SqlCommand scmd = new SqlCommand(sql_check, conn);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "grade");
            dataGridView1.DataSource = ds.Tables["grade"];

            int width = this.dataGridView1.Width;
            //求出每一列的header宽度
            int avgWidth = width / ds.Tables["grade"].Columns.Count;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //设置每一列的宽度
                this.dataGridView1.Columns[i].Width = avgWidth;
            }
        }
       
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string sql_check = "select grade.Ano,grade.Eno,Ename from grade,spevent where grade.Eno=spevent.Eno";
            SqlCommand scmd = new SqlCommand(sql_check, conn);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "grade");
            dataGridView1.DataSource = ds.Tables["grade"];

            int width = this.dataGridView1.Width;
            //求出每一列的header宽度
            int avgWidth = width / ds.Tables["grade"].Columns.Count;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //设置每一列的宽度
                this.dataGridView1.Columns[i].Width = avgWidth;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            comboBox2.Text = "";
        }

        private void xiala()
        {
            SqlConnection conn = new SqlConnection(connstr);
            string sql_check = "select Eno from spevent";
            SqlCommand scmd = new SqlCommand(sql_check, conn);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "grade");

            this.comboBox1.DataSource = ds.Tables[0];
            this.comboBox1.DisplayMember = "Eno";
            this.comboBox1.ValueMember = "";

            this.comboBox2.DataSource = ds.Tables[0];
            this.comboBox2.DisplayMember = "Eno";
            this.comboBox2.ValueMember = "";
        }
    }
}
