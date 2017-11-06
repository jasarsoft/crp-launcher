using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Jasarsoft.Columbia
{
    public partial class DescriptionForm : Syncfusion.Windows.Forms.MetroForm
    {
        public DescriptionForm()
        {
            InitializeComponent();
        }

        private void DescriptionForm_Shown(object sender, EventArgs e)
        {
            this.buttonClose.Select();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
