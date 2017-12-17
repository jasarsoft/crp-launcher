#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia
{
    partial class DownloadForm
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
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.progressOne = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.progressAll = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.labelValue = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.buttonStart = new Syncfusion.Windows.Forms.ButtonAdv();
            this.imageStreamerSlide = new Syncfusion.Windows.Forms.Tools.ImageStreamer();
            this.labelErrorValue = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelTotal = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelError = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelTotalValue = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.buttonClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.workerSlide = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.progressOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.ForeColor = System.Drawing.Color.DimGray;
            this.labelName.Location = new System.Drawing.Point(12, 384);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(514, 22);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Molimo vas kliknite na Poèni da bih ste zapoèeli process ažuriranja potrebnih dat" +
    "oteka...";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.progressOne.BorderColor = System.Drawing.Color.DarkGray;
            this.progressOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressOne.CustomText = "";
            this.progressOne.CustomWaitingRender = false;
            this.progressOne.FontColor = System.Drawing.Color.WhiteSmoke;
            this.progressOne.ForeColor = System.Drawing.Color.Firebrick;
            this.progressOne.ForegroundImage = null;
            this.progressOne.GradientEndColor = System.Drawing.Color.DarkRed;
            this.progressOne.GradientStartColor = System.Drawing.Color.IndianRed;
            this.progressOne.Location = new System.Drawing.Point(12, 409);
            this.progressOne.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressOne.Name = "progressOne";
            this.progressOne.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.progressOne.SegmentWidth = 12;
            this.progressOne.Size = new System.Drawing.Size(640, 22);
            this.progressOne.Step = 1;
            this.progressOne.TabIndex = 7;
            this.progressOne.ThemesEnabled = false;
            this.progressOne.TubeEndColor = System.Drawing.Color.Black;
            this.progressOne.TubeStartColor = System.Drawing.Color.Red;
            this.progressOne.WaitingGradientEnabled = true;
            this.progressOne.WaitingGradientInterval = 1;
            this.progressOne.WaitingGradientWidth = 114;
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
            this.progressAll.BorderColor = System.Drawing.Color.DarkGray;
            this.progressAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressAll.CustomText = null;
            this.progressAll.CustomWaitingRender = false;
            this.progressAll.FontColor = System.Drawing.Color.WhiteSmoke;
            this.progressAll.ForeColor = System.Drawing.Color.Firebrick;
            this.progressAll.ForegroundImage = null;
            this.progressAll.GradientEndColor = System.Drawing.Color.DarkRed;
            this.progressAll.GradientStartColor = System.Drawing.Color.IndianRed;
            this.progressAll.Location = new System.Drawing.Point(12, 437);
            this.progressAll.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressAll.Name = "progressAll";
            this.progressAll.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.progressAll.SegmentWidth = 12;
            this.progressAll.Size = new System.Drawing.Size(640, 22);
            this.progressAll.Step = 1;
            this.progressAll.TabIndex = 8;
            this.progressAll.ThemesEnabled = false;
            this.progressAll.TubeEndColor = System.Drawing.Color.Black;
            this.progressAll.TubeStartColor = System.Drawing.Color.Red;
            this.progressAll.Value = 100;
            this.progressAll.WaitingGradientEnabled = true;
            this.progressAll.WaitingGradientInterval = 1;
            this.progressAll.WaitingGradientWidth = 114;
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = false;
            this.labelValue.ForeColor = System.Drawing.Color.DimGray;
            this.labelValue.Location = new System.Drawing.Point(532, 384);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(120, 22);
            this.labelValue.TabIndex = 9;
            this.labelValue.Text = "0/0 B";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonStart
            // 
            this.buttonStart.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonStart.BackColor = System.Drawing.Color.Firebrick;
            this.buttonStart.BeforeTouchSize = new System.Drawing.Size(144, 36);
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonStart.IsBackStageButton = false;
            this.buttonStart.Location = new System.Drawing.Point(358, 474);
            this.buttonStart.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(144, 36);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Poèni";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // imageStreamerSlide
            // 
            this.imageStreamerSlide.AllowDragging = true;
            this.imageStreamerSlide.ImageStreamDirection = Syncfusion.Windows.Forms.Tools.ImageStreamer.StreamDirection.TopToBottom;
            this.imageStreamerSlide.InternalBackColor = System.Drawing.Color.Transparent;
            this.imageStreamerSlide.Location = new System.Drawing.Point(12, 12);
            this.imageStreamerSlide.Name = "imageStreamerSlide";
            this.imageStreamerSlide.Size = new System.Drawing.Size(640, 360);
            this.imageStreamerSlide.SliderSpeed = 10000;
            this.imageStreamerSlide.SlideShow = true;
            this.imageStreamerSlide.TabIndex = 11;
            this.imageStreamerSlide.TextAnimationDirection = Syncfusion.Windows.Forms.Tools.ImageStreamer.TextStreamDirection.RightToLeft;
            this.imageStreamerSlide.Visible = false;
            // 
            // labelErrorValue
            // 
            this.labelErrorValue.AutoSize = false;
            this.labelErrorValue.ForeColor = System.Drawing.Color.DimGray;
            this.labelErrorValue.Location = new System.Drawing.Point(138, 474);
            this.labelErrorValue.Name = "labelErrorValue";
            this.labelErrorValue.Size = new System.Drawing.Size(100, 18);
            this.labelErrorValue.TabIndex = 12;
            this.labelErrorValue.Text = "0";
            this.labelErrorValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = false;
            this.labelTotal.ForeColor = System.Drawing.Color.DimGray;
            this.labelTotal.Location = new System.Drawing.Point(12, 492);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(120, 18);
            this.labelTotal.TabIndex = 13;
            this.labelTotal.Text = "Ukupno skinuto:";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelError
            // 
            this.labelError.AutoSize = false;
            this.labelError.ForeColor = System.Drawing.Color.DimGray;
            this.labelError.Location = new System.Drawing.Point(12, 474);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(120, 18);
            this.labelError.TabIndex = 14;
            this.labelError.Text = "Ukupno grešaka:";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotalValue
            // 
            this.labelTotalValue.AutoSize = false;
            this.labelTotalValue.ForeColor = System.Drawing.Color.DimGray;
            this.labelTotalValue.Location = new System.Drawing.Point(138, 492);
            this.labelTotalValue.Name = "labelTotalValue";
            this.labelTotalValue.Size = new System.Drawing.Size(100, 18);
            this.labelTotalValue.TabIndex = 15;
            this.labelTotalValue.Text = "0/0 B";
            this.labelTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonClose
            // 
            this.buttonClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonClose.BackColor = System.Drawing.Color.Firebrick;
            this.buttonClose.BeforeTouchSize = new System.Drawing.Size(144, 36);
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClose.IsBackStageButton = false;
            this.buttonClose.Location = new System.Drawing.Point(508, 474);
            this.buttonClose.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(144, 36);
            this.buttonClose.TabIndex = 16;
            this.buttonClose.Text = "Odustani";
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = global::Jasarsoft.Columbia.Properties.Resources.logo_slide;
            this.pictureLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(640, 360);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLogo.TabIndex = 17;
            this.pictureLogo.TabStop = false;
            // 
            // workerSlide
            // 
            this.workerSlide.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerSlide_DoWork);
            this.workerSlide.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerSlide_RunWorkerCompleted);
            // 
            // DownloadForm
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
            this.ClientSize = new System.Drawing.Size(664, 522);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTotalValue);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelErrorValue);
            this.Controls.Add(this.imageStreamerSlide);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.progressAll);
            this.Controls.Add(this.progressOne);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.Name = "DownloadForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State RolePlay | Ažuriranje...";
            this.Shown += new System.EventHandler(this.DownloadForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.progressOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressOne;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressAll;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelValue;
        private Syncfusion.Windows.Forms.ButtonAdv buttonStart;
        private Syncfusion.Windows.Forms.Tools.ImageStreamer imageStreamerSlide;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelErrorValue;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelTotal;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelError;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelTotalValue;
        private Syncfusion.Windows.Forms.ButtonAdv buttonClose;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.ComponentModel.BackgroundWorker workerSlide;
    }
}