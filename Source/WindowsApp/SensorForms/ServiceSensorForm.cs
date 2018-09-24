using MonitoR.Common.Common;
using MonitoR.Common.Constants;
using MonitoR.Common.Sensors;
using MonitoR.Common.Utilities;
using MonitoR.Configurator.SensorForms.SelectorForm;
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
    public partial class ServiceSensorForm : Form
    {
        private readonly CrudType crudType;
        public ServiceSensor Sensor { get; }
        public List<ISensor> ExistingSensors { get; }

        public ServiceSensorForm(CrudType crudType, ServiceSensor sensor, List<ISensor> existingSensors)
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
            txtName.Focus();
            ntxtNotifyAfterFailureTimes.Value = 1;
        }

        public void UpdateDataFromUI()
        {
            Sensor.Name = txtName.Text.Trim();
            Sensor.NotifyIfHappensAfterTimes = (int)ntxtNotifyAfterFailureTimes.Value;
            Sensor.CheckInterval = (int)ntxtCheckEveryTime.Value;
            Sensor.IntervalType = (CheckIntervalType)cmbTimeType.SelectedIndex;
            Sensor.Services.Clear();
            for (int i = 0; i < cklbServices.Items.Count; ++i)
            {
                Sensor.Services.Add(cklbServices.Items[i].ToString());
            }
            Sensor.Enabled = cbEnabled.Checked;
            Sensor.NotifyByEmail = cbNotifyByEmail.Checked;
            Sensor.RestartIfStopped = cbRestartServiceIfStopped.Checked;
        }

        public void UpdateUIFromData()
        {
            txtName.Text = Sensor.Name.Trim();
            ntxtNotifyAfterFailureTimes.Value = Sensor.NotifyIfHappensAfterTimes;
            ntxtCheckEveryTime.Value = Sensor.CheckInterval;
            cmbTimeType.SelectedIndex = (int)Sensor.IntervalType;
            cklbServices.Items.Clear();
            foreach (var dr in Sensor.Services)
            {
                cklbServices.Items.Add(dr);
            }
            cbEnabled.Checked = Sensor.Enabled;
            cbNotifyByEmail.Checked = Sensor.NotifyByEmail;
            cbRestartServiceIfStopped.Checked = Sensor.RestartIfStopped;
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
            using (var selectorForm = new ServiceSelectorForm())
            {
                if (selectorForm.ShowDialog(this) != DialogResult.OK)
                    return;

                cklbServices.Items.Clear();
                foreach (var item in selectorForm.GetSelectedItems())
                    cklbServices.Items.Add(item);
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (cklbServices.SelectedIndex == -1)
                return;

            cklbServices.Items.RemoveAt(cklbServices.SelectedIndex);
        }

        protected override void OnShown(EventArgs e)
        {
            txtName.Focus();
            base.OnShown(e);
        }
    }
}
