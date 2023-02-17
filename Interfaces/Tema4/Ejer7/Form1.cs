using Ejer7;
using System.Drawing;

namespace Ejer7;

public partial class Form1 : Form
{
    int x = 150;
    int y = 50;
    int min, max;
    Aula aula;
    int[,] notas;

    static String[] texts = File.ReadAllText(Environment.GetEnvironmentVariable("userprofile") + "\\alumnos.txt").Split(",");
    Label[,] tabla = new Label[texts.Length, 4];
    Label[] cabezeras = new Label[texts.Length + 4];

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        aula = new Aula(texts);
        notas = aula.mostrarTabla();

        this.Text = "Gestor aula";
        // this.Icon = new Icon("");

        boxAsignaturas.Items.Add("Todos");
        boxAsignaturas.SelectedIndex = 0;
        boxAlumnos.Items.Add("Todos");
        boxAlumnos.SelectedIndex = 0;
        lblMedia.Text = "Media: " + aula.media();

        for (int i = 0; i < 4; i++)
        {
            cabezeras[i] = new Label();
            cabezeras[i].Text = ((asignaturas)i).ToString();
            cabezeras[i].Font = new Font(this.Font, FontStyle.Bold);
            cabezeras[i].Location = new Point(x, y);
            cabezeras[i].Size = new Size(100, 30);
            cabezeras[i].TextAlign = ContentAlignment.MiddleCenter;
            cabezeras[i].Enabled = true;

            this.Controls.Add(cabezeras[i]);

            x += 100;

            boxAsignaturas.Items.Add((asignaturas)i);

        }

        x = 50;
        y = 80;

        for (int i = 0; i < texts.Length; i++)
        {
            cabezeras[i] = new Label();
            cabezeras[i].Text = texts[i];
            cabezeras[i].Font = new Font(this.Font, FontStyle.Italic);
            cabezeras[i].Location = new Point(x, y);
            cabezeras[i].Size = new Size(100, 30);
            cabezeras[i].TextAlign = ContentAlignment.MiddleCenter;
            cabezeras[i].Enabled = true;

            this.Controls.Add(cabezeras[i]);

            y += 30;

            boxAlumnos.Items.Add(texts[i]);
        }

        x = 150;
        y = 80;

        for (int i = 0; i < notas.GetLength(0); i++)
        {
            for (int j = 0; j < notas.GetLength(1); j++)
            {
                tabla[i, j] = new Label();
                tabla[i, j].Text = notas[i, j].ToString();
                tabla[i, j].Location = new Point(x, y);
                tabla[i, j].Size = new Size(100, 30);
                tabla[i, j].TextAlign = ContentAlignment.MiddleCenter;
                toolTip1.SetToolTip(tabla[i, j], ((asignaturas)j).ToString() + "-" + texts[i]);
                tabla[i, j].MouseEnter += label1_MouseEnter;
                tabla[i, j].MouseLeave += label1_MouseLeave;
                tabla[i, j].Enabled = true;

                this.Controls.Add(tabla[i, j]);

                x += 100;
            }
            x = 150;
            y += 30;
        }
    }

    private void boxAlumnos_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (boxAlumnos.SelectedIndex > 0)
        {
            if (boxAsignaturas.SelectedIndex > 0)
            {
                int i = boxAlumnos.SelectedIndex;
                int j = boxAsignaturas.SelectedIndex;
                i--; j--;
                lblMedia.Text = "Nota: " + notas[i,j];

            }
            else
            {
                aula.minsAndMaxs(boxAlumnos.SelectedIndex, ref min, ref max);
                lblMaxMin.Text = "Max: " + max + " Min: " + min;
                lblMedia.Text = "Media: " + aula.mediaAlumno(boxAlumnos.SelectedIndex);
            }
        }
        else
        {
            if (boxAsignaturas.SelectedIndex > 0)
            {
                lblMedia.Text = "Media: " + aula.mediaAsignatura(boxAsignaturas.SelectedIndex);
                lblMaxMin.Text = "Max: " + 0 + " Min: " + 0;
            }
            else
            {
                lblMedia.Text = "Media: " + aula.media();
                lblMaxMin.Text = "Max: " + 0 + " Min: " + 0;
            }
        }

    }

    private void label1_MouseEnter(object sender, EventArgs e)
    {
        ((Label)sender).BackColor = Color.Yellow;
    }

    private void label1_MouseLeave(object sender, EventArgs e)
    {
        ((Label)sender).BackColor = Label.DefaultBackColor;
    }
}
