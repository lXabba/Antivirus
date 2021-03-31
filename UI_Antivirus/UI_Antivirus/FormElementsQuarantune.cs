using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Antivirus
{
    public class FormElementsQuarantune
    {
        public Panel PanelQuarantine;
        public TextBox textBoxQuarantine;
        public Label VirusTypeQuarantine;
        public Label TimeQuarantine;
        public Label DataQuarantine;

        public bool check = false;
        public FormElementsQuarantune(FlowLayoutPanel flowLayoutPanelQuarantine)
        {
            PanelQuarantine = new System.Windows.Forms.Panel();
            textBoxQuarantine = new System.Windows.Forms.TextBox();
            VirusTypeQuarantine = new System.Windows.Forms.Label();
            TimeQuarantine = new System.Windows.Forms.Label();
            DataQuarantine = new System.Windows.Forms.Label();

            flowLayoutPanelQuarantine.Controls.Add(PanelQuarantine);
            // 
            // PanelQuarantine
            // 
            PanelQuarantine.BackColor = System.Drawing.SystemColors.ControlLightLight;
            PanelQuarantine.Controls.Add(textBoxQuarantine);
            PanelQuarantine.Controls.Add(VirusTypeQuarantine);
            PanelQuarantine.Controls.Add(TimeQuarantine);
            PanelQuarantine.Controls.Add(DataQuarantine);
            PanelQuarantine.Location = new System.Drawing.Point(3, 3);
            PanelQuarantine.Name = "PanelQuarantine";
            PanelQuarantine.Size = new System.Drawing.Size(573, 27);
            PanelQuarantine.TabIndex = 0;
            this.PanelQuarantine.Click += new System.EventHandler(this.PanelQuarantine_Click);
            // 
            // textBoxQuarantine
            // 
            textBoxQuarantine.BackColor = System.Drawing.SystemColors.ControlLightLight;
            textBoxQuarantine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxQuarantine.Location = new System.Drawing.Point(143, 6);
            textBoxQuarantine.Name = "textBoxQuarantine";
            textBoxQuarantine.Size = new System.Drawing.Size(320, 15);
            textBoxQuarantine.TabIndex = 5;
            // 
            // VirusTypeQuarantine
            // 
            VirusTypeQuarantine.AutoSize = true;
            VirusTypeQuarantine.Location = new System.Drawing.Point(481, 5);
            VirusTypeQuarantine.Name = "VirusTypeQuarantine";
            VirusTypeQuarantine.Size = new System.Drawing.Size(55, 17);
            VirusTypeQuarantine.TabIndex = 3;
            VirusTypeQuarantine.Text = "удален";
            // 
            // TimeQuarantine
            // 
            TimeQuarantine.AutoSize = true;
            TimeQuarantine.Location = new System.Drawing.Point(91, 5);
            TimeQuarantine.Name = "TimeQuarantine";
            TimeQuarantine.Size = new System.Drawing.Size(36, 17);
            TimeQuarantine.TabIndex = 1;
            TimeQuarantine.Text = "9:55";
            // 
            // DataQuarantine
            // 
            DataQuarantine.AutoSize = true;
            DataQuarantine.Location = new System.Drawing.Point(4, 5);
            DataQuarantine.Name = "DataQuarantine";
            DataQuarantine.Size = new System.Drawing.Size(64, 17);
            DataQuarantine.TabIndex = 0;
            DataQuarantine.Text = "18.03.21";
        }
        private void PanelQuarantine_Click(object sender, EventArgs e)
        {
            if (PanelQuarantine.BackColor != Color.LightBlue)
            {
                check = true;
                PanelQuarantine.BackColor = Color.LightBlue;
            }
            else
            {
                check = false;
                PanelQuarantine.BackColor = Color.White;
            }
        }
        public void DeletePanel(FlowLayoutPanel flowLayoutPanelQuarantune)
        {
            PanelQuarantine.Click -= new System.EventHandler(PanelQuarantine_Click);
            flowLayoutPanelQuarantune.Controls.Remove(PanelQuarantine);
        }

        public void Select()
        {
            check = true;
            PanelQuarantine.BackColor = Color.LightBlue;
        }
    }
}
