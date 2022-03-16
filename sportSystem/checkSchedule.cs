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
    public partial class checkSchedule : Form
    {

        string connstr = "server=YUAN;database=sportSystem;Trusted_Connection = True";
        public checkSchedule()
        {
            InitializeComponent();
            xiala();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                string sql = "";
                if (comboBox1.Text.Trim() != "")
                {
                    sql = sql + "spevent.Eno='" + comboBox1.Text.ToString() + "' and ";
                }
                if (textBox1.Text.Trim() != "")
                {
                    sql = sql + "athletes.Ano='" + textBox1.Text.ToString() + "' and ";
                }

                sql = sql.Substring(0, sql.Length - 5);
                string sql_select = "SELECT DISTINCT athletes.Ano,spevent.Eno,athletes.Aname,athletes.Asex,athletes.Aage,athletes.team,spevent.Ename,spevent.Edate,spevent.Eplace FROM athletes,grade,spevent WHERE athletes.Ano=grade.Ano AND grade.Eno=spevent.Eno and " + sql + " ORDER BY athletes.Ano,spevent.Eno ASC; ";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql_select, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                SqlConnection conn1 = new SqlConnection(connstr);
                SqlCommand scmd1 = new SqlCommand(sql_select, conn1);
                SqlDataAdapter sda1 = new SqlDataAdapter(scmd1);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "spevent");
                dataGridView1.DataSource = ds1.Tables["spevent"];

                int width = this.dataGridView1.Width;
                //求出每一列的header宽度
                int avgWidth = width / ds1.Tables["spevent"].Columns.Count;
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    //设置每一列的宽度
                    this.dataGridView1.Columns[i].Width = avgWidth;
                }
            }
            catch (Exception fe)
            {
                string sql_check = "exec all_schedule";
                SqlCommand scmd = new SqlCommand(sql_check, conn);
                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "grade");
                dataGridView1.DataSource = ds.Tables["grade"];
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string sql = "select grade.Ano,athletes.Aname,grade.Eno,spevent.Ename,athletes.Ecount from athletes,grade,spevent where athletes.Ano=grade.Ano and grade.Eno=spevent.Eno";
            if (textBox2.Text.Trim() == "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

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
            else
            {
                sql = "select grade.Ano,athletes.Aname,grade.Eno,spevent.Ename,athletes.Ecount from athletes,grade,spevent where athletes.Ano=grade.Ano and grade.Eno=spevent.Eno and athletes.Ano='"+textBox2.Text.ToString()+"'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string sql = "select team,Acount from team_grade";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

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
    }
}
