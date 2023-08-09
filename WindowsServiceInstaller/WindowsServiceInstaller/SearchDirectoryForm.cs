using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsServiceInstaller.MainPageForm;

namespace WindowsServiceInstaller
{
    public partial class SearchDirectoryForm : Form
    {
        List<string> stringContainer = new List<string>();
        MainPageForm mainPage = null;
        public SearchDirectoryForm(MainPageForm caller)
        {
            mainPage = caller;
            InitializeComponent();
            this.comboBox2.SelectedItem = comboBox2.Items[0];
        }

        private bool IsByPathMode()
        {
            return comboBox2.SelectedIndex == 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                DirectoryInfo di = new DirectoryInfo(dialog.FileName);

                stringContainer = Directory.GetFiles(di.FullName, "*.exe", SearchOption.AllDirectories).ToList();

                string extendString = "";
                if (stringContainer.Count() > 1)
                    extendString = " and " + Convert.ToString(stringContainer.Count() - 1) + " items";

                textBox1.Text = stringContainer[0] + extendString;

                linkLabel1.Text = Convert.ToString(stringContainer.Count()) + " items selected.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ServiceListItem> container = new List<ServiceListItem>();

            var objSearcher = new ManagementObjectSearcher("select * from Win32_Service");
            foreach(var item in objSearcher.Get())
            {
                if (IsByPathMode())
                {
                    if (item["pathname"] is not null && this.stringContainer.Contains(item["pathname"].ToString()))
                        container.Add(new ServiceListItem(item));
                }
                else
                {
                    // Folder name and file name will be matched.
                    foreach(var str in this.stringContainer)
                    {
                        if (str.Contains(item["name"].ToString()))
                        {
                            container.Add(new ServiceListItem(item));
                        }
                    }
                }
            }
            this.mainPage.ShowMatchedData(container);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var buff = "";
            foreach (var str in this.stringContainer)
                buff += str + "\n";

            MessageBox.Show("Selected files: \n" +
                buff);
        }
    }
}
