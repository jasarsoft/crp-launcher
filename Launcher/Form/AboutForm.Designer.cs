#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia
{
    partial class AboutForm
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
            this.buttonClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.horizonalLine = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelTitle = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.textboxTitle = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.textboxVersion = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.labelLicense = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.textboxDate = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.textboxCopyright = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.textboxLicense = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.labelCopyright = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelDeveloper = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelData = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.textboxDeveloper = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.labelVersion = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.textboxDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)(this.textboxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxCopyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxDeveloper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonClose.BackColor = System.Drawing.Color.Firebrick;
            this.buttonClose.BeforeTouchSize = new System.Drawing.Size(340, 59);
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.IsBackStageButton = false;
            this.buttonClose.Location = new System.Drawing.Point(12, 254);
            this.buttonClose.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(340, 59);
            this.buttonClose.TabIndex = 14;
            this.buttonClose.Text = "ZATVORI";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // horizonalLine
            // 
            this.horizonalLine.AutoSize = false;
            this.horizonalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizonalLine.Location = new System.Drawing.Point(12, 249);
            this.horizonalLine.Name = "horizonalLine";
            this.horizonalLine.Size = new System.Drawing.Size(340, 2);
            this.horizonalLine.TabIndex = 13;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = false;
            this.labelTitle.Location = new System.Drawing.Point(12, 21);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(120, 22);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Naziv softvera:";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textboxTitle
            // 
            this.textboxTitle.BackColor = System.Drawing.Color.White;
            this.textboxTitle.BeforeTouchSize = new System.Drawing.Size(214, 22);
            this.textboxTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxTitle.ForeColor = System.Drawing.Color.Black;
            this.textboxTitle.Location = new System.Drawing.Point(138, 21);
            this.textboxTitle.MaxLength = 128;
            this.textboxTitle.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxTitle.Name = "textboxTitle";
            this.textboxTitle.ReadOnly = true;
            this.textboxTitle.Size = new System.Drawing.Size(214, 22);
            this.textboxTitle.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxTitle.TabIndex = 6;
            this.textboxTitle.Text = "Columbia State Launcher";
            this.textboxTitle.WordWrap = false;
            // 
            // textboxVersion
            // 
            this.textboxVersion.BackColor = System.Drawing.Color.White;
            this.textboxVersion.BeforeTouchSize = new System.Drawing.Size(214, 22);
            this.textboxVersion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxVersion.ForeColor = System.Drawing.Color.Black;
            this.textboxVersion.Location = new System.Drawing.Point(138, 49);
            this.textboxVersion.MaxLength = 128;
            this.textboxVersion.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxVersion.Name = "textboxVersion";
            this.textboxVersion.ReadOnly = true;
            this.textboxVersion.Size = new System.Drawing.Size(214, 22);
            this.textboxVersion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxVersion.TabIndex = 7;
            this.textboxVersion.Text = "1.0.0.0 Alpha";
            this.textboxVersion.WordWrap = false;
            // 
            // labelLicense
            // 
            this.labelLicense.AutoSize = false;
            this.labelLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLicense.Location = new System.Drawing.Point(12, 133);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(120, 22);
            this.labelLicense.TabIndex = 4;
            this.labelLicense.Text = "Licenca korištenja:";
            this.labelLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLicense.Click += new System.EventHandler(this.LabelLicense_Click);
            // 
            // textboxDate
            // 
            this.textboxDate.BackColor = System.Drawing.Color.White;
            this.textboxDate.BeforeTouchSize = new System.Drawing.Size(214, 22);
            this.textboxDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxDate.ForeColor = System.Drawing.Color.Black;
            this.textboxDate.Location = new System.Drawing.Point(138, 77);
            this.textboxDate.MaxLength = 128;
            this.textboxDate.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxDate.Name = "textboxDate";
            this.textboxDate.ReadOnly = true;
            this.textboxDate.Size = new System.Drawing.Size(214, 22);
            this.textboxDate.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxDate.TabIndex = 8;
            this.textboxDate.Text = "20. oktobar 2017";
            this.textboxDate.WordWrap = false;
            // 
            // textboxCopyright
            // 
            this.textboxCopyright.BackColor = System.Drawing.Color.White;
            this.textboxCopyright.BeforeTouchSize = new System.Drawing.Size(214, 22);
            this.textboxCopyright.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxCopyright.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxCopyright.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxCopyright.ForeColor = System.Drawing.Color.Black;
            this.textboxCopyright.Location = new System.Drawing.Point(138, 105);
            this.textboxCopyright.MaxLength = 128;
            this.textboxCopyright.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxCopyright.Name = "textboxCopyright";
            this.textboxCopyright.ReadOnly = true;
            this.textboxCopyright.Size = new System.Drawing.Size(214, 22);
            this.textboxCopyright.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxCopyright.TabIndex = 9;
            this.textboxCopyright.Text = "Columbia State Team";
            this.textboxCopyright.WordWrap = false;
            // 
            // textboxLicense
            // 
            this.textboxLicense.BackColor = System.Drawing.Color.White;
            this.textboxLicense.BeforeTouchSize = new System.Drawing.Size(214, 22);
            this.textboxLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxLicense.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxLicense.ForeColor = System.Drawing.Color.Black;
            this.textboxLicense.Location = new System.Drawing.Point(138, 133);
            this.textboxLicense.MaxLength = 128;
            this.textboxLicense.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxLicense.Name = "textboxLicense";
            this.textboxLicense.ReadOnly = true;
            this.textboxLicense.Size = new System.Drawing.Size(214, 22);
            this.textboxLicense.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxLicense.TabIndex = 10;
            this.textboxLicense.Text = "Vlasnièki softver";
            this.textboxLicense.WordWrap = false;
            this.textboxLicense.Click += new System.EventHandler(this.TextboxLicense_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = false;
            this.labelCopyright.Location = new System.Drawing.Point(12, 105);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(120, 22);
            this.labelCopyright.TabIndex = 3;
            this.labelCopyright.Text = "Autorsko pravo:";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDeveloper
            // 
            this.labelDeveloper.AutoSize = false;
            this.labelDeveloper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDeveloper.Location = new System.Drawing.Point(12, 161);
            this.labelDeveloper.Name = "labelDeveloper";
            this.labelDeveloper.Size = new System.Drawing.Size(120, 22);
            this.labelDeveloper.TabIndex = 5;
            this.labelDeveloper.Text = "Programer i dizajner:";
            this.labelDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDeveloper.Click += new System.EventHandler(this.LabelDeveloper_Click);
            // 
            // labelData
            // 
            this.labelData.AutoSize = false;
            this.labelData.Location = new System.Drawing.Point(12, 77);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(120, 22);
            this.labelData.TabIndex = 2;
            this.labelData.Text = "Datum izmjene:";
            this.labelData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textboxDeveloper
            // 
            this.textboxDeveloper.BackColor = System.Drawing.Color.White;
            this.textboxDeveloper.BeforeTouchSize = new System.Drawing.Size(214, 22);
            this.textboxDeveloper.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxDeveloper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxDeveloper.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxDeveloper.ForeColor = System.Drawing.Color.Black;
            this.textboxDeveloper.Location = new System.Drawing.Point(138, 161);
            this.textboxDeveloper.MaxLength = 128;
            this.textboxDeveloper.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxDeveloper.Name = "textboxDeveloper";
            this.textboxDeveloper.OverflowIndicatorToolTipText = "Kliknite da posjetite github stranicu autora";
            this.textboxDeveloper.ReadOnly = true;
            this.textboxDeveloper.Size = new System.Drawing.Size(214, 22);
            this.textboxDeveloper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxDeveloper.TabIndex = 11;
            this.textboxDeveloper.Text = "Edin (jasarsoft) Jašareviæ";
            this.textboxDeveloper.WordWrap = false;
            this.textboxDeveloper.Click += new System.EventHandler(this.TextboxDeveloper_Click);
            this.textboxDeveloper.MouseHover += new System.EventHandler(this.TextboxDeveloper_MouseHover);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = false;
            this.labelVersion.Location = new System.Drawing.Point(12, 49);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(120, 22);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "Verzija sofvera:";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textboxDescription
            // 
            this.textboxDescription.BackColor = System.Drawing.Color.White;
            this.textboxDescription.BeforeTouchSize = new System.Drawing.Size(214, 22);
            this.textboxDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxDescription.ForeColor = System.Drawing.Color.Black;
            this.textboxDescription.Location = new System.Drawing.Point(12, 189);
            this.textboxDescription.MaxLength = 1024;
            this.textboxDescription.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxDescription.Multiline = true;
            this.textboxDescription.Name = "textboxDescription";
            this.textboxDescription.ReadOnly = true;
            this.textboxDescription.Size = new System.Drawing.Size(340, 48);
            this.textboxDescription.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxDescription.TabIndex = 12;
            this.textboxDescription.Text = "SAMP Columbia State Launcher napravljen u cilju lakšeg korištenja, bezbjednog pri" +
    "stupa te automatski ažuriranja SAMP Columbia State moda za GTA San Andreas Multi" +
    "player.";
            // 
            // AboutForm
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
            this.ClientSize = new System.Drawing.Size(364, 325);
            this.Controls.Add(this.textboxDescription);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.textboxDeveloper);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelDeveloper);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.textboxLicense);
            this.Controls.Add(this.textboxCopyright);
            this.Controls.Add(this.textboxDate);
            this.Controls.Add(this.labelLicense);
            this.Controls.Add(this.textboxVersion);
            this.Controls.Add(this.textboxTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.horizonalLine);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State RolePlay | Launcher";
            this.Load += new System.EventHandler(this.AboutLauncher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textboxTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxCopyright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxDeveloper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxDescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv buttonClose;
        private Syncfusion.Windows.Forms.Tools.AutoLabel horizonalLine;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelTitle;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxTitle;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxVersion;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelLicense;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxDate;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxCopyright;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxLicense;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelCopyright;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelDeveloper;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelData;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxDeveloper;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelVersion;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxDescription;

    }
}