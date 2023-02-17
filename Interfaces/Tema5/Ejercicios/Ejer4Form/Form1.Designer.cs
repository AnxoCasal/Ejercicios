namespace Ejer4Form
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
            this.validateTextBox1 = new Ejercio1.ValidateTextBox();
            this.grafico1 = new Ejercio1.Grafico();
            this.SuspendLayout();
            // 
            // validateTextBox1
            // 
            this.validateTextBox1.Location = new System.Drawing.Point(108, 118);
            this.validateTextBox1.Multilinea = false;
            this.validateTextBox1.Name = "validateTextBox1";
            this.validateTextBox1.Size = new System.Drawing.Size(214, 65);
            this.validateTextBox1.TabIndex = 1;
            this.validateTextBox1.Texto = "";
            this.validateTextBox1.Tipo = Ejercio1.ValidateTextBox.eTipo.Numerico;
            // 
            // grafico1
            // 
            this.grafico1.Estilo = Ejercio1.Grafico.estilos.Lienas;
            this.grafico1.Location = new System.Drawing.Point(175, 275);
            this.grafico1.Modo = Ejercio1.Grafico.modes.Automatico;
            this.grafico1.Name = "grafico1";
            this.grafico1.Size = new System.Drawing.Size(345, 227);
            this.grafico1.TabIndex = 2;
            this.grafico1.TamañoMax = 100;
            this.grafico1.TextoAbajo = "Abajo";
            this.grafico1.TextoIzquierda = "Izquierda";
            this.grafico1.Valores = new int[] {
        3,
        5,
        1,
        12,
        9};
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 639);
            this.Controls.Add(this.grafico1);
            this.Controls.Add(this.validateTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private Ejercio1.ValidateTextBox validateTextBox1;
        private Ejercio1.Grafico grafico1;
    }
}

