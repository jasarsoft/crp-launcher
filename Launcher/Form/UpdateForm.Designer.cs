#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia.Launcher
{
    partial class UpdateForm
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
            this.labelValue = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.progressAll = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.progressOne = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.workerUpdate = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.progressAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = false;
            this.labelValue.ForeColor = System.Drawing.Color.DimGray;
            this.labelValue.Location = new System.Drawing.Point(252, 109);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(100, 22);
            this.labelValue.TabIndex = 14;
            this.labelValue.Text = "0/0 B";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressAll
            // 
            this.progressAll.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.progressAll.BackGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.progressAll.BackgroundStyle = Syncfusion.Windows.Forms.Tools.ProgressBarBackgroundStyles.Gradient;
            this.progressAll.BackMultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressAll.BackSegments = false;
            this.progressAll.BackTubeEndColor = System.Drawing.Color.White;
            this.progressAll.BackTubeStartColor = System.Drawing.Color.LightGray;
            this.progressAll.BorderColor = System.Drawing.Color.AliceBlue;
            this.progressAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressAll.CustomText = null;
            this.progressAll.CustomWaitingRender = false;
            this.progressAll.FontColor = System.Drawing.Color.WhiteSmoke;
            this.progressAll.ForeColor = System.Drawing.Color.Firebrick;
            this.progressAll.ForegroundImage = null;
            this.progressAll.GradientEndColor = System.Drawing.Color.DarkRed;
            this.progressAll.GradientStartColor = System.Drawing.Color.IndianRed;
            this.progressAll.Location = new System.Drawing.Point(12, 162);
            this.progressAll.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressAll.Name = "progressAll";
            this.progressAll.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.progressAll.SegmentWidth = 12;
            this.progressAll.Size = new System.Drawing.Size(340, 22);
            this.progressAll.Step = 1;
            this.progressAll.TabIndex = 13;
            this.progressAll.ThemesEnabled = false;
            this.progressAll.TubeEndColor = System.Drawing.Color.Black;
            this.progressAll.TubeStartColor = System.Drawing.Color.Red;
            this.progressAll.Value = 100;
            this.progressAll.WaitingGradientEnabled = true;
            this.progressAll.WaitingGradientInterval = 1;
            this.progressAll.WaitingGradientWidth = 114;
            // 
            // progressOne
            // 
            this.progressOne.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.progressOne.BackGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.progressOne.BackgroundStyle = Syncfusion.Windows.Forms.Tools.ProgressBarBackgroundStyles.Gradient;
            this.progressOne.BackMultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressOne.BackSegments = false;
            this.progressOne.BackTubeEndColor = System.Drawing.Color.White;
            this.progressOne.BackTubeStartColor = System.Drawing.Color.LightGray;
            this.progressOne.BorderColor = System.Drawing.Color.AliceBlue;
            this.progressOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressOne.CustomText = "";
            this.progressOne.CustomWaitingRender = false;
            this.progressOne.FontColor = System.Drawing.Color.WhiteSmoke;
            this.progressOne.ForeColor = System.Drawing.Color.Firebrick;
            this.progressOne.ForegroundImage = null;
            this.progressOne.GradientEndColor = System.Drawing.Color.DarkRed;
            this.progressOne.GradientStartColor = System.Drawing.Color.IndianRed;
            this.progressOne.Location = new System.Drawing.Point(12, 134);
            this.progressOne.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressOne.Name = "progressOne";
            this.progressOne.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.progressOne.SegmentWidth = 12;
            this.progressOne.Size = new System.Drawing.Size(340, 22);
            this.progressOne.Step = 1;
            this.progressOne.TabIndex = 12;
            this.progressOne.ThemesEnabled = false;
            this.progressOne.TubeEndColor = System.Drawing.Color.Black;
            this.progressOne.TubeStartColor = System.Drawing.Color.Red;
            this.progressOne.WaitingGradientEnabled = true;
            this.progressOne.WaitingGradientInterval = 1;
            this.progressOne.WaitingGradientWidth = 114;
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.ForeColor = System.Drawing.Color.DimGray;
            this.labelName.Location = new System.Drawing.Point(12, 109);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(234, 22);
            this.labelName.TabIndex = 11;
            this.labelName.Text = "Naziv:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(340, 85);
            this.pictureLogo.TabIndex = 10;
            this.pictureLogo.TabStop = false;
            // 
            // workerUpdate
            // 
            this.workerUpdate.WorkerReportsProgress = true;
            this.workerUpdate.WorkerSupportsCancellation = true;
            // 
            // UpdateForm
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
            this.ClientSize = new System.Drawing.Size(364, 196);
            this.ControlBox = false;
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.progressAll);
            this.Controls.Add(this.progressOne);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State | Ažuriranje...";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.UpdateForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.progressAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel labelValue;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressAll;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressOne;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.ComponentModel.BackgroundWorker workerUpdate;
    }
}