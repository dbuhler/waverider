namespace WaveriderGUI
{
    partial class RecordDialog
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
            this.buttonBegRecord = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxSamplingRate = new System.Windows.Forms.ComboBox();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonEndRecord = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBegRecord
            // 
            this.buttonBegRecord.Image = global::WaveriderGUI.Properties.Resources.IconRecord24;
            this.buttonBegRecord.Location = new System.Drawing.Point(133, 19);
            this.buttonBegRecord.Name = "buttonBegRecord";
            this.buttonBegRecord.Size = new System.Drawing.Size(64, 64);
            this.buttonBegRecord.TabIndex = 1;
            this.buttonBegRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(41, 99);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(122, 99);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxSamplingRate
            // 
            this.comboBoxSamplingRate.FormattingEnabled = true;
            this.comboBoxSamplingRate.Location = new System.Drawing.Point(12, 62);
            this.comboBoxSamplingRate.Name = "comboBoxSamplingRate";
            this.comboBoxSamplingRate.Size = new System.Drawing.Size(114, 21);
            this.comboBoxSamplingRate.TabIndex = 5;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(6, 19);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(45, 17);
            this.radioButton8.TabIndex = 6;
            this.radioButton8.Text = "8 bit";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Checked = true;
            this.radioButton16.Location = new System.Drawing.Point(57, 19);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(51, 17);
            this.radioButton16.TabIndex = 7;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "16 bit";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.radioButton8);
            this.groupBox.Controls.Add(this.radioButton16);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(114, 44);
            this.groupBox.TabIndex = 8;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Bits per Sample";
            // 
            // buttonEndRecord
            // 
            this.buttonEndRecord.Image = global::WaveriderGUI.Properties.Resources.IconStop24;
            this.buttonEndRecord.Location = new System.Drawing.Point(133, 19);
            this.buttonEndRecord.Name = "buttonEndRecord";
            this.buttonEndRecord.Size = new System.Drawing.Size(64, 64);
            this.buttonEndRecord.TabIndex = 9;
            this.buttonEndRecord.UseVisualStyleBackColor = true;
            this.buttonEndRecord.Visible = false;
            this.buttonEndRecord.Click += new System.EventHandler(this.buttonEndRecord_Click);
            // 
            // RecordDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(209, 134);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.comboBoxSamplingRate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonBegRecord);
            this.Controls.Add(this.buttonEndRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Record Dialog";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBegRecord;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxSamplingRate;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonEndRecord;
    }
}