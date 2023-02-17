namespace Ejer9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.faToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionDeSeleccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajusteDeLineaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mayusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorTextoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFondoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMain
            // 
            this.textBoxMain.Location = new System.Drawing.Point(0, 24);
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMain.Size = new System.Drawing.Size(800, 426);
            this.textBoxMain.TabIndex = 0;
            this.textBoxMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMain_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faToolStripMenuItem,
            this.ediciónToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // faToolStripMenuItem
            // 
            this.faToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.guardarToolStripMenuItem,
            this.abrirArchivoToolStripMenuItem,
            this.recientesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.faToolStripMenuItem.Name = "faToolStripMenuItem";
            this.faToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.faToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo documento";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // abrirArchivoToolStripMenuItem
            // 
            this.abrirArchivoToolStripMenuItem.Name = "abrirArchivoToolStripMenuItem";
            this.abrirArchivoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirArchivoToolStripMenuItem.Text = "Abrir archivo";
            this.abrirArchivoToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivoToolStripMenuItem_Click);
            // 
            // recientesToolStripMenuItem
            // 
            this.recientesToolStripMenuItem.Name = "recientesToolStripMenuItem";
            this.recientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recientesToolStripMenuItem.Text = "Recientes";
            this.recientesToolStripMenuItem.Click += new System.EventHandler(this.recientesToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deshacerToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.cortarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.seleccionarTodoToolStripMenuItem,
            this.informacionDeSeleccionToolStripMenuItem});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // deshacerToolStripMenuItem
            // 
            this.deshacerToolStripMenuItem.Name = "deshacerToolStripMenuItem";
            this.deshacerToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.deshacerToolStripMenuItem.Text = "Deshacer";
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.cortarToolStripMenuItem.Text = "Cortar";
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.pegarToolStripMenuItem.Text = "Pegar";
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";
            // 
            // informacionDeSeleccionToolStripMenuItem
            // 
            this.informacionDeSeleccionToolStripMenuItem.Name = "informacionDeSeleccionToolStripMenuItem";
            this.informacionDeSeleccionToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.informacionDeSeleccionToolStripMenuItem.Text = "Informacion de seleccion";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajusteDeLineaToolStripMenuItem,
            this.mayusToolStripMenuItem,
            this.minusToolStripMenuItem,
            this.colorTextoToolStripMenuItem,
            this.colorFondoToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // ajusteDeLineaToolStripMenuItem
            // 
            this.ajusteDeLineaToolStripMenuItem.Name = "ajusteDeLineaToolStripMenuItem";
            this.ajusteDeLineaToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.ajusteDeLineaToolStripMenuItem.Text = "Ajuste de linea";
            // 
            // mayusToolStripMenuItem
            // 
            this.mayusToolStripMenuItem.Name = "mayusToolStripMenuItem";
            this.mayusToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.mayusToolStripMenuItem.Text = "Mayus.";
            // 
            // minusToolStripMenuItem
            // 
            this.minusToolStripMenuItem.Name = "minusToolStripMenuItem";
            this.minusToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.minusToolStripMenuItem.Text = "Minus.";
            // 
            // colorTextoToolStripMenuItem
            // 
            this.colorTextoToolStripMenuItem.Name = "colorTextoToolStripMenuItem";
            this.colorTextoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.colorTextoToolStripMenuItem.Text = "Color texto";
            // 
            // colorFondoToolStripMenuItem
            // 
            this.colorFondoToolStripMenuItem.Name = "colorFondoToolStripMenuItem";
            this.colorFondoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.colorFondoToolStripMenuItem.Text = "Color fondo";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Notas: ningun archivo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxMain;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem faToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem1;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem abrirArchivoToolStripMenuItem;
        private ToolStripMenuItem recientesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem ediciónToolStripMenuItem;
        private ToolStripMenuItem deshacerToolStripMenuItem;
        private ToolStripMenuItem copiarToolStripMenuItem;
        private ToolStripMenuItem cortarToolStripMenuItem;
        private ToolStripMenuItem pegarToolStripMenuItem;
        private ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private ToolStripMenuItem informacionDeSeleccionToolStripMenuItem;
        private ToolStripMenuItem herramientasToolStripMenuItem;
        private ToolStripMenuItem ajusteDeLineaToolStripMenuItem;
        private ToolStripMenuItem mayusToolStripMenuItem;
        private ToolStripMenuItem minusToolStripMenuItem;
        private ToolStripMenuItem colorTextoToolStripMenuItem;
        private ToolStripMenuItem colorFondoToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}