using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitoR.Common.Utilities;


namespace MonitoR.Configurator.SensorForms.SelectorForm
{
    public partial class ServiceSelectorForm : Form
    {
        List<string> serviceList = new List<string>();
        public ServiceSelectorForm()
        {
            InitializeComponent();
            RefreshItems();
            LoadServicesInUI();
        }

        void LoadServicesInUI(string filter = "")
        {
            var itemsToAdd =  new List<string>(serviceList);
            checkedListBox1.Items.Clear();
            if (filter.IsTrimmedStringNullOrEmpty() == false)
            {
                itemsToAdd = itemsToAdd.Where(x => x.ToUpper().Contains(filter.ToUpper())).ToList();
            }
            foreach(var item in itemsToAdd)
                checkedListBox1.Items.Add(item);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Refresh();
            txtFilter.Text = "";
            LoadServicesInUI();
        }

        private void RefreshItems()
        {
            serviceList = ServiceController.GetServices().Select(x => x.DisplayName).ToList();
        }

        public List<string> GetSelectedItems()
        {
            var result = new List<string>();
            for(int i = 0; i < checkedListBox1.Items.Count;++i)
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
                MessageBox.Show("No service is selected");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            LoadServicesInUI(txtFilter.Text);
        }

        private void TxtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            LoadServicesInUI(txtFilter.Text);
        }
    }
}
