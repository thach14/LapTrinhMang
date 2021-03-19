
namespace Client
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(46, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(156, 198);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(46, 285);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(100, 22);
            this.txtChat.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(166, 285);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(36, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = ">";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 450);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSend;
    }
}

