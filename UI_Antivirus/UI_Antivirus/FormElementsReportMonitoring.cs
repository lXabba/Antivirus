using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Antivirus
{
    public class FormElementsReportMonitoring
    {
        public Panel ReportMonitoringPanel;
        public Label ReportMonitoringTime;
        public Label ReportMonitoringDate;
        public TextBox ReportMonitoringtextBox;
        public Label ReportMonitoringChange;
        public FormElementsReportMonitoring(FlowLayoutPanel flowLayoutPanelReportMonitoring)
        {
            ReportMonitoringPanel = new System.Windows.Forms.Panel();
            ReportMonitoringTime = new System.Windows.Forms.Label();
            ReportMonitoringDate = new System.Windows.Forms.Label();
            ReportMonitoringtextBox = new System.Windows.Forms.TextBox();
            ReportMonitoringChange = new System.Windows.Forms.Label();

            flowLayoutPanelReportMonitoring.Controls.Add(ReportMonitoringPanel);
            // ReportMonitoringPanel
            // 
            ReportMonitoringPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            ReportMonitoringPanel.Controls.Add(ReportMonitoringtextBox);
            ReportMonitoringPanel.Controls.Add(ReportMonitoringChange);
            ReportMonitoringPanel.Controls.Add(ReportMonitoringTime);
            ReportMonitoringPanel.Controls.Add(ReportMonitoringDate);
            ReportMonitoringPanel.Location = new System.Drawing.Point(3, 3);
            ReportMonitoringPanel.Name = "ReportMonitoringPanel";
            ReportMonitoringPanel.Size = new System.Drawing.Size(573, 27);
            ReportMonitoringPanel.TabIndex = 0;
            // 
            // ReportMonitoringChange
            // 
            ReportMonitoringChange.AutoSize = true;
            ReportMonitoringChange.Location = new System.Drawing.Point(481, 5);
            ReportMonitoringChange.Name = "ReportMonitoringChange";
            ReportMonitoringChange.Size = new System.Drawing.Size(55, 17);
            ReportMonitoringChange.TabIndex = 3;
            ReportMonitoringChange.Text = "удален";
            // 
            // ReportMonitoringTime
            // 
            ReportMonitoringTime.AutoSize = true;
            ReportMonitoringTime.Location = new System.Drawing.Point(91, 5);
            ReportMonitoringTime.Name = "ReportMonitoringTime";
            ReportMonitoringTime.Size = new System.Drawing.Size(36, 17);
            ReportMonitoringTime.TabIndex = 1;
            ReportMonitoringTime.Text = "9:55";
            // 
            // ReportMonitoringDate
            // 
            ReportMonitoringDate.AutoSize = true;
            ReportMonitoringDate.Location = new System.Drawing.Point(4, 5);
            ReportMonitoringDate.Name = "ReportMonitoringDate";
            ReportMonitoringDate.Size = new System.Drawing.Size(64, 17);
            ReportMonitoringDate.TabIndex = 0;
            ReportMonitoringDate.Text = "18.03.21";
            // 
            // ReportMonitoringtextBox
            // 
            ReportMonitoringtextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            ReportMonitoringtextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ReportMonitoringtextBox.Location = new System.Drawing.Point(143, 6);
            ReportMonitoringtextBox.Name = "ReportMonitoringtextBox";
            ReportMonitoringtextBox.Size = new System.Drawing.Size(320, 15);
            ReportMonitoringtextBox.TabIndex = 5;
        }
    }
}
