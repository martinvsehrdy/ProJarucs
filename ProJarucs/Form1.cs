using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace ProJaru
{
    public partial class Form1 : Form
    {
        UserControl1[] usercontrol;
        Tkomun odesilac;
        const int usercontrol1max = 4;
        Char[] strPort;
        int strPortPoc;
        int odeslanoHodnot;
        TKlavesyRezie poKazdeHodn, poNHodn;
        bool detekceCOM=false;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            strPort = new Char[13];
            strPortPoc = 0;
            odeslanoHodnot = 0;
            poKazdeHodn = new TKlavesyRezie(button4);
            poNHodn = new TKlavesyRezie(button5);
            usercontrol = new UserControl1[usercontrol1max];
            for (int i = 0; i < usercontrol1max; i++)
            {
                usercontrol[i] = new UserControl1();
                usercontrol[i].Location = new Point(40, 70 + i * 30);
                usercontrol[i].Parent = tabPage1;
            }
            button1_Click(null, null);      // nacte vsechny ostatní aplikace
            button3_Click(null, null);      // nacte vsechny porty
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (odesilac == null) odesilac = new Tkomun(this.Handle);
            odesilac.loadprogramy();
            comboBox1.Items.Clear();
            comboBox1.Text = "Hlavní cílový program";
            for (int j = 0; j < usercontrol1max; j++)
            {
                usercontrol[j].comboBox1.Items.Clear();
                usercontrol[j].comboBox1.Text = "Cílový program " + (j + 1).ToString();
            }
            for (int i = 0; i < odesilac.getpocOkna(); i++)
            {
                comboBox1.Items.Add( odesilac.getnazevOkna(i) );
                for (int j = 0; j < usercontrol1max; j++)
                {
                    usercontrol[j].comboBox1.Items.Add(odesilac.getnazevOkna(i));
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //prohlídne všechny COM-porty
            String[] porty = SerialPort.GetPortNames();
            comboBox2.Items.Clear();
            comboBox2.Text = "COM-port s interfejsem";
            foreach (String port in porty)
            {
                try
                {
                    /*serialPort1.PortName = port;
                    serialPort1.BaudRate = 9600;
                    serialPort1.Open();
                    //String q;
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write("I" + (char)13);
                        Thread.Sleep(1000);

                        //q = new string(strPort);
                        //if( 0<serialPort1.ReadBufferSize ) 
                          //  q=serialPort1.ReadLine();
                        serialPort1.Close();
                    }//*/
                    comboBox2.Items.Add(port);
                    
                }
                catch (Exception)
                {
                    comboBox2.Items.Add(port);
                }
                //*/
            }
            
        }

        private void serialP_zpracovat(byte data)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action<byte>(serialP_zpracovat), data);
            }
            else
            {
                if (data == 13)
                {
                    if (strPort[0] == '0' && strPort[2] == 'A')
                    {
                        if (textBox2.Text == "") textBox2.Text = ".";
                        int plen = strPortPoc - 3 + textBox2.TextLength - 1;
                        Char[] p1 = new Char[plen];
                        int i = 0;
                        while (strPort[i+3] != '.')
                        {
                            p1[i] = strPort[i+3];
                            i++;
                        }
                        int j;
                        for(j=0;j<textBox2.TextLength;j++)
                        {
                            p1[i + j] = textBox2.Text[j];
                        }
                        i += j;
                        while (i<plen)
                        {
                            p1[i] = strPort[i + 3 - textBox2.TextLength + 1];
                            i++;
                        }

                        int cil=comboBox1.SelectedIndex;
                        // odešle změřenou hodnotu
                        odeslanoHodnot++;
                        odesilac.odeslatklav(cil, new String(p1)+textBox3.Text);
                        for(i=0;i<poKazdeHodn.getpoc();i++)
                        {
                            //poKazdeHodn
                            //if((int)poKazdeHodn.getzprava(i).Msg==(int)Tkomun.WMessages.WM_KEYDOWN)
                                odesilac.odeslatZpravu(cil, poKazdeHodn.getzprava(i));
                        }
                        if (numericUpDown1.Value!=0 && odeslanoHodnot % numericUpDown1.Value == 0)
                        {
                            odesilac.odeslatklav(cil, textBox4.Text);
                            for (i = 0; i < poKazdeHodn.getpoc(); i++)
                            {
                                //poNHodn
                                odesilac.odeslatZpravu(cil, poNHodn.getzprava(i));
                            }
                        }
                        
                    }
                    

                    Char[] p = new Char[strPortPoc];
                    for (int i = 0; i < strPortPoc; i++)
                    {
                        p[i] = strPort[i];
                    }
                    listBox1.Items.Add(new String(p));
                    strPortPoc = 0;
                }
                else
                {
                    strPort[strPortPoc] = (char)data;
                    strPortPoc++;
                }
            }
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                while (serialPort1.IsOpen && serialPort1.ReadBufferSize != 0)
                {
                    int a = serialPort1.ReadByte();
                    serialP_zpracovat((byte)a);
                }
                //*/
                
            }
            catch (Exception)
            {

            }
        }

        private void povolitPrvky(bool povol)
        {
            bool enabl = povol;

            label1.Enabled = enabl;
            label2.Enabled = enabl;
            label3.Enabled = enabl;
            label4.Enabled = enabl;
            label5.Enabled = enabl;
            label6.Enabled = enabl;
            numericUpDown1.Enabled = enabl;
            textBox1.Enabled = enabl;
            textBox2.Enabled = enabl;
            textBox3.Enabled = enabl;
            textBox4.Enabled = enabl;
            spustitToolStripMenuItem.Enabled = enabl;
            comboBox1.Enabled = enabl;
            comboBox2.Enabled = enabl;
            checkBox1.Enabled = enabl;
            button1.Enabled = enabl;
            button2.Enabled = enabl;
            button3.Enabled = enabl;
            button4.Enabled = enabl;
            button5.Enabled = enabl;
            for (int i = 0; i < usercontrol1max; i++)
            {
                usercontrol[i].Enabled = enabl;
            }
        }

        private void spustitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Musíte zadat COM port s interfejsem");
                return;
            }
            try
            {
                serialPort1.PortName = comboBox2.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    povolitPrvky(false);
                    
                    
                }
            }
            catch (Exception)
            {
            }
            int a;
            try
            {
                a = Convert.ToInt32(textBox1.Text);
                timer1.Interval = a;
                timer1.Start();
            }
            catch (Exception)
            {
            }
            listBox1.Items.Clear();
        }
       
        private void zastavitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (serialPort1.IsOpen) serialPort1.Close();
            if (!serialPort1.IsOpen)
            {
                povolitPrvky(true);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            zastavitToolStripMenuItem_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked && serialPort1.IsOpen) serialPort1.Write("A" + (char)13);
        }

        private void přečteníIdentifikacenázvuInterfejsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.WriteLine("I"+(char)13);
        }

        private void přečteníSériovéhoČíslaInterfejsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.WriteLine("N" + (char)13);
        }

        private void přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.WriteLine("V" + (char)13);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!poKazdeHodn.enabled)
            {
                // zapnout
                poKazdeHodn.enabled = true;
                poKazdeHodn.reset();
                button4.Text = "";
                Application.AddMessageFilter(poKazdeHodn);
            }
            else
            {
                poKazdeHodn.enabled = false;
                button4.Text = "nic";
                Application.RemoveMessageFilter(poKazdeHodn);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!poNHodn.enabled)
            {
                // zapnout
                poNHodn.enabled = true;
                poNHodn.reset();
                button5.Text = "";
                Application.AddMessageFilter(poNHodn);
            }
            else
            {
                poNHodn.enabled = false;
                button5.Text = "nic";
                Application.RemoveMessageFilter(poNHodn);
            }
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (poKazdeHodn != null && poKazdeHodn.enabled) listBox2.Items.Add(e.KeyValue);
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add(poKazdeHodn.getpoc());
            for (int i = 0; i < poKazdeHodn.getpoc(); i++)
            {
                listBox2.Items.Add(poKazdeHodn.getzprava(i).Msg + ": " + poKazdeHodn.getzprava(i).WParam);
            }
        }




    }

}
