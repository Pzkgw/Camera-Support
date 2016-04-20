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
            this.labelPlaybackPosition = new System.Windows.Forms.Label();
            this.panelVlc = new System.Windows.Forms.Panel();
            this.tabHost = new System.Windows.Forms.TabControl();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtDevUrl = new System.Windows.Forms.TextBox();
            this.txtDevUser = new System.Windows.Forms.TextBox();
            this.txtDevPass = new System.Windows.Forms.TextBox();
            this.btnDevConnect = new System.Windows.Forms.Button();
            this.lblDevUrl = new System.Windows.Forms.Label();
            this.lblDevUser = new System.Windows.Forms.Label();
            this.lblDevPass = new System.Windows.Forms.Label();
            this.tabHost.SuspendLayout();
            this.tabDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPlaybackPosition
            // 
            this.labelPlaybackPosition.AutoSize = true;
            this.labelPlaybackPosition.Location = new System.Drawing.Point(382, 498);
            this.labelPlaybackPosition.Name = "labelPlaybackPosition";
            this.labelPlaybackPosition.Size = new System.Drawing.Size(0, 13);
            this.labelPlaybackPosition.TabIndex = 0;
            // 
            // panelVlc
            // 
            this.panelVlc.Location = new System.Drawing.Point(375, 12);
            this.panelVlc.Name = "panelVlc";
            this.panelVlc.Size = new System.Drawing.Size(728, 483);
            this.panelVlc.TabIndex = 1;
            // 
            // tabHost
            // 
            this.tabHost.Controls.Add(this.tabDevice);
            this.tabHost.Controls.Add(this.tabLog);
            this.tabHost.Location = new System.Drawing.Point(1, 0);
            this.tabHost.Name = "tabHost";
            this.tabHost.SelectedIndex = 0;
            this.tabHost.Size = new System.Drawing.Size(368, 495);
            this.tabHost.TabIndex = 2;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.lblDevPass);
            this.tabDevice.Controls.Add(this.lblDevUser);
            this.tabDevice.Controls.Add(this.lblDevUrl);
            this.tabDevice.Controls.Add(this.btnDevConnect);
            this.tabDevice.Controls.Add(this.txtDevPass);
            this.tabDevice.Controls.Add(this.txtDevUser);
            this.tabDevice.Controls.Add(this.txtDevUrl);
            this.tabDevice.Location = new System.Drawing.Point(4, 22);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevice.Size = new System.Drawing.Size(360, 469);
            this.tabDevice.TabIndex = 0;
            this.tabDevice.Text = "Device";
            this.tabDevice.UseVisualStyleBackColor = true;
            // 
            // tabLog
            // 
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(349, 457);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(693, 501);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(96, 28);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // txtDevUrl
            // 
            this.txtDevUrl.Location = new System.Drawing.Point(109, 67);
            this.txtDevUrl.Name = "txtDevUrl";
            this.txtDevUrl.Size = new System.Drawing.Size(231, 20);
            this.txtDevUrl.TabIndex = 0;
            // 
            // txtDevUser
            // 
            this.txtDevUser.Location = new System.Drawing.Point(111, 122);
            this.txtDevUser.Name = "txtDevUser";
            this.txtDevUser.Size = new System.Drawing.Size(162, 20);
            this.txtDevUser.TabIndex = 1;
            // 
            // txtDevPass
            // 
            this.txtDevPass.Location = new System.Drawing.Point(114, 171);
            this.txtDevPass.Name = "txtDevPass";
            this.txtDevPass.Size = new System.Drawing.Size(158, 20);
            this.txtDevPass.TabIndex = 2;
            // 
            // btnDevConnect
            // 
            this.btnDevConnect.Location = new System.Drawing.Point(119, 233);
            this.btnDevConnect.Name = "btnDevConnect";
            this.btnDevConnect.Size = new System.Drawing.Size(95, 25);
            this.btnDevConnect.TabIndex = 3;
            this.btnDevConnect.Text = "Connect";
            this.btnDevConnect.UseVisualStyleBackColor = true;
            // 
            // lblDevUrl
            // 
            this.lblDevUrl.AutoSize = true;
            this.lblDevUrl.Location = new System.Drawing.Point(11, 59);
            this.lblDevUrl.Name = "lblDevUrl";
            this.lblDevUrl.Size = new System.Drawing.Size(23, 13);
            this.lblDevUrl.TabIndex = 4;
            this.lblDevUrl.Text = "Url:";
            // 
            // lblDevUser
            // 
            this.lblDevUser.AutoSize = true;
            this.lblDevUser.Location = new System.Drawing.Point(20, 121);
            this.lblDevUser.Name = "lblDevUser";
            this.lblDevUser.Size = new System.Drawing.Size(32, 13);
            this.lblDevUser.TabIndex = 5;
            this.lblDevUser.Text = "User:";
            // 
            // lblDevPass
            // 
            this.lblDevPass.AutoSize = true;
            this.lblDevPass.Location = new System.Drawing.Point(23, 172);
            this.lblDevPass.Name = "lblDevPass";
            this.lblDevPass.Size = new System.Drawing.Size(56, 13);
            this.lblDevPass.TabIndex = 6;
            this.lblDevPass.Text = "Password:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 587);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.tabHost);
            this.Controls.Add(this.panelVlc);
            this.Controls.Add(this.labelPlaybackPosition);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.tabHost.ResumeLayout(false);
            this.tabDevice.ResumeLayout(false);
            this.tabDevice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlaybackPosition;
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
    }
}