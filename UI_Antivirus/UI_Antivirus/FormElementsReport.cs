using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Antivirus
{
    public class FormElementsReport
    {
        public Panel PanelReport;
        public Label ResultReportLabel;
        public Label TimeReportLabel;
        public Label DataReportLabel;
        public TextBox textBoxReport;
        public FormElementsReport(FlowLayoutPanel flowLayoutPanelReport)
        {
            PanelReport = new System.Windows.Forms.Panel();
            ResultReportLabel = new System.Windows.Forms.Label();
            TimeReportLabel = new System.Windows.Forms.Label();
            DataReportLabel = new System.Windows.Forms.Label();
            textBoxReport = new System.Windows.Forms.TextBox();

            flowLayoutPanelReport.Controls.Add(PanelReport);
            // PanelReport
            // 
            PanelReport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            PanelReport.Controls.Add(textBoxReport);
            PanelReport.Controls.Add(ResultReportLabel);
            PanelReport.Controls.Add(TimeReportLabel);
            PanelReport.Controls.Add(DataReportLabel);
            PanelReport.Location = new System.Drawing.Point(3, 3);
            PanelReport.Name = "PanelReport";
            PanelReport.Size = new System.Drawing.Size(573, 27);
            PanelReport.TabIndex = 0;
            // 
            // ResultReportLabel
            // 
            ResultReportLabel.AutoSize = true;
            ResultReportLabel.Location = new System.Drawing.Point(481, 5);
            ResultReportLabel.Name = "ResultReportLabel";
            ResultReportLabel.Size = new System.Drawing.Size(55, 17);
            ResultReportLabel.TabIndex = 3;
            ResultReportLabel.Text = "удален";
            // 
            // TimeReportLabel
            // 
            TimeReportLabel.AutoSize = true;
            TimeReportLabel.Location = new System.Drawing.Point(91, 5);
            TimeReportLabel.Name = "TimeReportLabel";
            TimeReportLabel.Size = new System.Drawing.Size(36, 17);
            TimeReportLabel.TabIndex = 1;
            TimeReportLabel.Text = "9:55";
            // 
            // DataReportLabel
            // 
            DataReportLabel.AutoSize = true;
            DataReportLabel.Location = new System.Drawing.Point(4, 5);
            DataReportLabel.Name = "DataReportLabel";
            DataReportLabel.Size = new System.Drawing.Size(64, 17);
            DataReportLabel.TabIndex = 0;
            DataReportLabel.Text = "18.03.21";
            // 
            // textBoxReport
            // 
            textBoxReport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            textBoxReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxReport.Location = new System.Drawing.Point(143, 6);
            textBoxReport.Name = "textBoxReport";
            textBoxReport.Size = new System.Drawing.Size(320, 15);
            textBoxReport.TabIndex = 6;
        }
        public void DeletePanel(FlowLayoutPanel flowLayoutPanelQuarantune)
        {
           
            flowLayoutPanelQuarantune.Controls.Remove(PanelReport);
        }
    }
}
