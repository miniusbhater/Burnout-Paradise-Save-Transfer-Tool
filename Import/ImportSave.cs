using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Burnout_Paradise_Save_Transfer.Import
{
    public partial class ImportSave : Form
    {
        public ImportSave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string username = Environment.UserName;
                string saveLocation = $"C:\\Users\\{username}\\AppData\\Local\\Criterion Games\\Burnout Paradise";
                CopyDirectory(textBox1.Text, saveLocation);
                MessageBox.Show($"Import finished");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Import failed: {ex.Message}");
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

        private void ImportSave_Load(object sender, EventArgs e)
        {

        }
    }
}
