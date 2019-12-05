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
    public partial class 采购单驳回 : Form
    {
        public 采购单驳回()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            string strUpdate = "UPDATE 采购申请单 SET 是否驳回=true where 采购申请单编号=" + textBox2.Text;
            con.Open();
            OleDbCommand inst = new OleDbCommand(strUpdate, con);
            inst.ExecuteNonQuery();
            MessageBox.Show("修改成功！");
            this.Hide();
        }
    }
}
