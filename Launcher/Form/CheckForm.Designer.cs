#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForm));
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.progressLoad = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.workerFile = new System.ComponentModel.BackgroundWorker();
            this.labelDescription = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelHorizontalLine = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.buttonStart = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonClose = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.progressLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.ForeColor = System.Drawing.Color.DimGray;
            this.labelName.Location = new System.Drawing.Point(12, 201);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(340, 22);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Molimo vas kliknite na Poèni da pokrente provjeru...";
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
            this.progressLoad.Location = new System.Drawing.Point(12, 226);
            this.progressLoad.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressLoad.Name = "progressLoad";
            this.progressLoad.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.progressLoad.SegmentWidth = 10;
            this.progressLoad.Size = new System.Drawing.Size(340, 22);
            this.progressLoad.Step = 1;
            this.progressLoad.TabIndex = 4;
            this.progressLoad.ThemesEnabled = false;
            this.progressLoad.TubeEndColor = System.Drawing.Color.Black;
            this.progressLoad.TubeStartColor = System.Drawing.Color.Red;
            this.progressLoad.WaitingGradientInterval = 1;
            this.progressLoad.WaitingGradientWidth = 114;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(340, 100);
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
            // labelDescription
            // 
            this.labelDescription.AutoSize = false;
            this.labelDescription.ForeColor = System.Drawing.Color.DimGray;
            this.labelDescription.Location = new System.Drawing.Point(12, 115);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(340, 75);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = resources.GetString("labelDescription.Text");
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHorizontalLine
            // 
            this.labelHorizontalLine.AutoSize = false;
            this.labelHorizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHorizontalLine.ForeColor = System.Drawing.Color.DimGray;
            this.labelHorizontalLine.Location = new System.Drawing.Point(12, 190);
            this.labelHorizontalLine.Name = "labelHorizontalLine";
            this.labelHorizontalLine.Size = new System.Drawing.Size(340, 2);
            this.labelHorizontalLine.TabIndex = 2;
            this.labelHorizontalLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonStart
            // 
            this.buttonStart.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonStart.BackColor = System.Drawing.Color.Firebrick;
            this.buttonStart.BeforeTouchSize = new System.Drawing.Size(108, 36);
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonStart.IsBackStageButton = false;
            this.buttonStart.Location = new System.Drawing.Point(130, 264);
            this.buttonStart.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(108, 36);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Poèni";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.buttonStart.MouseLeave += new System.EventHandler(this.buttonStart_MouseLeave);
            this.buttonStart.MouseHover += new System.EventHandler(this.buttonStart_MouseHover);
            // 
            // buttonClose
            // 
            this.buttonClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonClose.BackColor = System.Drawing.Color.Firebrick;
            this.buttonClose.BeforeTouchSize = new System.Drawing.Size(108, 36);
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClose.IsBackStageButton = false;
            this.buttonClose.Location = new System.Drawing.Point(244, 264);
            this.buttonClose.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(108, 36);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Zatvori";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            this.buttonClose.MouseHover += new System.EventHandler(this.buttonClose_MouseHover);
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
            this.CaptionButtonColor = System.Drawing.Color.Black;
            this.CaptionButtonHoverColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CaptionForeColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(364, 312);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelHorizontalLine);
            this.Controls.Add(this.labelDescription);
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
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State | Provjera...";
            this.Load += new System.EventHandler(this.CheckForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.progressLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressLoad;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.ComponentModel.BackgroundWorker workerFile;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelHorizontalLine;
        private Syncfusion.Windows.Forms.ButtonAdv buttonStart;
        private Syncfusion.Windows.Forms.ButtonAdv buttonClose;
    }
}