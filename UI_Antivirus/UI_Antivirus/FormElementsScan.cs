using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UI_Antivirus
{
    public class FormElementsScan
    {
        
        public Panel PanelScan;
        public Label ResultScanLabel;
        public Label TimeScanLabel;
        public Label DataScanLabel;
        public TextBox PathScanTextBox;

        public bool check = false;
        public FormElementsScan(FlowLayoutPanel flowLayoutPanelScan)
        {
            PanelScan = new System.Windows.Forms.Panel();
            ResultScanLabel = new System.Windows.Forms.Label();
            TimeScanLabel = new System.Windows.Forms.Label();
            DataScanLabel = new System.Windows.Forms.Label();
            PathScanTextBox = new System.Windows.Forms.TextBox();
           
            flowLayoutPanelScan.Controls.Add(PanelScan);
            // PanelScan
            // 
            PanelScan.BackColor = SystemColors.ControlLightLight;
            PanelScan.Controls.Add(PathScanTextBox);
            PanelScan.Controls.Add(ResultScanLabel);
            PanelScan.Controls.Add(TimeScanLabel);
            PanelScan.Controls.Add(DataScanLabel);
            PanelScan.Location = new System.Drawing.Point(3, 3);
            PanelScan.Name = "PanelScan";
            PanelScan.Size = new System.Drawing.Size(573, 27);
            PanelScan.TabIndex = 0;
            PanelScan.Click += new System.EventHandler(PanelScan_Click);
            // 
            // ResultScanLabel
            // 
            ResultScanLabel.AutoSize = true;
            ResultScanLabel.Location = new System.Drawing.Point(481, 5);
            ResultScanLabel.Name = "ResultScanLabel";
            ResultScanLabel.Size = new System.Drawing.Size(44, 17);
            ResultScanLabel.TabIndex = 3;
            ResultScanLabel.Text = "trojan";
            // 
            // TimeScanLabel
            // 
            TimeScanLabel.AutoSize = true;
            TimeScanLabel.Location = new System.Drawing.Point(91, 5);
            TimeScanLabel.Name = "TimeScanLabel";
            TimeScanLabel.Size = new System.Drawing.Size(36, 17);
            TimeScanLabel.TabIndex = 1;
            TimeScanLabel.Text = "9:55";
            // 
            // DataScanLabel
            // 
            DataScanLabel.AutoSize = true;
            DataScanLabel.Location = new System.Drawing.Point(4, 5);
            DataScanLabel.Name = "DataScanLabel";
            DataScanLabel.Size = new System.Drawing.Size(64, 17);
            DataScanLabel.TabIndex = 0;
            DataScanLabel.Text = "18.03.21";
            // 
            // PathScanTextBox
            // 
            PathScanTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            PathScanTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            PathScanTextBox.Location = new System.Drawing.Point(143, 6);
            PathScanTextBox.Name = "PathScanTextBox";
            PathScanTextBox.Size = new System.Drawing.Size(320, 15);
            PathScanTextBox.TabIndex = 4;
            PathScanTextBox.ReadOnly = true;
        }
        public void Select()
        {
            PanelScan.BackColor = Color.LightBlue;
            check = true;
        }
        private void PanelScan_Click(object sender, EventArgs e)
        {
            if (PanelScan.BackColor != Color.LightBlue)
            {
                check = true;
                PanelScan.BackColor = Color.LightBlue;
            }
            else
            {
                check = false;
                PanelScan.BackColor = Color.White;
            }
        }

        public void DeletePanel(FlowLayoutPanel flowLayoutPanelScan)
        {
            PanelScan.Click -= new System.EventHandler(PanelScan_Click);
            flowLayoutPanelScan.Controls.Remove(PanelScan);
        }
    }
}
