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
            this.cbbMonThi = new System.Windows.Forms.ComboBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLuuBai = new System.Windows.Forms.Button();
            this.txtLuuBai = new System.Windows.Forms.TextBox();
            this.txtMesseage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvMain
            // 
            this.lsvMain.HideSelection = false;
            this.lsvMain.Location = new System.Drawing.Point(53, 295);
            this.lsvMain.Name = "lsvMain";
            this.lsvMain.Size = new System.Drawing.Size(583, 205);
            this.lsvMain.TabIndex = 3;
            this.lsvMain.UseCompatibleStateImageBehavior = false;
            this.lsvMain.View = System.Windows.Forms.View.List;
            // 
            // btnSendStudents
            // 
            this.btnSendStudents.Location = new System.Drawing.Point(409, 81);
            this.btnSendStudents.Name = "btnSendStudents";
            this.btnSendStudents.Size = new System.Drawing.Size(227, 24);
            this.btnSendStudents.TabIndex = 6;
            this.btnSendStudents.Text = "Lấy DS Từ CSDL";
            this.btnSendStudents.UseVisualStyleBackColor = true;
            this.btnSendStudents.Click += new System.EventHandler(this.btnSendStudents_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(543, 235);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(93, 45);
            this.btnBegin.TabIndex = 7;
            this.btnBegin.Text = "Bắt đầu";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(412, 234);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(93, 45);
            this.btnSendFile.TabIndex = 9;
            this.btnSendFile.Text = "Phát đề";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTimeLeft);
            this.groupBox1.Location = new System.Drawing.Point(517, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 59);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian còn lại:";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(28, 26);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(54, 20);
            this.lblTimeLeft.TabIndex = 11;
            this.lblTimeLeft.Text = "00:00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSetTime);
            this.groupBox2.Location = new System.Drawing.Point(409, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(102, 59);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Time:";
            // 
            // txtSetTime
            // 
            this.txtSetTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetTime.Location = new System.Drawing.Point(3, 19);
            this.txtSetTime.Name = "txtSetTime";
            this.txtSetTime.Size = new System.Drawing.Size(99, 31);
            this.txtSetTime.TabIndex = 13;
            this.txtSetTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 42);
            this.label1.TabIndex = 13;
            this.label1.Text = "Quản Lý Thi Cử";
            // 
            // txtTenDeThi
            // 
            this.txtTenDeThi.Location = new System.Drawing.Point(71, 64);
            this.txtTenDeThi.Name = "txtTenDeThi";
            this.txtTenDeThi.ReadOnly = true;
            this.txtTenDeThi.Size = new System.Drawing.Size(150, 20);
            this.txtTenDeThi.TabIndex = 14;
            this.txtTenDeThi.Text = "Chọn đề thi";
            this.txtTenDeThi.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Đề thi";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnChonDeThi
            // 
            this.btnChonDeThi.Image = global::Server.Properties.Resources.icons8_folder_32;
            this.btnChonDeThi.Location = new System.Drawing.Point(248, 54);
            this.btnChonDeThi.Name = "btnChonDeThi";
            this.btnChonDeThi.Size = new System.Drawing.Size(75, 39);
            this.btnChonDeThi.TabIndex = 16;
            this.btnChonDeThi.UseVisualStyleBackColor = true;
            this.btnChonDeThi.Click += new System.EventHandler(this.btnChonDeThi_Click);
            // 
            // cbbMonThi
            // 
            this.cbbMonThi.FormattingEnabled = true;
            this.cbbMonThi.Items.AddRange(new object[] {
            "laptrinhmang"});
            this.cbbMonThi.Location = new System.Drawing.Point(71, 21);
            this.cbbMonThi.Name = "cbbMonThi";
            this.cbbMonThi.Size = new System.Drawing.Size(252, 21);
            this.cbbMonThi.TabIndex = 17;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(409, 46);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 18;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Môn thi:";
            // 
            // btnLuuBai
            // 
            this.btnLuuBai.Image = global::Server.Properties.Resources.icons8_folder_32;
            this.btnLuuBai.Location = new System.Drawing.Point(248, 19);
            this.btnLuuBai.Name = "btnLuuBai";
            this.btnLuuBai.Size = new System.Drawing.Size(75, 38);
            this.btnLuuBai.TabIndex = 22;
            this.btnLuuBai.UseVisualStyleBackColor = true;
            this.btnLuuBai.Click += new System.EventHandler(this.btnLuuBai_Click);
            // 
            // txtLuuBai
            // 
            this.txtLuuBai.Location = new System.Drawing.Point(6, 30);
            this.txtLuuBai.Name = "txtLuuBai";
            this.txtLuuBai.ReadOnly = true;
            this.txtLuuBai.Size = new System.Drawing.Size(215, 20);
            this.txtLuuBai.TabIndex = 20;
            this.txtLuuBai.Text = "D:\\";
            // 
            // txtMesseage
            // 
            this.txtMesseage.Location = new System.Drawing.Point(53, 521);
            this.txtMesseage.Name = "txtMesseage";
            this.txtMesseage.Size = new System.Drawing.Size(486, 20);
            this.txtMesseage.TabIndex = 23;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(561, 518);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 24;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "IP Server";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(483, 15);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(153, 20);
            this.txtIP.TabIndex = 26;
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLuuBai);
            this.groupBox3.Controls.Add(this.btnLuuBai);
            this.groupBox3.Location = new System.Drawing.Point(47, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 72);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn đường dẫn lưu bài thi";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbbMonThi);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtTenDeThi);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnChonDeThi);
            this.groupBox4.Location = new System.Drawing.Point(47, 167);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 113);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chọn môn thi và đề thi";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::Server.Properties.Resources.icons8_folder_32;
            this.btnExcel.Location = new System.Drawing.Point(561, 119);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 45);
            this.btnExcel.TabIndex = 30;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(409, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "Lấy DSSV Từ File Excel";
            // 
            // Server
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 563);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMesseage);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.btnSendStudents);
            this.Controls.Add(this.lsvMain);
            this.MaximumSize = new System.Drawing.Size(698, 602);
            this.MinimumSize = new System.Drawing.Size(698, 602);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.Load += new System.EventHandler(this.Server_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbbMonThi;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLuuBai;
        private System.Windows.Forms.TextBox txtLuuBai;
        private System.Windows.Forms.TextBox txtMesseage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox textBox1;
    }
}

