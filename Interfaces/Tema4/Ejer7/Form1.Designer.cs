namespace Ejer7;

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
            this.boxAsignaturas = new System.Windows.Forms.ComboBox();
            this.boxAlumnos = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblMedia = new System.Windows.Forms.Label();
            this.lblMaxMin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boxAsignaturas
            // 
            this.boxAsignaturas.FormattingEnabled = true;
            this.boxAsignaturas.Location = new System.Drawing.Point(12, 12);
            this.boxAsignaturas.Name = "boxAsignaturas";
            this.boxAsignaturas.Size = new System.Drawing.Size(121, 23);
            this.boxAsignaturas.TabIndex = 0;
            this.boxAsignaturas.SelectedIndexChanged += new System.EventHandler(this.boxAlumnos_SelectedIndexChanged);
            // 
            // boxAlumnos
            // 
            this.boxAlumnos.FormattingEnabled = true;
            this.boxAlumnos.Location = new System.Drawing.Point(139, 12);
            this.boxAlumnos.Name = "boxAlumnos";
            this.boxAlumnos.Size = new System.Drawing.Size(121, 23);
            this.boxAlumnos.TabIndex = 1;
            this.boxAlumnos.SelectedIndexChanged += new System.EventHandler(this.boxAlumnos_SelectedIndexChanged);
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.Location = new System.Drawing.Point(309, 15);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(46, 15);
            this.lblMedia.TabIndex = 2;
            this.lblMedia.Text = "Media: ";
            // 
            // lblMaxMin
            // 
            this.lblMaxMin.AutoSize = true;
            this.lblMaxMin.Location = new System.Drawing.Point(404, 15);
            this.lblMaxMin.Name = "lblMaxMin";
            this.lblMaxMin.Size = new System.Drawing.Size(60, 15);
            this.lblMaxMin.TabIndex = 3;
            this.lblMaxMin.Text = "Min: Max:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 753);
            this.Controls.Add(this.lblMaxMin);
            this.Controls.Add(this.lblMedia);
            this.Controls.Add(this.boxAlumnos);
            this.Controls.Add(this.boxAsignaturas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Clase 2ºDAM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ComboBox boxAsignaturas;
    private ComboBox boxAlumnos;
    private ToolTip toolTip1;
    private Label lblMedia;
    private Label lblMaxMin;
}
