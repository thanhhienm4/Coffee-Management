namespace Quan_li_quan_cafe
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxusername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LIBtn = new System.Windows.Forms.Button();
            this.EXbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxusername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 43);
            this.panel1.TabIndex = 0;
            // 
            // tbxusername
            // 
            this.tbxusername.Location = new System.Drawing.Point(168, 12);
            this.tbxusername.Name = "tbxusername";
            this.tbxusername.Size = new System.Drawing.Size(220, 20);
            this.tbxusername.TabIndex = 2;
            this.tbxusername.Text = "mistakem4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tền đăng nhập";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbxpassword);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 41);
            this.panel2.TabIndex = 1;
            // 
            // tbxpassword
            // 
            this.tbxpassword.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.tbxpassword.Location = new System.Drawing.Point(168, 10);
            this.tbxpassword.Name = "tbxpassword";
            this.tbxpassword.PasswordChar = '*';
            this.tbxpassword.Size = new System.Drawing.Size(220, 20);
            this.tbxpassword.TabIndex = 3;
            this.tbxpassword.Text = "12345";
            this.tbxpassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // LIBtn
            // 
            this.LIBtn.Location = new System.Drawing.Point(180, 128);
            this.LIBtn.Name = "LIBtn";
            this.LIBtn.Size = new System.Drawing.Size(98, 23);
            this.LIBtn.TabIndex = 2;
            this.LIBtn.Text = "Đăng nhập";
            this.LIBtn.UseVisualStyleBackColor = true;
            this.LIBtn.Click += new System.EventHandler(this.LIBtn_Click);
            // 
            // EXbtn
            // 
            this.EXbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EXbtn.Location = new System.Drawing.Point(307, 128);
            this.EXbtn.Name = "EXbtn";
            this.EXbtn.Size = new System.Drawing.Size(93, 23);
            this.EXbtn.TabIndex = 3;
            this.EXbtn.Text = "Thoát";
            this.EXbtn.UseVisualStyleBackColor = true;
            this.EXbtn.Click += new System.EventHandler(this.EXbtn_Click);
            // 
            // LogInForm
            // 
            this.AcceptButton = this.LIBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EXbtn;
            this.ClientSize = new System.Drawing.Size(436, 191);
            this.Controls.Add(this.EXbtn);
            this.Controls.Add(this.LIBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogInForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxusername;
        private System.Windows.Forms.TextBox tbxpassword;
        private System.Windows.Forms.Button LIBtn;
        private System.Windows.Forms.Button EXbtn;
    }
}

