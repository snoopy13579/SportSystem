using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace sportSystem
{
    public partial class athletesMgr : Form
    {
        string Ano, Aname, Asex, team;
        int Aage;

        string connstr = "server=YUAN;database=sportSystem;Trusted_Connection = True";

        //删除页删除按钮
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            try
            {
                Ano = textBox4.Text.ToString();
                if (Ano.Trim() == "")
                {
                    MessageBox.Show("编号不能为空！");
                    return;
                }

                string sql2 = "select COUNT(Eno)  AS count from grade where Ano='" + Ano + "'";
                SqlCommand scmd2 = new SqlCommand(sql2, conn);
                SqlDataAdapter sda2 = new SqlDataAdapter(scmd2);
                DataSet ds2 = new DataSet();
                sda2.Fill(ds2, "athletes");
                dataGridView1.DataSource = ds2.Tables["athletes"];
                int count = int.Parse(ds2.Tables[0].Rows[0]["count"].ToString());

                string sql3 = "select * from grade where Ano='" + Ano + "'";
                SqlCommand scmd3 = new SqlCommand(sql3, conn);
                SqlDataAdapter sda3 = new SqlDataAdapter(scmd3);
                DataSet ds3 = new DataSet();
                sda3.Fill(ds3, "athletes");
                dataGridView1.DataSource = ds3.Tables["athletes"];

                for (int i = 0; i <count; i++)
                {
                    string sql = "delete from grade where Ano='" + Ano + "' and Eno='" + ds3.Tables[0].Rows[i]["Eno"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                string sql1 = "delete from athletes where Ano='" + Ano + "'";
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
            string sql_check = "select * from athletes";
            select_info(sql_check);
        }

        //修改页进入修改按钮
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                Ano = textBox5.Text.ToString();
                string sql = "select * from athletes where Ano='" + Ano + "'";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                textBox6.Enabled = true;
                textBox7.Enabled = true;
                radioButton6.Enabled = true;
                radioButton7.Enabled = true;
                panel3.Enabled = true;
            }
            catch (Exception fe)
            {
                MessageBox.Show("数据输入有误");
            }


            //显示所有运动员信息
            string sql_check = "select * from athletes where Ano='" + Ano + "'";
            SqlCommand scmd = new SqlCommand(sql_check, conn);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "athletes");
            dataGridView1.DataSource = ds.Tables["athletes"];

            try
            {
                //填入默认信息
                string val = ds.Tables[0].Rows[0]["Aname"].ToString();
                textBox6.Text = val;
                string val1 = ds.Tables[0].Rows[0]["Asex"].ToString();
                if (val1 == "男") radioButton6.Checked = true;
                else radioButton7.Checked = true;
                string val2 = ds.Tables[0].Rows[0]["Aage"].ToString();
                textBox7.Text = val2;
            }
            catch (Exception fe)
            {
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                radioButton6.Enabled = false;
                radioButton7.Enabled = false;
                panel3.Enabled = false;
                MessageBox.Show("输入信息有误！");
            }


            int width = this.dataGridView1.Width;
            //求出每一列的header宽度
            int avgWidth = width / ds.Tables["athletes"].Columns.Count;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //设置每一列的宽度
                this.dataGridView1.Columns[i].Width = avgWidth;
            }
        }

        //修改页保存按钮
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                if (radioButton6.Checked) Asex = "男";
                if (radioButton7.Checked) Asex = "女";

                Ano = textBox5.Text.ToString();
                Aname = textBox6.Text.ToString();
                Aage = int.Parse(textBox7.Text.ToString());


                string sql = "update athletes set Aname='" + Aname + "',Asex='" + Asex + "',Aage=" + Aage + " where Ano='" + Ano + "'";

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
            string sql_check = "select * from athletes";
            select_info(sql_check);
        }

        //查询页查询按钮
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string sql = "";
            try
            {
                if (textBox10.Text.Trim() != "")
                {
                    sql = sql + "Ano='" + textBox10.Text.ToString() + "' and ";
                }
                if (textBox9.Text.Trim() != "")
                {
                    sql = sql + "Aname='" + textBox9.Text.ToString() + "' and ";
                }
                if (radioButton14.Checked == true)
                {
                    sql = sql + "Asex='男' and ";
                }
                if (radioButton15.Checked == true)
                {
                    sql = sql + "Asex='女' and ";
                }
                if (textBox8.Text.Trim() != "")
                {
                    sql = sql + "Aage=" + int.Parse(textBox8.Text.ToString()) + " and ";
                }
                if (radioButton12.Checked == true)
                {
                    sql = sql + "team='队一' and ";
                }
                if (radioButton13.Checked == true)
                {
                    sql = sql + "team='队二' and ";
                }
                if (radioButton11.Checked == true)
                {
                    sql = sql + "team='队三' and ";
                }
                sql = sql.Substring(0, sql.Length - 5);
                string sql_select = "select * from athletes where " + sql;
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

        //查询页重置按钮
        private void button7_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
        }

        public athletesMgr()
        {
            InitializeComponent();
        }

        //刷新按钮
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sql_check = "select * from athletes";
            select_info(sql_check);
        }

        //添加页提交按钮
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                if (radioButton1.Checked) Asex = "男";
                if (radioButton2.Checked) Asex = "女";
                if (radioButton3.Checked) team = "队一";
                if (radioButton4.Checked) team = "队二";
                if (radioButton5.Checked) team = "队三";

                Ano = textBox1.Text.ToString();
                Aname = textBox2.Text.ToString();
                Aage = int.Parse(textBox3.Text.ToString());

                string sqlCheck = "select * from team_grade where team='" + team + "'";
                SqlCommand scmd_chk = new SqlCommand(sqlCheck, conn);
                SqlDataAdapter sda_chk = new SqlDataAdapter(scmd_chk);
                DataSet ds_chk = new DataSet();
                sda_chk.Fill(ds_chk, "athletes");
                dataGridView1.DataSource = ds_chk.Tables["athletes"];

                int val = int.Parse(ds_chk.Tables[0].Rows[0]["Acount"].ToString());
                if (val >= 5)
                {
                    MessageBox.Show("提交失败，每队最多5个人，队伍人数达到上限！请选择其他队");
                    return;
                }


                string sql = "insert into athletes(Ano,Aname,Asex,Aage,team,Ecount) values ('" + Ano + "','" + Aname + "','" + Asex + "'," + Aage + ",'" + team + "',0);";

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
            string sql_check = "select * from athletes";
            select_info(sql_check);
        }

        //添加页重置按钮
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
        }

        public void select_info(string sql)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand scmd = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "athletes");
            dataGridView1.DataSource = ds.Tables["athletes"];

            int width = this.dataGridView1.Width;
            //求出每一列的header宽度
            int avgWidth = width / ds.Tables["athletes"].Columns.Count;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //设置每一列的宽度
                this.dataGridView1.Columns[i].Width = avgWidth;
            }
        }
    }
}
