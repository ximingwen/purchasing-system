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
    public partial class 验收单增改 : Form
    {
        public 验收单增改()
        {
            InitializeComponent();
        }

        private void 验收单增改_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\purchasing.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            string SQL = "select * from 采购合同 where 是否处理=false";
            DataSet myds = new DataSet();
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
            adper.Fill(myds);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = myds.Tables[0];
            string[] items = { "是", "否" };
            finish.Items.Clear();
            finish.Items.AddRange(items);
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(items);
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(items);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells["采购订单编号"].Value.ToString();
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            con.Open();
            string strSle = "select 物料名称,物料号,类型,采购数量,供应商编号,采购申请单编号 from 采购合同 where 采购订单编号=" + a;
            myada1 = new OleDbDataAdapter(strSle, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            textBox2.Text = myds.Tables[0].Rows[0]["物料名称"].ToString();
            textBox3.Text = myds.Tables[0].Rows[0]["物料号"].ToString();
            textBox11.Text = a;
            textBox5.Text = myds.Tables[0].Rows[0]["类型"].ToString();
            textBox6.Text = myds.Tables[0].Rows[0]["采购数量"].ToString();
            textBox10.Text = myds.Tables[0].Rows[0]["供应商编号"].ToString();
            strSle = "select max(验收单编号) from 验收单";
            OleDbCommand inst = new OleDbCommand(strSle, con);
            int s = Convert.ToInt32(inst.ExecuteScalar().ToString()) + 1;
            textBox1.Text = s.ToString();
        }
        //插入新的
        private void button1_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            string re_turngood;
            string re_turnfee;
            string fin_ish;
          
            if (finish.SelectedIndex == 0)
            {
                fin_ish = "true";

            }
            else
            {
                fin_ish = "false";
            }
            if (comboBox1.SelectedIndex == 0)
            {
                re_turngood = "true";

            }
            else
            {
                re_turngood = "false";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                re_turnfee = "true";

            }
            else
            {
                re_turnfee = "false";
            }
            string strInsert = " INSERT INTO 验收单(验收单编号,采购订单编号,物料名称,物料号,验收人,职工编号,验收数量,验收时间,是否重新发货,是否退费,处理时间,是否完成,供应商编号) VALUES ( ";
            strInsert += textBox1.Text + ",";
            strInsert += textBox11.Text + ",'";
            strInsert += textBox2.Text + "','";
            strInsert += textBox3.Text + "','";
            strInsert += textBox8.Text + "','";
            strInsert += textBox9.Text + "','";
            strInsert += textBox6.Text + "','";
            strInsert += dateTimePicker1.Value.ToString("yy-MM-dd") + "',";
            strInsert += re_turngood + ",";
            strInsert += re_turnfee + ",'";
            strInsert += riqi.Value.Date.ToString("yy-MM-dd") + "',";
            strInsert += fin_ish+ ",'";
            strInsert += textBox10.Text + "')";
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox11.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }


    }
}
