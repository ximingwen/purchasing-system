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
    public partial class 库存管理 : Form
    {
        public 库存管理()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            欢迎界面 welcome = new 欢迎界面();
            welcome.Show();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void 库存管理_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\purchasing.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            if (e.TabPage == increasing)
            {
                string SQL = "select * from 入库单";
                DataSet myds = new DataSet();
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                adper.Fill(myds);
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.DataSource = myds.Tables[0];
            }
            if (e.TabPage == giving)
            {
                string SQL = "select * from 出库单";
                DataSet myds = new DataSet();
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                adper.Fill(myds);
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.DataSource = myds.Tables[0];
            }
            if (e.TabPage == inventory)
            {
                string SQL = "select * from 库存信息表";
                DataSet myds = new DataSet();
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                adper.Fill(myds);
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.DataSource = myds.Tables[0];
            }
            if (e.TabPage == applying)
            {
                string SQL = "select * from 采购申请单";
                DataSet myds = new DataSet();
                OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                adper.Fill(myds);
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.DataSource = myds.Tables[0];
                //待审核5
                SQL = "select * from 采购申请单 where 采购部审核=false";
                myds = new DataSet();
                adper = new OleDbDataAdapter(SQL, conn);
                adper.Fill(myds);
                dataGridView5.AllowUserToAddRows = false;
                dataGridView5.DataSource = myds.Tables[0];
                //未通过6
                SQL = "select * from 采购申请单 where 是否驳回=true";
                myds = new DataSet();
                adper = new OleDbDataAdapter(SQL, conn);
                adper.Fill(myds);
                dataGridView6.AllowUserToAddRows = false;
                dataGridView6.DataSource = myds.Tables[0];

                //已通过7
                SQL = "select * from 采购申请单 where 是否驳回=false and 采购部审核=true";
                myds = new DataSet();
                adper = new OleDbDataAdapter(SQL, conn);
                adper.Fill(myds);
                dataGridView7.AllowUserToAddRows = false;
                dataGridView7.DataSource = myds.Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(tabControl1.SelectedIndex.ToString());

            if (a == 3)
            {
                采购申请单增改 m = new 采购申请单增改();
                m.ShowDialog();
            }
        }
    }
}
