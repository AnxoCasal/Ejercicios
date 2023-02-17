namespace Ejer8
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpen = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.siguienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anterioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrevius = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblDataImg = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(204, 74);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(174, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.toolTip1.SetToolTip(this.btnOpen, "Open folder");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.ContextMenuStrip = this.contextMenuStrip1;
            this.panelContainer.Location = new System.Drawing.Point(12, 103);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(555, 418);
            this.panelContainer.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siguienteToolStripMenuItem,
            this.anterioToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 70);
            // 
            // siguienteToolStripMenuItem
            // 
            this.siguienteToolStripMenuItem.Name = "siguienteToolStripMenuItem";
            this.siguienteToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.siguienteToolStripMenuItem.Text = "Siguiente";
            this.siguienteToolStripMenuItem.Click += new System.EventHandler(this.btnPrevius_Click);
            // 
            // anterioToolStripMenuItem
            // 
            this.anterioToolStripMenuItem.Name = "anterioToolStripMenuItem";
            this.anterioToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.anterioToolStripMenuItem.Text = "Anterior";
            this.anterioToolStripMenuItem.Click += new System.EventHandler(this.btnPrevius_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // btnPrevius
            // 
            this.btnPrevius.Enabled = false;
            this.btnPrevius.Location = new System.Drawing.Point(12, 74);
            this.btnPrevius.Name = "btnPrevius";
            this.btnPrevius.Size = new System.Drawing.Size(186, 23);
            this.btnPrevius.TabIndex = 2;
            this.btnPrevius.Text = "Previus";
            this.toolTip1.SetToolTip(this.btnPrevius, "Show previus image");
            this.btnPrevius.UseVisualStyleBackColor = true;
            this.btnPrevius.Click += new System.EventHandler(this.btnPrevius_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(384, 74);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(183, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.toolTip1.SetToolTip(this.btnNext, "Show next image");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnPrevius_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 15);
            this.lblPath.TabIndex = 4;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(358, 29);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(0, 15);
            this.lblImage.TabIndex = 5;
            // 
            // lblDataImg
            // 
            this.lblDataImg.AutoSize = true;
            this.lblDataImg.Location = new System.Drawing.Point(17, 48);
            this.lblDataImg.Name = "lblDataImg";
            this.lblDataImg.Size = new System.Drawing.Size(0, 15);
            this.lblDataImg.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 533);
            this.Controls.Add(this.lblDataImg);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevius);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Image Viwer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnOpen_KeyUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnOpen;
        private Panel panelContainer;
        private Button btnPrevius;
        private Button btnNext;
        private Label lblPath;
        private Label lblImage;
        private Label lblDataImg;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem anterioToolStripMenuItem;
        private ToolStripMenuItem siguienteToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolTip toolTip1;
    }
}