namespace Ejer3Form
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
            this.intervalos = new System.Windows.Forms.ComboBox();
            this.lienzo = new System.Windows.Forms.PictureBox();
            this.ImageExplorer = new System.Windows.Forms.Button();
            this.spotify = new Ejercio1.Spotify();
            ((System.ComponentModel.ISupportInitialize)(this.lienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // intervalos
            // 
            this.intervalos.FormattingEnabled = true;
            this.intervalos.Location = new System.Drawing.Point(471, 559);
            this.intervalos.Name = "intervalos";
            this.intervalos.Size = new System.Drawing.Size(121, 21);
            this.intervalos.TabIndex = 1;
            // 
            // lienzo
            // 
            this.lienzo.Location = new System.Drawing.Point(12, 12);
            this.lienzo.Name = "lienzo";
            this.lienzo.Size = new System.Drawing.Size(975, 464);
            this.lienzo.TabIndex = 2;
            this.lienzo.TabStop = false;
            // 
            // ImageExplorer
            // 
            this.ImageExplorer.Location = new System.Drawing.Point(13, 482);
            this.ImageExplorer.Name = "ImageExplorer";
            this.ImageExplorer.Size = new System.Drawing.Size(974, 23);
            this.ImageExplorer.TabIndex = 3;
            this.ImageExplorer.Text = "Select Folder";
            this.ImageExplorer.UseVisualStyleBackColor = true;
            this.ImageExplorer.Click += new System.EventHandler(this.ImageExplorer_Click);
            // 
            // spotify
            // 
            this.spotify.BackColor = System.Drawing.SystemColors.Control;
            this.spotify.Location = new System.Drawing.Point(382, 512);
            this.spotify.minutes = 0;
            this.spotify.Name = "spotify";
            this.spotify.seconds = 0;
            this.spotify.Size = new System.Drawing.Size(83, 97);
            this.spotify.TabIndex = 0;
            this.spotify.DesbordaTiempo += new System.EventHandler(this.spotify1_DesbordaTiempo);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1019, 621);
            this.Controls.Add(this.ImageExplorer);
            this.Controls.Add(this.lienzo);
            this.Controls.Add(this.intervalos);
            this.Controls.Add(this.spotify);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lienzo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ejercio1.Spotify spotify1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox intervals;
        private Ejercio1.Spotify spotify;
        private System.Windows.Forms.ComboBox intervalos;
        private System.Windows.Forms.PictureBox lienzo;
        private System.Windows.Forms.Button ImageExplorer;
    }
}

