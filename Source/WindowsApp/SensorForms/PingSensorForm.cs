using MonitoR.Common.Common;
using MonitoR.Common.Constants;
using MonitoR.Common.Sensors;
using MonitoR.Common.Utilities;
using MonitoR.Configurator.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoR.Configurator.SensorForms
{
    public partial class PingSensorForm : Form
    {
        private readonly CrudType crudType;
        public PingSensor Sensor { get; }
        public List<ISensor> ExistingSensors { get; }

        public PingSensorForm(CrudType crudType, PingSensor sensor, List<ISensor> existingSensors)
        {
            Sensor = sensor;
            ExistingSensors = existingSensors;
            this.crudType = crudType;
            InitializeComponent();
            InitCustomCode();

            if (crudType == CrudType.Add)
            {
                cmbTimeType.SelectedIndex = (int)CheckIntervalType.Minutes;
                Sensor.Id = Guid.NewGuid();
            }

            UpdateUIFromData();
        }

        private void InitCustomCode()
        {
            cklbDrives.Items.Clear();
            txtName.Focus();
            ntxtNotifyAfterFailureTimes.Value = 1;
        }

        public void UpdateDataFromUI()
        {
            Sensor.Name = txtName.Text.Trim();
            Sensor.NotifyIfHappensAfterTimes = (int)ntxtNotifyAfterFailureTimes.Value;
            Sensor.CheckInterval = (int)ntxtCheckEveryTime.Value;
            Sensor.IntervalType = (CheckIntervalType)cmbTimeType.SelectedIndex;
            Sensor.Servers.Clear();
            foreach (var item in cklbDrives.Items)
            {
                Sensor.Servers.Add(item.ToString());
            }
            Sensor.Enabled = cbEnabled.Checked;
            Sensor.NotifyByEmail = cbNotifyByEmail.Checked;
        }

        public void UpdateUIFromData()
        {
            txtName.Text = Sensor.Name.Trim();
            ntxtNotifyAfterFailureTimes.Value = Sensor.NotifyIfHappensAfterTimes;
            ntxtCheckEveryTime.Value = Sensor.CheckInterval;
            cmbTimeType.SelectedIndex = (int)Sensor.IntervalType;
            cklbDrives.Items.Clear();
            foreach (var item in Sensor.Servers)
            {
                cklbDrives.Items.Add(item);
            }
            cbEnabled.Checked = Sensor.Enabled;
            cbNotifyByEmail.Checked = Sensor.NotifyByEmail;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            UpdateDataFromUI();
            var result = Sensor.IsValid(ExistingSensors);
            if (ReturnValue.IsNullOrFalse(result))
            {
                MessageBox.Show(result != null ? result.ErrorMessages.ToString(" ") : "Invalid Option");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtAddItem_Click(object sender, EventArgs e)
        {
            var url = "";

            if (FormUtils.InputBox("Add new server", "Enter a server to ping ", ref url) != DialogResult.OK)
                return;
            cklbDrives.Items.Add(url);
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (cklbDrives.SelectedIndex == -1)
                return;

            cklbDrives.Items.RemoveAt(cklbDrives.SelectedIndex);
        }

        protected override void OnShown(EventArgs e)
        {
            txtName.Focus();
            base.OnShown(e);
        }
    }
}
