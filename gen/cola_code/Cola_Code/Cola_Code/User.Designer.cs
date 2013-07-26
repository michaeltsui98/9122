namespace php
{
    partial class User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOneMenu = new System.Windows.Forms.TextBox();
            this.txtTwoMenu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.txtDefaultOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSqlGroup = new System.Windows.Forms.TextBox();
            this.txtSqlWhere = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ckbList = new System.Windows.Forms.CheckBox();
            this.ckbAdd = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "一级菜单:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "二级菜单:";
            // 
            // txtOneMenu
            // 
            this.txtOneMenu.Location = new System.Drawing.Point(123, 28);
            this.txtOneMenu.Name = "txtOneMenu";
            this.txtOneMenu.Size = new System.Drawing.Size(140, 21);
            this.txtOneMenu.TabIndex = 1;
            // 
            // txtTwoMenu
            // 
            this.txtTwoMenu.Location = new System.Drawing.Point(123, 62);
            this.txtTwoMenu.Name = "txtTwoMenu";
            this.txtTwoMenu.Size = new System.Drawing.Size(140, 21);
            this.txtTwoMenu.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSql);
            this.groupBox1.Controls.Add(this.txtDefaultOrder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSqlGroup);
            this.groupBox1.Controls.Add(this.txtSqlWhere);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(60, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 271);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "多表查询";
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(44, 20);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(418, 120);
            this.txtSql.TabIndex = 3;
            this.txtSql.Text = "";
            // 
            // txtDefaultOrder
            // 
            this.txtDefaultOrder.Location = new System.Drawing.Point(96, 155);
            this.txtDefaultOrder.Name = "txtDefaultOrder";
            this.txtDefaultOrder.Size = new System.Drawing.Size(138, 21);
            this.txtDefaultOrder.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "SQL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "默认排序字段:";
            // 
            // txtSqlGroup
            // 
            this.txtSqlGroup.Location = new System.Drawing.Point(71, 224);
            this.txtSqlGroup.Name = "txtSqlGroup";
            this.txtSqlGroup.Size = new System.Drawing.Size(391, 21);
            this.txtSqlGroup.TabIndex = 2;
            // 
            // txtSqlWhere
            // 
            this.txtSqlWhere.Location = new System.Drawing.Point(72, 190);
            this.txtSqlWhere.Name = "txtSqlWhere";
            this.txtSqlWhere.Size = new System.Drawing.Size(390, 21);
            this.txtSqlWhere.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "SQL条件:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "SQL分组:";
            // 
            // ckbList
            // 
            this.ckbList.AutoSize = true;
            this.ckbList.Location = new System.Drawing.Point(226, 412);
            this.ckbList.Name = "ckbList";
            this.ckbList.Size = new System.Drawing.Size(84, 16);
            this.ckbList.TabIndex = 5;
            this.ckbList.Text = "生成列表页";
            this.ckbList.UseVisualStyleBackColor = true;
            // 
            // ckbAdd
            // 
            this.ckbAdd.AutoSize = true;
            this.ckbAdd.Location = new System.Drawing.Point(365, 412);
            this.ckbAdd.Name = "ckbAdd";
            this.ckbAdd.Size = new System.Drawing.Size(108, 16);
            this.ckbAdd.TabIndex = 6;
            this.ckbAdd.Text = "生成添加编辑页";
            this.ckbAdd.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "保存Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ckbAdd);
            this.Controls.Add(this.ckbList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTwoMenu);
            this.Controls.Add(this.txtOneMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "User";
            this.Text = "User";
            
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOneMenu;
        private System.Windows.Forms.TextBox txtTwoMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtSql;
        private System.Windows.Forms.TextBox txtDefaultOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckbList;
        private System.Windows.Forms.CheckBox ckbAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSqlGroup;
        private System.Windows.Forms.TextBox txtSqlWhere;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}