#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia.Launcher
{
    partial class CheckForm
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
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.progressLoad = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.workerFile = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.progressLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.ForeColor = System.Drawing.Color.DimGray;
            this.labelName.Location = new System.Drawing.Point(12, 109);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(340, 22);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Provjera æe uskoro zapoèeti...";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressLoad
            // 
            this.progressLoad.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.progressLoad.BackGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.progressLoad.BackgroundStyle = Syncfusion.Windows.Forms.Tools.ProgressBarBackgroundStyles.Gradient;
            this.progressLoad.BackMultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressLoad.BackSegments = false;
            this.progressLoad.BackTubeEndColor = System.Drawing.Color.White;
            this.progressLoad.BackTubeStartColor = System.Drawing.Color.LightGray;
            this.progressLoad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            this.progressLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressLoad.CustomText = null;
            this.progressLoad.CustomWaitingRender = false;
            this.progressLoad.FontColor = System.Drawing.Color.WhiteSmoke;
            this.progressLoad.ForeColor = System.Drawing.Color.Firebrick;
            this.progressLoad.ForegroundImage = null;
            this.progressLoad.GradientEndColor = System.Drawing.Color.DarkRed;
            this.progressLoad.GradientStartColor = System.Drawing.Color.IndianRed;
            this.progressLoad.Location = new System.Drawing.Point(12, 134);
            this.progressLoad.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressLoad.Name = "progressLoad";
            this.progressLoad.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.progressLoad.SegmentWidth = 10;
            this.progressLoad.Size = new System.Drawing.Size(340, 22);
            this.progressLoad.Step = 1;
            this.progressLoad.TabIndex = 7;
            this.progressLoad.ThemesEnabled = false;
            this.progressLoad.TubeEndColor = System.Drawing.Color.Black;
            this.progressLoad.TubeStartColor = System.Drawing.Color.Red;
            this.progressLoad.WaitingGradientInterval = 1;
            this.progressLoad.WaitingGradientWidth = 114;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(340, 85);
            this.pictureLogo.TabIndex = 6;
            this.pictureLogo.TabStop = false;
            // 
            // workerFile
            // 
            this.workerFile.WorkerReportsProgress = true;
            this.workerFile.WorkerSupportsCancellation = true;
            this.workerFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerFile_DoWork);
            this.workerFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerFile_ProgressChanged);
            this.workerFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerFile_RunWorkerCompleted);
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderColor = System.Drawing.Color.Firebrick;
            this.BorderThickness = 6;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.Firebrick;
            this.CaptionBarHeight = 24;
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CaptionForeColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(364, 168);
            this.ControlBox = false;
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.progressLoad);
            this.Controls.Add(this.pictureLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "CheckForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State | Provjera...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CheckForm_Load);
            this.Shown += new System.EventHandler(this.CheckForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.progressLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressLoad;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.ComponentModel.BackgroundWorker workerFile;
    }
}