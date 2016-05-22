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
    public partial class UserControl2 : UserControl
    {
        private TKlavesyRezie poNHodn;

        public UserControl2()
        {
            InitializeComponent();
            poNHodn = new TKlavesyRezie(button1);
        }

        public int getPocZprav()
        {
            return poNHodn.getpoc();
        }

        public Message getZprava(int indexOfMsg)
        {
            return poNHodn.getzprava(indexOfMsg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!poNHodn.enabled)
            {
                // zapnout
                poNHodn.enabled = true;
                poNHodn.reset();
                button1.Text = "";
                Application.AddMessageFilter(poNHodn);
            }
            else
            {
                poNHodn.enabled = false;
                button1.Text = "nic";
                Application.RemoveMessageFilter(poNHodn);
            }
        }
    }
}
