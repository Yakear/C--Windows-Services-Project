using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsServiceInstaller
{
    public partial class CustomServiceForm : Form
    {
        MainPageForm mainPage;
        // Contains 'select file/s' button's file names.
        List<string> selectedFileNames1 = new List<string>();
        // Contains 'select directory' button's file names.
        List<string> selectedFileNames2 = new List<string>();
        public CustomServiceForm(MainPageForm mp)
        {
            InitializeComponent();

            mainPage = mp;
            // Default values
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
            comboBox3.SelectedItem = comboBox3.Items[1];
            comboBox4.SelectedItem = comboBox4.Items[1];
            comboBox5.SelectedItem = comboBox5.Items[1];
            comboBox6.SelectedItem = comboBox6.Items[0];
            textBox5.Enabled = false;
            textBox7.Text = "1";
            textBox5.Text = "60";
            textBox8.Text = "The service is crashed.";
            label5.Enabled = false;
            label10.Enabled = false;

            ManageRestartTimeBlank();
        }

        private void CustomizeForMultipleSelections()
        {
            if (IsMultiFileMode())
            {
                comboBox1.Show();
                comboBox6.Show();
                textBox3.Hide();
                textBox4.Hide();
                //textBox1.Enabled = true;
            }
            else
            {
                comboBox1.Hide();
                comboBox6.Hide();
                textBox3.Show();
                textBox4.Show();
                //textBox1.Enabled = false;
            }
        }

        private bool IsMultiFileMode()
        {
            bool selectDirectory = checkBox1.Checked;
            if (selectDirectory)
                return selectedFileNames2.Count() > 1;
            else
                return selectedFileNames1.Count() > 1;
        }

        // 'Select file' button. 
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Enabled == true)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = @"C:\";//--"C:\\";
                openFileDialog1.Filter = "Exe File (*.exe)|*.exe";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.Multiselect = true;
                // A file selected.
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {
                    string[] container = openFileDialog1.FileName.Split("\\");
                    //string exename = container[container.Length - 1];
                    //string exenameWithoutDot = exename.Split(".")[0];
                    selectedFileNames1 = openFileDialog1.FileNames.ToList();
                    
                    string extendString = "";
                    if (selectedFileNames1.Count() > 1)
                        extendString = " and " + Convert.ToString(selectedFileNames1.Count() - 1) + " items";

                    textBox2.Text = selectedFileNames1[0] + extendString;

                    linkLabel2.Text = Convert.ToString(selectedFileNames1.Count()) + " items selected.";

                    CustomizeForMultipleSelections();
                }
            }
        }
        // 'Select directory' button.
        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Enabled == true)
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                // A directory selected.
                if (CommonFileDialogResult.Ok == dialog.ShowDialog())
                {
                    DirectoryInfo di = new DirectoryInfo(dialog.FileName);

                    //selectedFileNames2.Clear();
                    selectedFileNames2 = Directory.GetFiles(di.FullName, "*.exe", SearchOption.AllDirectories).ToList();

                    string extendString = "";
                    if (selectedFileNames2.Count() > 1)
                        extendString = " and " + Convert.ToString(selectedFileNames2.Count() - 1) + " items";

                    textBox6.Text = selectedFileNames2[0] + extendString;

                    linkLabel1.Text = Convert.ToString(selectedFileNames2.Count()) + " items selected.";

                    CustomizeForMultipleSelections();
                }
            }
        }

        /* 'Install Service' button
        * ServiceHelper will help for install a service
        * but for recovery and description settings:
        * ChangeServiceConfig2 method is currently not used.
        * instead sc commands are used. 
        */
        private void button1_Click(object sender, EventArgs e)
        {
            bool isMultiSelect = IsMultiFileMode();
            string serviceName = textBox3.Text;
            string displayName = textBox4.Text;
            string description = richTextBox1.Text;
            string binPath = "";
            ServiceBootFlag[] bootSettings = new ServiceBootFlag[3] { ServiceBootFlag.AutoStart, ServiceBootFlag.DemandStart, ServiceBootFlag.Disabled };
            ServiceBootFlag startType = bootSettings[comboBox2.SelectedIndex];
            /* 'Select file' button binpath box => textBox2. 
            'Select directory' button binpath box => textBox6. 
             */
            if (checkBox1.Checked == false)
                binPath = textBox2.Text;
            else
                binPath = textBox6.Text;

            // Name or Display blanks is empty.
            if (!isMultiSelect && (serviceName == "" || displayName == ""))
            {
                MessageBox.Show("Service Name and Display Name blanks must be filled.");
                return;
            }
            else if (binPath == "")
            {
                MessageBox.Show("Service binpath blank must be filled.");
                return;
            }

            // Multi file from 'select file' button
            if (checkBox1.Checked == false && selectedFileNames1.Count() > 1)
            {
                // Build service name and displayname.
                List<string> serviceNames = new List<string>();
                List<string> displayNames = new List<string>();

                int successCount = 0;
                foreach(var binPathIndv in selectedFileNames1)
                {
                    var temp = binPathIndv.Split("\\");
                    serviceName = temp[temp.Length - 1].Split(".")[0];
                    displayName = serviceName;
                    try
                    {
                        ServiceHelper.InstallService(serviceName, displayName, binPathIndv, startType);
                        SetRecoverySettings(serviceName);
                        SetDescription(serviceName, description);
                    }
                    catch (ApplicationException ex)
                    {
                        MessageBox.Show(ex.Message);
                        continue;
                    }
                    successCount++;
                    this.mainPage.RefreshTableData(true, serviceName);
                }
                MessageBox.Show(String.Format("Selected services are installed. Success: {0}/{1} ",successCount,selectedFileNames1.Count));
            }
            // Multi file from 'select directory' button
            else if (checkBox1.Checked == true && selectedFileNames2.Count() > 1)
            {
                // Build service name and displayname.
                List<string> serviceNames = new List<string>();
                List<string> displayNames = new List<string>();

                int successCount = 0;
                foreach (var binPathIndv in selectedFileNames2)
                {
                    var temp = binPathIndv.Split("\\");
                    serviceName = temp[temp.Length - 1].Split(".")[0];
                    displayName = serviceName;
                    try
                    {
                        ServiceHelper.InstallService(serviceName, displayName, binPathIndv, startType);
                        SetRecoverySettings(serviceName);
                        SetDescription(serviceName, description);
                    }
                    catch (ApplicationException ex)
                    {
                        MessageBox.Show(ex.Message);
                        continue;
                    }
                    successCount++;
                    this.mainPage.RefreshTableData(true, serviceName);
                }
                MessageBox.Show(String.Format("Selected services are installed. Success: {0}/{1} ", successCount, selectedFileNames2.Count));
            }
            // Just one file from 'select file' button 
            else if (checkBox1.Checked == false && selectedFileNames1.Count() == 1)
            {
                try
                {
                    ServiceHelper.InstallService(serviceName, displayName, binPath, startType);
                    SetRecoverySettings(serviceName);
                    SetDescription(serviceName, description);
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                this.mainPage.RefreshTableData(true, serviceName);
                //MessageBox.Show("Service is successfully installed.");
            }
            // Just one file from 'select directory' button 
            else if (checkBox1.Checked == true && selectedFileNames2.Count() == 1)
            {
                try
                {
                    ServiceHelper.InstallService(serviceName, displayName, binPath, startType);
                    SetRecoverySettings(serviceName);
                    SetDescription(serviceName, description);
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                this.mainPage.RefreshTableData(true, serviceName);
            }

        }

        private void SetRecoverySettings(string serviceName)
        {
            int delay = Convert.ToInt32(textBox5.Text) * 1000;
            string[] recoveryStr = new string[] { "", "restart", "run", "reboot" };
            string command = String.Format("sc failure {0} reset= {1} reboot= \"{2}\" actions= {3}/{4}/{5}/{6}/{7}/{8}"
                ,serviceName, Convert.ToInt32(textBox7.Text) * 24 * 3600, textBox8.Text,
                recoveryStr[comboBox3.SelectedIndex], delay,
                recoveryStr[comboBox4.SelectedIndex], delay,
                recoveryStr[comboBox5.SelectedIndex], delay
                );

            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + command);
            ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);
            //Process.WaitForExit();
        }

        private void SetDescription(string serviceName, string description)
        {
            string command = String.Format("sc description {0} \"{1}\""
                , serviceName, description
                );

            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + command);
            ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);
            //Process.WaitForExit();
        }

        /*private void buildFailureActions(string serviceName)
        {
            int delayMS = Convert.ToInt32(textBox5.Text) * 1000;
            int NUM_ACTIONS = 3;
            int[] arrActions = new int[NUM_ACTIONS * 2];
            int index = 0;
            arrActions[index++] = comboBox3.SelectedIndex;
            arrActions[index++] = delayMS;
            arrActions[index++] = comboBox4.SelectedIndex;
            arrActions[index++] = delayMS;
            arrActions[index++] = comboBox5.SelectedIndex;
            arrActions[index++] = delayMS;
            IntPtr tmpBuff = Marshal.AllocHGlobal(NUM_ACTIONS * 8);
            try
            {
                Marshal.Copy(arrActions, 0, tmpBuff, NUM_ACTIONS * 2);
                SERVICE_FAILURE_ACTIONS sfa = new SERVICE_FAILURE_ACTIONS();
                sfa.cActions = 3;
                sfa.dwResetPeriod = Convert.ToInt32(textBox7.Text);
                sfa.lpCommand = textBox9.Text;
                sfa.lpRebootMsg = textBox8.Text;
                sfa.lpsaActions = new IntPtr(tmpBuff.ToInt64());
                ServiceHelper.SetRecoveryOptions(serviceName, sfa);
            }
            finally
            {
                Marshal.FreeHGlobal(tmpBuff);
                tmpBuff = IntPtr.Zero;
            };
        }*/

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ManagePathObjects(!checkBox1.Checked);
        }

        public void ManagePathObjects(bool selectFile)
        {
            if (selectFile)
            {
                label9.Enabled = true;
                textBox2.Enabled = true;
                button3.Enabled = true;
                label17.Enabled = true;
                button3.Enabled = true;
                linkLabel2.Enabled = true;

                label12.Enabled = false;
                textBox6.Enabled = false;
                button4.Enabled = false;
                label11.Enabled = false;
                linkLabel1.Enabled = false;

                checkBox1.Checked = false;
            }
            else
            {
                label9.Enabled = false;
                textBox2.Enabled = false;
                button3.Enabled = false;
                label17.Enabled = false;
                button3.Enabled = false;
                linkLabel2.Enabled = false;

                label12.Enabled = true;
                textBox6.Enabled = true;
                button4.Enabled = true;
                label11.Enabled = true;
                linkLabel1.Enabled = true;

                checkBox1.Checked = true;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageRestartTimeBlank();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageRestartTimeBlank();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageRestartTimeBlank();
        }

        private void ManageRestartTimeBlank()
        {
            if (comboBox3.SelectedIndex == 1 ||
                comboBox4.SelectedIndex == 1 ||
                comboBox5.SelectedIndex == 1)
            {
                textBox5.Enabled = true;
                label5.Enabled = true;
                label10.Enabled = true;
            }
            else
            {
                textBox5.Enabled = false;
                label5.Enabled = false;
                label10.Enabled = false;
            }
        }

        // Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var buff = "";
            foreach(var str in this.selectedFileNames1)
                buff += str + "\n";

            MessageBox.Show("Selected files: \ns" +
                buff);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var buff = "";
            foreach (var str in this.selectedFileNames2)
                buff += str + "\n";

            MessageBox.Show("Selected files: \n" +
                buff);
        }
    }
}
