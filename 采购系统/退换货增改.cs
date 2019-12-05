using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace 采购系统
{
    public partial class 退换货增改 : Form
    {
        public 退换货增改()
        {
            InitializeComponent();
        }

        private void 退换货增改_Load(object sender, EventArgs e)
        {
            //string SQL = "select 退换货申请编号,验收单编号,物料名称,物料号,供应商编号,数量,金额,采购部门审核.采购部门审核时间,供应商确认,供应商确认时间 from 退换货申请表";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\purchasing.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            string SQL = "select * from 验收单 where 是否完成=false and (是否重新发货=true or 是否退费=true)";
            DataSet myds = new DataSet();
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
            adper.Fill(myds);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = myds.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strInsert = " INSERT INTO 退换货申请表(退换货申请编号,验收单编号,物料名称,物料号,金额,数量,提交时间,申请原因) VALUES(";
            strInsert += textBox3.Text + ",";
            strInsert += textBox2.Text + ",'";
            strInsert += textBox4.Text + "','";
            strInsert += textBox5.Text + "','";
            strInsert += textBox8.Text + "','";
            strInsert += textBox7.Text + "','";
            strInsert += riqi.Value.Date.ToString("yy-MM-dd") + "','";
            strInsert += textBox9.Text + "')";
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            OleDbCommand inst = new OleDbCommand(strInsert, con);
            try
            {

                inst.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells["验收单编号"].Value.ToString();
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            con.Open();
            string strSle = "select 物料名称,物料号,验收数量,供应商编号 from 验收单 where 验收单编号=" + a;
            myada1 = new OleDbDataAdapter(strSle, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            textBox4.Text = myds.Tables[0].Rows[0]["物料名称"].ToString();
            textBox5.Text = myds.Tables[0].Rows[0]["物料号"].ToString();
            textBox2.Text = a;
            textBox6.Text = myds.Tables[0].Rows[0]["验收数量"].ToString();
            textBox7.Text = myds.Tables[0].Rows[0]["供应商编号"].ToString();
            strSle = "select max(退换货申请编号) from 退换货申请表";
            OleDbCommand inst = new OleDbCommand(strSle, con);
            int s = Convert.ToInt32(inst.ExecuteScalar().ToString()) + 1;
            textBox3.Text = s.ToString();
        }
    }
}
       