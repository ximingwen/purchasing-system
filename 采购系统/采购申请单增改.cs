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
    public partial class 采购申请单增改 : Form
    {
        public 采购申请单增改()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (tbStu1.Text == "" || tbStu2.Text == "" || tbStu3.Text == "" || tbStu4.Text == "" || tbStu5.Text == "" || tbStu7.Text == "")
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }*/

            string strInsert = " INSERT INTO 采购申请单(采购申请单编号,物料名称,物料号,类型,数量,参考价格,预计到货时间,申请原因,生成订单) VALUES ( '";
            strInsert += textBox1.Text + "','";
            strInsert += textBox2.Text + "','";
            strInsert += textBox4.Text + "','";
            strInsert += textBox5.Text + "','";
            strInsert += textBox6.Text + "','";
            strInsert += textBox7.Text + "','";
            strInsert += riqi.Value.Date.ToString("yy-MM-dd") + "','";
            strInsert += textBox8.Text + "',false)";
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
                MessageBox.Show("申请单编号已重复，请查证！");
            }

            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void 采购申请单增改_Load(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            string strSle = "select max(采购申请单编号) from 采购申请单";
            OleDbCommand inst = new OleDbCommand(strSle, con);
            int s = Convert.ToInt32(inst.ExecuteScalar().ToString()) + 1;
            textBox1.Text = s.ToString();
        }
    }
}
