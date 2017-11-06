#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia
{
    partial class LoginForm
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
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panelMain = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.textboxName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelAuthentic = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.textboxAuthentic = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.textboxPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.labelPassword = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.buttonLogin = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonClose = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textboxName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxAuthentic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = global::Jasarsoft.Columbia.Properties.Resources.cover;
            this.pictureLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(340, 85);
            this.pictureLogo.TabIndex = 4;
            this.pictureLogo.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.BorderColor = System.Drawing.Color.Gainsboro;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.autoLabel2);
            this.panelMain.Controls.Add(this.textboxName);
            this.panelMain.Controls.Add(this.labelName);
            this.panelMain.Controls.Add(this.labelAuthentic);
            this.panelMain.Controls.Add(this.textboxAuthentic);
            this.panelMain.Controls.Add(this.textboxPassword);
            this.panelMain.Controls.Add(this.labelPassword);
            this.panelMain.Location = new System.Drawing.Point(12, 103);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(340, 133);
            this.panelMain.TabIndex = 5;
            // 
            // autoLabel2
            // 
            this.autoLabel2.AutoSize = false;
            this.autoLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.autoLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.autoLabel2.Location = new System.Drawing.Point(11, 46);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(314, 2);
            this.autoLabel2.TabIndex = 6;
            this.autoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textboxName
            // 
            this.textboxName.BackColor = System.Drawing.Color.White;
            this.textboxName.BeforeTouchSize = new System.Drawing.Size(183, 22);
            this.textboxName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxName.CornerRadius = 3;
            this.textboxName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textboxName.ForeColor = System.Drawing.Color.Black;
            this.textboxName.Location = new System.Drawing.Point(142, 12);
            this.textboxName.MaxLength = 64;
            this.textboxName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxName.MinimumSize = new System.Drawing.Size(10, 6);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(183, 22);
            this.textboxName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxName.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.Location = new System.Drawing.Point(11, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(125, 22);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Korisnièko ime:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAuthentic
            // 
            this.labelAuthentic.AutoSize = false;
            this.labelAuthentic.DX = -129;
            this.labelAuthentic.DY = -1;
            this.labelAuthentic.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAuthentic.LabeledControl = this.textboxAuthentic;
            this.labelAuthentic.Location = new System.Drawing.Point(13, 96);
            this.labelAuthentic.Name = "labelAuthentic";
            this.labelAuthentic.Size = new System.Drawing.Size(125, 22);
            this.labelAuthentic.TabIndex = 3;
            this.labelAuthentic.Text = "Autentifikacija lozinke:";
            this.labelAuthentic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textboxAuthentic
            // 
            this.textboxAuthentic.BackColor = System.Drawing.Color.White;
            this.textboxAuthentic.BeforeTouchSize = new System.Drawing.Size(183, 22);
            this.textboxAuthentic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxAuthentic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxAuthentic.CornerRadius = 3;
            this.textboxAuthentic.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textboxAuthentic.ForeColor = System.Drawing.Color.Black;
            this.textboxAuthentic.Location = new System.Drawing.Point(142, 97);
            this.textboxAuthentic.MaxLength = 64;
            this.textboxAuthentic.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxAuthentic.MinimumSize = new System.Drawing.Size(14, 10);
            this.textboxAuthentic.Name = "textboxAuthentic";
            this.textboxAuthentic.PasswordChar = '*';
            this.textboxAuthentic.Size = new System.Drawing.Size(183, 22);
            this.textboxAuthentic.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxAuthentic.TabIndex = 2;
            this.textboxAuthentic.WordWrap = false;
            // 
            // textboxPassword
            // 
            this.textboxPassword.BackColor = System.Drawing.Color.White;
            this.textboxPassword.BeforeTouchSize = new System.Drawing.Size(183, 22);
            this.textboxPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxPassword.CornerRadius = 3;
            this.textboxPassword.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textboxPassword.ForeColor = System.Drawing.Color.Black;
            this.textboxPassword.Location = new System.Drawing.Point(142, 60);
            this.textboxPassword.MaxLength = 64;
            this.textboxPassword.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textboxPassword.MinimumSize = new System.Drawing.Size(10, 6);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.Size = new System.Drawing.Size(183, 22);
            this.textboxPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textboxPassword.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = false;
            this.labelPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPassword.Location = new System.Drawing.Point(11, 60);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(125, 22);
            this.labelPassword.TabIndex = 0;
            this.labelPassword.Text = "Admin zaštitna lozinka:";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonLogin.BeforeTouchSize = new System.Drawing.Size(222, 59);
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.IsBackStageButton = false;
            this.buttonLogin.Location = new System.Drawing.Point(12, 251);
            this.buttonLogin.MetroColor = System.Drawing.Color.RoyalBlue;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(222, 59);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "ADMIN PRIJAVA";
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonClose.BackColor = System.Drawing.Color.Firebrick;
            this.buttonClose.BeforeTouchSize = new System.Drawing.Size(112, 59);
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.IsBackStageButton = false;
            this.buttonClose.Location = new System.Drawing.Point(240, 251);
            this.buttonClose.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(112, 59);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "ZATVORI";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderColor = System.Drawing.Color.Firebrick;
            this.BorderThickness = 6;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.Firebrick;
            this.CaptionBarHeight = 30;
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CaptionForeColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(364, 322);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.pictureLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP NovaMahala | Admin Prijava";
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textboxName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxAuthentic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLogo;
        private Syncfusion.Windows.Forms.Tools.GradientPanel panelMain;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelAuthentic;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxAuthentic;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxPassword;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelPassword;
        private Syncfusion.Windows.Forms.ButtonAdv buttonLogin;
        private Syncfusion.Windows.Forms.ButtonAdv buttonClose;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textboxName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
    }
}