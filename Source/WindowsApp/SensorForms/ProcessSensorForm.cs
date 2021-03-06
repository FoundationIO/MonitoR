﻿using MonitoR.Common.Common;
using MonitoR.Common.Constants;
using MonitoR.Common.Sensors;
using MonitoR.Common.Utilities;
using MonitoR.Configurator.SensorForms.SelectorForm;
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
    public partial class ProcessSensorForm : Form
    {
        private readonly CrudType crudType;
        public ProcessSensor Sensor { get; }
        public List<ISensor> ExistingSensors { get; }

        public ProcessSensorForm(CrudType crudType, ProcessSensor sensor, List<ISensor> existingSensors)
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
            Sensor.Executables.Clear();
            for (int i = 0; i < cklbDrives.Items.Count; ++i)
            {
                Sensor.Executables.Add(cklbDrives.Items[i].ToString());
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
            foreach (var dr in Sensor.Executables)
            {
                cklbDrives.Items.Add(dr);
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

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (cklbDrives.SelectedIndex == -1)
                return;

            cklbDrives.Items.RemoveAt(cklbDrives.SelectedIndex);
        }

        private void BtSelectItem_Click(object sender, EventArgs e)
        {
            using (var selectorForm = new ProcessSelectorForm())
            {
                if (selectorForm.ShowDialog(this) != DialogResult.OK)
                    return;

                cklbDrives.Items.Clear();
                foreach (var item in selectorForm.GetSelectedItems())
                    cklbDrives.Items.Add(item);
            }
        }

        private void BtAddItem_Click(object sender, EventArgs e)
        {
            var url = "";

            if (FormUtils.InputBox("Add new Executable", "Enter an Executable to check ", ref url) != DialogResult.OK)
                return;
            cklbDrives.Items.Add(url);
        }

        protected override void OnShown(EventArgs e)
        {
            txtName.Focus();
            base.OnShown(e);
        }
    }
}
