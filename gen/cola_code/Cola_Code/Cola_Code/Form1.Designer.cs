namespace php
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.db_selet = new System.Windows.Forms.ComboBox();
            this.table_list = new System.Windows.Forms.ListBox();
            this.field = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pHP代码生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成模型文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成列表程序文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据升级文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库转换工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.武汉客客ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.txtControl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.ComboBox();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.field)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "连接服务器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(74, 56);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(100, 21);
            this.txtUid.TabIndex = 2;
            this.txtUid.Text = "root";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(74, 83);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.Text = "123456";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "主机地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据库";
            // 
            // db_selet
            // 
            this.db_selet.FormattingEnabled = true;
            this.db_selet.Location = new System.Drawing.Point(74, 167);
            this.db_selet.Name = "db_selet";
            this.db_selet.Size = new System.Drawing.Size(121, 20);
            this.db_selet.TabIndex = 5;
            this.db_selet.SelectedIndexChanged += new System.EventHandler(this.db_selet_SelectedIndexChanged);
            // 
            // table_list
            // 
            this.table_list.FormattingEnabled = true;
            this.table_list.ItemHeight = 12;
            this.table_list.Location = new System.Drawing.Point(66, 210);
            this.table_list.Name = "table_list";
            this.table_list.Size = new System.Drawing.Size(180, 256);
            this.table_list.TabIndex = 6;
            this.table_list.Click += new System.EventHandler(this.table_list_Click);
            // 
            // field
            // 
            this.field.AllowUserToAddRows = false;
            this.field.AllowUserToDeleteRows = false;
            this.field.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.field.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.field.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.field.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.field.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.field.Location = new System.Drawing.Point(281, 24);
            this.field.MultiSelect = false;
            this.field.Name = "field";
            this.field.RowHeadersVisible = false;
            this.field.RowTemplate.Height = 23;
            this.field.Size = new System.Drawing.Size(436, 359);
            this.field.TabIndex = 0;
            this.field.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.field_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "Field";
            this.Column1.FillWeight = 97.65685F;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "字段代码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 78;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "asName";
            this.Column2.FillWeight = 97.65685F;
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "要显示的别名";
            this.Column2.Name = "Column2";
            this.Column2.Width = 73;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "select";
            this.Column3.FillWeight = 97.65685F;
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "作为查询字段";
            this.Column3.Name = "Column3";
            this.Column3.Width = 53;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.DataPropertyName = "search";
            this.Column4.FillWeight = 97.65685F;
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "作为搜索字段";
            this.Column4.Name = "Column4";
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.DataPropertyName = "edit";
            this.Column5.FillWeight = 97.65685F;
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "作为编辑字段";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "type";
            this.Column6.HeaderText = "type";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(281, 443);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "生成Admin程序";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pHP代码生成ToolStripMenuItem,
            this.关于我们ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(964, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pHP代码生成ToolStripMenuItem
            // 
            this.pHP代码生成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成模型文件ToolStripMenuItem,
            this.生成列表程序文件ToolStripMenuItem,
            this.数据升级文件ToolStripMenuItem,
            this.数据库转换工具ToolStripMenuItem});
            this.pHP代码生成ToolStripMenuItem.Name = "pHP代码生成ToolStripMenuItem";
            this.pHP代码生成ToolStripMenuItem.Size = new System.Drawing.Size(91, 21);
            this.pHP代码生成ToolStripMenuItem.Text = "PHP代码生成";
            // 
            // 生成模型文件ToolStripMenuItem
            // 
            this.生成模型文件ToolStripMenuItem.Name = "生成模型文件ToolStripMenuItem";
            this.生成模型文件ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.生成模型文件ToolStripMenuItem.Text = "生成模型文件";
            this.生成模型文件ToolStripMenuItem.Click += new System.EventHandler(this.生成模型文件ToolStripMenuItem_Click);
            // 
            // 生成列表程序文件ToolStripMenuItem
            // 
            this.生成列表程序文件ToolStripMenuItem.Name = "生成列表程序文件ToolStripMenuItem";
            this.生成列表程序文件ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.生成列表程序文件ToolStripMenuItem.Text = "生成列表程序文件";
            // 
            // 数据升级文件ToolStripMenuItem
            // 
            this.数据升级文件ToolStripMenuItem.Name = "数据升级文件ToolStripMenuItem";
            this.数据升级文件ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.数据升级文件ToolStripMenuItem.Text = " 数据库升级";
            this.数据升级文件ToolStripMenuItem.Click += new System.EventHandler(this.数据升级文件ToolStripMenuItem_Click);
            // 
            // 数据库转换工具ToolStripMenuItem
            // 
            this.数据库转换工具ToolStripMenuItem.Name = "数据库转换工具ToolStripMenuItem";
            this.数据库转换工具ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.数据库转换工具ToolStripMenuItem.Text = "数据库转换工具";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.武汉客客ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            // 
            // 武汉客客ToolStripMenuItem
            // 
            this.武汉客客ToolStripMenuItem.Name = "武汉客客ToolStripMenuItem";
            this.武汉客客ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.武汉客客ToolStripMenuItem.Text = "武汉客客";
            this.武汉客客ToolStripMenuItem.Click += new System.EventHandler(this.武汉客客ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(964, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel1.Text = "我们来自于武汉客客";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(585, 481);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // txtControl
            // 
            this.txtControl.Location = new System.Drawing.Point(357, 401);
            this.txtControl.Name = "txtControl";
            this.txtControl.Size = new System.Drawing.Size(286, 21);
            this.txtControl.TabIndex = 3;
            this.txtControl.Text = "如：Control_xx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "控制器名称:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(470, 481);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "生成模型";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtHost
            // 
            this.txtHost.FormattingEnabled = true;
            this.txtHost.Items.AddRange(new object[] {
            "localhost",
            "127.0.0.1",
            "192.168.1.99"});
            this.txtHost.Location = new System.Drawing.Point(75, 32);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(121, 20);
            this.txtHost.TabIndex = 9;
            this.txtHost.Text = "localhost";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(281, 481);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(100, 21);
            this.txtDir.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(389, 481);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "选择保存目录";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.生成模型文件ToolStripMenuItem_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(400, 443);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "生成User程序";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 565);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.field);
            this.Controls.Add(this.table_list);
            this.Controls.Add(this.db_selet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtControl);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "for Cola PHP 代码生成";
            ((System.ComponentModel.ISupportInitialize)(this.field)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox db_selet;
        private System.Windows.Forms.ListBox table_list;
        private System.Windows.Forms.DataGridView field;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pHP代码生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成模型文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成列表程序文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据升级文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库转换工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 武汉客客ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtControl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ComboBox txtHost;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

