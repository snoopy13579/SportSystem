using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sportSystem
{
    public partial class eventMgr : Form
    {
        string Eno, Eplace, Ename,Eattrib;

        string connstr = "server=YUAN;database=sportSystem;Trusted_Connection = True";

        //添加重置
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        //刷新按钮
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sql_check = "select * from spevent";
            select_info(sql_check);
        }

        public eventMgr()
        {
            InitializeComponent();
            xiala();
        }

        //删除
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            try
            {
                Eno = comboBox1.Text.ToString();
                if (Eno.Trim() == "")
                {
                    MessageBox.Show("编号不能为空！");
                    return;
                }

                string sql2 = "select COUNT(Eno)  AS count from grade where Eno='" + Eno + "'";
                SqlCommand scmd2 = new SqlCommand(sql2, conn);
                SqlDataAdapter sda2 = new SqlDataAdapter(scmd2);
                DataSet ds2 = new DataSet();
                sda2.Fill(ds2, "athletes");
                dataGridView1.DataSource = ds2.Tables["athletes"];
                int count = int.Parse(ds2.Tables[0].Rows[0]["count"].ToString());

                string sql3 = "select * from grade where Eno='" + Eno + "'";
                SqlCommand scmd3 = new SqlCommand(sql3, conn);
                SqlDataAdapter sda3 = new SqlDataAdapter(scmd3);
                DataSet ds3 = new DataSet();
                sda3.Fill(ds3, "athletes");
                dataGridView1.DataSource = ds3.Tables["athletes"];

                for (int i = 0; i < count; i++)
                {
                    string sql = "delete from grade where Eno='" + Eno + "' and Ano='" + ds3.Tables[0].Rows[i]["Ano"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                string sql1 = "delete from spevent where Eno='" + Eno + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("执行完毕！");
            }
            catch (Exception fe)
            {
                MessageBox.Show("数据输入有误");
            }

            //显示所有运动员信息
            string sql_check = "select * from spevent";
            select_info(sql_check);
            xiala();
        }

        //添加提交
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                Eno = textBox1.Text.ToString();
                Eplace = textBox2.Text.ToString();
                Ename = textBox3.Text.ToString();
                radioButton1.Checked = true;
                if (Eno.Trim() == "" || Eplace.Trim() == "" || Ename.Trim() == "")
                {
                    MessageBox.Show("不允许有空值！");
                    return;
                }
                if (radioButton1.Checked == true)
                {
                    Eattrib = "升";
                }
                else
                {
                    Eattrib = "降";
                }

                string sql = "insert into spevent(Eno,Edate,Eplace,Ename,Eattrib) values ('" + Eno + "','" + dateTimePicker1.Value + "','" + Eplace + "','" + Ename + "','"+Eattrib+"');";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("提交成功");
            }
            catch (Exception fe)
            {
                MessageBox.Show("数据输入有误");
            }

            //显示所有运动员信息
            string sql_check = "select * from spevent";
            select_info(sql_check);
            xiala();
        }

        //进入修改
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                Eno = comboBox2.Text.ToString();
                string sql = "select * from spevent where Eno='" + Eno + "'";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                textBox4.Enabled = true;
                textBox5.Enabled = true;
                dateTimePicker2.Enabled = true;

            }
            catch (Exception fe)
            {
                MessageBox.Show("数据输入有误");
            }


            //显示所有运动员信息
            string sql_check = "select * from spevent where Eno='" + Eno + "'";
            SqlCommand scmd = new SqlCommand(sql_check, conn);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "spevent");
            dataGridView1.DataSource = ds.Tables["spevent"];

            try
            {
                //填入默认信息
                string val = ds.Tables[0].Rows[0]["Edate"].ToString();
                dateTimePicker2.Text = val;
                string val1 = ds.Tables[0].Rows[0]["Eplace"].ToString();
                textBox5.Text = val1;
                string val2 = ds.Tables[0].Rows[0]["Ename"].ToString();
                textBox4.Text = val2;
            }
            catch (Exception fe)
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                dateTimePicker2.Enabled = false;
                MessageBox.Show("输入信息有误！");
            }


            int width = this.dataGridView1.Width;
            //求出每一列的header宽度
            int avgWidth = width / ds.Tables["spevent"].Columns.Count;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //设置每一列的宽度
                this.dataGridView1.Columns[i].Width = avgWidth;
            }
        }

        //查询提交
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string sql = "";
            try
            {
                if (comboBox3.Text.Trim() != "")
                {
                    sql = sql + "Eno='" + comboBox3.Text.ToString() + "' and ";
                }
                if (textBox7.Text.Trim() != "")
                {
                    sql = sql + "Eplace='" + textBox7.Text.ToString() + "' and ";
                }
                if (textBox8.Text.Trim() != "")
                {
                    sql = sql + "Ename='" + textBox8.Text.ToString() + "' and ";
                }
                sql = sql.Substring(0, sql.Length - 5);
                string sql_select = "select * from spevent where " + sql;
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql_select, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                select_info(sql_select);
            }
            catch (Exception fe)
            {
                MessageBox.Show("条件输入异常！");
            }
        }

        //查询重置
        private void button7_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox7.Clear();
            textBox8.Clear();
        }

        //修改提交
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {

                Ename = textBox4.Text.ToString();
                Eplace = textBox5.Text.ToString();


                string sql = "update spevent set Edate='" + dateTimePicker2.Value + "',Ename='" + Ename + "',Eplace='" + Eplace + "' where Eno='" + Eno + "'";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("修改成功");
            }
            catch (Exception fe)
            {
                MessageBox.Show("数据输入有误");
            }

            //显示所有运动员信息
            string sql_check = "select * from spevent";
            select_info(sql_check);
        }

        public void select_info(string sql)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand scmd = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "spevent");
            dataGridView1.DataSource = ds.Tables["spevent"];

            int width = this.dataGridView1.Width;
            //求出每一列的header宽度
            int avgWidth = width / ds.Tables["spevent"].Columns.Count;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //设置每一列的宽度
                this.dataGridView1.Columns[i].Width = avgWidth;
            }
        }

        //下拉菜单函数
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

            this.comboBox3.DataSource = ds.Tables[0];
            this.comboBox3.DisplayMember = "Eno";
            this.comboBox3.ValueMember = "";
        }
    }
}
