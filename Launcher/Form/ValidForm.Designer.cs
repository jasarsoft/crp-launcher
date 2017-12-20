#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia
{
    partial class ValidForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidForm));
            this.progressLoad = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.workerFile = new System.ComponentModel.BackgroundWorker();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.labelDescription = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.buttonClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.labelError = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelValue = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)(this.progressLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
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
            this.progressLoad.Location = new System.Drawing.Point(12, 261);
            this.progressLoad.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressLoad.Name = "progressLoad";
            this.progressLoad.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.progressLoad.SegmentWidth = 10;
            this.progressLoad.Size = new System.Drawing.Size(340, 22);
            this.progressLoad.Step = 1;
            this.progressLoad.TabIndex = 3;
            this.progressLoad.ThemesEnabled = false;
            this.progressLoad.TubeEndColor = System.Drawing.Color.Black;
            this.progressLoad.TubeStartColor = System.Drawing.Color.Red;
            this.progressLoad.WaitingGradientInterval = 1;
            this.progressLoad.WaitingGradientWidth = 114;
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.ForeColor = System.Drawing.Color.DimGray;
            this.labelName.Location = new System.Drawing.Point(12, 236);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(340, 22);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Validacija æe automatski zapoèeti...";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // workerFile
            // 
            this.workerFile.WorkerReportsProgress = true;
            this.workerFile.WorkerSupportsCancellation = true;
            this.workerFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerFile_DoWork);
            this.workerFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.WorkerFile_ProgressChanged);
            this.workerFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerFile_RunWorkerCompleted);
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(340, 100);
            this.pictureLogo.TabIndex = 2;
            this.pictureLogo.TabStop = false;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = false;
            this.labelDescription.ForeColor = System.Drawing.Color.DimGray;
            this.labelDescription.Location = new System.Drawing.Point(12, 115);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(340, 112);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = resources.GetString("labelDescription.Text");
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonClose
            // 
            this.buttonClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonClose.BackColor = System.Drawing.Color.Firebrick;
            this.buttonClose.BeforeTouchSize = new System.Drawing.Size(108, 36);
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClose.IsBackStageButton = false;
            this.buttonClose.Location = new System.Drawing.Point(244, 289);
            this.buttonClose.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(108, 36);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Odustani";
            // 
            // labelError
            // 
            this.labelError.AutoSize = false;
            this.labelError.ForeColor = System.Drawing.Color.DimGray;
            this.labelError.Location = new System.Drawing.Point(12, 289);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(95, 36);
            this.labelError.TabIndex = 8;
            this.labelError.Text = "Ukupno grešaka:";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = false;
            this.labelValue.ForeColor = System.Drawing.Color.DimGray;
            this.labelValue.Location = new System.Drawing.Point(113, 289);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(80, 36);
            this.labelValue.TabIndex = 9;
            this.labelValue.Text = "0";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ValidForm
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
            this.CaptionButtonHoverColor = System.Drawing.Color.Black;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CaptionForeColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(364, 337);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.progressLoad);
            this.Controls.Add(this.pictureLogo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "ValidForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State | Validacija...";
            this.Load += new System.EventHandler(this.ValidForm_Load);
            this.Shown += new System.EventHandler(this.ValidForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.progressLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLogo;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressLoad;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private System.ComponentModel.BackgroundWorker workerFile;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelDescription;
        private Syncfusion.Windows.Forms.ButtonAdv buttonClose;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelError;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelValue;
    }
}