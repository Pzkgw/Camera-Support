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
            this.tabLog = new System.Windows.Forms.TabPage();
            this.txtDev = new System.Windows.Forms.TextBox();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.lblDev = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtDevUser = new System.Windows.Forms.TextBox();
            this.txtDevPass = new System.Windows.Forms.TextBox();
            this.btnDevConnect = new System.Windows.Forms.Button();
            this.lblDevUrl = new System.Windows.Forms.Label();
            this.lblDevUser = new System.Windows.Forms.Label();
            this.lblDevPass = new System.Windows.Forms.Label();
            this.groupBoxDev = new System.Windows.Forms.GroupBox();
            this.comboAddress = new System.Windows.Forms.ComboBox();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.groupBoxVlcFactors = new System.Windows.Forms.GroupBox();
            this.txtZoomF = new System.Windows.Forms.TextBox();
            this.lblZoomF = new System.Windows.Forms.Label();
            this.lblHeightF = new System.Windows.Forms.Label();
            this.lblWidthF = new System.Windows.Forms.Label();
            this.textBoxHeightF = new System.Windows.Forms.TextBox();
            this.textBoxWidthF = new System.Windows.Forms.TextBox();
            this.groupBoxBtns = new System.Windows.Forms.GroupBox();
            this.chkFullVid = new System.Windows.Forms.CheckBox();
            this.chkPlayLoop = new System.Windows.Forms.CheckBox();
            this.tabHost.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabDevice.SuspendLayout();
            this.groupBoxDev.SuspendLayout();
            this.groupBoxVlcFactors.SuspendLayout();
            this.groupBoxBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVlcNotify
            // 
            this.lblVlcNotify.AutoSize = true;
            this.lblVlcNotify.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVlcNotify.Location = new System.Drawing.Point(337, 4);
            this.lblVlcNotify.Name = "lblVlcNotify";
            this.lblVlcNotify.Size = new System.Drawing.Size(0, 15);
            this.lblVlcNotify.TabIndex = 0;
            // 
            // panelVlc
            // 
            this.panelVlc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVlc.Location = new System.Drawing.Point(337, 22);
            this.panelVlc.Name = "panelVlc";
            this.panelVlc.Size = new System.Drawing.Size(766, 473);
            this.panelVlc.TabIndex = 1;
            // 
            // tabHost
            // 
            this.tabHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabHost.Controls.Add(this.tabLog);
            this.tabHost.Controls.Add(this.tabDevice);
            this.tabHost.Location = new System.Drawing.Point(1, 0);
            this.tabHost.Name = "tabHost";
            this.tabHost.SelectedIndex = 0;
            this.tabHost.Size = new System.Drawing.Size(330, 495);
            this.tabHost.TabIndex = 2;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtDev);
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(322, 469);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // txtDev
            // 
            this.txtDev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDev.Location = new System.Drawing.Point(3, 3);
            this.txtDev.Multiline = true;
            this.txtDev.Name = "txtDev";
            this.txtDev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDev.Size = new System.Drawing.Size(316, 463);
            this.txtDev.TabIndex = 0;
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
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(120, 16);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(79, 37);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Visible = false;
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
            this.groupBoxDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxDev.Controls.Add(this.comboAddress);
            this.groupBoxDev.Controls.Add(this.btnDevConnect);
            this.groupBoxDev.Controls.Add(this.lblDevPass);
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
            // comboAddress
            // 
            this.comboAddress.FormattingEnabled = true;
            this.comboAddress.Location = new System.Drawing.Point(69, 30);
            this.comboAddress.Name = "comboAddress";
            this.comboAddress.Size = new System.Drawing.Size(445, 23);
            this.comboAddress.TabIndex = 7;
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Enabled = false;
            this.btnSnapshot.Location = new System.Drawing.Point(349, 16);
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
            this.btnRecord.Location = new System.Drawing.Point(348, 55);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(86, 49);
            this.btnRecord.TabIndex = 6;
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Visible = false;
            // 
            // groupBoxVlcFactors
            // 
            this.groupBoxVlcFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVlcFactors.Controls.Add(this.txtZoomF);
            this.groupBoxVlcFactors.Controls.Add(this.lblZoomF);
            this.groupBoxVlcFactors.Controls.Add(this.lblHeightF);
            this.groupBoxVlcFactors.Controls.Add(this.lblWidthF);
            this.groupBoxVlcFactors.Controls.Add(this.textBoxHeightF);
            this.groupBoxVlcFactors.Controls.Add(this.textBoxWidthF);
            this.groupBoxVlcFactors.Location = new System.Drawing.Point(998, 501);
            this.groupBoxVlcFactors.Name = "groupBoxVlcFactors";
            this.groupBoxVlcFactors.Size = new System.Drawing.Size(115, 108);
            this.groupBoxVlcFactors.TabIndex = 7;
            this.groupBoxVlcFactors.TabStop = false;
            this.groupBoxVlcFactors.Text = "Factor";
            // 
            // txtZoomF
            // 
            this.txtZoomF.Location = new System.Drawing.Point(50, 82);
            this.txtZoomF.Name = "txtZoomF";
            this.txtZoomF.Size = new System.Drawing.Size(41, 20);
            this.txtZoomF.TabIndex = 5;
            this.txtZoomF.Text = "100";
            this.txtZoomF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // lblHeightF
            // 
            this.lblHeightF.AutoSize = true;
            this.lblHeightF.Location = new System.Drawing.Point(6, 53);
            this.lblHeightF.Name = "lblHeightF";
            this.lblHeightF.Size = new System.Drawing.Size(41, 13);
            this.lblHeightF.TabIndex = 3;
            this.lblHeightF.Text = "Height:";
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
            // textBoxHeightF
            // 
            this.textBoxHeightF.Location = new System.Drawing.Point(50, 50);
            this.textBoxHeightF.Name = "textBoxHeightF";
            this.textBoxHeightF.Size = new System.Drawing.Size(41, 20);
            this.textBoxHeightF.TabIndex = 1;
            this.textBoxHeightF.Text = "1";
            this.textBoxHeightF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // groupBoxBtns
            // 
            this.groupBoxBtns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBtns.Controls.Add(this.chkFullVid);
            this.groupBoxBtns.Controls.Add(this.chkPlayLoop);
            this.groupBoxBtns.Controls.Add(this.btnPlay);
            this.groupBoxBtns.Controls.Add(this.btnSnapshot);
            this.groupBoxBtns.Controls.Add(this.btnRecord);
            this.groupBoxBtns.Location = new System.Drawing.Point(552, 501);
            this.groupBoxBtns.Name = "groupBoxBtns";
            this.groupBoxBtns.Size = new System.Drawing.Size(440, 108);
            this.groupBoxBtns.TabIndex = 8;
            this.groupBoxBtns.TabStop = false;
            // 
            // chkFullVid
            // 
            this.chkFullVid.AutoSize = true;
            this.chkFullVid.Location = new System.Drawing.Point(231, 58);
            this.chkFullVid.Name = "chkFullVid";
            this.chkFullVid.Size = new System.Drawing.Size(71, 17);
            this.chkFullVid.TabIndex = 8;
            this.chkFullVid.Text = "Full video";
            this.chkFullVid.UseVisualStyleBackColor = true;
            // 
            // chkPlayLoop
            // 
            this.chkPlayLoop.AutoSize = true;
            this.chkPlayLoop.Checked = true;
            this.chkPlayLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlayLoop.Location = new System.Drawing.Point(231, 27);
            this.chkPlayLoop.Name = "chkPlayLoop";
            this.chkPlayLoop.Size = new System.Drawing.Size(90, 17);
            this.chkPlayLoop.TabIndex = 7;
            this.chkPlayLoop.Text = "Play continuu";
            this.chkPlayLoop.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 608);
            this.Controls.Add(this.groupBoxBtns);
            this.Controls.Add(this.groupBoxVlcFactors);
            this.Controls.Add(this.groupBoxDev);
            this.Controls.Add(this.tabHost);
            this.Controls.Add(this.panelVlc);
            this.Controls.Add(this.lblVlcNotify);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.tabHost.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.tabDevice.ResumeLayout(false);
            this.tabDevice.PerformLayout();
            this.groupBoxDev.ResumeLayout(false);
            this.groupBoxDev.PerformLayout();
            this.groupBoxVlcFactors.ResumeLayout(false);
            this.groupBoxVlcFactors.PerformLayout();
            this.groupBoxBtns.ResumeLayout(false);
            this.groupBoxBtns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVlcNotify;
        internal System.Windows.Forms.Panel panelVlc;
        private System.Windows.Forms.TabControl tabHost;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.Button btnDevConnect;
        private System.Windows.Forms.TextBox txtDevPass;
        private System.Windows.Forms.TextBox txtDevUser;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblDevPass;
        private System.Windows.Forms.Label lblDevUser;
        private System.Windows.Forms.Label lblDevUrl;
        private System.Windows.Forms.GroupBox groupBoxDev;
        private System.Windows.Forms.Label lblDev;
        internal System.Windows.Forms.Button btnSnapshot;
        internal System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.GroupBox groupBoxVlcFactors;
        private System.Windows.Forms.Label lblHeightF;
        private System.Windows.Forms.Label lblWidthF;
        private System.Windows.Forms.TextBox textBoxHeightF;
        private System.Windows.Forms.TextBox textBoxWidthF;
        private System.Windows.Forms.TextBox txtZoomF;
        private System.Windows.Forms.Label lblZoomF;
        private System.Windows.Forms.TextBox txtDev;
        private System.Windows.Forms.ComboBox comboAddress;
        private System.Windows.Forms.GroupBox groupBoxBtns;
        private System.Windows.Forms.CheckBox chkPlayLoop;
        private System.Windows.Forms.CheckBox chkFullVid;
    }
}