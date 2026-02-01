namespace Burnout_Paradise_Save_Transfer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form getinfo = new Export.GetInfo();
            getinfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form import = new Import.ImportSave();
            import.Show();
        }
    }
}
