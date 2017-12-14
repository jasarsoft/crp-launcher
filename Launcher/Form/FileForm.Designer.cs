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
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.gridListControl1 = new Syncfusion.Windows.Forms.Grid.GridListControl();
            this.labelUnknown = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelMissed = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelValid = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelTotal = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.buttonOK = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.gridListControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = false;
            this.labelName.ForeColor = System.Drawing.Color.DimGray;
            this.labelName.Gap = 2;
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Top;
            this.labelName.Size = new System.Drawing.Size(604, 28);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Sljedeæa lista sadrži detaljan izvještaj o vašem trenutnom stanju Columbia State " +
    "modifikacije:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridListControl1
            // 
            this.gridListControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(94)))), ((int)(((byte)(171)))), ((int)(((byte)(222)))));
            this.gridListControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridListControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridListControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.gridListControl1.HeaderBackColor = System.Drawing.Color.Silver;
            this.gridListControl1.HeaderTextColor = System.Drawing.Color.Black;
            this.gridListControl1.ItemHeight = 16;
            this.gridListControl1.Location = new System.Drawing.Point(12, 46);
            this.gridListControl1.MultiColumn = true;
            this.gridListControl1.Name = "gridListControl1";
            this.gridListControl1.Properties.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridListControl1.Properties.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.gridListControl1.SelectedIndex = -1;
            this.gridListControl1.Size = new System.Drawing.Size(604, 252);
            this.gridListControl1.TabIndex = 2;
            this.gridListControl1.TopIndex = 0;
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
            // labelValid
            // 
            this.labelValid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValid.AutoSize = false;
            this.labelValid.ForeColor = System.Drawing.Color.DimGray;
            this.labelValid.Gap = 2;
            this.labelValid.Location = new System.Drawing.Point(138, 310);
            this.labelValid.Name = "labelValid";
            this.labelValid.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Top;
            this.labelValid.Size = new System.Drawing.Size(120, 18);
            this.labelValid.TabIndex = 5;
            this.labelValid.Text = "Validni: 0";
            this.labelValid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.labelTotal.Text = "Ukupno: 0";
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
            this.Controls.Add(this.labelValid);
            this.Controls.Add(this.labelMissed);
            this.Controls.Add(this.labelUnknown);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.gridListControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.Name = "FileForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.Text = "SAMP Columbia State | Zapisnik";
            this.Load += new System.EventHandler(this.FileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridListControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private Syncfusion.Windows.Forms.Grid.GridListControl gridListControl1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelUnknown;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelMissed;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelValid;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelTotal;
        private Syncfusion.Windows.Forms.ButtonAdv buttonOK;
    }
}