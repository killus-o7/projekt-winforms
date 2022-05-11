using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    public partial class Form1 : Form
    {
        private String[] paths = { };
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "mp3 files (*.mp3)|*.mp3";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                int arr_l = ofd.FileNames.Length,
                    paths_l = paths.Length;

                System.Console.WriteLine(paths_l);
                System.Console.WriteLine(arr_l);

                Array.Resize(ref paths, paths.Length + arr_l);
                for (int i = 0; i < arr_l; i++)
                {
                    paths[paths_l + i] = ofd.FileNames[i];
                    listBox.Items.Add(ofd.SafeFileNames[i]);
                }
            }
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = paths[listBox.SelectedIndex];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }
    }
}
