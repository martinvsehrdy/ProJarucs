using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProJaru
{
    public partial class UserControl1 : UserControl
    {
        public int odeslanoHodnot = 0;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = !checkBox1.Checked;
            comboBox1.Enabled = !checkBox1.Checked;
        }
    }
}
