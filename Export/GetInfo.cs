using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Burnout_Paradise_Save_Transfer.Export
{
    public partial class GetInfo : Form
    {
        public GetInfo()
        {
            InitializeComponent();
            this.Shown += GetInfo_Shown;
        }

        public void GetInfo_Load(object sender, EventArgs e)
        {
           
        }

        private void GetInfo_Shown(object sender, EventArgs e)
        {
            string username = Environment.UserName;
            bool saveExists = Directory.Exists($"C:\\Users\\{username}\\AppData\\Local\\Criterion Games\\Burnout Paradise");
            if (saveExists)
            {
                string saveLocation = $"C:\\Users\\{username}\\AppData\\Local\\Criterion Games\\Burnout Paradise";
                this.Close();
                Form export = new ExportSave(saveLocation);
                export.Show();              
            }
            else
            {
                MessageBox.Show("Unable to find your Burnout Paradise save");
                this.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
