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
    public partial class 采购管理 : Form
    {
        public 采购管理()
        {
            InitializeComponent();
        }

        private void Purchaser_Selected(object sender, TabControlEventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\purchasing.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            if (e.TabPage == pletter)
            {
                string SQL = "select * from 采购申请单 ";
                DataSet myds = new DataSet();
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                adper.Fill(myds);
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.DataSource = myds.Tables[0];
                SQL = "select 采购申请单编号,物料名称,物料号,类型,数量,参考价格,预计到货时间,申请原因 from 采购申请单 where 采购部审核=false and 是否驳回=false";
                adper = new OleDbDataAdapter(SQL, conn);
                myds = new DataSet();
                adper.Fill(myds);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.DataSource = myds.Tables[0];
            }
                if (e.TabPage == pcontract)
                {
                  string SQL = "select * from 采购合同";
                  DataSet myds = new DataSet();
                  OleDbDataAdapter  adper = new OleDbDataAdapter(SQL, conn);
                    adper.Fill(myds);
                    dataGridView4.AllowUserToAddRows = false;
                    dataGridView4.DataSource = myds.Tables[0];
                    //未通过6
                    SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=true";
                    adper = new OleDbDataAdapter(SQL, conn);
                    myds = new DataSet();
                    adper.Fill(myds);
                    dataGridView6.AllowUserToAddRows = false;
                    dataGridView6.DataSource = myds.Tables[0];
                    //通过7
                    SQL = "select * from 采购合同 where 供应商确认=true and 供应商驳回=false";
                    adper = new OleDbDataAdapter(SQL, conn);
                    myds = new DataSet();
                    adper.Fill(myds);
                    dataGridView7.AllowUserToAddRows = false;
                    dataGridView7.DataSource = myds.Tables[0];
                }
                if (e.TabPage == supplier)
                {
                   string SQL = "select * from 供应商信息表";
                   DataSet myds = new DataSet();
                   OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                    adper.Fill(myds);
                    dataGridView5.AllowUserToAddRows = false;
                    dataGridView5.DataSource = myds.Tables[0];
                }
                if (e.TabPage == changinggood)
                {

                    string SQL = "select * from 退换货申请表";
                    DataSet myds = new DataSet();
                    OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                    adper.Fill(myds);
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.DataSource = myds.Tables[0];
                    //待确认8
                    SQL = "select * from 退换货申请表 where 供应商确认=false and 是否驳回=false";
                     myds = new DataSet();
                    adper = new OleDbDataAdapter(SQL, conn);
                    adper.Fill(myds);
                    dataGridView8.AllowUserToAddRows = false;
                    dataGridView8.DataSource = myds.Tables[0];
                   
                    //未通过9
                    SQL = "select * from 退换货申请表 where 供应商确认=false and 是否驳回=true";
                    adper = new OleDbDataAdapter(SQL, conn);
                    myds = new DataSet();
                    adper.Fill(myds);
                    dataGridView9.AllowUserToAddRows = false;
                    dataGridView9.DataSource = myds.Tables[0];
                }
        }

        private void button9_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            欢迎界面 welcome = new 欢迎界面();
            welcome.Show();
        }
        //增加
        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(tabControl1.SelectedIndex.ToString());
          
           
            if (a == 1)
            {
                采购订单增改 m = new 采购订单增改();
                m.ShowDialog();
            }
            if (a == 2)
            {
                供应商增改 m = new 供应商增改();
                m.ShowDialog();
            }
            if (a == 3)
            {
                退换货增改 m = new 退换货增改();
                m.ShowDialog();
            }

        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(tabControl1.SelectedIndex.ToString());

            if (a == 0)
            {
                string strDelete = "DELETE FROM 采购申请单 WHERE 采购申请单编号='" + dataGridView3.CurrentRow.Cells["采购申请单编号"].Value.ToString() + "'";
                string mypath = Application.StartupPath + "\\purchasing.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

                OleDbConnection con = new OleDbConnection(constr);
                con.Open();
                OleDbCommand inst = new OleDbCommand(strDelete, con);
                inst.ExecuteNonQuery();
                MessageBox.Show("已删除");
                string SQL = "select 采购申请单编号,物料名称,物料号,类型,数量,参考价格,预计到货时间,申请原因 from 采购申请单";
                DataSet myds = new DataSet();
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, con);
                adper.Fill(myds);
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.DataSource = myds.Tables[0];
            }
            if (a == 1)
            {
                
            }
            if (a == 2)
            {
                
            }
            if (a == 3)
            {
            }

        }

        private void 采购管理_Load(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void changinggood_Click(object sender, EventArgs e)
        {

        }
        //待审核
        string number;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView2.CurrentRow.Index;
            number = dataGridView2.Rows[a].Cells["采购申请单编号"].Value.ToString();
            textBox18.Text = number;
            textBox12.Text = number;

        }
        //通过
        private void button16_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            string time = DateTime.Now.ToString("yy-MM-dd");
            string strUpdate = "UPDATE 采购申请单 SET 采购部审核=true where 采购申请单编号=" + number;
            con.Open();
            OleDbCommand inst = new OleDbCommand(strUpdate, con);
            inst.ExecuteNonQuery();
            MessageBox.Show("修改成功！");
            //刷新
            String SQL = "select * from 采购申请单 where 采购部审核=false and 是否驳回=false";
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, con);
            DataSet myds = new DataSet();
            adper.Fill(myds);
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.DataSource = myds.Tables[0];
        }
        //采购单驳回
        private void button15_Click(object sender, EventArgs e)
        {
            采购单驳回 re_turn = new 采购单驳回();
            re_turn.textBox2.Text = number;
            re_turn.ShowDialog();
        }

        

      
       

       
       
    }
}
