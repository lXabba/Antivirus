using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Antivirus
{
    public class FormElementsToScheduleScan
    {
        public Panel PanelToScheduleScan;
        public TextBox TextBoxToScheduleScan;
        public Label TimeToScheduleScan;
        public Label DateToToScheduleScan;
        public bool check = false;
        public FormElementsToScheduleScan(FlowLayoutPanel flowLayoutPanel)
        {
            PanelToScheduleScan = new System.Windows.Forms.Panel();
            TextBoxToScheduleScan = new System.Windows.Forms.TextBox();
            TimeToScheduleScan = new System.Windows.Forms.Label();
            DateToToScheduleScan = new System.Windows.Forms.Label();

            flowLayoutPanel.Controls.Add(PanelToScheduleScan);
            // 
            // PanelToScheduleScan
            // 
            PanelToScheduleScan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            PanelToScheduleScan.Controls.Add(TextBoxToScheduleScan);
            PanelToScheduleScan.Controls.Add(TimeToScheduleScan);
            PanelToScheduleScan.Controls.Add(DateToToScheduleScan);
            PanelToScheduleScan.Location = new System.Drawing.Point(3, 3);
            PanelToScheduleScan.Name = "PanelToScheduleScan";
            PanelToScheduleScan.Size = new System.Drawing.Size(573, 27);
            PanelToScheduleScan.TabIndex = 0;
            PanelToScheduleScan.Click += new System.EventHandler(PanelToScheduleScan_Click);
            // 
            // TextBoxToScheduleScan
            // 
            TextBoxToScheduleScan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            TextBoxToScheduleScan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TextBoxToScheduleScan.Location = new System.Drawing.Point(143, 6);
            TextBoxToScheduleScan.Name = "TextBoxToScheduleScan";
            TextBoxToScheduleScan.Size = new System.Drawing.Size(413, 15);
            TextBoxToScheduleScan.TabIndex = 4;

            // 
            // TimeToScheduleScan
            // 
            TimeToScheduleScan.AutoSize = true;
            TimeToScheduleScan.Location = new System.Drawing.Point(91, 5);
            TimeToScheduleScan.Name = "TimeToScheduleScan";
            TimeToScheduleScan.Size = new System.Drawing.Size(36, 17);
            TimeToScheduleScan.TabIndex = 1;
            TimeToScheduleScan.Text = "9:55";
            // 
            // DateToToScheduleScan
            // 
            DateToToScheduleScan.AutoSize = true;
            DateToToScheduleScan.Location = new System.Drawing.Point(4, 5);
            DateToToScheduleScan.Name = "DateToToScheduleScan";
            DateToToScheduleScan.Size = new System.Drawing.Size(64, 17);
            DateToToScheduleScan.TabIndex = 0;
            DateToToScheduleScan.Text = "18.03.21";
        }
        private void PanelToScheduleScan_Click(object sender, EventArgs e)
        {
            if (PanelToScheduleScan.BackColor != Color.LightBlue)
            {
                PanelToScheduleScan.BackColor = Color.LightBlue;
                check = true;
            }
            else
            {
                PanelToScheduleScan.BackColor = Color.White;
                check = false;
            }

        }
        public void Select()
        {
            PanelToScheduleScan.BackColor = Color.LightBlue;
            check = true;
        }
        public void DeletePanel(FlowLayoutPanel flowLayoutPanel)
        {

            flowLayoutPanel.Controls.Remove(PanelToScheduleScan);
        }
    }
}
