namespace Ejer3
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.viewProcces = new System.Windows.Forms.Button();
            this.proccesInfo = new System.Windows.Forms.Button();
            this.closeProcess = new System.Windows.Forms.Button();
            this.killProcess = new System.Windows.Forms.Button();
            this.runApp = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(342, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1009, 567);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 519);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(324, 23);
            this.textBox2.TabIndex = 1;
            // 
            // viewProcces
            // 
            this.viewProcces.Location = new System.Drawing.Point(92, 55);
            this.viewProcces.Name = "viewProcces";
            this.viewProcces.Size = new System.Drawing.Size(146, 50);
            this.viewProcces.TabIndex = 2;
            this.viewProcces.Text = "ViewProcces";
            this.viewProcces.UseVisualStyleBackColor = true;
            this.viewProcces.Click += new System.EventHandler(this.viewProcces_Click);
            // 
            // proccesInfo
            // 
            this.proccesInfo.Location = new System.Drawing.Point(92, 128);
            this.proccesInfo.Name = "proccesInfo";
            this.proccesInfo.Size = new System.Drawing.Size(146, 50);
            this.proccesInfo.TabIndex = 3;
            this.proccesInfo.Text = "Process Info";
            this.proccesInfo.UseVisualStyleBackColor = true;
            this.proccesInfo.Click += new System.EventHandler(this.proccesInfo_Click);
            // 
            // closeProcess
            // 
            this.closeProcess.Location = new System.Drawing.Point(92, 202);
            this.closeProcess.Name = "closeProcess";
            this.closeProcess.Size = new System.Drawing.Size(146, 50);
            this.closeProcess.TabIndex = 4;
            this.closeProcess.Text = "Close Process";
            this.closeProcess.UseVisualStyleBackColor = true;
            this.closeProcess.Click += new System.EventHandler(this.closeProcess_Click);
            // 
            // killProcess
            // 
            this.killProcess.Location = new System.Drawing.Point(92, 274);
            this.killProcess.Name = "killProcess";
            this.killProcess.Size = new System.Drawing.Size(146, 50);
            this.killProcess.TabIndex = 5;
            this.killProcess.Text = "Kill Procces";
            this.killProcess.UseVisualStyleBackColor = true;
            this.killProcess.Click += new System.EventHandler(this.killProcess_Click);
            // 
            // runApp
            // 
            this.runApp.Location = new System.Drawing.Point(92, 347);
            this.runApp.Name = "runApp";
            this.runApp.Size = new System.Drawing.Size(146, 50);
            this.runApp.TabIndex = 6;
            this.runApp.Text = "Run app";
            this.runApp.UseVisualStyleBackColor = true;
            this.runApp.Click += new System.EventHandler(this.runApp_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(92, 421);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(146, 50);
            this.Start.TabIndex = 7;
            this.Start.Text = "Starts with...";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 591);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.runApp);
            this.Controls.Add(this.killProcess);
            this.Controls.Add(this.closeProcess);
            this.Controls.Add(this.proccesInfo);
            this.Controls.Add(this.viewProcces);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button viewProcces;
        private Button proccesInfo;
        private Button closeProcess;
        private Button killProcess;
        private Button runApp;
        private Button Start;
    }
}