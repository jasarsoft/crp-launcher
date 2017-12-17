#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia.Host
{
    partial class MainForm
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
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.workerStream = new System.ComponentModel.BackgroundWorker();
            this.workerColumbia = new System.ComponentModel.BackgroundWorker();
            this.labelCopyright = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLogo
            // 
            this.pictureLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(340, 85);
            this.pictureLogo.TabIndex = 4;
            this.pictureLogo.TabStop = false;
            // 
            // workerStream
            // 
            this.workerStream.WorkerSupportsCancellation = true;
            this.workerStream.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerStream_DoWork);
            this.workerStream.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerStream_RunWorkerCompleted);
            // 
            // workerColumbia
            // 
            this.workerColumbia.WorkerSupportsCancellation = true;
            this.workerColumbia.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerColumbia_DoWork);
            this.workerColumbia.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerColumbia_RunWorkerCompleted);
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = false;
            this.labelCopyright.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCopyright.ForeColor = System.Drawing.Color.Gray;
            this.labelCopyright.Location = new System.Drawing.Point(12, 109);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(340, 50);
            this.labelCopyright.TabIndex = 7;
            this.labelCopyright.Text = "Molimo vas saèekajte dok se Columbia State launcher uèita.\r\nZa sva pitanja, suges" +
    "tije, kritike i slièno posjetite naš forum.\r\nSva prava zadržana od strane Columb" +
    "ia State time i treæi strana.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderColor = System.Drawing.Color.Firebrick;
            this.BorderThickness = 6;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.Firebrick;
            this.CaptionBarHeight = 24;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CaptionForeColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(364, 168);
            this.ControlBox = false;
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.pictureLogo);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State RolePlay | Host";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLogo;
        private System.ComponentModel.BackgroundWorker workerStream;
        private System.ComponentModel.BackgroundWorker workerColumbia;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelCopyright;
    }
}