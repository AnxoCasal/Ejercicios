using System.IO;

namespace Ejer1;

public partial class Form1 : Form
{
    string path;
    string truePath;
    public Form1()
    {
        InitializeComponent();
    }

    private void enterBtn_Click(object sender, EventArgs e)
    {
        if (txtBoxPath.Text.StartsWith("%") && txtBoxPath.Text.EndsWith("%") && txtBoxPath.Text.Length > 1)
        {
            path = Environment.GetEnvironmentVariable(txtBoxPath.Text.Substring(1, txtBoxPath.TextLength - 2));
        }
        else
        {
            path = txtBoxPath.Text;
        }


        if (Directory.Exists(path))
        {
            lblPath.Text = path;
            btnShowDire.Enabled = true;
            btnShowFiles.Enabled = true;
        }
        else
        {
            lblPath.Text = "El directorio no existe";
            btnShowDire.Enabled = false;
            btnShowFiles.Enabled = false;
        }
    }

    private void listBoxSubDire_DoubleClick(object sender, EventArgs e)
    {
        if (listBoxSubDire.SelectedIndex == 0)
        {
            if (Directory.GetParent(path) != null)
            {
                txtBoxPath.Text = Directory.GetParent(path).ToString();
                btnEnter.PerformClick();
                btnShowDire.PerformClick();
                btnShowFiles.PerformClick();
            }
        }
        else if (listBoxSubDire.SelectedItem != null)
        {
            txtBoxPath.Text = path+listBoxSubDire.SelectedItem.ToString() + "\\";
            btnEnter.PerformClick();
            btnShowDire.PerformClick();
            btnShowFiles.PerformClick();
        }
    }

    private void btnShowDire_Click(object sender, EventArgs e)
    {
        listBoxSubDire.Items.Clear();
        listBoxSubDire.Items.Add("..");
        try
        {

            foreach (string directorio in Directory.GetDirectories(path))
            {
                String[] aux = directorio.Split('/','\\');
                listBoxSubDire.Items.Add(aux[aux.Length-1]);
            }

        }
        catch (UnauthorizedAccessException)
        {
            lblPath.Text = "No tienes permisos";
        }
    }

    private void showFiles_Click(object sender, EventArgs e)
    {
        try
        {
            listBoxFiles.Items.Clear();
            foreach (string file in Directory.GetFiles(path))
            {
                listBoxFiles.Items.Add(file);
            }
        }
        catch (UnauthorizedAccessException)
        {
            lblPath.Text = "No tienes permisos";
        }
    }

    private void listBoxFiles_DoubleClick(object sender, EventArgs e)
    {
        if (listBoxFiles.SelectedItem != null)
        {
            Form2 f2 = new Form2(listBoxFiles.SelectedItem.ToString());
            f2.ShowDialog();
        }
    }

    private void listBoxFiles_Click(object sender, EventArgs e)
    {
        if (listBoxFiles.SelectedItem != null)
        {

            FileInfo f = new FileInfo(listBoxFiles.SelectedItem.ToString());
            switch (f.Length)
            {
                case < 1024:
                    lblSize.Text = f.Length.ToString() + " B";
                    break;
                case < 1024000:
                    lblSize.Text = f.Length / 1000 + " KB";
                    break;
                case < 1024000000:
                    lblSize.Text = f.Length / 1000000 + " MB";
                    break;
                default:
                    lblSize.Text = f.Length / 1000000000 + " GB";
                    break;
            }
        }
    }
}
