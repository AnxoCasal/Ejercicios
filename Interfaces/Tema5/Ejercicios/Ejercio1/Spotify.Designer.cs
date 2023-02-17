namespace Ejercio1
{
    partial class Spotify
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Spotify));
            this.play_pause = new System.Windows.Forms.Button();
            this.lblCrono = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // play_pause
            // 
            this.play_pause.BackColor = System.Drawing.SystemColors.Window;
            this.play_pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.play_pause.Cursor = System.Windows.Forms.Cursors.Default;
            this.play_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play_pause.Image = ((System.Drawing.Image)(resources.GetObject("play_pause.Image")));
            this.play_pause.Location = new System.Drawing.Point(11, 29);
            this.play_pause.Name = "play_pause";
            this.play_pause.Size = new System.Drawing.Size(63, 61);
            this.play_pause.TabIndex = 0;
            this.play_pause.UseVisualStyleBackColor = false;
            this.play_pause.Click += new System.EventHandler(this.play_pause_Click);
            // 
            // lblCrono
            // 
            this.lblCrono.AutoSize = true;
            this.lblCrono.Location = new System.Drawing.Point(27, 13);
            this.lblCrono.Name = "lblCrono";
            this.lblCrono.Size = new System.Drawing.Size(35, 13);
            this.lblCrono.TabIndex = 1;
            this.lblCrono.Text = "label1";
            // 
            // Spotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblCrono);
            this.Controls.Add(this.play_pause);
            this.Name = "Spotify";
            this.Size = new System.Drawing.Size(83, 97);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button play_pause;
        private System.Windows.Forms.Label lblCrono;
    }
}
