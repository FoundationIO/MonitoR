using MonitoR.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoR.Configurator.SensorForms.SelectorForm
{
    public partial class ProcessSelectorForm : Form
    {
        List<string> serviceList = new List<string>();
        public ProcessSelectorForm()
        {
            InitializeComponent();
            RefreshItems();
            LoadProcessesInUI();
        }
        void LoadProcessesInUI(string filter = "")
        {
            var itemsToAdd = new List<string>(serviceList);
            checkedListBox1.Items.Clear();
            if (filter.IsTrimmedStringNullOrEmpty() == false)
            {
                itemsToAdd = itemsToAdd.Where(x => x.ToUpper().Contains(filter.ToUpper())).ToList();
            }

            foreach (var item in itemsToAdd)
                checkedListBox1.Items.Add(item);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Refresh();
            LoadProcessesInUI();
        }

        private void RefreshItems()
        {
            serviceList = Process.GetProcesses().Select(x => x.ProcessName).ToList();
        }

        public List<string> GetSelectedItems()
        {
            var result = new List<string>();
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            {
                if (checkedListBox1.GetItemChecked(i) == false)
                    continue;
                result.Add(checkedListBox1.Items[i].ToString());
            }
            return result;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (GetSelectedItems().Count == 0)
            {
                MessageBox.Show("No Process is selected");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            LoadProcessesInUI(txtFilter.Text);
        }

        private void TxtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            LoadProcessesInUI(txtFilter.Text);
        }
    }
}
