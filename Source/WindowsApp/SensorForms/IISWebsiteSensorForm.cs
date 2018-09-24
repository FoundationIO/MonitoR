using MonitoR.Common.Common;
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
    public partial class IISWebsiteSensorForm : Form
    {
        private readonly CrudType crudType;
        public IISWebsiteSensor Sensor { get; }
        public List<ISensor> ExistingSensors { get; }

        public IISWebsiteSensorForm(CrudType crudType, IISWebsiteSensor sensor, List<ISensor> existingSensors)
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
            foreach (var ws in IISUtils.GetWebsiteList())
            {
                cklbDrives.Items.Add(ws);
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
            Sensor.Enabled = cbEnabled.Checked;
            Sensor.NotifyByEmail = cbNotifyByEmail.Checked;

            Sensor.Websites.Clear();

            for (int i = 0; i < cklbDrives.Items.Count; ++i)
            {
                if (!cklbDrives.GetItemChecked(i))
                    continue;
                Sensor.Websites.Add(cklbDrives.Items[i].ToString());
            }
        }

        public void UpdateUIFromData()
        {
            txtName.Text = Sensor.Name.Trim();
            ntxtNotifyAfterFailureTimes.Value = Sensor.NotifyIfHappensAfterTimes;
            ntxtCheckEveryTime.Value = Sensor.CheckInterval;
            cmbTimeType.SelectedIndex = (int)Sensor.IntervalType;
            cbEnabled.Checked = Sensor.Enabled;
            cbNotifyByEmail.Checked = Sensor.NotifyByEmail;

            foreach (var dr in Sensor.Websites)
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
            var result = Sensor.IsValid(ExistingSensors);
            if (ReturnValue.IsNullOrFalse(result))
            {
                MessageBox.Show(result != null ? result.ErrorMessages.ToString(" ") : "Invalid Option");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnShown(EventArgs e)
        {
            txtName.Focus();
            base.OnShown(e);
        }
    }
}
