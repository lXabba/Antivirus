
namespace UI_Antivirus
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScanPanelButton = new System.Windows.Forms.Button();
            this.ScanPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.IgnorScan = new System.Windows.Forms.Button();
            this.DeleteAllScan = new System.Windows.Forms.Button();
            this.DeleteFileScan = new System.Windows.Forms.Button();
            this.ScanRunning = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelScan = new System.Windows.Forms.Panel();
            this.ResultScanLabel = new System.Windows.Forms.Label();
            this.PathScanLabel = new System.Windows.Forms.Label();
            this.TimeScanLabel = new System.Windows.Forms.Label();
            this.DataScanLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DirButtonScan = new System.Windows.Forms.Button();
            this.FileButtonScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MonitorPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DeleteAllMonitoring = new System.Windows.Forms.Button();
            this.DeleteFileMonitoring = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelMonitoring = new System.Windows.Forms.Panel();
            this.PathMonitorLabel = new System.Windows.Forms.Label();
            this.TimeMonitorLabel = new System.Windows.Forms.Label();
            this.DataMonitorLabel = new System.Windows.Forms.Label();
            this.DirButtonMonitoring = new System.Windows.Forms.Button();
            this.FileButtonMonitoring = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.MonitorPanelButton = new System.Windows.Forms.Button();
            this.ReportPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelReport = new System.Windows.Forms.Panel();
            this.ResultReportLabel = new System.Windows.Forms.Label();
            this.PathReportLabel = new System.Windows.Forms.Label();
            this.TimeReportLabel = new System.Windows.Forms.Label();
            this.DataReportLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ReportPanelButton = new System.Windows.Forms.Button();
            this.StartMonitoring = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PlanPanelButton = new System.Windows.Forms.Button();
            this.ScanPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.PanelScan.SuspendLayout();
            this.MonitorPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.PanelMonitoring.SuspendLayout();
            this.ReportPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.PanelReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScanPanelButton
            // 
            this.ScanPanelButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ScanPanelButton.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScanPanelButton.Location = new System.Drawing.Point(13, 13);
            this.ScanPanelButton.Name = "ScanPanelButton";
            this.ScanPanelButton.Size = new System.Drawing.Size(160, 63);
            this.ScanPanelButton.TabIndex = 0;
            this.ScanPanelButton.Text = "Сканирование";
            this.ScanPanelButton.UseVisualStyleBackColor = false;
            this.ScanPanelButton.Click += new System.EventHandler(this.ScanPanelButton_Click);
            // 
            // ScanPanel
            // 
            this.ScanPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ScanPanel.Controls.Add(this.panel1);
            this.ScanPanel.Controls.Add(this.DirButtonScan);
            this.ScanPanel.Controls.Add(this.FileButtonScan);
            this.ScanPanel.Controls.Add(this.label1);
            this.ScanPanel.Location = new System.Drawing.Point(0, 0);
            this.ScanPanel.Name = "ScanPanel";
            this.ScanPanel.Size = new System.Drawing.Size(611, 431);
            this.ScanPanel.TabIndex = 1;
            this.ScanPanel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.IgnorScan);
            this.panel1.Controls.Add(this.DeleteAllScan);
            this.panel1.Controls.Add(this.DeleteFileScan);
            this.panel1.Controls.Add(this.ScanRunning);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 299);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Font = new System.Drawing.Font("Aznauri Square", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(138, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Карантин";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // IgnorScan
            // 
            this.IgnorScan.BackColor = System.Drawing.SystemColors.Window;
            this.IgnorScan.Font = new System.Drawing.Font("Aznauri Square", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IgnorScan.Location = new System.Drawing.Point(366, 267);
            this.IgnorScan.Name = "IgnorScan";
            this.IgnorScan.Size = new System.Drawing.Size(112, 23);
            this.IgnorScan.TabIndex = 5;
            this.IgnorScan.Text = "Игнорировать";
            this.IgnorScan.UseVisualStyleBackColor = false;
            // 
            // DeleteAllScan
            // 
            this.DeleteAllScan.BackColor = System.Drawing.SystemColors.Window;
            this.DeleteAllScan.Font = new System.Drawing.Font("Aznauri Square", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteAllScan.Location = new System.Drawing.Point(484, 267);
            this.DeleteAllScan.Name = "DeleteAllScan";
            this.DeleteAllScan.Size = new System.Drawing.Size(112, 23);
            this.DeleteAllScan.TabIndex = 5;
            this.DeleteAllScan.Text = "Удалить все";
            this.DeleteAllScan.UseVisualStyleBackColor = false;
            // 
            // DeleteFileScan
            // 
            this.DeleteFileScan.BackColor = System.Drawing.SystemColors.Window;
            this.DeleteFileScan.Font = new System.Drawing.Font("Aznauri Square", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteFileScan.Location = new System.Drawing.Point(20, 267);
            this.DeleteFileScan.Name = "DeleteFileScan";
            this.DeleteFileScan.Size = new System.Drawing.Size(112, 23);
            this.DeleteFileScan.TabIndex = 4;
            this.DeleteFileScan.Text = "Удалить";
            this.DeleteFileScan.UseVisualStyleBackColor = false;
            // 
            // ScanRunning
            // 
            this.ScanRunning.AutoSize = true;
            this.ScanRunning.BackColor = System.Drawing.Color.Snow;
            this.ScanRunning.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScanRunning.Location = new System.Drawing.Point(17, 43);
            this.ScanRunning.Name = "ScanRunning";
            this.ScanRunning.Size = new System.Drawing.Size(153, 15);
            this.ScanRunning.TabIndex = 3;
            this.ScanRunning.Text = "Выполнено 23%";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.PanelScan);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(576, 203);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // PanelScan
            // 
            this.PanelScan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelScan.Controls.Add(this.ResultScanLabel);
            this.PanelScan.Controls.Add(this.PathScanLabel);
            this.PanelScan.Controls.Add(this.TimeScanLabel);
            this.PanelScan.Controls.Add(this.DataScanLabel);
            this.PanelScan.Location = new System.Drawing.Point(3, 3);
            this.PanelScan.Name = "PanelScan";
            this.PanelScan.Size = new System.Drawing.Size(573, 27);
            this.PanelScan.TabIndex = 0;
            // 
            // ResultScanLabel
            // 
            this.ResultScanLabel.AutoSize = true;
            this.ResultScanLabel.Location = new System.Drawing.Point(314, 4);
            this.ResultScanLabel.Name = "ResultScanLabel";
            this.ResultScanLabel.Size = new System.Drawing.Size(44, 17);
            this.ResultScanLabel.TabIndex = 3;
            this.ResultScanLabel.Text = "trojan";
            // 
            // PathScanLabel
            // 
            this.PathScanLabel.AutoSize = true;
            this.PathScanLabel.Location = new System.Drawing.Point(140, 4);
            this.PathScanLabel.Name = "PathScanLabel";
            this.PathScanLabel.Size = new System.Drawing.Size(156, 17);
            this.PathScanLabel.TabIndex = 2;
            this.PathScanLabel.Text = "C:/TraliVali/TraTrali.exe";
            // 
            // TimeScanLabel
            // 
            this.TimeScanLabel.AutoSize = true;
            this.TimeScanLabel.Location = new System.Drawing.Point(91, 4);
            this.TimeScanLabel.Name = "TimeScanLabel";
            this.TimeScanLabel.Size = new System.Drawing.Size(36, 17);
            this.TimeScanLabel.TabIndex = 1;
            this.TimeScanLabel.Text = "9:55";
            // 
            // DataScanLabel
            // 
            this.DataScanLabel.AutoSize = true;
            this.DataScanLabel.Location = new System.Drawing.Point(4, 4);
            this.DataScanLabel.Name = "DataScanLabel";
            this.DataScanLabel.Size = new System.Drawing.Size(64, 17);
            this.DataScanLabel.TabIndex = 0;
            this.DataScanLabel.Text = "18.03.21";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(166, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(430, 22);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(430, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Snow;
            this.label2.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Сканирование:";
            // 
            // DirButtonScan
            // 
            this.DirButtonScan.BackColor = System.Drawing.SystemColors.Window;
            this.DirButtonScan.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DirButtonScan.Location = new System.Drawing.Point(348, 63);
            this.DirButtonScan.Name = "DirButtonScan";
            this.DirButtonScan.Size = new System.Drawing.Size(176, 57);
            this.DirButtonScan.TabIndex = 2;
            this.DirButtonScan.Text = "Директория";
            this.DirButtonScan.UseVisualStyleBackColor = false;
            // 
            // FileButtonScan
            // 
            this.FileButtonScan.BackColor = System.Drawing.SystemColors.Window;
            this.FileButtonScan.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileButtonScan.Location = new System.Drawing.Point(90, 63);
            this.FileButtonScan.Name = "FileButtonScan";
            this.FileButtonScan.Size = new System.Drawing.Size(176, 57);
            this.FileButtonScan.TabIndex = 1;
            this.FileButtonScan.Text = "Файл";
            this.FileButtonScan.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(177, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Что желаете сканировать?";
            // 
            // MonitorPanel
            // 
            this.MonitorPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MonitorPanel.Controls.Add(this.panel4);
            this.MonitorPanel.Controls.Add(this.ScanPanel);
            this.MonitorPanel.Controls.Add(this.ReportPanel);
            this.MonitorPanel.Controls.Add(this.DirButtonMonitoring);
            this.MonitorPanel.Controls.Add(this.FileButtonMonitoring);
            this.MonitorPanel.Controls.Add(this.label13);
            this.MonitorPanel.Location = new System.Drawing.Point(180, 13);
            this.MonitorPanel.Name = "MonitorPanel";
            this.MonitorPanel.Size = new System.Drawing.Size(611, 431);
            this.MonitorPanel.TabIndex = 4;
            this.MonitorPanel.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel4.Controls.Add(this.StopButton);
            this.panel4.Controls.Add(this.StartMonitoring);
            this.panel4.Controls.Add(this.DeleteAllMonitoring);
            this.panel4.Controls.Add(this.DeleteFileMonitoring);
            this.panel4.Controls.Add(this.flowLayoutPanel2);
            this.panel4.Location = new System.Drawing.Point(0, 132);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(611, 299);
            this.panel4.TabIndex = 3;
            // 
            // DeleteAllMonitoring
            // 
            this.DeleteAllMonitoring.BackColor = System.Drawing.SystemColors.Window;
            this.DeleteAllMonitoring.Font = new System.Drawing.Font("Aznauri Square", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteAllMonitoring.Location = new System.Drawing.Point(484, 267);
            this.DeleteAllMonitoring.Name = "DeleteAllMonitoring";
            this.DeleteAllMonitoring.Size = new System.Drawing.Size(112, 23);
            this.DeleteAllMonitoring.TabIndex = 5;
            this.DeleteAllMonitoring.Text = "Удалить все";
            this.DeleteAllMonitoring.UseVisualStyleBackColor = false;
            // 
            // DeleteFileMonitoring
            // 
            this.DeleteFileMonitoring.BackColor = System.Drawing.SystemColors.Window;
            this.DeleteFileMonitoring.Font = new System.Drawing.Font("Aznauri Square", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteFileMonitoring.Location = new System.Drawing.Point(20, 267);
            this.DeleteFileMonitoring.Name = "DeleteFileMonitoring";
            this.DeleteFileMonitoring.Size = new System.Drawing.Size(112, 23);
            this.DeleteFileMonitoring.TabIndex = 4;
            this.DeleteFileMonitoring.Text = "Удалить";
            this.DeleteFileMonitoring.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.PanelMonitoring);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(20, 15);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(576, 246);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // PanelMonitoring
            // 
            this.PanelMonitoring.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelMonitoring.Controls.Add(this.PathMonitorLabel);
            this.PanelMonitoring.Controls.Add(this.TimeMonitorLabel);
            this.PanelMonitoring.Controls.Add(this.DataMonitorLabel);
            this.PanelMonitoring.Location = new System.Drawing.Point(3, 3);
            this.PanelMonitoring.Name = "PanelMonitoring";
            this.PanelMonitoring.Size = new System.Drawing.Size(573, 27);
            this.PanelMonitoring.TabIndex = 0;
            // 
            // PathMonitorLabel
            // 
            this.PathMonitorLabel.AutoSize = true;
            this.PathMonitorLabel.Location = new System.Drawing.Point(140, 4);
            this.PathMonitorLabel.Name = "PathMonitorLabel";
            this.PathMonitorLabel.Size = new System.Drawing.Size(156, 17);
            this.PathMonitorLabel.TabIndex = 2;
            this.PathMonitorLabel.Text = "C:/TraliVali/TraTrali.exe";
            // 
            // TimeMonitorLabel
            // 
            this.TimeMonitorLabel.AutoSize = true;
            this.TimeMonitorLabel.Location = new System.Drawing.Point(91, 4);
            this.TimeMonitorLabel.Name = "TimeMonitorLabel";
            this.TimeMonitorLabel.Size = new System.Drawing.Size(36, 17);
            this.TimeMonitorLabel.TabIndex = 1;
            this.TimeMonitorLabel.Text = "9:55";
            // 
            // DataMonitorLabel
            // 
            this.DataMonitorLabel.AutoSize = true;
            this.DataMonitorLabel.Location = new System.Drawing.Point(4, 4);
            this.DataMonitorLabel.Name = "DataMonitorLabel";
            this.DataMonitorLabel.Size = new System.Drawing.Size(64, 17);
            this.DataMonitorLabel.TabIndex = 0;
            this.DataMonitorLabel.Text = "18.03.21";
            // 
            // DirButtonMonitoring
            // 
            this.DirButtonMonitoring.BackColor = System.Drawing.SystemColors.Window;
            this.DirButtonMonitoring.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DirButtonMonitoring.Location = new System.Drawing.Point(348, 63);
            this.DirButtonMonitoring.Name = "DirButtonMonitoring";
            this.DirButtonMonitoring.Size = new System.Drawing.Size(176, 57);
            this.DirButtonMonitoring.TabIndex = 2;
            this.DirButtonMonitoring.Text = "Директория";
            this.DirButtonMonitoring.UseVisualStyleBackColor = false;
            // 
            // FileButtonMonitoring
            // 
            this.FileButtonMonitoring.BackColor = System.Drawing.SystemColors.Window;
            this.FileButtonMonitoring.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileButtonMonitoring.Location = new System.Drawing.Point(90, 63);
            this.FileButtonMonitoring.Name = "FileButtonMonitoring";
            this.FileButtonMonitoring.Size = new System.Drawing.Size(176, 57);
            this.FileButtonMonitoring.TabIndex = 1;
            this.FileButtonMonitoring.Text = "Файл";
            this.FileButtonMonitoring.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(177, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(266, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Что желаете мониторить?";
            // 
            // MonitorPanelButton
            // 
            this.MonitorPanelButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.MonitorPanelButton.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MonitorPanelButton.Location = new System.Drawing.Point(13, 82);
            this.MonitorPanelButton.Name = "MonitorPanelButton";
            this.MonitorPanelButton.Size = new System.Drawing.Size(160, 63);
            this.MonitorPanelButton.TabIndex = 5;
            this.MonitorPanelButton.Text = "Мониторинг";
            this.MonitorPanelButton.UseVisualStyleBackColor = false;
            // 
            // ReportPanel
            // 
            this.ReportPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ReportPanel.Controls.Add(this.panel5);
            this.ReportPanel.Controls.Add(this.label16);
            this.ReportPanel.Location = new System.Drawing.Point(3, 3);
            this.ReportPanel.Name = "ReportPanel";
            this.ReportPanel.Size = new System.Drawing.Size(611, 431);
            this.ReportPanel.TabIndex = 6;
            this.ReportPanel.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel5.Controls.Add(this.flowLayoutPanel3);
            this.panel5.Location = new System.Drawing.Point(0, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(611, 368);
            this.panel5.TabIndex = 3;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.Controls.Add(this.PanelReport);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(20, 15);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(576, 318);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // PanelReport
            // 
            this.PanelReport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelReport.Controls.Add(this.ResultReportLabel);
            this.PanelReport.Controls.Add(this.PathReportLabel);
            this.PanelReport.Controls.Add(this.TimeReportLabel);
            this.PanelReport.Controls.Add(this.DataReportLabel);
            this.PanelReport.Location = new System.Drawing.Point(3, 3);
            this.PanelReport.Name = "PanelReport";
            this.PanelReport.Size = new System.Drawing.Size(573, 27);
            this.PanelReport.TabIndex = 0;
            // 
            // ResultReportLabel
            // 
            this.ResultReportLabel.AutoSize = true;
            this.ResultReportLabel.Location = new System.Drawing.Point(314, 4);
            this.ResultReportLabel.Name = "ResultReportLabel";
            this.ResultReportLabel.Size = new System.Drawing.Size(55, 17);
            this.ResultReportLabel.TabIndex = 3;
            this.ResultReportLabel.Text = "удален";
            // 
            // PathReportLabel
            // 
            this.PathReportLabel.AutoSize = true;
            this.PathReportLabel.Location = new System.Drawing.Point(140, 4);
            this.PathReportLabel.Name = "PathReportLabel";
            this.PathReportLabel.Size = new System.Drawing.Size(156, 17);
            this.PathReportLabel.TabIndex = 2;
            this.PathReportLabel.Text = "C:/TraliVali/TraTrali.exe";
            // 
            // TimeReportLabel
            // 
            this.TimeReportLabel.AutoSize = true;
            this.TimeReportLabel.Location = new System.Drawing.Point(91, 4);
            this.TimeReportLabel.Name = "TimeReportLabel";
            this.TimeReportLabel.Size = new System.Drawing.Size(36, 17);
            this.TimeReportLabel.TabIndex = 1;
            this.TimeReportLabel.Text = "9:55";
            // 
            // DataReportLabel
            // 
            this.DataReportLabel.AutoSize = true;
            this.DataReportLabel.Location = new System.Drawing.Point(4, 4);
            this.DataReportLabel.Name = "DataReportLabel";
            this.DataReportLabel.Size = new System.Drawing.Size(64, 17);
            this.DataReportLabel.TabIndex = 0;
            this.DataReportLabel.Text = "18.03.21";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(177, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(233, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Отчет по мониторингу.";
            // 
            // ReportPanelButton
            // 
            this.ReportPanelButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ReportPanelButton.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportPanelButton.Location = new System.Drawing.Point(12, 151);
            this.ReportPanelButton.Name = "ReportPanelButton";
            this.ReportPanelButton.Size = new System.Drawing.Size(160, 63);
            this.ReportPanelButton.TabIndex = 7;
            this.ReportPanelButton.Text = "Отчет";
            this.ReportPanelButton.UseVisualStyleBackColor = false;
            // 
            // StartMonitoring
            // 
            this.StartMonitoring.BackColor = System.Drawing.SystemColors.Window;
            this.StartMonitoring.Font = new System.Drawing.Font("Aznauri Square", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartMonitoring.Location = new System.Drawing.Point(138, 267);
            this.StartMonitoring.Name = "StartMonitoring";
            this.StartMonitoring.Size = new System.Drawing.Size(112, 23);
            this.StartMonitoring.TabIndex = 6;
            this.StartMonitoring.Text = "Запустить";
            this.StartMonitoring.UseVisualStyleBackColor = false;
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.SystemColors.Window;
            this.StopButton.Font = new System.Drawing.Font("Aznauri Square", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopButton.Location = new System.Drawing.Point(366, 267);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(112, 23);
            this.StopButton.TabIndex = 7;
            this.StopButton.Text = "Остановить";
            this.StopButton.UseVisualStyleBackColor = false;
            // 
            // PlanPanelButton
            // 
            this.PlanPanelButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PlanPanelButton.Font = new System.Drawing.Font("Aznauri Square", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlanPanelButton.Location = new System.Drawing.Point(12, 220);
            this.PlanPanelButton.Name = "PlanPanelButton";
            this.PlanPanelButton.Size = new System.Drawing.Size(160, 63);
            this.PlanPanelButton.TabIndex = 8;
            this.PlanPanelButton.Text = "Запланировать";
            this.PlanPanelButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI_Antivirus.Properties.Resources.the_best_free_antivirus_protection_of_2016_r4m7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1450, 456);
            this.Controls.Add(this.PlanPanelButton);
            this.Controls.Add(this.ReportPanelButton);
            this.Controls.Add(this.MonitorPanelButton);
            this.Controls.Add(this.MonitorPanel);
            this.Controls.Add(this.ScanPanelButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Antivirus Protasova";
            this.ScanPanel.ResumeLayout(false);
            this.ScanPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.PanelScan.ResumeLayout(false);
            this.PanelScan.PerformLayout();
            this.MonitorPanel.ResumeLayout(false);
            this.MonitorPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.PanelMonitoring.ResumeLayout(false);
            this.PanelMonitoring.PerformLayout();
            this.ReportPanel.ResumeLayout(false);
            this.ReportPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.PanelReport.ResumeLayout(false);
            this.PanelReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ScanPanelButton;
        private System.Windows.Forms.Panel ScanPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel PanelScan;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DirButtonScan;
        private System.Windows.Forms.Button FileButtonScan;
        private System.Windows.Forms.Label ResultScanLabel;
        private System.Windows.Forms.Label PathScanLabel;
        private System.Windows.Forms.Label TimeScanLabel;
        private System.Windows.Forms.Label DataScanLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button IgnorScan;
        private System.Windows.Forms.Button DeleteAllScan;
        private System.Windows.Forms.Button DeleteFileScan;
        private System.Windows.Forms.Label ScanRunning;
        private System.Windows.Forms.Panel MonitorPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button DeleteAllMonitoring;
        private System.Windows.Forms.Button DeleteFileMonitoring;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel PanelMonitoring;
        private System.Windows.Forms.Label PathMonitorLabel;
        private System.Windows.Forms.Label TimeMonitorLabel;
        private System.Windows.Forms.Label DataMonitorLabel;
        private System.Windows.Forms.Button DirButtonMonitoring;
        private System.Windows.Forms.Button FileButtonMonitoring;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button MonitorPanelButton;
        private System.Windows.Forms.Panel ReportPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel PanelReport;
        private System.Windows.Forms.Label ResultReportLabel;
        private System.Windows.Forms.Label PathReportLabel;
        private System.Windows.Forms.Label TimeReportLabel;
        private System.Windows.Forms.Label DataReportLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button ReportPanelButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartMonitoring;
        private System.Windows.Forms.Button PlanPanelButton;
    }
}

