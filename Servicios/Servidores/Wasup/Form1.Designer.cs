namespace Wasup
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.enterBtn = new System.Windows.Forms.Button();
            this.usernameTxtBox = new System.Windows.Forms.TextBox();
            this.usernameLBl = new System.Windows.Forms.Label();
            this.inputTxtBox = new System.Windows.Forms.TextBox();
            this.chatroomTxtBox = new System.Windows.Forms.TextBox();
            this.userListBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.infoLbl = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterBtn
            // 
            this.enterBtn.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterBtn.Location = new System.Drawing.Point(350, 220);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(100, 40);
            this.enterBtn.TabIndex = 0;
            this.enterBtn.Text = "Enter server";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // usernameTxtBox
            // 
            this.usernameTxtBox.Location = new System.Drawing.Point(290, 190);
            this.usernameTxtBox.Name = "usernameTxtBox";
            this.usernameTxtBox.Size = new System.Drawing.Size(220, 20);
            this.usernameTxtBox.TabIndex = 1;
            this.usernameTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usernameLBl
            // 
            this.usernameLBl.AutoSize = true;
            this.usernameLBl.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLBl.Location = new System.Drawing.Point(353, 157);
            this.usernameLBl.Name = "usernameLBl";
            this.usernameLBl.Size = new System.Drawing.Size(97, 16);
            this.usernameLBl.TabIndex = 2;
            this.usernameLBl.Text = "USERNAME";
            // 
            // inputTxtBox
            // 
            this.inputTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTxtBox.Location = new System.Drawing.Point(0, 434);
            this.inputTxtBox.Name = "inputTxtBox";
            this.inputTxtBox.Size = new System.Drawing.Size(701, 26);
            this.inputTxtBox.TabIndex = 3;
            this.inputTxtBox.Visible = false;
            // 
            // chatroomTxtBox
            // 
            this.chatroomTxtBox.Location = new System.Drawing.Point(0, 52);
            this.chatroomTxtBox.Multiline = true;
            this.chatroomTxtBox.Name = "chatroomTxtBox";
            this.chatroomTxtBox.ReadOnly = true;
            this.chatroomTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatroomTxtBox.Size = new System.Drawing.Size(782, 336);
            this.chatroomTxtBox.TabIndex = 4;
            this.chatroomTxtBox.Visible = false;
            // 
            // userListBtn
            // 
            this.userListBtn.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userListBtn.Location = new System.Drawing.Point(153, 401);
            this.userListBtn.Name = "userListBtn";
            this.userListBtn.Size = new System.Drawing.Size(234, 23);
            this.userListBtn.TabIndex = 5;
            this.userListBtn.Text = "User List";
            this.userListBtn.UseVisualStyleBackColor = true;
            this.userListBtn.Visible = false;
            this.userListBtn.Click += new System.EventHandler(this.userListBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(403, 401);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(228, 23);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Visible = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Location = new System.Drawing.Point(12, 9);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(44, 13);
            this.infoLbl.TabIndex = 7;
            this.infoLbl.Text = "EMPTY";
            this.infoLbl.Visible = false;
            // 
            // sendBtn
            // 
            this.sendBtn.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtn.Location = new System.Drawing.Point(707, 430);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 30);
            this.sendBtn.TabIndex = 8;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Visible = false;
            this.sendBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.sendBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.userListBtn);
            this.Controls.Add(this.chatroomTxtBox);
            this.Controls.Add(this.inputTxtBox);
            this.Controls.Add(this.usernameLBl);
            this.Controls.Add(this.usernameTxtBox);
            this.Controls.Add(this.enterBtn);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.TextBox usernameTxtBox;
        private System.Windows.Forms.Label usernameLBl;
        private System.Windows.Forms.TextBox inputTxtBox;
        private System.Windows.Forms.TextBox chatroomTxtBox;
        private System.Windows.Forms.Button userListBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.Button sendBtn;
    }
}

