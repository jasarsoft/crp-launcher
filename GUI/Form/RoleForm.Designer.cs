#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.ColumbiaGUI
{
    partial class RoleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleForm));
            this.buttonClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.textDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.pictureMain = new System.Windows.Forms.PictureBox();
            this.comboRole = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.textDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboRole)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonClose.BackColor = System.Drawing.Color.Firebrick;
            this.buttonClose.BeforeTouchSize = new System.Drawing.Size(340, 56);
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.IsBackStageButton = false;
            this.buttonClose.Location = new System.Drawing.Point(12, 331);
            this.buttonClose.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(340, 56);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "ZATVORI";
            // 
            // textDescription
            // 
            this.textDescription.BackColor = System.Drawing.Color.White;
            this.textDescription.BeforeTouchSize = new System.Drawing.Size(340, 140);
            this.textDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textDescription.ForeColor = System.Drawing.Color.Black;
            this.textDescription.Location = new System.Drawing.Point(12, 185);
            this.textDescription.MaxLength = 1024;
            this.textDescription.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textDescription.MinimumSize = new System.Drawing.Size(10, 6);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.ReadOnly = true;
            this.textDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDescription.Size = new System.Drawing.Size(340, 140);
            this.textDescription.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textDescription.TabIndex = 2;
            // 
            // pictureMain
            // 
            this.pictureMain.Image = ((System.Drawing.Image)(resources.GetObject("pictureMain.Image")));
            this.pictureMain.Location = new System.Drawing.Point(12, 12);
            this.pictureMain.Name = "pictureMain";
            this.pictureMain.Size = new System.Drawing.Size(340, 140);
            this.pictureMain.TabIndex = 11;
            this.pictureMain.TabStop = false;
            // 
            // comboRole
            // 
            this.comboRole.BackColor = System.Drawing.Color.White;
            this.comboRole.BeforeTouchSize = new System.Drawing.Size(340, 21);
            this.comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRole.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboRole.ForeColor = System.Drawing.Color.Black;
            this.comboRole.Location = new System.Drawing.Point(12, 158);
            this.comboRole.MaxLength = 1024;
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(340, 21);
            this.comboRole.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.comboRole.TabIndex = 1;
            // 
            // RoleForm
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
            this.ClientSize = new System.Drawing.Size(364, 399);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.pictureMain);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textDescription);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "RoleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State | RolePlay Pravila";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.textDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboRole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.Windows.Forms.ButtonAdv buttonClose;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textDescription;
        private System.Windows.Forms.PictureBox pictureMain;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboRole;
    }
}