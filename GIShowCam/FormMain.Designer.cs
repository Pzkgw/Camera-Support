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
            this.SuspendLayout();
            // 
            // labelPlaybackPosition
            // 
            this.labelPlaybackPosition.AutoSize = true;
            this.labelPlaybackPosition.Location = new System.Drawing.Point(49, 483);
            this.labelPlaybackPosition.Name = "labelPlaybackPosition";
            this.labelPlaybackPosition.Size = new System.Drawing.Size(0, 13);
            this.labelPlaybackPosition.TabIndex = 0;
            // 
            // panelVlc
            // 
            this.panelVlc.Location = new System.Drawing.Point(375, 12);
            this.panelVlc.Name = "panelVlc";
            this.panelVlc.Size = new System.Drawing.Size(579, 483);
            this.panelVlc.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 524);
            this.Controls.Add(this.panelVlc);
            this.Controls.Add(this.labelPlaybackPosition);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlaybackPosition;
        private System.Windows.Forms.Panel panelVlc;
    }
}