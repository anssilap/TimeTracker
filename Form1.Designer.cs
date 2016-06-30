namespace TimeTracker
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxDebugInfo = new System.Windows.Forms.TextBox();
            this.buttonStartTimer = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddTime = new System.Windows.Forms.Button();
            this.buttonRemoveTime = new System.Windows.Forms.Button();
            this.buttonResetTime = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSeconds = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDebugInfo
            // 
            this.textBoxDebugInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDebugInfo.Location = new System.Drawing.Point(12, 275);
            this.textBoxDebugInfo.Multiline = true;
            this.textBoxDebugInfo.Name = "textBoxDebugInfo";
            this.textBoxDebugInfo.ReadOnly = true;
            this.textBoxDebugInfo.Size = new System.Drawing.Size(602, 36);
            this.textBoxDebugInfo.TabIndex = 3;
            // 
            // buttonStartTimer
            // 
            this.buttonStartTimer.Location = new System.Drawing.Point(12, 12);
            this.buttonStartTimer.Name = "buttonStartTimer";
            this.buttonStartTimer.Size = new System.Drawing.Size(98, 31);
            this.buttonStartTimer.TabIndex = 4;
            this.buttonStartTimer.Text = "Start timer";
            this.buttonStartTimer.UseVisualStyleBackColor = true;
            this.buttonStartTimer.Click += new System.EventHandler(this.buttonStartTimer_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.labelTimer.Location = new System.Drawing.Point(116, 12);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(187, 31);
            this.labelTimer.TabIndex = 5;
            this.labelTimer.Text = "00:00";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "h";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "m";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "s";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonAddTime
            // 
            this.buttonAddTime.Location = new System.Drawing.Point(116, 49);
            this.buttonAddTime.Name = "buttonAddTime";
            this.buttonAddTime.Size = new System.Drawing.Size(90, 20);
            this.buttonAddTime.TabIndex = 12;
            this.buttonAddTime.Text = "Add time";
            this.buttonAddTime.UseVisualStyleBackColor = true;
            this.buttonAddTime.Click += new System.EventHandler(this.buttonAddTime_Click);
            // 
            // buttonRemoveTime
            // 
            this.buttonRemoveTime.Location = new System.Drawing.Point(116, 75);
            this.buttonRemoveTime.Name = "buttonRemoveTime";
            this.buttonRemoveTime.Size = new System.Drawing.Size(90, 20);
            this.buttonRemoveTime.TabIndex = 13;
            this.buttonRemoveTime.Text = "Remove time";
            this.buttonRemoveTime.UseVisualStyleBackColor = true;
            this.buttonRemoveTime.Click += new System.EventHandler(this.buttonRemoveTime_Click);
            // 
            // buttonResetTime
            // 
            this.buttonResetTime.Location = new System.Drawing.Point(116, 101);
            this.buttonResetTime.Name = "buttonResetTime";
            this.buttonResetTime.Size = new System.Drawing.Size(90, 20);
            this.buttonResetTime.TabIndex = 14;
            this.buttonResetTime.Text = "ResetTime";
            this.buttonResetTime.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TimeTrackerNotifier";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // numericUpDownHours
            // 
            this.numericUpDownHours.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numericUpDownHours.Location = new System.Drawing.Point(31, 49);
            this.numericUpDownHours.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownHours.Name = "numericUpDownHours";
            this.numericUpDownHours.Size = new System.Drawing.Size(79, 20);
            this.numericUpDownHours.TabIndex = 15;
            // 
            // numericUpDownMinutes
            // 
            this.numericUpDownMinutes.Location = new System.Drawing.Point(31, 75);
            this.numericUpDownMinutes.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownMinutes.Name = "numericUpDownMinutes";
            this.numericUpDownMinutes.Size = new System.Drawing.Size(79, 20);
            this.numericUpDownMinutes.TabIndex = 16;
            // 
            // numericUpDownSeconds
            // 
            this.numericUpDownSeconds.Location = new System.Drawing.Point(31, 101);
            this.numericUpDownSeconds.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownSeconds.Name = "numericUpDownSeconds";
            this.numericUpDownSeconds.Size = new System.Drawing.Size(79, 20);
            this.numericUpDownSeconds.TabIndex = 17;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 323);
            this.Controls.Add(this.numericUpDownSeconds);
            this.Controls.Add(this.numericUpDownMinutes);
            this.Controls.Add(this.numericUpDownHours);
            this.Controls.Add(this.buttonResetTime);
            this.Controls.Add(this.buttonRemoveTime);
            this.Controls.Add(this.buttonAddTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonStartTimer);
            this.Controls.Add(this.textBoxDebugInfo);
            this.Name = "FormMain";
            this.Text = "TimeTracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDebugInfo;
        private System.Windows.Forms.Button buttonStartTimer;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddTime;
        private System.Windows.Forms.Button buttonRemoveTime;
        private System.Windows.Forms.Button buttonResetTime;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
        private System.Windows.Forms.NumericUpDown numericUpDownSeconds;
    }
}

