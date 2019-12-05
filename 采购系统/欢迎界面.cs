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
    public partial class 欢迎界面 : Form
    {
        采购管理 Purchaser;
        库存管理 Keeper;
        质检管理 Checker;
        供应商操作 Supplier;

        static public string Num;
        public 欢迎界面()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //string constr="Provider ={ Microsoft Access Driver(*.mdb, *.accdb)}; DBQ=" + Application.StartupPath + "\\purchasing.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\purchasing.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            if (ID.Text == "" && PW.Text != "")
                MessageBox.Show("请输入用户名");
            if (PW.Text == "" && ID.Text != "")
                MessageBox.Show("请输入密码");
            if (ID.Text == "" && PW.Text == "")
                MessageBox.Show("请输入用户名和密码");
            else
            {
                if (purchaser.Checked == false && keeper.Checked == false && checker.Checked == false && supplier.Checked == false)
                    MessageBox.Show("请选择登录身份");
                else
                {

                    if (purchaser.Checked == true)
                    {
                        string cstr = "select * from 职工表 where 职工编号='" + ID.Text.Trim() + "' and 登录密码='" + PW.Text.Trim() + "' and 职务='采购员'";
                        OleDbCommand comm = new OleDbCommand(cstr, conn);
                        OleDbDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            Num = ID.Text.Trim();
                            this.Hide();
                            Purchaser = new 采购管理();
                            string SQL = "select 采购申请单编号,物料名称,物料号,类型,数量,参考价格,预计到货时间,申请原因 from 采购申请单";
                            DataSet myds = new DataSet();
                            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                            adper.Fill(myds);
                            Purchaser.dataGridView3.AllowUserToAddRows = false;
                            Purchaser.dataGridView3.DataSource = myds.Tables[0];
                            SQL = "select 采购申请单编号,物料名称,物料号,类型,数量,参考价格,预计到货时间,申请原因  from 采购申请单 where 采购部审核=false and 是否驳回=false";
                            adper = new OleDbDataAdapter(SQL, conn);
                            myds = new DataSet();
                            adper.Fill(myds);
                            Purchaser.dataGridView2.AllowUserToAddRows = false;
                            Purchaser.dataGridView2.DataSource = myds.Tables[0];
                            Purchaser.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码输入错误，请重新输入！");
                            ID.Text = "";
                            PW.Text = "";
                        }
                    }
                    if (keeper.Checked == true)
                    {
                        string cstr = "select * from 职工表 where 职工编号='"+ID.Text+ "'and 登录密码='"+PW.Text+ "'and 职务='库存保管员'";
                        OleDbCommand comm = new OleDbCommand(cstr, conn);
                        OleDbDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            Num = ID.Text.Trim();
                            this.Hide();
                            Keeper = new 库存管理();
                            string SQL = "select 入库单号,验收单编号,物料号,仓库编号,类型,数量,入库人,入库时间,职工编号 from 入库单";
                            DataSet myds = new DataSet();
                            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                            adper.Fill(myds);
                            Keeper.dataGridView3.AllowUserToAddRows = false;
                            Keeper.dataGridView3.DataSource = myds.Tables[0];
                            Keeper.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码输入错误，请重新输入！");
                            ID.Text = "";
                            PW.Text = "";
                        }
                    }
                    if (checker.Checked == true)
                    {
                        string cstr = "select * from 职工表 where 职工编号='" + ID.Text + "'and 登录密码='" + PW.Text + "'and 职务='质检员'";
                        OleDbCommand comm = new OleDbCommand(cstr, conn);
                        OleDbDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            //入库单号,验收单编号,物料号,仓库编号,类型,数量,入库人,入库时间,职工编号
                            Num = ID.Text.Trim();
                            this.Hide();
                            Checker = new 质检管理();
                            string SQL = "select * from 验收单";
                            DataSet myds = new DataSet();
                            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                            adper.Fill(myds);
                            Checker.dataGridView1.AllowUserToAddRows = false;
                            Checker.dataGridView1.DataSource = myds.Tables[0];
                            Checker.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码输入错误，请重新输入！");
                            ID.Text = "";
                            PW.Text = "";
                        }
                    }
                    if (supplier.Checked == true)
                    {
                        string cstr = "select * from 供应商信息表 where 供应商编号='" + ID.Text.Trim() + "'and 密码='" + PW.Text.Trim() + " '";
                        OleDbCommand comm = new OleDbCommand(cstr, conn);
                        OleDbDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            Num = ID.Text.Trim();
                            this.Hide();
                            Supplier = new 供应商操作();
                            String SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=false";
                            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                            DataSet myds = new DataSet();
                            adper.Fill(myds);
                            Supplier.dataGridView1.AllowUserToAddRows = false;
                            Supplier.dataGridView1.DataSource = myds.Tables[0];
                            //已确认
                            SQL = "select * from 采购合同 where 供应商确认=true and 供应商驳回=false";
                            adper = new OleDbDataAdapter(SQL, conn);
                            myds = new DataSet();
                            adper.Fill(myds);
                            Supplier.dataGridView2.AllowUserToAddRows = false;
                            Supplier.dataGridView2.DataSource = myds.Tables[0];
                            //已驳回
                            SQL = "select * from 采购合同 where 供应商确认=false and 供应商驳回=true";
                            adper = new OleDbDataAdapter(SQL, conn);
                            myds = new DataSet();
                            adper.Fill(myds);
                            Supplier.dataGridView3.AllowUserToAddRows = false;
                            Supplier.dataGridView3.DataSource = myds.Tables[0];
                            Supplier.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("用户名或密码输入错误，请重新输入！");
                            ID.Text = "";
                            PW.Text = "";
                        }
                    }

                }
            }
        }
    }
}
