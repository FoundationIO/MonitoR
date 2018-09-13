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
    public partial class HttpSensorForm : Form
    {
        private CrudType crudType;
        public HttpSensor Sensor { get; private set; }
        public List<ISensor> ExistingSensors { get; private set; }

        public HttpSensorForm(CrudType crudType, HttpSensor sensor, List<ISensor> existingSensors)
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
            txtName.Focus();
            ntxtNotifyAfterFailureTimes.Value = 1;
            cbHttpMethod.SelectedIndex = 1;
        }

        public void UpdateDataFromUI()
        {
            Sensor.Name = txtName.Text.Trim();
            Sensor.NotifyIfHappensAfterTimes = (int)ntxtNotifyAfterFailureTimes.Value;
            Sensor.CheckInterval = (int)ntxtCheckEveryTime.Value;
            Sensor.IntervalType = (CheckIntervalType)cmbTimeType.SelectedIndex;
            Sensor.RequestMethod = cbHttpMethod.Text;
            Sensor.Urls.Clear();
            foreach (var item in cklbDrives.Items)
            {
                Sensor.Urls.Add(item.ToString());
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
            if (Sensor.RequestMethod == null)
            {
                cbHttpMethod.SelectedIndex = 1;
            }
            else
            {
                var idx = cbHttpMethod.Items.IndexOf(Sensor.RequestMethod);
                if (idx < 0)
                    cbHttpMethod.SelectedIndex = 1;
            }

            cklbDrives.Items.Clear();
            foreach (var item in Sensor.Urls)
            {
                cklbDrives.Items.Add(item);
            }
            cbEnabled.Checked = Sensor.Enabled;
            cbNotifyByEmail.Checked = Sensor.NotifyByEmail;
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

        private void BtAddItem_Click(object sender, EventArgs e)
        {
            var url = "";

            if (FormUtils.InputBox("Add new website", "Enter a website Url to check ", ref url) != DialogResult.OK)
            {
                return;
            }

            if (ValidationUtils.IsUrlValid(url) == false)
            {
                MessageBox.Show($"{url} is not a valid Url");
                return;
            }
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
