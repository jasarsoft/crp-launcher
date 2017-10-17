#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.ColumbiaGUI
{
    partial class MainForm
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMain = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.labelPassword = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.textPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.textName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.buttonLogin = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(364, 24);
            this.menuMain.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 100);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BorderColor = System.Drawing.Color.Gainsboro;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.labelPassword);
            this.panelMain.Controls.Add(this.textPassword);
            this.panelMain.Controls.Add(this.textName);
            this.panelMain.Controls.Add(this.labelName);
            this.panelMain.Location = new System.Drawing.Point(12, 133);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(340, 85);
            this.panelMain.TabIndex = 2;
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(110, 22);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Korisnièko ime:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = false;
            this.labelPassword.Location = new System.Drawing.Point(12, 49);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(110, 22);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Lozinka pristupa:";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.Color.White;
            this.textPassword.BeforeTouchSize = new System.Drawing.Size(198, 22);
            this.textPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textPassword.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textPassword.Location = new System.Drawing.Point(128, 49);
            this.textPassword.MaxLength = 128;
            this.textPassword.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(198, 22);
            this.textPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textPassword.TabIndex = 5;
            this.textPassword.Text = "textBoxExt2";
            // 
            // textName
            // 
            this.textName.BackColor = System.Drawing.Color.White;
            this.textName.BeforeTouchSize = new System.Drawing.Size(198, 22);
            this.textName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textName.ForeColor = System.Drawing.Color.Black;
            this.textName.Location = new System.Drawing.Point(129, 12);
            this.textName.MaxLength = 24;
            this.textName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(198, 22);
            this.textName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textName.TabIndex = 4;
            this.textName.Text = "Ime_Prezime";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.buttonLogin.BeforeTouchSize = new System.Drawing.Size(340, 56);
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.IsBackStageButton = false;
            this.buttonLogin.Location = new System.Drawing.Point(12, 233);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(340, 56);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "PRIJAVI SE";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BorderThickness = 4;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.DodgerBlue;
            this.CaptionBarHeight = 30;
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionButtonHoverColor = System.Drawing.Color.Gray;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClientSize = new System.Drawing.Size(364, 301);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.DodgerBlue;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel panelMain;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private Syncfusion.Windows.Forms.ButtonAdv buttonLogin;
    }
}