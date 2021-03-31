using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntivirusLibrary;
using System.Threading;

namespace UI_Antivirus
{
   
    public partial class Form1 : Form
    {
        List<FormElementsScan> lformElementsScans = new List<FormElementsScan>();
        List<FormElementsMonitoring> lformElementsMonitorings = new List<FormElementsMonitoring>();
        List<FormElementsReportMonitoring> lformElementsReportMonitorings = new List<FormElementsReportMonitoring>();
        List<FormElementsReport> lformElementsReports = new List<FormElementsReport>();
        List<FormElementsQuarantune> lformElementsQuarantunes = new List<FormElementsQuarantune>();
        List<FormElementsToScheduleScan> lformElementsShedules = new List<FormElementsToScheduleScan>();
        List<FormElementsShedule> lformElementsShedulesAfterScan = new List<FormElementsShedule>();

        bool operationDone = true;
        IntPtr handleC;
        
        public Form1()
        {
            InitializeComponent();
           Thread readThread = new Thread(Reading);
           readThread.Start();
            
           handleC = AntivirusLibrary.MailSlotClientMethods.CreateClientMail();


        }

        private void ScanPanelButton_Click(object sender, EventArgs e)
        {
            ScanResultLabel.Text = "";

            ScanRunning.Text = "Не выполняется";
            OffAll();
            ScanPanel.Visible = true;
            ScanPanel.Location = new System.Drawing.Point(179, 13);
            ScanPanelButton.BackColor = Color.LightBlue;
        }

        
        private void DeleteFileScan_Click(object sender, EventArgs e)
        {
            int count = 0;
            
            string temp = "";
            foreach(var panel in lformElementsScans)
            {
                if (panel.check)
                {
                    temp += panel.PathScanTextBox.Text;
                    temp += "?";
                    count++;
                    panel.DeletePanel(flowLayoutPanelScan);
                }
                
                
            }
          
            temp = temp.Substring(0, temp.Length - 1);
            
            //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
            //AntivirusLibrary.MailSlotClientMethods.SendQuest($"1|{count}?{temp}|0");
            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"1|{count}?{temp}|0");

        }

        private void MonitorPanelButton_Click(object sender, EventArgs e)
        {
            foreach (var temp in lformElementsMonitorings)
            {
                temp.DeletePanel(flowLayoutPanelMonitor);
            }
            List<string> tempList = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("Monitoring");
            foreach (var file in tempList)
            {
                var panelTemp = new FormElementsMonitoring(flowLayoutPanelMonitor);
                var tempData = new AntivirusLibrary.DataReportMonitoring(file);
                panelTemp.textBoxMonitor.Text = tempData.path;
                panelTemp.DataMonitorLabel.Text = tempData.date;
                panelTemp.TimeMonitorLabel.Text = tempData.time;
                if (tempData.operation.Equals("QUARANTINE")) panelTemp.ChangesMonitorLabel.Checked = false;
                else if (tempData.operation.Equals("DELETE")) panelTemp.ChangesMonitorLabel.Checked = true;

                lformElementsMonitorings.Add(panelTemp);
            }

            OffAll();
            MonitorPanel.Visible = true;
            MonitorPanel.Location = new System.Drawing.Point(179, 13);
            MonitorPanelButton.BackColor = Color.LightBlue;
        }

        private void PanelMonitoring_Click(object sender, EventArgs e)
        {
            if (PanelMonitoring.BackColor != Color.LightBlue)
                PanelMonitoring.BackColor = Color.LightBlue;
            else PanelMonitoring.BackColor = Color.White;
        }
        private void Reading()
        {
            while (true)
            {
                string mail = AntivirusLibrary.MailSlotClientMethods.ReadMail(handleC);

                if (mail.StartsWith("Всего"))
                {
                   
                        ScanRunning.Invoke((ThreadStart)delegate ()
                        {
                            ScanResultLabel.Text = mail;
                        });
                }
                if (mail.Equals("Завершено"))
                {
                    List<string> temp = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("Scan");
                    ScanRunning.Invoke((ThreadStart)delegate ()
                    {
                        ScanRunning.Text = mail +$". Найдено {temp.Count} угроз";
                    });
                }
                if (mail.StartsWith("Выполнено"))
                {
                    if (int.Parse(mail.Split(' ')[1]) >= 0){
                        ScanRunning.Invoke((ThreadStart)delegate ()
                        {
                            ScanRunning.Text = mail + "%";
                        });
                    }
                }
                if (mail.StartsWith("Monitor")) Console.WriteLine(mail);
                if (mail.Equals("Operation done"))
                {

                    operationDone = true;

                   
                }
                if (mail.Split(' ')[0].Equals("Scaned"))
                {

                    //textBoxScaning.Invoke(new Action(() => textBoxScaning.Text = mail));
                    textBoxScaning.Invoke((ThreadStart)delegate ()
                    {
                        textBoxScaning.Text = mail;
                    });
                    Console.WriteLine("Write here" + mail);
                }


            }
        }

        private void OffAll()
        {
            ScanPanel.Visible = false;
            MonitorPanel.Visible = false;
            PanelReportMonitor.Visible = false;
            ReportPanel.Visible = false;
            QuarantinePanel.Visible = false;
            ShedulePanel.Visible = false;
            MonitorPanelButton.BackColor = Color.White;
            ScanPanelButton.BackColor = Color.White;
            MonitorReportPanelButton.BackColor = Color.White;
            ReportPanelButton.BackColor = Color.White;
            PanelButtonQuarantine.BackColor = Color.White;
            PlanPanelButton.BackColor = Color.White;
            
            
        }

        private void DeleteFileMonitoring_Click(object sender, EventArgs e)
        {
            
            foreach (var element in lformElementsMonitorings)
            {
                if (element.check)
                {
                    AntivirusLibrary.DataBaseMethods.DataBaseDeleteNoteWhereAnd($"WHERE PATH=('{element.textBoxMonitor.Text}')", "Monitoring");
                    element.DeletePanel(flowLayoutPanelMonitor);
                }
            }

        }

        private void ReportPanelButton_Click(object sender, EventArgs e)
        {
            List<string> temp = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("MonitoringReport");
            if (temp.Count > 100)
            {
                for (int i = 0; i < temp.Count - 100; i++)
                {
                    AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(temp[i].Split('?')[1], "MonitoringReport");
                }
            }

            List<string> tempList = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("MonitoringReport");
            foreach (var path in tempList)
            {
                var tempDate = new AntivirusLibrary.DataReportMonitoring(path);
                FormElementsReportMonitoring tempForm = new FormElementsReportMonitoring(flowLayoutPanelReportMonitoring);
                tempForm.ReportMonitoringtextBox.Text = tempDate.path;
                tempForm.ReportMonitoringDate.Text = tempDate.date;
                tempForm.ReportMonitoringTime.Text = tempDate.time;
                tempForm.ReportMonitoringChange.Text = tempDate.virusType+" "+tempDate.operation;
                lformElementsReportMonitorings.Add(tempForm);
            }

            OffAll();
            PanelReportMonitor.Visible = true;
            PanelReportMonitor.Location = new System.Drawing.Point(179, 13);
            MonitorReportPanelButton.BackColor = Color.LightBlue;
        }

        private void ReportPanelButton_Click_1(object sender, EventArgs e)
        {
            List<string> tempL = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("ScanReport");
            if (tempL.Count > 100)
            {
                for (int i = 0; i < tempL.Count - 100; i++)
                {
                    AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(tempL[i].Split('?')[1], "ScanReport");
                }
            }

            foreach (var temp in lformElementsReports)
            {
                temp.DeletePanel(flowLayoutPanelReport);
            }
            List<string> tempList = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("ScanReport");
            foreach (var scanFile in tempList)
            {
                var strScanTemp = new AntivirusLibrary.DataReport(scanFile);
                var panelTemp = new FormElementsReport(flowLayoutPanelReport);
                panelTemp.textBoxReport.Text = strScanTemp.path;
                panelTemp.ResultReportLabel.Text = strScanTemp.virusType;
                panelTemp.DataReportLabel.Text = strScanTemp.date;
                panelTemp.TimeReportLabel.Text = strScanTemp.time;
                lformElementsReports.Add(panelTemp);
            }

            OffAll();
            ReportPanel.Visible = true;
            ReportPanel.Location = new System.Drawing.Point(179, 13);
            ReportPanelButton.BackColor = Color.LightBlue;
        }

        private void Quarantine_Click(object sender, EventArgs e)
        {
            foreach(var temp in lformElementsQuarantunes)
            {
                temp.DeletePanel(flowLayoutPanelQuarantine);
            }
            List<string> tempList = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("Quarantine");
            foreach(string quarantineFile in tempList)
            {
                var strQuarantineTemp = new AntivirusLibrary.DataReport(quarantineFile);
                var panelTemp = new FormElementsQuarantune(flowLayoutPanelQuarantine);
                panelTemp.textBoxQuarantine.Text = strQuarantineTemp.path;
                panelTemp.VirusTypeQuarantine.Text = strQuarantineTemp.virusType;
                panelTemp.DataQuarantine.Text = strQuarantineTemp.date;
                panelTemp.TimeQuarantine.Text = strQuarantineTemp.time;
                lformElementsQuarantunes.Add(panelTemp);
            }

            OffAll();
            QuarantinePanel.Visible = true;
            QuarantinePanel.Location = new System.Drawing.Point(179, 13);
            PanelButtonQuarantine.BackColor = Color.LightBlue;
        }

        private void DirButtonScan_Click(object sender, EventArgs e)
        {
            ScanResultLabel.Text = "";
           operationDone = false;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    Console.WriteLine("BeginServer");
                    //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
                    //AntivirusLibrary.MailSlotClientMethods.SendQuest($"0|1?{fbd.SelectedPath}|0");
                    AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"0|1?{fbd.SelectedPath}|0");
                    Console.WriteLine("Sended");
                }
            }

           
        }

        private void DeleteAllScan_Click(object sender, EventArgs e)
        {
            foreach (FormElementsScan panel in lformElementsScans)
            {
                panel.Select();
            }
        }

        private void SendToQuarantine_Click(object sender, EventArgs e)
        {
            
            string temp = "";
            int count = 0;
            foreach (var panel in lformElementsScans)
            {
                if (panel.check)
                {
                    count++;
                    temp += panel.PathScanTextBox.Text;
                    temp += "?";
                    panel.DeletePanel(flowLayoutPanelScan);
                }
            }
            var k = 0;
            temp = temp.Substring(0, temp.Length - 1);
            
            if (count != 0)
            {
                //AntivirusLibrary.MailSlotClientMethods.SendQuest($"2|{count}?{temp}|0");
                AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"2|{count}?{temp}|0");
            }
        }

        private void FileButtonScan_Click(object sender, EventArgs e)
        {
            ScanResultLabel.Text = "";
            operationDone = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                if (openFileDialog.ShowDialog() == DialogResult.OK )
                {
                    string filePath = openFileDialog.FileName;
                    if (filePath.Equals(null) || filePath.Equals("")) return;
                    //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
                    //AntivirusLibrary.MailSlotClientMethods.SendQuest($"0|1?{filePath}|0");
                    AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"0|1?{filePath}|0");
                }
            }
        }

        private void DirButtonMonitoring_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    
                    
                    string date = DateTime.Now.ToString("MM/dd/yyyy");
                    string time = DateTime.Now.ToString("H:mm");
                    DataBaseMethods.AddNote("Monitoring", "'PATH','DATE','TIME'", $"'{fbd.SelectedPath}','{date}','{time}'");

                    
                    var panelTemp = new FormElementsMonitoring(flowLayoutPanelMonitor);
                    panelTemp.textBoxMonitor.Text = fbd.SelectedPath;
                    panelTemp.DataMonitorLabel.Text = date;
                    panelTemp.TimeMonitorLabel.Text = time;
                    panelTemp.DeafultMonitoringAction();

                    lformElementsMonitorings.Add(panelTemp);
                }
            }
            
           

            

        }

        private void PlanPanelButton_Click(object sender, EventArgs e)
        {
            foreach (var temp in lformElementsShedules)
            {
                temp.DeletePanel(flowLayoutPaneltoSScan);
            }
            List<string> tempList = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("Schedule");
            foreach (var file in tempList)
            {
                var panelTemp = new FormElementsToScheduleScan(flowLayoutPaneltoSScan);

                panelTemp.TextBoxToScheduleScan.Text = file.Split('?')[1];
                panelTemp.TimeToScheduleScan.Text = file.Split('?')[2];
                panelTemp.DateToToScheduleScan.Text = file.Split('?')[3];
                lformElementsShedules.Add(panelTemp);
            }

            foreach (var temp in lformElementsShedulesAfterScan)
            {
                temp.DeletePanel(flowLayoutScanSchedule);
            }
            List<string> tempList2 = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("ScheduleReport");
            foreach (var file in tempList2)
            {
                var panelTemp = new FormElementsShedule(flowLayoutScanSchedule);

                panelTemp.SheduleTextBox.Text = file.Split('?')[1];
                panelTemp.SheduleLabelDate.Text = file.Split('?')[3];
                panelTemp.SheduleLabelTime.Text = file.Split('?')[4];
                panelTemp.SheduleLabelVirusType.Text = file.Split('?')[2];
                lformElementsShedulesAfterScan.Add(panelTemp);
            }

            OffAll();
            ShedulePanel.Visible = true;
            ShedulePanel.Location = new System.Drawing.Point(179, 13);
            PlanPanelButton.BackColor = Color.LightBlue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int count = 0;

            string temp = "";
            foreach (var panel in lformElementsShedulesAfterScan)
            {
                if (panel.check)
                {
                    temp += panel.SheduleTextBox.Text;
                    temp += "?";
                    count++;
                    panel.DeletePanel(flowLayoutScanSchedule);
                }


            }

            temp = temp.Substring(0, temp.Length - 1);

            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"1|{count}?{temp}|0");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            operationDone = false;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string time = string.Format("{0:00}", Hourse.Value) +":"+ string.Format("{0:00}",Minutes.Value);
                    string date = DateTime.Now.ToString("MM/dd/yyyy");
                    DataBaseMethods.AddNote("Schedule", "'PATH','TIME','DATE'", $"'{fbd.SelectedPath}','{time}','{date}'");

                    FormElementsToScheduleScan tempPanel = new FormElementsToScheduleScan(flowLayoutPaneltoSScan);
                    tempPanel.DateToToScheduleScan.Text = date;
                    tempPanel.TimeToScheduleScan.Text = time;
                    tempPanel.TextBoxToScheduleScan.Text = fbd.SelectedPath;

                    lformElementsShedules.Add(tempPanel);
                }
            }

            

        }

        private void button11_Click(object sender, EventArgs e)
        {
            operationDone = true;
            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"8|0|0");

        }

        private void StartMonitoring_Click(object sender, EventArgs e)
        {
            //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
            //AntivirusLibrary.MailSlotClientMethods.SendQuest($"4|0|0");
            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"4|0|0");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
            //AntivirusLibrary.MailSlotClientMethods.SendQuest($"5|0|0");
            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"5|0|0");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (filePath.Equals(null) || filePath.Equals("")) return;

                    string time = string.Format("{0:00}", Hourse.Value) + ":" + string.Format("{0:00}", Minutes.Value);
                    string date = DateTime.Now.ToString("MM/dd/yyyy");
                    DataBaseMethods.AddNote("Schedule", "'PATH','TIME','DATE'", $"'{filePath}','{time}','{date}'");

                    FormElementsToScheduleScan tempPanel = new FormElementsToScheduleScan(flowLayoutPaneltoSScan);
                    tempPanel.DateToToScheduleScan.Text = date;
                    tempPanel.TimeToScheduleScan.Text = time;
                    tempPanel.TextBoxToScheduleScan.Text = filePath;

                    lformElementsShedules.Add(tempPanel);
                }
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach(var element in lformElementsShedules)
            {
                element.Select();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (var element in lformElementsShedules)
            {
                if (element.check)
                {
                    AntivirusLibrary.DataBaseMethods.DataBaseDeleteNoteWhereAnd($"WHERE PATH=('{element.TextBoxToScheduleScan.Text}') AND TIME=('{element.TimeToScheduleScan.Text}')", "Schedule");
                    element.DeletePanel(flowLayoutPaneltoSScan);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var element in lformElementsShedulesAfterScan)
            {
                element.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;

            string temp = "";
            foreach (var panel in lformElementsShedulesAfterScan)
            {
                if (panel.check)
                {
                    temp += panel.SheduleTextBox.Text;
                    temp += "?";
                    count++;
                    panel.DeletePanel(flowLayoutScanSchedule);
                    AntivirusLibrary.DataBaseMethods.DataBaseDeleteNoteWhereAnd($"WHERE PATH=('{panel.SheduleTextBox.Text}')", "ScheduleReport");
                }


            }

            temp = temp.Substring(0, temp.Length - 1);

            //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
            //AntivirusLibrary.MailSlotClientMethods.SendQuest($"2|{count}?{temp}|0");
            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"2|{count}?{temp}|0");

            foreach (var temps in lformElementsShedulesAfterScan)
            {
                temps.DeletePanel(flowLayoutScanSchedule);
            }
            List<string> tempList2 = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("ScheduleReport");
            foreach (var file in tempList2)
            {
                var panelTemp = new FormElementsShedule(flowLayoutScanSchedule);

                panelTemp.SheduleTextBox.Text = file.Split('?')[1];
                panelTemp.SheduleLabelDate.Text = file.Split('?')[3];
                panelTemp.SheduleLabelTime.Text = file.Split('?')[4];
                panelTemp.SheduleLabelVirusType.Text = file.Split('?')[2];
                lformElementsShedulesAfterScan.Add(panelTemp);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;

            string temp = "";
            foreach (var panel in lformElementsShedulesAfterScan)
            {
                if (panel.check)
                {
                    temp += panel.SheduleTextBox.Text;
                    temp += "?";
                    count++;
                    panel.DeletePanel(flowLayoutScanSchedule);
                    AntivirusLibrary.DataBaseMethods.DataBaseDeleteNoteWhereAnd($"WHERE PATH=('{panel.SheduleTextBox.Text}')", "ScheduleReport");
                }


            }

            temp = temp.Substring(0, temp.Length - 1);

            //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
            //AntivirusLibrary.MailSlotClientMethods.SendQuest($"3|{count}?{temp}|0");
            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"3|{count}?{temp}|0");

            foreach (var temps in lformElementsShedulesAfterScan)
            {
                temps.DeletePanel(flowLayoutScanSchedule);
            }
            List<string> tempList2 = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("ScheduleReport");
            foreach (var file in tempList2)
            {
                var panelTemp = new FormElementsShedule(flowLayoutScanSchedule);

                panelTemp.SheduleTextBox.Text = file.Split('?')[1];
                panelTemp.SheduleLabelDate.Text = file.Split('?')[3];
                panelTemp.SheduleLabelTime.Text = file.Split('?')[4];
                panelTemp.SheduleLabelVirusType.Text = file.Split('?')[2];
                lformElementsShedulesAfterScan.Add(panelTemp);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            foreach (var temp in lformElementsScans)
            {
                temp.DeletePanel(flowLayoutPanelScan);
            }
            List<string> lscanReport = AntivirusLibrary.DataBaseMethods.DataBaseGetAllNotes("Scan");
            Console.WriteLine("lscan");
            foreach (var scanFile in lscanReport)
            {

                var strScanTemp = new AntivirusLibrary.DataReport(scanFile);
                var panelTemp = new FormElementsScan(flowLayoutPanelScan);

                panelTemp.PathScanTextBox.Text = strScanTemp.path;
                panelTemp.ResultScanLabel.Text = strScanTemp.virusType;
                panelTemp.DataScanLabel.Text = strScanTemp.date;
                panelTemp.TimeScanLabel.Text = strScanTemp.time;
                lformElementsScans.Add(panelTemp);

            }
        }

        private void DeleteAllMonitoring_Click(object sender, EventArgs e)
        {
            foreach (var element in lformElementsMonitorings)
            {
              AntivirusLibrary.DataBaseMethods.DataBaseDeleteNoteWhereAnd($"WHERE PATH=('{element.textBoxMonitor.Text}')", "Monitoring");
              element.DeletePanel(flowLayoutPanelMonitor);
              
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 0;

            string temp = "";
            foreach (var panel in lformElementsQuarantunes)
            {
                if (panel.check)
                {
                    temp += panel.textBoxQuarantine.Text;
                    temp += "?";
                    count++;
                    panel.DeletePanel(flowLayoutPanelQuarantine);
                }


            }

            temp = temp.Substring(0, temp.Length - 1);

            //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
            //AntivirusLibrary.MailSlotClientMethods.SendQuest($"1|{count}?{temp}|0");
            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"1|{count}?{temp}|0");
        }

        private void QuarantineSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var panel in lformElementsQuarantunes)
            {

                panel.Select();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;

            string temp = "";
            foreach (var panel in lformElementsQuarantunes)
            {
                if (panel.check)
                {
                    temp += panel.textBoxQuarantine.Text;
                    temp += "?";
                    count++;
                    panel.DeletePanel(flowLayoutPanelQuarantine);
                }


            }

            temp = temp.Substring(0, temp.Length - 1);

            //AntivirusLibrary.MailSlotClientMethods.CreateServerConnection();
            //AntivirusLibrary.MailSlotClientMethods.SendQuest($"9|{count}?{temp}|0");
            AntivirusLibrary.SocketClientMethods.SocketClientWriteMessage($"9|{count}?{temp}|0");
        }
    }
}
