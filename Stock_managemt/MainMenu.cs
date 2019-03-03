using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_managemt
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnsInvoice_Click(object sender, EventArgs e)
        {

        }

        private void mnsDoc_Click(object sender, EventArgs e)
        {

        }

        private void timTime_Tick(object sender, EventArgs e)
        {
            stsTime.Text = DateTime.Now.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss:");
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            oCenter oc = new oCenter();
            oc.Cpuv_conDataBase();
            //MessageBox.Show(oc.Cput_ConvertDate(DateTime.Now.Date).ToString("dd/MM/yyyy"));

        }

        private void mnsUser_Click(object sender, EventArgs e)
        {
            FrmUser frm = new FrmUser();
            frm.Show();
        }

        private void mnsFix_Click(object sender, EventArgs e)
        {

        }
    }
}
