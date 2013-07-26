namespace php
{
    partial class DBupdate
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
            this.cmbOld = new System.Windows.Forms.ComboBox();
            this.cmbNew = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblOdb = new System.Windows.Forms.Label();
            this.lblNdb = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblProc = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbOld
            // 
            this.cmbOld.FormattingEnabled = true;
            this.cmbOld.Location = new System.Drawing.Point(137, 47);
            this.cmbOld.Name = "cmbOld";
            this.cmbOld.Size = new System.Drawing.Size(166, 20);
            this.cmbOld.TabIndex = 0;
            // 
            // cmbNew
            // 
            this.cmbNew.FormattingEnabled = true;
            this.cmbNew.Location = new System.Drawing.Point(432, 47);
            this.cmbNew.Name = "cmbNew";
            this.cmbNew.Size = new System.Drawing.Size(175, 20);
            this.cmbNew.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(272, 120);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "升级数据库";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblOdb
            // 
            this.lblOdb.AutoSize = true;
            this.lblOdb.Location = new System.Drawing.Point(73, 54);
            this.lblOdb.Name = "lblOdb";
            this.lblOdb.Size = new System.Drawing.Size(29, 12);
            this.lblOdb.TabIndex = 3;
            this.lblOdb.Text = "老库";
            // 
            // lblNdb
            // 
            this.lblNdb.AutoSize = true;
            this.lblNdb.Location = new System.Drawing.Point(373, 54);
            this.lblNdb.Name = "lblNdb";
            this.lblNdb.Size = new System.Drawing.Size(53, 12);
            this.lblNdb.TabIndex = 4;
            this.lblNdb.Text = "新数据库";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(157, 91);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(470, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblProc
            // 
            this.lblProc.AutoSize = true;
            this.lblProc.BackColor = System.Drawing.Color.Transparent;
            this.lblProc.Location = new System.Drawing.Point(362, 96);
            this.lblProc.Name = "lblProc";
            this.lblProc.Size = new System.Drawing.Size(0, 12);
            this.lblProc.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "saveSql";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // DBupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 428);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblProc);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblNdb);
            this.Controls.Add(this.lblOdb);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cmbNew);
            this.Controls.Add(this.cmbOld);
            this.Name = "DBupdate";
            this.Text = "DBupdate";
            this.Load += new System.EventHandler(this.DBupdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOld;
        private System.Windows.Forms.ComboBox cmbNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblOdb;
        private System.Windows.Forms.Label lblNdb;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProc;
        private System.Windows.Forms.Button button1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}