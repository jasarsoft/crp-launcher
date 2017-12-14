#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia
{
    partial class FileForm
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
            this.labelDescription = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.gridListControlFiles = new Syncfusion.Windows.Forms.Grid.GridListControl();
            this.labelUnknown = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelMissed = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelIncorrect = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelTotal = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.buttonOK = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.gridListControlFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.AutoSize = false;
            this.labelDescription.ForeColor = System.Drawing.Color.DimGray;
            this.labelDescription.Gap = 2;
            this.labelDescription.Location = new System.Drawing.Point(12, 12);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Top;
            this.labelDescription.Size = new System.Drawing.Size(604, 28);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Sljedeæa lista sadrži detaljan izvještaj o vašem trenutnom stanju Columbia State " +
    "modifikacije:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridListControlFiles
            // 
            this.gridListControlFiles.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(94)))), ((int)(((byte)(171)))), ((int)(((byte)(222)))));
            this.gridListControlFiles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridListControlFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridListControlFiles.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.gridListControlFiles.HeaderBackColor = System.Drawing.Color.Silver;
            this.gridListControlFiles.HeaderTextColor = System.Drawing.Color.Black;
            this.gridListControlFiles.ItemHeight = 16;
            this.gridListControlFiles.Location = new System.Drawing.Point(12, 46);
            this.gridListControlFiles.MultiColumn = true;
            this.gridListControlFiles.Name = "gridListControlFiles";
            this.gridListControlFiles.Properties.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridListControlFiles.Properties.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.gridListControlFiles.SelectedIndex = -1;
            this.gridListControlFiles.Size = new System.Drawing.Size(604, 252);
            this.gridListControlFiles.TabIndex = 2;
            this.gridListControlFiles.TopIndex = 0;
            // 
            // labelUnknown
            // 
            this.labelUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUnknown.AutoSize = false;
            this.labelUnknown.ForeColor = System.Drawing.Color.DimGray;
            this.labelUnknown.Gap = 2;
            this.labelUnknown.Location = new System.Drawing.Point(12, 310);
            this.labelUnknown.Name = "labelUnknown";
            this.labelUnknown.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Top;
            this.labelUnknown.Size = new System.Drawing.Size(120, 18);
            this.labelUnknown.TabIndex = 3;
            this.labelUnknown.Text = "Nepoznatih: 0";
            this.labelUnknown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMissed
            // 
            this.labelMissed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMissed.AutoSize = false;
            this.labelMissed.ForeColor = System.Drawing.Color.DimGray;
            this.labelMissed.Gap = 2;
            this.labelMissed.Location = new System.Drawing.Point(12, 328);
            this.labelMissed.Name = "labelMissed";
            this.labelMissed.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Top;
            this.labelMissed.Size = new System.Drawing.Size(120, 18);
            this.labelMissed.TabIndex = 4;
            this.labelMissed.Text = "Nedostajuæi: 0";
            this.labelMissed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelIncorrect
            // 
            this.labelIncorrect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIncorrect.AutoSize = false;
            this.labelIncorrect.ForeColor = System.Drawing.Color.DimGray;
            this.labelIncorrect.Gap = 2;
            this.labelIncorrect.Location = new System.Drawing.Point(138, 310);
            this.labelIncorrect.Name = "labelIncorrect";
            this.labelIncorrect.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Top;
            this.labelIncorrect.Size = new System.Drawing.Size(120, 18);
            this.labelIncorrect.TabIndex = 5;
            this.labelIncorrect.Text = "Neispravnih: 0";
            this.labelIncorrect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotal.AutoSize = false;
            this.labelTotal.ForeColor = System.Drawing.Color.DimGray;
            this.labelTotal.Gap = 2;
            this.labelTotal.Location = new System.Drawing.Point(138, 328);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Top;
            this.labelTotal.Size = new System.Drawing.Size(120, 18);
            this.labelTotal.TabIndex = 6;
            this.labelTotal.Text = "Ukupno sve: 0";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOK
            // 
            this.buttonOK.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonOK.BackColor = System.Drawing.Color.Firebrick;
            this.buttonOK.BeforeTouchSize = new System.Drawing.Size(108, 36);
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOK.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonOK.IsBackStageButton = false;
            this.buttonOK.Location = new System.Drawing.Point(508, 310);
            this.buttonOK.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(108, 36);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "Uredu";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            this.buttonOK.MouseLeave += new System.EventHandler(this.buttonOK_MouseLeave);
            this.buttonOK.MouseHover += new System.EventHandler(this.buttonOK_MouseHover);
            // 
            // FileForm
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
            this.ClientSize = new System.Drawing.Size(628, 358);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelIncorrect);
            this.Controls.Add(this.labelMissed);
            this.Controls.Add(this.labelUnknown);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.gridListControlFiles);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.Name = "FileForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.Text = "SAMP Columbia State | Zapisnik";
            this.Load += new System.EventHandler(this.FileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridListControlFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel labelDescription;
        private Syncfusion.Windows.Forms.Grid.GridListControl gridListControlFiles;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelUnknown;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelMissed;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelIncorrect;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelTotal;
        private Syncfusion.Windows.Forms.ButtonAdv buttonOK;
    }
}