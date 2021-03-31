using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Antivirus
{
    public class FormElementsShedule
    {
        public Panel ShedulePanelAll;
        public TextBox SheduleTextBox;
        public Label SheduleLabelVirusType;
        public Label SheduleLabelTime;
        public Label SheduleLabelDate;
        public bool check = false;
        public FormElementsShedule(FlowLayoutPanel flowLayoutPanel)
        {
            ShedulePanelAll = new System.Windows.Forms.Panel();
            SheduleTextBox = new System.Windows.Forms.TextBox();
            SheduleLabelVirusType = new System.Windows.Forms.Label();
            SheduleLabelTime = new System.Windows.Forms.Label();
            SheduleLabelDate = new System.Windows.Forms.Label();

            flowLayoutPanel.Controls.Add(ShedulePanelAll);
            // 
            // ShedulePanelAll
            // 
            ShedulePanelAll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            ShedulePanelAll.Controls.Add(SheduleTextBox);
            ShedulePanelAll.Controls.Add(SheduleLabelVirusType);
            ShedulePanelAll.Controls.Add(SheduleLabelTime);
            ShedulePanelAll.Controls.Add(SheduleLabelDate);
            ShedulePanelAll.Location = new System.Drawing.Point(3, 3);
            ShedulePanelAll.Name = "ShedulePanelAll";
            ShedulePanelAll.Size = new System.Drawing.Size(573, 27);
            ShedulePanelAll.TabIndex = 0;
            ShedulePanelAll.Click += new System.EventHandler(this.ShedulePanelAll_Click);
            // 
            // SheduleTextBox
            // 
            SheduleTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            SheduleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SheduleTextBox.Location = new System.Drawing.Point(143, 6);
            SheduleTextBox.Name = "SheduleTextBox";
            SheduleTextBox.Size = new System.Drawing.Size(320, 15);
            SheduleTextBox.TabIndex = 4;
            // 
            // SheduleLabelVirusType
            // 
            SheduleLabelVirusType.AutoSize = true;
            SheduleLabelVirusType.Location = new System.Drawing.Point(481, 5);
            SheduleLabelVirusType.Name = "SheduleLabelVirusType";
            SheduleLabelVirusType.Size = new System.Drawing.Size(44, 17);
            SheduleLabelVirusType.TabIndex = 3;
            SheduleLabelVirusType.Text = "trojan";
            // 
            // SheduleLabelTime
            // 
            SheduleLabelTime.AutoSize = true;
            SheduleLabelTime.Location = new System.Drawing.Point(91, 5);
            SheduleLabelTime.Name = "SheduleLabelTime";
            SheduleLabelTime.Size = new System.Drawing.Size(36, 17);
            SheduleLabelTime.TabIndex = 1;
            SheduleLabelTime.Text = "9:55";
            // 
            // SheduleLabelDate
            // 
            SheduleLabelDate.AutoSize = true;
            SheduleLabelDate.Location = new System.Drawing.Point(4, 5);
            SheduleLabelDate.Name = "SheduleLabelDate";
            SheduleLabelDate.Size = new System.Drawing.Size(64, 17);
            SheduleLabelDate.TabIndex = 0;
            SheduleLabelDate.Text = "18.03.21";
        }
        private void ShedulePanelAll_Click(object sender, EventArgs e)
        {

            if (ShedulePanelAll.BackColor != Color.LightBlue)
            {
                ShedulePanelAll.BackColor = Color.LightBlue;
                check = true;
            }
            else
            {
                ShedulePanelAll.BackColor = Color.White;
                check = false;
            }
        }
        public void DeletePanel(FlowLayoutPanel flowLayoutPanel)
        {

            flowLayoutPanel.Controls.Remove(ShedulePanelAll);
        }
        public void Select()
        {
            ShedulePanelAll.BackColor = Color.LightBlue;
            check = true;
        }
    }
}
