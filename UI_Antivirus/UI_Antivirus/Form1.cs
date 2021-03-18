using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Antivirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ScanPanelButton_Click(object sender, EventArgs e)
        {
            ScanPanel.Visible = true;
            ScanPanelButton.BackColor = Color.LightBlue;
        }
    }
}
