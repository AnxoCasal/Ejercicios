namespace Ejer1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.listBoxSubDire = new System.Windows.Forms.ListBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.btnShowDire = new System.Windows.Forms.Button();
            this.btnShowFiles = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(468, 12);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(243, 23);
            this.txtBoxPath.TabIndex = 0;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(529, 41);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(119, 23);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "Change directory";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(1, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(82, 15);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "None selected";
            // 
            // listBoxSubDire
            // 
            this.listBoxSubDire.FormattingEnabled = true;
            this.listBoxSubDire.ItemHeight = 15;
            this.listBoxSubDire.Location = new System.Drawing.Point(37, 103);
            this.listBoxSubDire.Name = "listBoxSubDire";
            this.listBoxSubDire.Size = new System.Drawing.Size(530, 559);
            this.listBoxSubDire.TabIndex = 3;
            this.listBoxSubDire.DoubleClick += new System.EventHandler(this.listBoxSubDire_DoubleClick);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 15;
            this.listBoxFiles.Location = new System.Drawing.Point(659, 103);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(602, 559);
            this.listBoxFiles.TabIndex = 4;
            this.listBoxFiles.Click += new System.EventHandler(this.listBoxFiles_Click);
            this.listBoxFiles.DoubleClick += new System.EventHandler(this.listBoxFiles_DoubleClick);
            // 
            // btnShowDire
            // 
            this.btnShowDire.Enabled = false;
            this.btnShowDire.Location = new System.Drawing.Point(37, 74);
            this.btnShowDire.Name = "btnShowDire";
            this.btnShowDire.Size = new System.Drawing.Size(114, 23);
            this.btnShowDire.TabIndex = 5;
            this.btnShowDire.Text = "Show directories";
            this.btnShowDire.UseVisualStyleBackColor = true;
            this.btnShowDire.Click += new System.EventHandler(this.btnShowDire_Click);
            // 
            // btnShowFiles
            // 
            this.btnShowFiles.Enabled = false;
            this.btnShowFiles.Location = new System.Drawing.Point(659, 74);
            this.btnShowFiles.Name = "btnShowFiles";
            this.btnShowFiles.Size = new System.Drawing.Size(75, 23);
            this.btnShowFiles.TabIndex = 6;
            this.btnShowFiles.Text = "Show files";
            this.btnShowFiles.UseVisualStyleBackColor = true;
            this.btnShowFiles.Click += new System.EventHandler(this.showFiles_Click);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(758, 78);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(82, 15);
            this.lblSize.TabIndex = 7;
            this.lblSize.Text = "None selected";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.btnShowFiles);
            this.Controls.Add(this.btnShowDire);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.listBoxSubDire);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtBoxPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Directory Editor 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TextBox txtBoxPath;
    private Button btnEnter;
    private Label lblPath;
    private ListBox listBoxSubDire;
    private ListBox listBoxFiles;
    private Button btnShowDire;
    private Button btnShowFiles;
    private Label lblSize;
}
