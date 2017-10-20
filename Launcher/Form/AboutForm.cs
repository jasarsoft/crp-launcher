#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jasarsoft.Columbia.Launcher
{
    public partial class AboutForm : Syncfusion.Windows.Forms.MetroForm
    {

        public AboutForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutLauncher_Load(object sender, EventArgs e)
        {
            About about = new About();

            this.textboxTitle.Text = about.Title;
            this.textboxVersion.Text = about.Version;
            this.textboxDate.Text = about.Date;
            this.textboxCopyright.Text = about.Copyright;
            this.textboxLicense.Text = about.License;
            this.textboxDeveloper.Text = about.Developer;
            this.textboxDescription.Text = about.Description;

            this.buttonClose.Select();
        }

        private void textboxDeveloper_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jasarsoft");
        }

        private void textboxLicense_Click(object sender, EventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Proprietary_software");
        }

        private void textboxDeveloper_MouseHover(object sender, EventArgs e)
        {
            this.textboxDeveloper.Cursor = Cursors.Hand;
        }

        private void labelDeveloper_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jasarsoft");
        }

        private void labelLicense_Click(object sender, EventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Proprietary_software");
        }
    }
}
