#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia
{
    partial class RulesForm
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
            this.textboxDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.buttonClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.horizonalLine = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.comboboxRules = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.textboxDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textboxDescription
            // 
            this.textboxDescription.BackColor = System.Drawing.Color.White;
            this.textboxDescription.BeforeTouchSize = new System.Drawing.Size(340, 133);
            this.textboxDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxDescription.FocusBorderColor = System.Drawing.Color.Firebrick;
            this.textboxDescription.ForeColor = System.Drawing.Color.Black;
            this.textboxDescription.Location = new System.Drawing.Point(12, 139);
            this.textboxDescription.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxDescription.MinimumSize = new System.Drawing.Size(10, 6);
            this.textboxDescription.Multiline = true;
            this.textboxDescription.Name = "textboxDescription";
            this.textboxDescription.ReadOnly = true;
            this.textboxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxDescription.Size = new System.Drawing.Size(340, 133);
            this.textboxDescription.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxDescription.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonClose.BackColor = System.Drawing.Color.Firebrick;
            this.buttonClose.BeforeTouchSize = new System.Drawing.Size(340, 59);
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.IsBackStageButton = false;
            this.buttonClose.Location = new System.Drawing.Point(12, 289);
            this.buttonClose.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(340, 59);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "ZATVORI";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // horizonalLine
            // 
            this.horizonalLine.AutoSize = false;
            this.horizonalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizonalLine.Location = new System.Drawing.Point(12, 284);
            this.horizonalLine.Name = "horizonalLine";
            this.horizonalLine.Size = new System.Drawing.Size(340, 2);
            this.horizonalLine.TabIndex = 2;
            // 
            // comboboxRules
            // 
            this.comboboxRules.BackColor = System.Drawing.Color.White;
            this.comboboxRules.BeforeTouchSize = new System.Drawing.Size(340, 21);
            this.comboboxRules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxRules.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboboxRules.ForeColor = System.Drawing.Color.Black;
            this.comboboxRules.Location = new System.Drawing.Point(12, 112);
            this.comboboxRules.MaxLength = 1024;
            this.comboboxRules.MetroColor = System.Drawing.Color.Firebrick;
            this.comboboxRules.Name = "comboboxRules";
            this.comboboxRules.Size = new System.Drawing.Size(340, 21);
            this.comboboxRules.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.comboboxRules.TabIndex = 0;
            this.comboboxRules.SelectedIndexChanged += new System.EventHandler(this.comboboxRules_SelectedIndexChanged);
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = global::Jasarsoft.Columbia.Launcher.Properties.Resources.cover;
            this.pictureLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(340, 85);
            this.pictureLogo.TabIndex = 7;
            this.pictureLogo.TabStop = false;
            // 
            // RulesForm
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
            this.ClientSize = new System.Drawing.Size(364, 360);
            this.ControlBox = false;
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.comboboxRules);
            this.Controls.Add(this.horizonalLine);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textboxDescription);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "RulesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State | RolePlay Pravila";
            this.Load += new System.EventHandler(this.RulesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textboxDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxDescription;
        private Syncfusion.Windows.Forms.ButtonAdv buttonClose;
        private Syncfusion.Windows.Forms.Tools.AutoLabel horizonalLine;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboboxRules;
        private System.Windows.Forms.PictureBox pictureLogo;
    }
}