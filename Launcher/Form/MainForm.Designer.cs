#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Jasarsoft.Columbia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelLogin = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.labelPassword = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.textPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.textName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.labelName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileClient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuToolsUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLink = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLinkItemForum = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLinkItemYouTube = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLinkItemFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLinkItemTeamSpeak = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpItemRules = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuHelpItemLauncher = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpItemNovaMahala = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLogin = new Syncfusion.Windows.Forms.ButtonAdv();
            this.workerCheck = new System.ComponentModel.BackgroundWorker();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.workerHost = new System.ComponentModel.BackgroundWorker();
            this.workerGame = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelLogin)).BeginInit();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName)).BeginInit();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BorderColor = System.Drawing.Color.Gainsboro;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.textPassword);
            this.panelLogin.Controls.Add(this.textName);
            this.panelLogin.Controls.Add(this.labelName);
            this.panelLogin.Location = new System.Drawing.Point(12, 133);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(340, 85);
            this.panelLogin.TabIndex = 0;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = false;
            this.labelPassword.Location = new System.Drawing.Point(12, 49);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(110, 22);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Lozinka pristupa:";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.Color.White;
            this.textPassword.BeforeTouchSize = new System.Drawing.Size(198, 22);
            this.textPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPassword.CornerRadius = 1;
            this.textPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textPassword.ForeColor = System.Drawing.Color.Black;
            this.textPassword.Location = new System.Drawing.Point(128, 49);
            this.textPassword.MaxLength = 128;
            this.textPassword.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textPassword.MinimumSize = new System.Drawing.Size(6, 4);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(198, 22);
            this.textPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textPassword.TabIndex = 2;
            this.textPassword.Text = "textBoxExt2";
            // 
            // textName
            // 
            this.textName.BackColor = System.Drawing.Color.White;
            this.textName.BeforeTouchSize = new System.Drawing.Size(198, 22);
            this.textName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textName.CornerRadius = 1;
            this.textName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textName.ForeColor = System.Drawing.Color.Black;
            this.textName.Location = new System.Drawing.Point(129, 12);
            this.textName.MaxLength = 24;
            this.textName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textName.MinimumSize = new System.Drawing.Size(6, 4);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(198, 22);
            this.textName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textName.TabIndex = 1;
            this.textName.Text = "Ime_Prezime";
            // 
            // labelName
            // 
            this.labelName.AutoSize = false;
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(110, 22);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Korisnièko ime:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuMain
            // 
            this.menuMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemTools,
            this.menuItemLink,
            this.menuItemHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(364, 24);
            this.menuMain.TabIndex = 2;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileClient,
            this.menuFileAdmin,
            this.menuFileSeparator,
            this.menuFileExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(71, 20);
            this.menuItemFile.Text = "&Columbia";
            // 
            // menuFileClient
            // 
            this.menuFileClient.Name = "menuFileClient";
            this.menuFileClient.Size = new System.Drawing.Size(110, 22);
            this.menuFileClient.Text = "&Prijava";
            this.menuFileClient.ToolTipText = "Prijavite se kao klijent";
            this.menuFileClient.Click += new System.EventHandler(this.menuFileClient_Click);
            // 
            // menuFileAdmin
            // 
            this.menuFileAdmin.Enabled = false;
            this.menuFileAdmin.Name = "menuFileAdmin";
            this.menuFileAdmin.Size = new System.Drawing.Size(110, 22);
            this.menuFileAdmin.Text = "&Admin";
            this.menuFileAdmin.ToolTipText = "Prijavite se kao admin";
            this.menuFileAdmin.Click += new System.EventHandler(this.menuFileAdmin_Click);
            // 
            // menuFileSeparator
            // 
            this.menuFileSeparator.Name = "menuFileSeparator";
            this.menuFileSeparator.Size = new System.Drawing.Size(107, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(110, 22);
            this.menuFileExit.Text = "&Izlaz";
            this.menuFileExit.ToolTipText = "Zatvorite SAMP NovaMahala Launcer";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuItemTools
            // 
            this.menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolsCheck,
            this.menuToolsDownload,
            this.menuToolsSeparator,
            this.menuToolsUpdate});
            this.menuItemTools.Name = "menuItemTools";
            this.menuItemTools.Size = new System.Drawing.Size(43, 20);
            this.menuItemTools.Text = "&Alati";
            // 
            // menuToolsCheck
            // 
            this.menuToolsCheck.Name = "menuToolsCheck";
            this.menuToolsCheck.Size = new System.Drawing.Size(152, 22);
            this.menuToolsCheck.Text = "&Provjera";
            this.menuToolsCheck.ToolTipText = "Provjerite valjanost trenutni fajlova";
            this.menuToolsCheck.Click += new System.EventHandler(this.menuToolsCheck_Click);
            // 
            // menuToolsDownload
            // 
            this.menuToolsDownload.Enabled = false;
            this.menuToolsDownload.Name = "menuToolsDownload";
            this.menuToolsDownload.Size = new System.Drawing.Size(152, 22);
            this.menuToolsDownload.Text = "&Ažuriranje";
            this.menuToolsDownload.ToolTipText = "Ažurirajte potrebne fajlove najnovim";
            this.menuToolsDownload.Click += new System.EventHandler(this.menuToolsDownload_Click);
            // 
            // menuToolsSeparator
            // 
            this.menuToolsSeparator.Name = "menuToolsSeparator";
            this.menuToolsSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // menuToolsUpdate
            // 
            this.menuToolsUpdate.Name = "menuToolsUpdate";
            this.menuToolsUpdate.Size = new System.Drawing.Size(152, 22);
            this.menuToolsUpdate.Text = "&Nadogradnja";
            this.menuToolsUpdate.ToolTipText = "Nadogradite Launcher novom verzijom";
            this.menuToolsUpdate.Click += new System.EventHandler(this.menuToolsUpdate_Click);
            // 
            // menuItemLink
            // 
            this.menuItemLink.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLinkItemForum,
            this.menuLinkItemYouTube,
            this.menuLinkItemFacebook,
            this.menuLinkItemTeamSpeak});
            this.menuItemLink.Name = "menuItemLink";
            this.menuItemLink.Size = new System.Drawing.Size(57, 20);
            this.menuItemLink.Text = "&Linkovi";
            // 
            // menuLinkItemForum
            // 
            this.menuLinkItemForum.Name = "menuLinkItemForum";
            this.menuLinkItemForum.Size = new System.Drawing.Size(144, 22);
            this.menuLinkItemForum.Text = "Fo&rum";
            this.menuLinkItemForum.ToolTipText = "Službeni forum za klijent diskusije";
            this.menuLinkItemForum.Click += new System.EventHandler(this.menuLinkItemForum_Click);
            // 
            // menuLinkItemYouTube
            // 
            this.menuLinkItemYouTube.Name = "menuLinkItemYouTube";
            this.menuLinkItemYouTube.Size = new System.Drawing.Size(144, 22);
            this.menuLinkItemYouTube.Text = "&YouTube";
            this.menuLinkItemYouTube.ToolTipText = "Posjetite službeni YouTube kanal";
            this.menuLinkItemYouTube.Click += new System.EventHandler(this.menuLinkItemYouTube_Click);
            // 
            // menuLinkItemFacebook
            // 
            this.menuLinkItemFacebook.Name = "menuLinkItemFacebook";
            this.menuLinkItemFacebook.Size = new System.Drawing.Size(144, 22);
            this.menuLinkItemFacebook.Text = "&Facebook";
            this.menuLinkItemFacebook.ToolTipText = "Posjetite službenu Facebook Fan stranicu";
            this.menuLinkItemFacebook.Click += new System.EventHandler(this.menuLinkItemFacebook_Click);
            // 
            // menuLinkItemTeamSpeak
            // 
            this.menuLinkItemTeamSpeak.Name = "menuLinkItemTeamSpeak";
            this.menuLinkItemTeamSpeak.Size = new System.Drawing.Size(144, 22);
            this.menuLinkItemTeamSpeak.Text = "&TeamSpeak 3";
            this.menuLinkItemTeamSpeak.ToolTipText = "Ovorite TeamSpeak i prijavite se na NovaMahala-u";
            this.menuLinkItemTeamSpeak.Click += new System.EventHandler(this.menuLinkItemTeamSpeak_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpItemRules,
            this.menuHelpSeparator,
            this.menuHelpItemLauncher,
            this.menuHelpItemNovaMahala});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(57, 20);
            this.menuItemHelp.Text = "&Pomoæ";
            // 
            // menuHelpItemRules
            // 
            this.menuHelpItemRules.Name = "menuHelpItemRules";
            this.menuHelpItemRules.Size = new System.Drawing.Size(155, 22);
            this.menuHelpItemRules.Text = "&RolePlay";
            this.menuHelpItemRules.ToolTipText = "Opæenita RolePlay pravila i njihovi opisi";
            this.menuHelpItemRules.Click += new System.EventHandler(this.menuHelpItemRules_Click);
            // 
            // menuHelpSeparator
            // 
            this.menuHelpSeparator.Name = "menuHelpSeparator";
            this.menuHelpSeparator.Size = new System.Drawing.Size(152, 6);
            // 
            // menuHelpItemLauncher
            // 
            this.menuHelpItemLauncher.Name = "menuHelpItemLauncher";
            this.menuHelpItemLauncher.Size = new System.Drawing.Size(155, 22);
            this.menuHelpItemLauncher.Text = "&Launcher";
            this.menuHelpItemLauncher.ToolTipText = "Tehnièke informacije o Launcher-u";
            this.menuHelpItemLauncher.Click += new System.EventHandler(this.menuHelpItemLauncher_Click);
            // 
            // menuHelpItemNovaMahala
            // 
            this.menuHelpItemNovaMahala.Name = "menuHelpItemNovaMahala";
            this.menuHelpItemNovaMahala.Size = new System.Drawing.Size(155, 22);
            this.menuHelpItemNovaMahala.Text = "&Columbia State";
            this.menuHelpItemNovaMahala.ToolTipText = "O nastanku i historiji NovaMahala-e";
            this.menuHelpItemNovaMahala.Click += new System.EventHandler(this.menuHelpItemNovaMahala_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonLogin.BackColor = System.Drawing.Color.Firebrick;
            this.buttonLogin.BeforeTouchSize = new System.Drawing.Size(340, 56);
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonLogin.IsBackStageButton = false;
            this.buttonLogin.Location = new System.Drawing.Point(12, 233);
            this.buttonLogin.MetroColor = System.Drawing.Color.Firebrick;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(340, 56);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "PRIJAVI SE";
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            this.buttonLogin.MouseLeave += new System.EventHandler(this.buttonLogin_MouseLeave);
            this.buttonLogin.MouseHover += new System.EventHandler(this.buttonLogin_MouseHover);
            // 
            // workerCheck
            // 
            this.workerCheck.WorkerSupportsCancellation = true;
            this.workerCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerCheck_DoWork);
            this.workerCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerCheck_RunWorkerCompleted);
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.Location = new System.Drawing.Point(12, 27);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(340, 100);
            this.pictureLogo.TabIndex = 1;
            this.pictureLogo.TabStop = false;
            // 
            // workerHost
            // 
            this.workerHost.WorkerSupportsCancellation = true;
            this.workerHost.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerHost_DoWork);
            this.workerHost.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerHost_RunWorkerCompleted);
            // 
            // workerGame
            // 
            this.workerGame.WorkerSupportsCancellation = true;
            this.workerGame.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerGame_DoWork);
            this.workerGame.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerGame_RunWorkerCompleted);
            // 
            // MainForm
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
            this.ClientSize = new System.Drawing.Size(364, 301);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Firebrick;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMP Columbia State RolePlay | Prijava";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelLogin)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel panelLogin;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelName;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private Syncfusion.Windows.Forms.ButtonAdv buttonLogin;
        private System.ComponentModel.BackgroundWorker workerCheck;
        private System.Windows.Forms.ToolStripMenuItem menuFileClient;
        private System.Windows.Forms.ToolStripMenuItem menuFileAdmin;
        private System.Windows.Forms.ToolStripSeparator menuFileSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemTools;
        private System.Windows.Forms.ToolStripMenuItem menuToolsCheck;
        private System.Windows.Forms.ToolStripMenuItem menuToolsDownload;
        private System.Windows.Forms.ToolStripSeparator menuToolsSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuToolsUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuItemLink;
        private System.Windows.Forms.ToolStripMenuItem menuLinkItemForum;
        private System.Windows.Forms.ToolStripMenuItem menuLinkItemYouTube;
        private System.Windows.Forms.ToolStripMenuItem menuLinkItemFacebook;
        private System.Windows.Forms.ToolStripMenuItem menuLinkItemTeamSpeak;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpItemRules;
        private System.Windows.Forms.ToolStripSeparator menuHelpSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuHelpItemLauncher;
        private System.Windows.Forms.ToolStripMenuItem menuHelpItemNovaMahala;
        private System.ComponentModel.BackgroundWorker workerHost;
        private System.ComponentModel.BackgroundWorker workerGame;
    }
}