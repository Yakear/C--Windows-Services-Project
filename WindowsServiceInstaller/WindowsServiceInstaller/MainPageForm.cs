using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;
using System.Windows.Forms;

namespace WindowsServiceInstaller
{
    public partial class MainPageForm : Form
    {
        BindingList<ServiceListItem> bindingList = null;
        //Data gridview shown start index
        int shownStart = 0;
        //Data gridview shown end index
        int shownEnd = 0;

        CustomServiceForm installServiceWindow = null;
        SearchDirectoryForm searchDirectoryWindow = null;

        public MainPageForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button6, "Create a windows service.");
            toolTip2.SetToolTip(button7, "Create a windows service from a directory.");
            toolTip3.SetToolTip(button8, "Uninstall the service.");
            toolTip4.SetToolTip(button4, "Refresh services list.");
            toolTip5.SetToolTip(button9, "Search windows services in a specific directory.");

            RefreshServiceTable();
            installServiceWindow = new CustomServiceForm(this);
            searchDirectoryWindow = new SearchDirectoryForm(this);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_SelectRow();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_SelectRow();
        }
        private void dataGridView1_SelectRow()
        {
            var selectedrow = dataGridView1.SelectedRows[0];

            //label4.Text = dataGridView1.SelectedCells[0].Value.ToString();
            groupBox1.Text = selectedrow.Cells[0].Value.ToString(); // Service Name
            if (selectedrow.Cells[1].Value is not null)
                label12.Text = selectedrow.Cells[1].Value.ToString(); // Display Name
            if (selectedrow.Cells[2].Value is not null)
                label13.Text = "Description:\n" + selectedrow.Cells[2].Value.ToString(); // Description
        }

        // Refresh button
        private void button4_Click(object sender, EventArgs e)
        {
            RefreshServiceTable();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                textBox5.Hide();
                dataGridView1.Location = new Point(173, 74 + 19);
                //dataGridView1.Size = new Size(1239, 549 + 31);
            }
            else
            {
                textBox5.Show();
                dataGridView1.Location = new Point(173, 124);
                //dataGridView1.Size = new Size(1239, 549 - 31);
            }
        }

        // Open install service window with select file settigns
        private void button6_Click(object sender, EventArgs e)
        {
            installServiceWindow = new CustomServiceForm(this);
            installServiceWindow.ManagePathObjects(true);
            installServiceWindow.ShowDialog();
        }

        private void dataGridView1_OnScroll(object sender, ScrollEventArgs e)
        {
            var datacount = dataGridView1.Rows.Count;

            // list: startIdx - endIdx / totalServiceCount
            label14.Text = Convert.ToString(dataGridView1.FirstDisplayedScrollingRowIndex) + " - " + Convert.ToString(Math.Min(dataGridView1.FirstDisplayedScrollingRowIndex + 26, datacount)) + " / " + Convert.ToString(datacount) + " is showing.";
        }

        // Open install service window with select directory settigns
        private void button7_Click(object sender, EventArgs e)
        {
            installServiceWindow = new CustomServiceForm(this);
            installServiceWindow.ManagePathObjects(false);
            installServiceWindow.ShowDialog();
        }

        // Run filter text from 'Filter Text Box' when 'Enter Key' is pressed.
        private void txtMesaj_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                RefreshServiceTable();
            }
        }

        // Refresh List
        private void RefreshServiceTable()
        {
            //dataGridView1.AutoGenerateColumns = false;

            button4.Enabled = false;
            button4.Update();

            string filterText = textBox5.Text;

            var objSearcher = new ManagementObjectSearcher("select * from Win32_Service");
            var list = new List<ServiceListItem>();
            foreach (var item in objSearcher.Get())
            {
                // Case insensitive filter settings
                if (filterText != "")
                {
                    bool condition1 = item["name"].ToString().Contains(filterText);
                    bool condition2 = item["displayname"].ToString().Contains(filterText);
                    bool condition3 = item["description"] is null ? false : item["description"].ToString().Contains(filterText);
                    if (condition1 || condition2 || condition3)
                    {
                        //no action
                    }
                    else continue;
                }
                list.Add(new ServiceListItem(item));
            }

            bindingList = new BindingList<ServiceListItem>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

            dataGridView1.Columns[2].Width = 500;

            // shown service count in one page => 26
            shownEnd = Math.Min(26, dataGridView1.RowCount);

            button4.Enabled = true;
            button4.Update();
        }



        // Service Uninstall button.
        private void button8_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];

            if (selectedRow is null) return;

            string serviceName = selectedRow.Cells[0].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Are you sure that want uninstall selected service that has name: " + serviceName + "?", "Uninstall Service", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    ServiceHelper.Uninstall(serviceName);
                }
                catch (ApplicationException exception)
                {
                    MessageBox.Show(exception.Message);
                    return;
                }
                RefreshTableData(false, serviceName);
                //MessageBox.Show("Service is successfully uninstalled.");
            }
            else if (dialogResult == DialogResult.No)
            {
                //pass
            }
        }
        public void RefreshTableData(bool add, string serviceName)
        {
            this.installServiceWindow.Close();
            if (!add)
            {
                ServiceListItem dataToBeRemoved = null;
                foreach (ServiceListItem l in bindingList)
                    if (l.Name == serviceName) { dataToBeRemoved = l; break; }

                if (dataToBeRemoved is not null)
                    bindingList.Remove(dataToBeRemoved);
            }
            else
            {
                foreach (ServiceListItem l in bindingList)
                    if (l.Name == serviceName) { return; }

                var objSearcher = new ManagementObjectSearcher(String.Format("select * from Win32_Service where Name='{0}'", serviceName));
                var list = new List<ServiceListItem>();
                foreach (var item in objSearcher.Get())
                {
                    bindingList.Add(new ServiceListItem(item));
                    return;
                }
            }

        }
        public void ExecuteDeleteWindowsServiceCommand(string serviceName)
        {
            string command = String.Format("sc delete {0}", serviceName);

            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + command);
            ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);
            //Process.WaitForExit();
        }

        // Open searchdirectory window
        private void button9_Click(object sender, EventArgs e)
        {
            searchDirectoryWindow = new SearchDirectoryForm(this);
            searchDirectoryWindow.ShowDialog();
        }

        // Response method from searchDirectoryWindow.button1_Click(..
        public void ShowMatchedData(List<ServiceListItem> container)
        {
            bindingList = new BindingList<ServiceListItem>(container);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            this.searchDirectoryWindow.Close();
        }

        // Start service link label
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string serviceName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    // !!! 'Start Service' method is not completely tested.
                    ServiceHelper.StartService(serviceName);
                }
                catch (ApplicationException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        // Stop service link label
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string serviceName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    // !!! 'Stop Service' method is not completely tested.
                    ServiceHelper.StopService(serviceName);
                }
                catch (ApplicationException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}