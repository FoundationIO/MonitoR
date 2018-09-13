namespace MonitoR.Configurator.SensorForms.SelectorForm
{
    partial class ServiceSelectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceSelectorForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btReset);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 372);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "db_register16_h.bmp");
            this.imageList1.Images.SetKeyName(1, "db_unregister16_h.bmp");
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(397, 427);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 40;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(484, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "Service List";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(304, 427);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 39;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(17, 49);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(424, 304);
            this.checkedListBox1.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(49, 23);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(311, 20);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtFilter_KeyUp);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(366, 20);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(75, 23);
            this.btReset.TabIndex = 40;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.BtReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Filter";
            // 
            // ServiceSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceSelectorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service Selector";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button button1;
    }
}