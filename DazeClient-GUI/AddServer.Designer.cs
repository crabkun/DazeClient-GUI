namespace DazeClient_GUI
{
    partial class AddServer
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
            this.ServerName = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EncryptionParam = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ObscureParam = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Obscure = new System.Windows.Forms.ComboBox();
            this.Encryption = new System.Windows.Forms.ComboBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(116, 25);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(133, 21);
            this.ServerName.TabIndex = 1;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(116, 65);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(133, 21);
            this.Address.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "服务器IP：";
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(116, 145);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(133, 21);
            this.Username.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(116, 185);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(133, 21);
            this.Password.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(116, 105);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(133, 21);
            this.Port.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "端口：";
            // 
            // EncryptionParam
            // 
            this.EncryptionParam.Location = new System.Drawing.Point(116, 265);
            this.EncryptionParam.Name = "EncryptionParam";
            this.EncryptionParam.Size = new System.Drawing.Size(133, 21);
            this.EncryptionParam.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "加密参数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "加密方式：";
            // 
            // ObscureParam
            // 
            this.ObscureParam.Location = new System.Drawing.Point(116, 345);
            this.ObscureParam.Name = "ObscureParam";
            this.ObscureParam.Size = new System.Drawing.Size(133, 21);
            this.ObscureParam.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "伪装参数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "伪装方式：";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(73, 390);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 10;
            this.Save.Text = "保存并应用";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Obscure
            // 
            this.Obscure.FormattingEnabled = true;
            this.Obscure.Location = new System.Drawing.Point(116, 306);
            this.Obscure.Name = "Obscure";
            this.Obscure.Size = new System.Drawing.Size(133, 20);
            this.Obscure.TabIndex = 8;
            // 
            // Encryption
            // 
            this.Encryption.FormattingEnabled = true;
            this.Encryption.Location = new System.Drawing.Point(116, 226);
            this.Encryption.Name = "Encryption";
            this.Encryption.Size = new System.Drawing.Size(133, 20);
            this.Encryption.TabIndex = 6;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(174, 390);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 17;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // AddServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 436);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Encryption);
            this.Controls.Add(this.Obscure);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ObscureParam);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.EncryptionParam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建/修改";
            this.Load += new System.EventHandler(this.AddServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EncryptionParam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ObscureParam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ComboBox Obscure;
        private System.Windows.Forms.ComboBox Encryption;
        private System.Windows.Forms.Button Cancel;
    }
}