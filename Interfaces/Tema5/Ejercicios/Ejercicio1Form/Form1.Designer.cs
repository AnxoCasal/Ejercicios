using System.ComponentModel;

namespace Ejercicio1Form
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
            this.button2 = new System.Windows.Forms.Button();
            this.lblText2 = new Componentes
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblText2
            // 
            this.lblText2.Location = new System.Drawing.Point(12, 12);
            this.lblText2.Name = "lblText2";
            this.lblText2.Posicion = Ejercio1.POSICION.Izquierda;
            this.lblText2.PswChr = 'G';
            this.lblText2.Separacion = 0;
            this.lblText2.Size = new System.Drawing.Size(393, 20);
            this.lblText2.TabIndex = 2;
            this.lblText2.TextLbl = "LblText";
            this.lblText2.TextTxt = "";
            this.lblText2.PosicionChanged += new System.EventHandler(this.lblText1_PosicionChanged);
            this.lblText2.SeparacionChanged += new System.EventHandler(this.lblText1_SeparacionChanged);
            this.lblText2.TxtChanged += new System.EventHandler(this.lblText2_TxtChanged);
            this.lblText2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lblText1_KeyUp);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(588, 261);
            this.Controls.Add(this.lblText2);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.LblText lblTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Componentes.LblText lblText2;
    }
}

