using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Burnout_Paradise_Save_Transfer.Export
{
    public partial class ExportSave : Form
    {
        private readonly string _saveLocation;
        public ExportSave(string saveLocation)
        {
            InitializeComponent();
            _saveLocation = saveLocation;
        }

        private void Export_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }

        private  void button3_Click(object sender, EventArgs e)
        {
            try
            {
             CopyDirectory(_saveLocation, textBox1.Text);
             MessageBox.Show($"Export finished");
             Process.Start("explorer.exe", textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}");
            }
        }

        static void CopyDirectory(string source, string dest, bool overwrite = true)
        {
            Directory.CreateDirectory(dest);

            foreach (string file in Directory.GetFiles(source))
            {
                string destFile = Path.Combine(dest, Path.GetFileName(file));
                File.Copy(file, destFile, overwrite);
            }

            foreach (string dir in Directory.GetDirectories(source))
            {
                string destSubDir = Path.Combine(dest, Path.GetFileName(dir));
                CopyDirectory(dir, destSubDir, overwrite);
            }
        }

    }
}
