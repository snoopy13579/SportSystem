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
    public partial class gradeMgr : Form
    {
        string Ano, Eno, grade;

        string connstr = "server=YUAN;database=sportSystem;Trusted_Connection = True;MultipleActiveResultSets=true";
        public gradeMgr()
        {
            InitializeComponent();
            xiala();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sql_check = "select * from grade";
            select_info(sql_check);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.Text = "";
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            if (textBox1.Text.Trim() == "" || comboBox1.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("不能存在空！");
            }
            else
            {
                try
                {
                    Ano = textBox1.Text.ToString();
                    Eno = comboBox1.Text.ToString();
                    grade = textBox3.Text.ToString();

                    string sqlCheck1 = "select * from spevent where Eno='" + Eno + "'";
                    SqlCommand scmd_chk = new SqlCommand(sqlCheck1, conn);
                    SqlDataAdapter sda_chk = new SqlDataAdapter(scmd_chk);
                    DataSet ds_chk = new DataSet();
                    sda_chk.Fill(ds_chk, "athletes");
                    dataGridView1.DataSource = ds_chk.Tables["athletes"];

                    string sql1 = "update grade set eventGrade=" + grade + "where Ano='" + Ano + "' and Eno='" + Eno + "'";
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand(sql1, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    string val = ds_chk.Tables[0].Rows[0]["Eattrib"].ToString();
                    if (val == "降")
                    {
                        string sqlCheck = "exec personal_grade '" + Eno + "'";

                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sqlCheck, conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int a = int.Parse(reader[0].ToString());
                            string b = reader[1].ToString();
                            string sql = "update grade set grade=" + (11 - a) + " where Ano='" + b + "' and Eno='"+Eno+"'";
                            SqlCommand cmd1 = new SqlCommand(sql, conn);
                            cmd1.ExecuteNonQuery();
                        }
                        reader.Close();
                        conn.Close();
                    }
                    else
                    {
                        string sqlCheck = "SELECT RANK() OVER (ORDER BY eventGrade ASC) AS 排名,grade.Ano,grade.Eno,Ename,Aname,grade,team,grade.eventGrade FROM grade, athletes, spevent WHERE athletes.Ano = grade.Ano AND grade.Eno = spevent.Eno AND grade.Eno = '" + Eno + "'";

                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sqlCheck, conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int a = int.Parse(reader[0].ToString());
                            string b = reader[1].ToString();
                            string sql = "update grade set grade=" + (11 - a) + " where Ano='" + b + "' and Eno='" + Eno + "'";
                            SqlCommand cmd1 = new SqlCommand(sql, conn);
                            cmd1.ExecuteNonQuery();
                        }
                        reader.Close();
                        conn.Close();
                    }

                    MessageBox.Show("更新成功！");
                }
                catch (Exception fe)
                {
                    MessageBox.Show("数据输入有误！");
                }

            }
            string sql_check = "select * from grade";
            select_info(sql_check);
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
        }
    }
}
