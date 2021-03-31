using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Antivirus
{
    public class FormElementsMonitoring
    {
       public Panel PanelMonitoring;
       public Label TimeMonitorLabel;
       public Label DataMonitorLabel;
       public CheckBox ChangesMonitorLabel;
       public TextBox textBoxMonitor;

        public bool check = false;

        public FormElementsMonitoring(FlowLayoutPanel flowLayoutPanelMonitor)
        {
            PanelMonitoring = new System.Windows.Forms.Panel();
            TimeMonitorLabel = new System.Windows.Forms.Label();
            DataMonitorLabel = new System.Windows.Forms.Label();
            ChangesMonitorLabel = new System.Windows.Forms.CheckBox();
            textBoxMonitor = new System.Windows.Forms.TextBox();


            flowLayoutPanelMonitor.Controls.Add(PanelMonitoring);
            // PanelMonitoring
            // 
            PanelMonitoring.BackColor = System.Drawing.SystemColors.ControlLightLight;
            PanelMonitoring.Controls.Add(textBoxMonitor);
            PanelMonitoring.Controls.Add(ChangesMonitorLabel);
            PanelMonitoring.Controls.Add(TimeMonitorLabel);
            PanelMonitoring.Controls.Add(DataMonitorLabel);
            PanelMonitoring.Location = new System.Drawing.Point(3, 3);
            PanelMonitoring.Name = "PanelMonitoring";
            PanelMonitoring.Size = new System.Drawing.Size(573, 27);
            PanelMonitoring.TabIndex = 0;
            PanelMonitoring.Click += new System.EventHandler(PanelMonitoring_Click);
            // 
            // TimeMonitorLabel
            // 
            TimeMonitorLabel.AutoSize = true;
            TimeMonitorLabel.Location = new System.Drawing.Point(91, 5);
            TimeMonitorLabel.Name = "TimeMonitorLabel";
            TimeMonitorLabel.Size = new System.Drawing.Size(36, 17);
            TimeMonitorLabel.TabIndex = 1;
            TimeMonitorLabel.Text = "9:55";
            // 
            // DataMonitorLabel
            // 
            DataMonitorLabel.AutoSize = true;
            DataMonitorLabel.Location = new System.Drawing.Point(4, 5);
            DataMonitorLabel.Name = "DataMonitorLabel";
            DataMonitorLabel.Size = new System.Drawing.Size(64, 17);
            DataMonitorLabel.TabIndex = 0;
            DataMonitorLabel.Text = "18.03.21";
            // 
            // ChangesMonitorLabel
            // 
            ChangesMonitorLabel.AutoSize = true;
            ChangesMonitorLabel.Location = new System.Drawing.Point(481, 5);
            ChangesMonitorLabel.Name = "ChangesMonitorLabel";
            ChangesMonitorLabel.Size = new System.Drawing.Size(57, 17);
            ChangesMonitorLabel.TabIndex = 3;
            ChangesMonitorLabel.Text = "Карантин";
            ChangesMonitorLabel.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBoxMonitor
            // 
            textBoxMonitor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            textBoxMonitor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxMonitor.Location = new System.Drawing.Point(126, 6);
            textBoxMonitor.Name = "textBoxMonitor";
            textBoxMonitor.Size = new System.Drawing.Size(320, 15);
            textBoxMonitor.TabIndex = 5;

           


        }
        private void PanelMonitoring_Click(object sender, EventArgs e)
        {
            if (PanelMonitoring.BackColor != Color.LightBlue)
            {
                PanelMonitoring.BackColor = Color.LightBlue;
                check = true;
            }
            else
            {
                PanelMonitoring.BackColor = Color.White;
                check = false;
            }
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChangesMonitorLabel.Checked)
            {
                ChangesMonitorLabel.Text = "Карантин";
                AntivirusLibrary.DataBaseMethods.DataBaseUpdate("Monitoring", $"CHANGE='QUARANTINE' WHERE PATH='{textBoxMonitor.Text}'");
            }
            else
            {
                ChangesMonitorLabel.Text = "Удалить";
                AntivirusLibrary.DataBaseMethods.DataBaseUpdate("Monitoring", $"CHANGE='DELETE' WHERE PATH='{textBoxMonitor.Text}'");
            }
        }
        public void DeafultMonitoringAction()
        {
            AntivirusLibrary.DataBaseMethods.DataBaseUpdate("Monitoring", $"CHANGE='QUARANTINE' WHERE PATH='{textBoxMonitor.Text}'");
        }
        public void DeletePanel(FlowLayoutPanel flowLayoutPanelMonitoring)
        {

            flowLayoutPanelMonitoring.Controls.Remove(PanelMonitoring);
        }
        public void Select()
        {
            PanelMonitoring.BackColor = Color.LightBlue;
            check = true;
        }
    }
}
