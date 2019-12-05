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
    public partial class 质检管理 : Form
    {
        public 质检管理()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            欢迎界面 welcome = new 欢迎界面();
            welcome.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            验收单增改 m = new 验收单增改();
            m.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\purchasing.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            string SQL = "select * from 验收单";
            DataSet myds = new DataSet();
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
            adper.Fill(myds);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = myds.Tables[0];
        }
    }
}
