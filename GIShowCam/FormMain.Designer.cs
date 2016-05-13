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
            this.txtDev = new System.Windows.Forms.TextBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtDevUser = new System.Windows.Forms.TextBox();
            this.txtDevPass = new System.Windows.Forms.TextBox();
            this.btnDevConnect = new System.Windows.Forms.Button();
            this.lblDevUrl = new System.Windows.Forms.Label();
            this.lblDevUser = new System.Windows.Forms.Label();
            this.lblDevPass = new System.Windows.Forms.Label();
            this.groupBoxDev = new System.Windows.Forms.GroupBox();
            this.lblAdd = new System.Windows.Forms.Label();
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
            this.tabLowDev = new System.Windows.Forms.TabControl();
            this.tabLowCtrl = new System.Windows.Forms.TabPage();
            this.tabVlcDebug = new System.Windows.Forms.TabPage();
            this.txtLVDebug = new System.Windows.Forms.TextBox();
            this.tabVlcError = new System.Windows.Forms.TabPage();
            this.txtLVErrors = new System.Windows.Forms.TextBox();
            this.tabVlcInfo = new System.Windows.Forms.TabPage();
            this.txtLVInfo = new System.Windows.Forms.TextBox();
            this.tabWlcWarnings = new System.Windows.Forms.TabPage();
            this.txtLVWarnings = new System.Windows.Forms.TextBox();
            this.groupBoxDev.SuspendLayout();
            this.groupBoxVlcFactors.SuspendLayout();
            this.groupBoxBtns.SuspendLayout();
            this.tabLowDev.SuspendLayout();
            this.tabLowCtrl.SuspendLayout();
            this.tabVlcDebug.SuspendLayout();
            this.tabVlcError.SuspendLayout();
            this.tabVlcInfo.SuspendLayout();
            this.tabWlcWarnings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVlcNotify
            // 
            this.lblVlcNotify.AutoSize = true;
            this.lblVlcNotify.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVlcNotify.Location = new System.Drawing.Point(390, 294);
            this.lblVlcNotify.Name = "lblVlcNotify";
            this.lblVlcNotify.Size = new System.Drawing.Size(0, 15);
            this.lblVlcNotify.TabIndex = 0;
            // 
            // panelVlc
            // 
            this.panelVlc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVlc.Location = new System.Drawing.Point(327, 4);
            this.panelVlc.Name = "panelVlc";
            this.panelVlc.Size = new System.Drawing.Size(902, 511);
            this.panelVlc.TabIndex = 1;
            // 
            // txtDev
            // 
            this.txtDev.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDev.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDev.Location = new System.Drawing.Point(5, 4);
            this.txtDev.Multiline = true;
            this.txtDev.Name = "txtDev";
            this.txtDev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDev.Size = new System.Drawing.Size(316, 511);
            this.txtDev.TabIndex = 0;
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(224, 35);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(103, 37);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Stop";
            this.btnPlay.UseVisualStyleBackColor = true;
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
            this.btnDevConnect.Location = new System.Drawing.Point(181, 150);
            this.btnDevConnect.Name = "btnDevConnect";
            this.btnDevConnect.Size = new System.Drawing.Size(103, 37);
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
            this.groupBoxDev.Location = new System.Drawing.Point(3, 6);
            this.groupBoxDev.Name = "groupBoxDev";
            this.groupBoxDev.Size = new System.Drawing.Size(545, 216);
            this.groupBoxDev.TabIndex = 4;
            this.groupBoxDev.TabStop = false;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(23, 294);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(0, 15);
            this.lblAdd.TabIndex = 8;
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
            this.btnSnapshot.Location = new System.Drawing.Point(156, 218);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(103, 42);
            this.btnSnapshot.TabIndex = 5;
            this.btnSnapshot.Text = "Snapshot";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            // 
            // btnRecord
            // 
            this.btnRecord.Enabled = false;
            this.btnRecord.Location = new System.Drawing.Point(305, 218);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(103, 42);
            this.btnRecord.TabIndex = 6;
            this.btnRecord.UseVisualStyleBackColor = true;
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
            this.groupBoxVlcFactors.Enabled = false;
            this.groupBoxVlcFactors.Location = new System.Drawing.Point(6, 228);
            this.groupBoxVlcFactors.Name = "groupBoxVlcFactors";
            this.groupBoxVlcFactors.Size = new System.Drawing.Size(535, 53);
            this.groupBoxVlcFactors.TabIndex = 7;
            this.groupBoxVlcFactors.TabStop = false;
            // 
            // txtZoomF
            // 
            this.txtZoomF.Location = new System.Drawing.Point(383, 20);
            this.txtZoomF.Name = "txtZoomF";
            this.txtZoomF.Size = new System.Drawing.Size(50, 22);
            this.txtZoomF.TabIndex = 5;
            this.txtZoomF.Text = "100";
            this.txtZoomF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblZoomF
            // 
            this.lblZoomF.AutoSize = true;
            this.lblZoomF.Location = new System.Drawing.Point(346, 24);
            this.lblZoomF.Name = "lblZoomF";
            this.lblZoomF.Size = new System.Drawing.Size(31, 15);
            this.lblZoomF.TabIndex = 4;
            this.lblZoomF.Text = "Fov:";
            // 
            // lblHeightF
            // 
            this.lblHeightF.AutoSize = true;
            this.lblHeightF.Location = new System.Drawing.Point(194, 24);
            this.lblHeightF.Name = "lblHeightF";
            this.lblHeightF.Size = new System.Drawing.Size(46, 15);
            this.lblHeightF.TabIndex = 3;
            this.lblHeightF.Text = "Height:";
            // 
            // lblWidthF
            // 
            this.lblWidthF.AutoSize = true;
            this.lblWidthF.Location = new System.Drawing.Point(56, 23);
            this.lblWidthF.Name = "lblWidthF";
            this.lblWidthF.Size = new System.Drawing.Size(43, 15);
            this.lblWidthF.TabIndex = 2;
            this.lblWidthF.Text = "Width:";
            // 
            // textBoxHeightF
            // 
            this.textBoxHeightF.Location = new System.Drawing.Point(246, 21);
            this.textBoxHeightF.Name = "textBoxHeightF";
            this.textBoxHeightF.Size = new System.Drawing.Size(50, 22);
            this.textBoxHeightF.TabIndex = 1;
            this.textBoxHeightF.Text = "1";
            this.textBoxHeightF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxWidthF
            // 
            this.textBoxWidthF.Location = new System.Drawing.Point(105, 21);
            this.textBoxWidthF.Name = "textBoxWidthF";
            this.textBoxWidthF.Size = new System.Drawing.Size(50, 22);
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
            this.groupBoxBtns.Location = new System.Drawing.Point(554, 6);
            this.groupBoxBtns.Name = "groupBoxBtns";
            this.groupBoxBtns.Size = new System.Drawing.Size(660, 275);
            this.groupBoxBtns.TabIndex = 8;
            this.groupBoxBtns.TabStop = false;
            // 
            // chkFullVid
            // 
            this.chkFullVid.AutoSize = true;
            this.chkFullVid.Location = new System.Drawing.Point(552, 222);
            this.chkFullVid.Name = "chkFullVid";
            this.chkFullVid.Size = new System.Drawing.Size(84, 19);
            this.chkFullVid.TabIndex = 8;
            this.chkFullVid.Text = "Full screen";
            this.chkFullVid.UseVisualStyleBackColor = true;
            // 
            // chkPlayLoop
            // 
            this.chkPlayLoop.AutoSize = true;
            this.chkPlayLoop.Checked = true;
            this.chkPlayLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlayLoop.Enabled = false;
            this.chkPlayLoop.Location = new System.Drawing.Point(552, 197);
            this.chkPlayLoop.Name = "chkPlayLoop";
            this.chkPlayLoop.Size = new System.Drawing.Size(54, 19);
            this.chkPlayLoop.TabIndex = 7;
            this.chkPlayLoop.Text = "Loop";
            this.chkPlayLoop.UseVisualStyleBackColor = true;
            // 
            // tabLowDev
            // 
            this.tabLowDev.Controls.Add(this.tabLowCtrl);
            this.tabLowDev.Controls.Add(this.tabVlcDebug);
            this.tabLowDev.Controls.Add(this.tabVlcError);
            this.tabLowDev.Controls.Add(this.tabVlcInfo);
            this.tabLowDev.Controls.Add(this.tabWlcWarnings);
            this.tabLowDev.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabLowDev.Location = new System.Drawing.Point(5, 521);
            this.tabLowDev.Name = "tabLowDev";
            this.tabLowDev.SelectedIndex = 0;
            this.tabLowDev.Size = new System.Drawing.Size(1228, 355);
            this.tabLowDev.TabIndex = 9;
            // 
            // tabLowCtrl
            // 
            this.tabLowCtrl.BackColor = System.Drawing.Color.Transparent;
            this.tabLowCtrl.Controls.Add(this.lblAdd);
            this.tabLowCtrl.Controls.Add(this.groupBoxDev);
            this.tabLowCtrl.Controls.Add(this.groupBoxVlcFactors);
            this.tabLowCtrl.Controls.Add(this.groupBoxBtns);
            this.tabLowCtrl.Controls.Add(this.lblVlcNotify);
            this.tabLowCtrl.Location = new System.Drawing.Point(4, 24);
            this.tabLowCtrl.Name = "tabLowCtrl";
            this.tabLowCtrl.Padding = new System.Windows.Forms.Padding(3);
            this.tabLowCtrl.Size = new System.Drawing.Size(1220, 327);
            this.tabLowCtrl.TabIndex = 0;
            this.tabLowCtrl.Text = " Main Control Point ";
            // 
            // tabVlcDebug
            // 
            this.tabVlcDebug.Controls.Add(this.txtLVDebug);
            this.tabVlcDebug.Location = new System.Drawing.Point(4, 24);
            this.tabVlcDebug.Name = "tabVlcDebug";
            this.tabVlcDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabVlcDebug.Size = new System.Drawing.Size(1220, 327);
            this.tabVlcDebug.TabIndex = 1;
            this.tabVlcDebug.Text = " Debug ";
            this.tabVlcDebug.UseVisualStyleBackColor = true;
            // 
            // txtLVDebug
            // 
            this.txtLVDebug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLVDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLVDebug.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLVDebug.Location = new System.Drawing.Point(3, 3);
            this.txtLVDebug.Multiline = true;
            this.txtLVDebug.Name = "txtLVDebug";
            this.txtLVDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLVDebug.Size = new System.Drawing.Size(1214, 321);
            this.txtLVDebug.TabIndex = 0;
            // 
            // tabVlcError
            // 
            this.tabVlcError.Controls.Add(this.txtLVErrors);
            this.tabVlcError.Location = new System.Drawing.Point(4, 24);
            this.tabVlcError.Name = "tabVlcError";
            this.tabVlcError.Size = new System.Drawing.Size(1220, 327);
            this.tabVlcError.TabIndex = 2;
            this.tabVlcError.Text = "  Errors ";
            this.tabVlcError.UseVisualStyleBackColor = true;
            // 
            // txtLVErrors
            // 
            this.txtLVErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLVErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLVErrors.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLVErrors.Location = new System.Drawing.Point(0, 0);
            this.txtLVErrors.Multiline = true;
            this.txtLVErrors.Name = "txtLVErrors";
            this.txtLVErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLVErrors.Size = new System.Drawing.Size(1220, 327);
            this.txtLVErrors.TabIndex = 0;
            // 
            // tabVlcInfo
            // 
            this.tabVlcInfo.Controls.Add(this.txtLVInfo);
            this.tabVlcInfo.Location = new System.Drawing.Point(4, 24);
            this.tabVlcInfo.Name = "tabVlcInfo";
            this.tabVlcInfo.Size = new System.Drawing.Size(1220, 327);
            this.tabVlcInfo.TabIndex = 3;
            this.tabVlcInfo.Text = "  Info ";
            this.tabVlcInfo.UseVisualStyleBackColor = true;
            // 
            // txtLVInfo
            // 
            this.txtLVInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLVInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLVInfo.Location = new System.Drawing.Point(0, 0);
            this.txtLVInfo.Multiline = true;
            this.txtLVInfo.Name = "txtLVInfo";
            this.txtLVInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLVInfo.Size = new System.Drawing.Size(1220, 327);
            this.txtLVInfo.TabIndex = 0;
            // 
            // tabWlcWarnings
            // 
            this.tabWlcWarnings.Controls.Add(this.txtLVWarnings);
            this.tabWlcWarnings.Location = new System.Drawing.Point(4, 24);
            this.tabWlcWarnings.Name = "tabWlcWarnings";
            this.tabWlcWarnings.Size = new System.Drawing.Size(1220, 327);
            this.tabWlcWarnings.TabIndex = 4;
            this.tabWlcWarnings.Text = " Warnings ";
            this.tabWlcWarnings.UseVisualStyleBackColor = true;
            // 
            // txtLVWarnings
            // 
            this.txtLVWarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLVWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLVWarnings.Location = new System.Drawing.Point(0, 0);
            this.txtLVWarnings.Multiline = true;
            this.txtLVWarnings.Name = "txtLVWarnings";
            this.txtLVWarnings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLVWarnings.Size = new System.Drawing.Size(1220, 327);
            this.txtLVWarnings.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 875);
            this.Controls.Add(this.txtDev);
            this.Controls.Add(this.tabLowDev);
            this.Controls.Add(this.panelVlc);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera view";
            this.groupBoxDev.ResumeLayout(false);
            this.groupBoxDev.PerformLayout();
            this.groupBoxVlcFactors.ResumeLayout(false);
            this.groupBoxVlcFactors.PerformLayout();
            this.groupBoxBtns.ResumeLayout(false);
            this.groupBoxBtns.PerformLayout();
            this.tabLowDev.ResumeLayout(false);
            this.tabLowCtrl.ResumeLayout(false);
            this.tabLowCtrl.PerformLayout();
            this.tabVlcDebug.ResumeLayout(false);
            this.tabVlcDebug.PerformLayout();
            this.tabVlcError.ResumeLayout(false);
            this.tabVlcError.PerformLayout();
            this.tabVlcInfo.ResumeLayout(false);
            this.tabVlcInfo.PerformLayout();
            this.tabWlcWarnings.ResumeLayout(false);
            this.tabWlcWarnings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblVlcNotify;
        internal System.Windows.Forms.Panel panelVlc;
        internal System.Windows.Forms.Button btnDevConnect;
        internal System.Windows.Forms.TextBox txtDevPass;
        internal System.Windows.Forms.TextBox txtDevUser;
        internal System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblDevPass;
        private System.Windows.Forms.Label lblDevUser;
        private System.Windows.Forms.Label lblDevUrl;
        private System.Windows.Forms.GroupBox groupBoxDev;
        internal System.Windows.Forms.Button btnSnapshot;
        internal System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.GroupBox groupBoxVlcFactors;
        private System.Windows.Forms.Label lblHeightF;
        private System.Windows.Forms.Label lblWidthF;
        private System.Windows.Forms.TextBox textBoxHeightF;
        private System.Windows.Forms.TextBox textBoxWidthF;
        private System.Windows.Forms.TextBox txtZoomF;
        private System.Windows.Forms.Label lblZoomF;
        internal System.Windows.Forms.TextBox txtDev;
        internal System.Windows.Forms.ComboBox comboAddress;
        private System.Windows.Forms.GroupBox groupBoxBtns;
        internal System.Windows.Forms.CheckBox chkPlayLoop;
        internal System.Windows.Forms.CheckBox chkFullVid;
        internal System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.TabPage tabLowCtrl;
        private System.Windows.Forms.TabPage tabVlcDebug;
        private System.Windows.Forms.TabPage tabVlcError;
        private System.Windows.Forms.TabPage tabVlcInfo;
        private System.Windows.Forms.TabPage tabWlcWarnings;
        internal System.Windows.Forms.TextBox txtLVErrors;
        internal System.Windows.Forms.TextBox txtLVInfo;
        internal System.Windows.Forms.TextBox txtLVWarnings;
        internal System.Windows.Forms.TextBox txtLVDebug;
        internal System.Windows.Forms.TabControl tabLowDev;
    }
}