#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.ColumbiaGUI
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.progressLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.ForeColor = System.Drawing.Color.DimGray;
            this.labelName.Location = new System.Drawing.Point(12, 124);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(340, 22);
            this.labelName.TabIndex = 1;
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
            this.progressLoad.BorderColor = System.Drawing.Color.DarkGray;
            this.progressLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressLoad.CustomText = null;
            this.progressLoad.CustomWaitingRender = false;
            this.progressLoad.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.progressLoad.FontColor = System.Drawing.Color.WhiteSmoke;
            this.progressLoad.ForegroundImage = null;
            this.progressLoad.GradientEndColor = System.Drawing.Color.DarkRed;
            this.progressLoad.GradientStartColor = System.Drawing.Color.IndianRed;
            this.progressLoad.Location = new System.Drawing.Point(12, 149);
            this.progressLoad.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressLoad.Name = "progressLoad";
            this.progressLoad.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.progressLoad.SegmentWidth = 10;
            this.progressLoad.Size = new System.Drawing.Size(340, 22);
            this.progressLoad.Step = 1;
            this.progressLoad.TabIndex = 2;
            this.progressLoad.ThemesEnabled = false;
            this.progressLoad.TubeEndColor = System.Drawing.Color.Black;
            this.progressLoad.TubeStartColor = System.Drawing.Color.Red;
            this.progressLoad.WaitingGradientInterval = 1;
            this.progressLoad.WaitingGradientWidth = 114;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 100);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderColor = System.Drawing.Color.Firebrick;
            this.BorderThickness = 4;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.Firebrick;
            this.CaptionBarHeight = 24;
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CaptionForeColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(364, 183);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.progressLoad);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "CheckForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia RolePlay | Provjera...";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.progressLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}