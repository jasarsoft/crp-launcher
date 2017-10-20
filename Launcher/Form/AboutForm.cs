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

        private void TextboxDeveloper_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jasarsoft");
        }

        private void TextboxLicense_Click(object sender, EventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Proprietary_software");
        }

        private void TextboxDeveloper_MouseHover(object sender, EventArgs e)
        {
            this.textboxDeveloper.Cursor = Cursors.Hand;
        }

        private void LabelDeveloper_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jasarsoft");
        }

        private void LabelLicense_Click(object sender, EventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Proprietary_software");
        }
    }
}
