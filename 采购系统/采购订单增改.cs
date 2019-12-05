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
    public partial class 采购订单增改 : Form
    {
        public 采购订单增改()
        {
            InitializeComponent();
        }

        private void 采购订单增改_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\purchasing.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            string SQL = "select 采购申请单编号,物料名称,物料号,类型,数量,参考价格,预计到货时间,申请原因 from 采购申请单 where 生成订单=false and 采购部审核=true";
            DataSet myds = new DataSet();
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
            adper.Fill(myds);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = myds.Tables[0];
            string[] items = { "是","否" };
            finish.Items.Clear();
            finish.Items.AddRange(items);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells["采购申请单编号"].Value.ToString();
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            con.Open();
            string strSle = "select 物料名称,物料号,类型,数量,参考价格,采购申请单编号 from 采购申请单 where 采购申请单编号=" + a  ;
            myada1 = new OleDbDataAdapter(strSle, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            textBox2.Text = myds.Tables[0].Rows[0]["物料名称"].ToString();
            textBox3.Text = myds.Tables[0].Rows[0]["物料号"].ToString();
            textBox5.Text = myds.Tables[0].Rows[0]["类型"].ToString();
            textBox6.Text = myds.Tables[0].Rows[0]["数量"].ToString();
            textBox7.Text = myds.Tables[0].Rows[0]["参考价格"].ToString();
            textBox11.Text = myds.Tables[0].Rows[0]["采购申请单编号"].ToString();
            strSle = "select max(采购订单编号) from 采购合同";
            OleDbCommand inst = new OleDbCommand(strSle, con);
            int s =Convert.ToInt32( inst.ExecuteScalar().ToString())+1;
            textBox1.Text = s.ToString();
        }
        //增加采购订单
        private void button1_Click(object sender, EventArgs e)
        {
            string strInsert = " INSERT INTO 采购合同(采购申请单编号,采购订单编号,物料名称,物料号,类型,采购数量,采购金额,采购人,职工编号,供应商编号,生成日期) VALUES ( ";
            strInsert += textBox11.Text + ",";
            strInsert += textBox1.Text + ",'";
            strInsert += textBox2.Text + "','";
            strInsert += textBox3.Text + "','";
            strInsert += textBox5.Text + "','";
            strInsert += textBox6.Text + "','";
            strInsert += textBox7.Text + "','";
            strInsert += textBox8.Text + "','";
            strInsert += textBox4.Text + "','";
            strInsert += textBox10.Text + "','";
            strInsert += riqi.Value.Date.ToString("yy-MM-dd")+"')";
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
               // MessageBox.Show("合同编号已重复，请查证！");
            }
            //更新申请表
            if (finish.SelectedIndex == 0)
            {
                String Update = "UPDATE 采购申请单 SET 生成订单=true where 采购申请单编号="+textBox11.Text  ;
                inst = new OleDbCommand(Update, con);
                inst.ExecuteNonQuery();
                //重新加载待统计
                string SQL = "select 采购申请单编号,物料名称,物料号,类型,数量,参考价格,预计到货时间,申请原因 from 采购申请单 where 生成订单=false";
                DataSet myds = new DataSet();
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, con);
                adper.Fill(myds);
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.DataSource = myds.Tables[0];
                string[] items = { "是", "否" };
                finish.Items.Clear();
                finish.Items.AddRange(items);

            }
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
         
            
        }


      
    }
}
