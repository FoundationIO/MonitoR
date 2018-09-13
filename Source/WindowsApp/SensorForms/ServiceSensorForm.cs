﻿using MonitoR.Common.Constants;
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
        private CrudType crudType;
        public ServiceSensor Sensor { get; private set; }
        public List<ISensor> ExistingSensors { get; private set; }

        public ServiceSensorForm(CrudType crudType, ServiceSensor sensor, List<ISensor> existingSensors)
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
            this.Sensor.Services.Clear();
            for (int i = 0; i < cklbDrives.Items.Count; ++i)
            {
                this.Sensor.Services.Add(cklbDrives.Items[i].ToString());
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
            foreach (var dr in this.Sensor.Services)
            {
                cklbDrives.Items.Add(dr);
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
            using (var selectorForm = new ServiceSelectorForm())
            {
                if (selectorForm.ShowDialog(this) != DialogResult.OK)
                    return;

                this.cklbDrives.Items.Clear();
                foreach (var item in selectorForm.GetSelectedItems())
                    cklbDrives.Items.Add(item);
            }
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