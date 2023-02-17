using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer3Form
{
    public partial class Form1 : Form
    {

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        int cont = 0, actualImage = 0;
        private FolderBrowserDialog folderBrowserDialog1;
        private ArrayList images = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            spotify.seconds = 55;
            intervalos.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
            intervalos.SelectedIndex = 0;
            myTimer.Tick += new EventHandler(TimerEventProccesor);
            myTimer.Interval = 1000;
            myTimer.Start();
        }

        public void TimerEventProccesor(Object myObject, EventArgs myEventArgs)
        {
            if (spotify.isPlaying)
            {
                spotify.seconds++;
                cont++;
                if (cont >= intervalos.SelectedIndex + 1)
                {
                    cont = 0;
                    if (images.Count > 0)
                    {
                        try
                        {
                            lienzo.Image = Image.FromFile(images[actualImage].ToString());
                        }
                        catch (OutOfMemoryException)
                        {
                            Console.Write("Imagen Corrupta");
                            cont = intervalos.SelectedIndex + 1;
                        }
                        actualImage++;
                        if (actualImage > images.Count - 1)
                        {
                            actualImage = 0;
                        }
                    }
                }
            }
        }

        private void spotify1_DesbordaTiempo(object sender, EventArgs e)
        {
            spotify.minutes++;
        }

        private void ImageExplorer_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                images.Clear();
                actualImage = 0;
                foreach (String file in Directory.EnumerateFiles(folderBrowserDialog1.SelectedPath))
                {
                    if (file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg"))
                    {
                        images.Add(file);
                    }
                }
            }
        }
    }
}
