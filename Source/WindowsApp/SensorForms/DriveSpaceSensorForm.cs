using MonitoR.Common.Constants;
using MonitoR.Common.Sensors;
using MonitoR.Common.Utilities;
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

namespace MonitoR.Configurator.SensorForms
{
    public partial class DriveSpaceSensorForm : Form
    {
        private CrudType crudType;
        public DriveSpaceSensor Sensor { get; private set; }
        public List<ISensor> ExistingSensors { get; private set; }

        public DriveSpaceSensorForm(CrudType crudType, DriveSpaceSensor sensor, List<ISensor> existingSensors)
        {
            this.Sensor = sensor;
            this.ExistingSensors = existingSensors;        
            this.crudType = crudType;
            InitializeComponent();
            InitCustomCode();

            if (crudType == CrudType.Add)
            {
                cmbTimeType.SelectedIndex = 0;
                Sensor.Id = Guid.NewGuid();
            }

            UpdateUIFromData();
        }

        private void InitCustomCode()
        {
            cklbDrives.Items.Clear();
            foreach(var dr in DriveInfo.GetDrives())
            {
                cklbDrives.Items.Add(dr.Name);
            }
            txtName.Focus();
            ntxtNotifyAfterFailureTimes.Value = 1;
        }

        public void UpdateDataFromUI()
        {
            Sensor.Name = txtName.Text.Trim();
            Sensor.NotifyIfHappensAfterTimes = (int)ntxtNotifyAfterFailureTimes.Value;
            Sensor.CheckInterval = (int)ntxtCheckEveryTime.Value;
            Sensor.IntervalType = (CheckIntervalType)cmbTimeType.SelectedIndex;
            Sensor.PercentToCheck = (int)ntxtDiskUsageExceedValue.Value;
            Sensor.Enabled = cbEnabled.Checked;
            Sensor.NotifyByEmail = cbNotifyByEmail.Checked;

            this.Sensor.Drives.Clear();

            for (int i = 0; i < cklbDrives.Items.Count; ++i)
            {
                if (cklbDrives.GetItemChecked(i) == false)
                    continue;
                this.Sensor.Drives.Add(cklbDrives.Items[i].ToString());
            }
        }

        public void UpdateUIFromData()
        {
            txtName.Text = Sensor.Name.Trim();
            ntxtNotifyAfterFailureTimes.Value = Sensor.NotifyIfHappensAfterTimes;
            ntxtCheckEveryTime.Value = Sensor.CheckInterval;
            cmbTimeType.SelectedIndex = (int)Sensor.IntervalType;
            ntxtDiskUsageExceedValue.Value = Sensor.PercentToCheck;
            cbEnabled.Checked = Sensor.Enabled;
            cbNotifyByEmail.Checked = Sensor.NotifyByEmail;

            foreach (var dr in this.Sensor.Drives)
            {
                for (int i = 0; i < cklbDrives.Items.Count; ++i)
                {
                    if (cklbDrives.Items[i].ToString() == dr)
                        cklbDrives.SetItemChecked(i, true);
                }
            }
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            UpdateDataFromUI();
            var result = this.Sensor.IsValid(ExistingSensors);
            if (result == null || result.Result == false)
            {
                MessageBox.Show(result != null ? result.ErrorMessages.ToString(" ") : "Invalid Option");
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnShown(EventArgs e)
        {
            txtName.Focus();
            base.OnShown(e);
        }
    }
}
