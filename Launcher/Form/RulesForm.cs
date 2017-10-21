using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Jasarsoft.Columbia.Library;

namespace Jasarsoft.Columbia.Launcher
{
    public partial class RulesForm : Syncfusion.Windows.Forms.MetroForm
    {
        RolePlay rp;

        public RulesForm()
        {
            InitializeComponent();

            rp = new RolePlay();
        }

        private void RulesForm_Load(object sender, EventArgs e)
        {
            this.comboboxRules.Items.Clear();
            this.textboxDescription.Text = String.Empty;

            foreach(string title in rp.Title)
            {
                this.comboboxRules.Items.Add(title);
            }

            this.comboboxRules.SelectedIndex = 0;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboboxRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textboxDescription.Text = rp.Text[comboboxRules.SelectedIndex];
        }
    }
}
