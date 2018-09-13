using MonitoR.Common.Constants;
using MonitoR.Common.Sensors;
using MonitoR.Common.Utilities;
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
    public partial class RamSensorForm : Form
    {
        private CrudType crudType;
        public RamSensor Sensor { get; private set; }
        public List<ISensor> ExistingSensors { get; private set; }
        public RamSensorForm(CrudType crudType, RamSensor sensor, List<ISensor> existingSensors)
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
            txtName.Focus();
            ntxtNotifyAfterFailureTimes.Value = 1;
        }


        public void UpdateDataFromUI()
        {
            Sensor.Name = txtName.Text.Trim();
            Sensor.NotifyIfHappensAfterTimes = (int)ntxtNotifyAfterFailureTimes.Value;
            Sensor.CheckInterval = (int)ntxtCheckEveryTime.Value;
            Sensor.IntervalType = (CheckIntervalType)cmbTimeType.SelectedIndex;
            Sensor.Enabled = cbEnabled.Checked;
            Sensor.NotifyByEmail = cbNotifyByEmail.Checked;
            Sensor.PercentToCheck = (int)ntxtRamUsageExceedValue.Value;
        }

        public void UpdateUIFromData()
        {
            txtName.Text = Sensor.Name.Trim();
            ntxtNotifyAfterFailureTimes.Value = Sensor.NotifyIfHappensAfterTimes;
            ntxtCheckEveryTime.Value = Sensor.CheckInterval;
            cmbTimeType.SelectedIndex = (int)Sensor.IntervalType;
            cbEnabled.Checked = Sensor.Enabled;
            cbNotifyByEmail.Checked = Sensor.NotifyByEmail;
            ntxtRamUsageExceedValue.Value = Sensor.PercentToCheck;
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
