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
    public partial class checkGrade : Form
    {
        string Ano,Eno,team;
        string connstr = "server=YUAN;database=sportSystem;Trusted_Connection = True";
        public checkGrade()
        {
            InitializeComponent();
            xiala();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Eno = comboBox1.Text.ToString();
            SqlConnection conn = new SqlConnection(connstr);
            //显示单项成绩

            string sqlCheck1 = "select * from spevent where Eno='" + Eno + "'";
            SqlCommand scmd_chk = new SqlCommand(sqlCheck1, conn);
            SqlDataAdapter sda_chk = new SqlDataAdapter(scmd_chk);
            DataSet ds_chk = new DataSet();
            sda_chk.Fill(ds_chk, "athletes");
            dataGridView1.DataSource = ds_chk.Tables["athletes"];
            string val = ds_chk.Tables[0].Rows[0]["Eattrib"].ToString();
            string sql_check;
            if (val == "降")
            {
                sql_check = "exec personal_grade '" + Eno + "'";
            }
            else
            {
                sql_check = "SELECT RANK() OVER (ORDER BY eventGrade ASC) AS 排名,grade.Ano,grade.Eno,Ename,Aname,grade,team,grade.eventGrade FROM grade, athletes, spevent WHERE athletes.Ano = grade.Ano AND grade.Eno = spevent.Eno AND grade.Eno = '" + Eno + "'";
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            comboBox2.Text="";
        }
    
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string sql_check;
            if (radioButton1.Checked)
            {
                team = "队一";
                sql_check = "select * from team_grade where team='" + team + "'";
            }
            else if (radioButton2.Checked)
            {
                team = "队二";
                sql_check = "select * from team_grade where team='" + team + "'";
            }
            else if (radioButton3.Checked)
            {
                team = "队三";
                sql_check = "select * from team_grade where team='" + team + "'";
            }
            else
            {
                sql_check = "exec result_team";
            }
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
            if (comboBox2.Text.Trim() == "")
            {
                Ano = textBox2.Text.ToString();
                SqlConnection conn = new SqlConnection(connstr);
                //显示单项成绩
                string sql_check = "select * from grade where Ano='"+Ano+"'";
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
            else
            {
                Ano = textBox2.Text.ToString();
                Eno = comboBox2.Text.ToString();
                SqlConnection conn = new SqlConnection(connstr);
                //显示单项成绩
                string sql_check = "select * from grade where Ano='" + Ano + "' and Eno='"+Eno+"'";
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
