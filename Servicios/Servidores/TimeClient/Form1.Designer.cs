namespace TimeClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timeBtn = new System.Windows.Forms.Button();
            this.dateBtn = new System.Windows.Forms.Button();
            this.allBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.txtBoxPass = new System.Windows.Forms.TextBox();
            this.resultLbl = new System.Windows.Forms.Label();
            this.optionsBtn = new System.Windows.Forms.Button();
            this.lblConexion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeBtn
            // 
            this.timeBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeBtn.Location = new System.Drawing.Point(19, 37);
            this.timeBtn.Name = "timeBtn";
            this.timeBtn.Size = new System.Drawing.Size(122, 77);
            this.timeBtn.TabIndex = 0;
            this.timeBtn.Text = "Time";
            this.timeBtn.UseVisualStyleBackColor = true;
            this.timeBtn.Click += new System.EventHandler(this.allBtns_click);
            // 
            // dateBtn
            // 
            this.dateBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateBtn.Location = new System.Drawing.Point(147, 37);
            this.dateBtn.Name = "dateBtn";
            this.dateBtn.Size = new System.Drawing.Size(122, 77);
            this.dateBtn.TabIndex = 1;
            this.dateBtn.Text = "Date";
            this.dateBtn.UseVisualStyleBackColor = true;
            this.dateBtn.Click += new System.EventHandler(this.allBtns_click);
            // 
            // allBtn
            // 
            this.allBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.allBtn.Location = new System.Drawing.Point(19, 120);
            this.allBtn.Name = "allBtn";
            this.allBtn.Size = new System.Drawing.Size(122, 77);
            this.allBtn.TabIndex = 2;
            this.allBtn.Text = "All";
            this.allBtn.UseVisualStyleBackColor = true;
            this.allBtn.Click += new System.EventHandler(this.allBtns_click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeBtn.Location = new System.Drawing.Point(147, 120);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(122, 77);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.allBtns_click);
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.Location = new System.Drawing.Point(158, 203);
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.Size = new System.Drawing.Size(100, 23);
            this.txtBoxPass.TabIndex = 4;
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(19, 206);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(0, 15);
            this.resultLbl.TabIndex = 5;
            // 
            // optionsBtn
            // 
            this.optionsBtn.Location = new System.Drawing.Point(2, 3);
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(51, 23);
            this.optionsBtn.TabIndex = 6;
            this.optionsBtn.Text = "OPTS";
            this.optionsBtn.UseVisualStyleBackColor = true;
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);
            // 
            // lblConexion
            // 
            this.lblConexion.AutoSize = true;
            this.lblConexion.Location = new System.Drawing.Point(68, 11);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(0, 15);
            this.lblConexion.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 240);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.optionsBtn);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.txtBoxPass);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.allBtn);
            this.Controls.Add(this.dateBtn);
            this.Controls.Add(this.timeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button timeBtn;
        private Button dateBtn;
        private Button allBtn;
        private Button closeBtn;
        private TextBox txtBoxPass;
        private Label resultLbl;
        private Button optionsBtn;
        private Label lblConexion;
    }
}