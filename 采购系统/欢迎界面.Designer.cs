namespace 采购系统
{
    partial class 欢迎界面
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.keeper = new System.Windows.Forms.RadioButton();
            this.purchaser = new System.Windows.Forms.RadioButton();
            this.checker = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.TextBox();
            this.PW = new System.Windows.Forms.TextBox();
            this.supplier = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文行楷", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(204, 76);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(232, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎登录";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(189, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(189, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "密  码";
            // 
            // keeper
            // 
            this.keeper.AutoSize = true;
            this.keeper.Location = new System.Drawing.Point(29, 331);
            this.keeper.Name = "keeper";
            this.keeper.Size = new System.Drawing.Size(123, 22);
            this.keeper.TabIndex = 3;
            this.keeper.Text = "仓库管理员";
            this.keeper.UseVisualStyleBackColor = true;
            // 
            // purchaser
            // 
            this.purchaser.AutoSize = true;
            this.purchaser.Location = new System.Drawing.Point(193, 331);
            this.purchaser.Name = "purchaser";
            this.purchaser.Size = new System.Drawing.Size(96, 22);
            this.purchaser.TabIndex = 4;
            this.purchaser.Text = " 采购员";
            this.purchaser.UseVisualStyleBackColor = true;
            // 
            // checker
            // 
            this.checker.AutoSize = true;
            this.checker.Location = new System.Drawing.Point(349, 331);
            this.checker.Name = "checker";
            this.checker.Size = new System.Drawing.Size(87, 22);
            this.checker.TabIndex = 5;
            this.checker.Text = "质检员";
            this.checker.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(193, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "登  录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(391, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 41);
            this.button2.TabIndex = 7;
            this.button2.Text = "忘记密码";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(312, 201);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(124, 28);
            this.ID.TabIndex = 8;
            // 
            // PW
            // 
            this.PW.Location = new System.Drawing.Point(312, 268);
            this.PW.Name = "PW";
            this.PW.PasswordChar = '*';
            this.PW.Size = new System.Drawing.Size(124, 28);
            this.PW.TabIndex = 9;
            // 
            // supplier
            // 
            this.supplier.AutoSize = true;
            this.supplier.Location = new System.Drawing.Point(499, 331);
            this.supplier.Name = "supplier";
            this.supplier.Size = new System.Drawing.Size(87, 22);
            this.supplier.TabIndex = 10;
            this.supplier.Text = "供应商";
            this.supplier.UseVisualStyleBackColor = true;
            // 
            // 欢迎界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 467);
            this.Controls.Add(this.supplier);
            this.Controls.Add(this.PW);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checker);
            this.Controls.Add(this.purchaser);
            this.Controls.Add(this.keeper);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "欢迎界面";
            this.Text = "欢迎来到采购管理系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton keeper;
        private System.Windows.Forms.RadioButton purchaser;
        private System.Windows.Forms.RadioButton checker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox PW;
        private System.Windows.Forms.RadioButton supplier;
    }
}

