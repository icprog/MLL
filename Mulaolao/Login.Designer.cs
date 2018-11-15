namespace Mulaolao
{
    partial class Login
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
            this.UserId = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.textB2 = new System.Windows.Forms.TextBox();
            this.Action = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.comboB1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserId
            // 
            this.UserId.AutoSize = true;
            this.UserId.Location = new System.Drawing.Point(140, 17);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(41, 12);
            this.UserId.TabIndex = 0;
            this.UserId.Text = "用户名";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(140, 51);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(41, 12);
            this.Password.TabIndex = 1;
            this.Password.Text = "密  码";
            // 
            // textB2
            // 
            this.textB2.Location = new System.Drawing.Point(200, 48);
            this.textB2.Name = "textB2";
            this.textB2.PasswordChar = '*';
            this.textB2.Size = new System.Drawing.Size(100, 21);
            this.textB2.TabIndex = 3;
            // 
            // Action
            // 
            this.Action.Location = new System.Drawing.Point(142, 108);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(75, 23);
            this.Action.TabIndex = 5;
            this.Action.Text = "登录";
            this.Action.UseVisualStyleBackColor = true;
            this.Action.Click += new System.EventHandler(this.Action_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(225, 108);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // comboB1
            // 
            this.comboB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboB1.FormattingEnabled = true;
            this.comboB1.Location = new System.Drawing.Point(200, 14);
            this.comboB1.Name = "comboB1";
            this.comboB1.Size = new System.Drawing.Size(100, 20);
            this.comboB1.TabIndex = 7;
            this.comboB1.SelectedValueChanged += new System.EventHandler(this.comboB1_SelectedValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Mulaolao.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 119);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(200, 81);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "记住密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AcceptButton = this.Action;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 147);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboB1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Action);
            this.Controls.Add(this.textB2);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserId;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox textB2;
        private System.Windows.Forms.Button Action;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox comboB1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}