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
    public partial class 供应商操作 : Form
    {
        public 供应商操作()
        {
            InitializeComponent();
        }

       

     
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\purchasing.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            if (e.TabPage ==tabPage1)
            {
                String SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=false";
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                DataSet myds = new DataSet();
                adper.Fill(myds);
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.DataSource = myds.Tables[0];
                //已确认
                SQL = "select * from 采购合同 where 供应商确认=true and 供应商驳回=false";
                adper = new OleDbDataAdapter(SQL, conn);
                myds = new DataSet();
                adper.Fill(myds);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.DataSource = myds.Tables[0];
                //已驳回
                SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=true";
                adper = new OleDbDataAdapter(SQL, conn);
                myds = new DataSet();
                adper.Fill(myds);
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.DataSource = myds.Tables[0];
            }
            if (e.TabPage == tabPage2)
            {
                String SQL = "select * from 退换货申请表 where 供应商确认=false and 是否驳回=false";
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                DataSet myds = new DataSet();
                adper.Fill(myds);
                dataGridView6.AllowUserToAddRows = false;
                dataGridView6.DataSource = myds.Tables[0];
                //已确认
                SQL = "select * from 退换货申请表 where 供应商确认=true and 是否驳回=false";
                adper = new OleDbDataAdapter(SQL, conn);
                myds = new DataSet();
                adper.Fill(myds);
                dataGridView5.AllowUserToAddRows = false;
                dataGridView5.DataSource = myds.Tables[0];
                //已驳回
                SQL = "select * from 退换货申请表 where 供应商确认=false and 是否驳回=true";
                adper = new OleDbDataAdapter(SQL, conn);
                myds = new DataSet();
                adper.Fill(myds);
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.DataSource = myds.Tables[0];
            }
        }
        //合同确定
        private void button1_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            string strUpdate = "UPDATE 采购合同 SET 供应商确认=true where 采购订单编号=" + number;
            con.Open();
            OleDbCommand inst = new OleDbCommand(strUpdate, con);
            inst.ExecuteNonQuery();
           
            MessageBox.Show("修改成功！");
            //刷新
            String SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=false";
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, con);
            DataSet myds = new DataSet();
            adper.Fill(myds);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = myds.Tables[0];
            SQL = "select * from 采购合同 where 供应商确认=true and 供应商驳回=false";
            adper = new OleDbDataAdapter(SQL, con);
            myds = new DataSet();
            adper.Fill(myds);
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.DataSource = myds.Tables[0];

        }
        //合同驳回
        private void button2_Click(object sender, EventArgs e)
        {
            采购合同驳回 re_turn = new 采购合同驳回();
            re_turn.textBox2.Text = number;
            re_turn.ShowDialog();

            //刷新
           /* String SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=false";
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, con);
            DataSet myds = new DataSet();
            adper.Fill(myds);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = myds.Tables[0];
            SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=true";
            adper = new OleDbDataAdapter(SQL, con);
            myds = new DataSet();
            adper.Fill(myds);
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.DataSource = myds.Tables[0];*/
        }
        //退换货申请确定
        private void button4_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            string time = DateTime.Now.ToString("yy-MM-dd");
            string strUpdate = "UPDATE 退换货申请表 SET 供应商确认=true, 供应商确认时间='"+time+"' where 退换货申请编号="+number; 
            con.Open();
            OleDbCommand inst = new OleDbCommand(strUpdate, con);
            inst.ExecuteNonQuery();
            MessageBox.Show("修改成功！");
            //刷新
            String SQL = "select * from 退换货申请表 where 供应商确认=false and 是否驳回=false";
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, con);
            DataSet myds = new DataSet();
            adper.Fill(myds);
            dataGridView6.AllowUserToAddRows = false;
            dataGridView6.DataSource = myds.Tables[0];
            SQL = "select * from 退换货申请表 where 供应商确认=true and 是否驳回=false";
            adper = new OleDbDataAdapter(SQL, con);
            myds = new DataSet();
            adper.Fill(myds);
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.DataSource = myds.Tables[0];

        }
        //退换货申请驳回
        private void button3_Click(object sender, EventArgs e)
        {
            退换货驳回 re_turn= new 退换货驳回();
            re_turn.textBox2.Text = number;
            re_turn.ShowDialog();
            
        }
       
        string number;
        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView6.CurrentRow.Index;
            number = dataGridView6.Rows[a].Cells["退换货申请编号"].Value.ToString();
            textBox2.Text = number;
        }

 

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            number = dataGridView1.Rows[a].Cells["采购订单编号"].Value.ToString();
            textBox3.Text = number;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            欢迎界面 welcome = new 欢迎界面();
            welcome.Show();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }
        //待确认合同刷新
        private void button7_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection conn = new OleDbConnection(constr);
            String SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=false";
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
            DataSet myds = new DataSet();
            adper.Fill(myds);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = myds.Tables[0];
            //已确认
            SQL = "select * from 采购合同 where 供应商确认=true and 供应商驳回=false";
            adper = new OleDbDataAdapter(SQL, conn);
            myds = new DataSet();
            adper.Fill(myds);
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.DataSource = myds.Tables[0];
            //已驳回
            SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=true";
            adper = new OleDbDataAdapter(SQL, conn);
            myds = new DataSet();
            adper.Fill(myds);
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.DataSource = myds.Tables[0];
 
        }
        //退换货申请刷新
        private void button8_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection conn = new OleDbConnection(constr);
            String SQL = "select * from 退换货申请表 where 供应商确认=false and 是否驳回=false";
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
            DataSet myds = new DataSet();
            adper.Fill(myds);
            dataGridView6.AllowUserToAddRows = false;
            dataGridView6.DataSource = myds.Tables[0];
            //已确认
            SQL = "select * from 退换货申请表 where 供应商确认=true and 是否驳回=false";
            adper = new OleDbDataAdapter(SQL, conn);
            myds = new DataSet();
            adper.Fill(myds);
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.DataSource = myds.Tables[0];
            //已驳回
            SQL = "select * from 退换货申请表 where 供应商确认=false and 是否驳回=true";
            adper = new OleDbDataAdapter(SQL, conn);
            myds = new DataSet();
            adper.Fill(myds);
            dataGridView4.AllowUserToAddRows = false;
        }

       
    }
}
