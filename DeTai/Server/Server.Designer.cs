namespace Server
{
    partial class Server
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
            this.lsvMain = new System.Windows.Forms.ListView();
            this.btnSendStudents = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSetTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenDeThi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChonDeThi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvMain
            // 
            this.lsvMain.HideSelection = false;
            this.lsvMain.Location = new System.Drawing.Point(217, 229);
            this.lsvMain.Name = "lsvMain";
            this.lsvMain.Size = new System.Drawing.Size(458, 375);
            this.lsvMain.TabIndex = 3;
            this.lsvMain.UseCompatibleStateImageBehavior = false;
            this.lsvMain.View = System.Windows.Forms.View.List;
            // 
            // btnSendStudents
            // 
            this.btnSendStudents.Location = new System.Drawing.Point(217, 174);
            this.btnSendStudents.Name = "btnSendStudents";
            this.btnSendStudents.Size = new System.Drawing.Size(133, 45);
            this.btnSendStudents.TabIndex = 6;
            this.btnSendStudents.Text = "Gửi Danh sách Sinh viên";
            this.btnSendStudents.UseVisualStyleBackColor = true;
            this.btnSendStudents.Click += new System.EventHandler(this.btnSendStudents_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(78, 345);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(78, 45);
            this.btnBegin.TabIndex = 7;
            this.btnBegin.Text = "Bắt đầu";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(464, 174);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(72, 45);
            this.btnSendFile.TabIndex = 9;
            this.btnSendFile.Text = "Phát đề";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTimeLeft);
            this.groupBox1.Location = new System.Drawing.Point(542, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 64);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian còn lại:";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(16, 26);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(54, 20);
            this.lblTimeLeft.TabIndex = 11;
            this.lblTimeLeft.Text = "00:00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSetTime);
            this.groupBox2.Location = new System.Drawing.Point(72, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(78, 59);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Time:";
            // 
            // txtSetTime
            // 
            this.txtSetTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetTime.Location = new System.Drawing.Point(6, 19);
            this.txtSetTime.Name = "txtSetTime";
            this.txtSetTime.Size = new System.Drawing.Size(72, 31);
            this.txtSetTime.TabIndex = 13;
            this.txtSetTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(170, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 42);
            this.label1.TabIndex = 13;
            this.label1.Text = "Quản Lý Thi Cử";
            // 
            // txtTenDeThi
            // 
            this.txtTenDeThi.Location = new System.Drawing.Point(270, 123);
            this.txtTenDeThi.Name = "txtTenDeThi";
            this.txtTenDeThi.Size = new System.Drawing.Size(150, 20);
            this.txtTenDeThi.TabIndex = 14;
            this.txtTenDeThi.Text = "Chọn đề thi";
            this.txtTenDeThi.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Đề thi";
            // 
            // btnChonDeThi
            // 
            this.btnChonDeThi.Location = new System.Drawing.Point(461, 121);
            this.btnChonDeThi.Name = "btnChonDeThi";
            this.btnChonDeThi.Size = new System.Drawing.Size(75, 23);
            this.btnChonDeThi.TabIndex = 16;
            this.btnChonDeThi.Text = "Chọn đề thi";
            this.btnChonDeThi.UseVisualStyleBackColor = true;
            this.btnChonDeThi.Click += new System.EventHandler(this.btnChonDeThi_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 613);
            this.Controls.Add(this.btnChonDeThi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenDeThi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.btnSendStudents);
            this.Controls.Add(this.lsvMain);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lsvMain;
        private System.Windows.Forms.Button btnSendStudents;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSetTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenDeThi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChonDeThi;
    }
}

