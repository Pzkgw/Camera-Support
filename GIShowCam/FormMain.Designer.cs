namespace GIShowCam
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
            this.lblVlcNotify = new System.Windows.Forms.Label();
            this.panelVlc = new System.Windows.Forms.Panel();
            this.tabHost = new System.Windows.Forms.TabControl();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.lblDev = new System.Windows.Forms.Label();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtDevUrl = new System.Windows.Forms.TextBox();
            this.txtDevUser = new System.Windows.Forms.TextBox();
            this.txtDevPass = new System.Windows.Forms.TextBox();
            this.btnDevConnect = new System.Windows.Forms.Button();
            this.lblDevUrl = new System.Windows.Forms.Label();
            this.lblDevUser = new System.Windows.Forms.Label();
            this.lblDevPass = new System.Windows.Forms.Label();
            this.groupBoxDev = new System.Windows.Forms.GroupBox();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.groupBoxVlcChange = new System.Windows.Forms.GroupBox();
            this.textBoxWidthF = new System.Windows.Forms.TextBox();
            this.textBoxHeightF = new System.Windows.Forms.TextBox();
            this.lblWidthF = new System.Windows.Forms.Label();
            this.lblHeightF = new System.Windows.Forms.Label();
            this.lblZoomF = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabHost.SuspendLayout();
            this.tabDevice.SuspendLayout();
            this.groupBoxDev.SuspendLayout();
            this.groupBoxVlcChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVlcNotify
            // 
            this.lblVlcNotify.AutoSize = true;
            this.lblVlcNotify.Location = new System.Drawing.Point(604, 9);
            this.lblVlcNotify.Name = "lblVlcNotify";
            this.lblVlcNotify.Size = new System.Drawing.Size(0, 13);
            this.lblVlcNotify.TabIndex = 0;
            // 
            // panelVlc
            // 
            this.panelVlc.Location = new System.Drawing.Point(337, 22);
            this.panelVlc.Name = "panelVlc";
            this.panelVlc.Size = new System.Drawing.Size(766, 473);
            this.panelVlc.TabIndex = 1;
            // 
            // tabHost
            // 
            this.tabHost.Controls.Add(this.tabDevice);
            this.tabHost.Controls.Add(this.tabLog);
            this.tabHost.Location = new System.Drawing.Point(1, 0);
            this.tabHost.Name = "tabHost";
            this.tabHost.SelectedIndex = 0;
            this.tabHost.Size = new System.Drawing.Size(330, 495);
            this.tabHost.TabIndex = 2;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.lblDev);
            this.tabDevice.Location = new System.Drawing.Point(4, 22);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevice.Size = new System.Drawing.Size(322, 469);
            this.tabDevice.TabIndex = 0;
            this.tabDevice.Text = "Device";
            this.tabDevice.UseVisualStyleBackColor = true;
            // 
            // lblDev
            // 
            this.lblDev.AutoSize = true;
            this.lblDev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDev.Location = new System.Drawing.Point(3, 3);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(0, 13);
            this.lblDev.TabIndex = 0;
            // 
            // tabLog
            // 
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(322, 469);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(670, 521);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(96, 28);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Visible = false;
            // 
            // txtDevUrl
            // 
            this.txtDevUrl.Location = new System.Drawing.Point(69, 30);
            this.txtDevUrl.Name = "txtDevUrl";
            this.txtDevUrl.Size = new System.Drawing.Size(466, 21);
            this.txtDevUrl.TabIndex = 0;
            // 
            // txtDevUser
            // 
            this.txtDevUser.Location = new System.Drawing.Point(69, 69);
            this.txtDevUser.Name = "txtDevUser";
            this.txtDevUser.Size = new System.Drawing.Size(120, 21);
            this.txtDevUser.TabIndex = 1;
            // 
            // txtDevPass
            // 
            this.txtDevPass.Location = new System.Drawing.Point(267, 68);
            this.txtDevPass.Name = "txtDevPass";
            this.txtDevPass.Size = new System.Drawing.Size(120, 21);
            this.txtDevPass.TabIndex = 2;
            // 
            // btnDevConnect
            // 
            this.btnDevConnect.Location = new System.Drawing.Point(418, 62);
            this.btnDevConnect.Name = "btnDevConnect";
            this.btnDevConnect.Size = new System.Drawing.Size(96, 34);
            this.btnDevConnect.TabIndex = 3;
            this.btnDevConnect.Text = "Connect";
            this.btnDevConnect.UseVisualStyleBackColor = true;
            // 
            // lblDevUrl
            // 
            this.lblDevUrl.AutoSize = true;
            this.lblDevUrl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDevUrl.Location = new System.Drawing.Point(7, 33);
            this.lblDevUrl.Name = "lblDevUrl";
            this.lblDevUrl.Size = new System.Drawing.Size(56, 15);
            this.lblDevUrl.TabIndex = 4;
            this.lblDevUrl.Text = "Address:";
            // 
            // lblDevUser
            // 
            this.lblDevUser.AutoSize = true;
            this.lblDevUser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDevUser.Location = new System.Drawing.Point(7, 71);
            this.lblDevUser.Name = "lblDevUser";
            this.lblDevUser.Size = new System.Drawing.Size(37, 15);
            this.lblDevUser.TabIndex = 5;
            this.lblDevUser.Text = "User:";
            // 
            // lblDevPass
            // 
            this.lblDevPass.AutoSize = true;
            this.lblDevPass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDevPass.Location = new System.Drawing.Point(195, 72);
            this.lblDevPass.Name = "lblDevPass";
            this.lblDevPass.Size = new System.Drawing.Size(66, 15);
            this.lblDevPass.TabIndex = 6;
            this.lblDevPass.Text = "Password:";
            // 
            // groupBoxDev
            // 
            this.groupBoxDev.Controls.Add(this.btnDevConnect);
            this.groupBoxDev.Controls.Add(this.lblDevPass);
            this.groupBoxDev.Controls.Add(this.txtDevUrl);
            this.groupBoxDev.Controls.Add(this.lblDevUser);
            this.groupBoxDev.Controls.Add(this.lblDevUrl);
            this.groupBoxDev.Controls.Add(this.txtDevUser);
            this.groupBoxDev.Controls.Add(this.txtDevPass);
            this.groupBoxDev.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxDev.Location = new System.Drawing.Point(1, 501);
            this.groupBoxDev.Name = "groupBoxDev";
            this.groupBoxDev.Size = new System.Drawing.Size(545, 108);
            this.groupBoxDev.TabIndex = 4;
            this.groupBoxDev.TabStop = false;
            this.groupBoxDev.Text = "Device";
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Enabled = false;
            this.btnSnapshot.Location = new System.Drawing.Point(823, 522);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(85, 26);
            this.btnSnapshot.TabIndex = 5;
            this.btnSnapshot.Text = "Snapshot";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Visible = false;
            // 
            // btnRecord
            // 
            this.btnRecord.Enabled = false;
            this.btnRecord.Location = new System.Drawing.Point(823, 554);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(86, 27);
            this.btnRecord.TabIndex = 6;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Visible = false;
            // 
            // groupBoxVlcChange
            // 
            this.groupBoxVlcChange.Controls.Add(this.textBox1);
            this.groupBoxVlcChange.Controls.Add(this.lblZoomF);
            this.groupBoxVlcChange.Controls.Add(this.lblHeightF);
            this.groupBoxVlcChange.Controls.Add(this.lblWidthF);
            this.groupBoxVlcChange.Controls.Add(this.textBoxHeightF);
            this.groupBoxVlcChange.Controls.Add(this.textBoxWidthF);
            this.groupBoxVlcChange.Location = new System.Drawing.Point(998, 501);
            this.groupBoxVlcChange.Name = "groupBoxVlcChange";
            this.groupBoxVlcChange.Size = new System.Drawing.Size(115, 108);
            this.groupBoxVlcChange.TabIndex = 7;
            this.groupBoxVlcChange.TabStop = false;
            this.groupBoxVlcChange.Text = "Factor";
            // 
            // textBoxWidthF
            // 
            this.textBoxWidthF.Location = new System.Drawing.Point(50, 20);
            this.textBoxWidthF.Name = "textBoxWidthF";
            this.textBoxWidthF.Size = new System.Drawing.Size(41, 20);
            this.textBoxWidthF.TabIndex = 0;
            this.textBoxWidthF.Text = "1";
            this.textBoxWidthF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxHeightF
            // 
            this.textBoxHeightF.Location = new System.Drawing.Point(50, 53);
            this.textBoxHeightF.Name = "textBoxHeightF";
            this.textBoxHeightF.Size = new System.Drawing.Size(41, 20);
            this.textBoxHeightF.TabIndex = 1;
            this.textBoxHeightF.Text = "1";
            this.textBoxHeightF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWidthF
            // 
            this.lblWidthF.AutoSize = true;
            this.lblWidthF.Location = new System.Drawing.Point(6, 23);
            this.lblWidthF.Name = "lblWidthF";
            this.lblWidthF.Size = new System.Drawing.Size(38, 13);
            this.lblWidthF.TabIndex = 2;
            this.lblWidthF.Text = "Width:";
            // 
            // lblHeightF
            // 
            this.lblHeightF.AutoSize = true;
            this.lblHeightF.Location = new System.Drawing.Point(6, 57);
            this.lblHeightF.Name = "lblHeightF";
            this.lblHeightF.Size = new System.Drawing.Size(41, 13);
            this.lblHeightF.TabIndex = 3;
            this.lblHeightF.Text = "Height:";
            // 
            // lblZoomF
            // 
            this.lblZoomF.AutoSize = true;
            this.lblZoomF.Location = new System.Drawing.Point(10, 85);
            this.lblZoomF.Name = "lblZoomF";
            this.lblZoomF.Size = new System.Drawing.Size(37, 13);
            this.lblZoomF.TabIndex = 4;
            this.lblZoomF.Text = "Zoom:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(41, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "100";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 608);
            this.Controls.Add(this.groupBoxVlcChange);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnSnapshot);
            this.Controls.Add(this.groupBoxDev);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.tabHost);
            this.Controls.Add(this.panelVlc);
            this.Controls.Add(this.lblVlcNotify);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.tabHost.ResumeLayout(false);
            this.tabDevice.ResumeLayout(false);
            this.tabDevice.PerformLayout();
            this.groupBoxDev.ResumeLayout(false);
            this.groupBoxDev.PerformLayout();
            this.groupBoxVlcChange.ResumeLayout(false);
            this.groupBoxVlcChange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVlcNotify;
        private System.Windows.Forms.Panel panelVlc;
        private System.Windows.Forms.TabControl tabHost;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.Button btnDevConnect;
        private System.Windows.Forms.TextBox txtDevPass;
        private System.Windows.Forms.TextBox txtDevUser;
        private System.Windows.Forms.TextBox txtDevUrl;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblDevPass;
        private System.Windows.Forms.Label lblDevUser;
        private System.Windows.Forms.Label lblDevUrl;
        private System.Windows.Forms.GroupBox groupBoxDev;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.GroupBox groupBoxVlcChange;
        private System.Windows.Forms.Label lblHeightF;
        private System.Windows.Forms.Label lblWidthF;
        private System.Windows.Forms.TextBox textBoxHeightF;
        private System.Windows.Forms.TextBox textBoxWidthF;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblZoomF;
    }
}