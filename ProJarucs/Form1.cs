﻿//#define DEVEL
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
using System.Runtime.InteropServices;

namespace ProJaru
{
    public partial class Form1 : Form
    {
        UserControl1[] usercontrol;
        UserControl2[] poNHodn;
        String[] porty;
        String[] portyCOM;
        Tkomun odesilac;
        //TComPort comPort1;
        const int usercontrol1max = 4;
        const int usercontrol2max = 1;
        char[] strPort;
        int strPortPoc;

        
        TKlavesyRezie poKazdeHodn;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            strPort = new Char[13];
            strPortPoc = 0;
            labelChyba.Text = "";
            poKazdeHodn = new TKlavesyRezie(button4);
            usercontrol = new UserControl1[usercontrol1max];
            for (int i = 0; i < usercontrol1max; i++)
            {
                usercontrol[i] = new UserControl1();
                usercontrol[i].Location = new Point(comboBox1.Location.X, 50 + i * 50);
                usercontrol[i].label1.Text += (i+1).ToString()+":";
                usercontrol[i].Parent = groupBox1;
            }

            poNHodn = new UserControl2[usercontrol2max];
            for (int i = 0; i < usercontrol2max; i++)
            {
                poNHodn[i] = new UserControl2();
                poNHodn[i].Location = new Point(0, 148 + i * 55);
                poNHodn[i].Parent = groupBox3;
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

        private void konecNacitaniPortu()
        {
            if (button3.InvokeRequired)
            {
                button3.Invoke(new Action(konecNacitaniPortu));
            }
            else
            {
                button3.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        private void combobox2_add(String str)
        {
            if (comboBox2.InvokeRequired)
                {
                    comboBox2.Invoke(new Action<String>(combobox2_add), str);
                }
                else
                {
                    comboBox2.Items.Add(str);
                }
        }
        private void getOnePortInfo()
        {
            porty = SerialPort.GetPortNames();

            //for (int iui = 0; iui < 5; iui++)
            foreach (String port in porty)
            {
                //listBox1.Items.Add(port);

                Thread.Sleep(100);
                SerialPort serialp1 = new SerialPort();
                serialp1.PortName = port;
                serialp1.ReadTimeout = 200;
                string q = "";
                try
                {
                    serialp1.Open();
                    serialp1.WriteLine("I" + (char)13);
                    Thread.Sleep(100);
                    while (serialp1.IsOpen && serialp1.BytesToRead != 0)
                    {
                        int a = serialp1.ReadByte();
                        if (a != 13) q = q + (char)a;
                        //else break;
                    }
                    q = q + " (";
                    serialp1.WriteLine("N" + (char)13);
                    Thread.Sleep(100);
                    while (serialp1.IsOpen && serialp1.BytesToRead != 0)
                    {
                        int a = serialp1.ReadByte();
                        if (a != 13) q = q + (char)a;
                        //else break;
                    }
                    q = q + ")";
                }
                catch (Exception)
                {
                }
                #if(DEVEL)
                if (q.Length > 3)
                {
                    combobox2_add(port+q);
                }
                else
                {
                    combobox2_add(port);
                }
                String[] portyCOM1 = new String[portyCOM.Length + 1];
                for (int i = 0; i < portyCOM.Length; i++) portyCOM1[i] = portyCOM[i];
                portyCOM1[portyCOM.Length] = port;
                portyCOM = portyCOM1;
#else
                if (q.Length > 3)
                {
                    combobox2_add(q);
                    String[] portyCOM1 = new String[portyCOM.Length + 1];
                    for (int i = 0; i < portyCOM.Length; i++) portyCOM1[i] = portyCOM[i];
                    portyCOM1[portyCOM.Length] = port;
                    portyCOM = portyCOM1;
                }
#endif

                try
                {
                    if (serialp1.IsOpen)
                    {
                        serialp1.Close();
                    }
                }
                catch (Exception)
                {
                }

            }
            konecNacitaniPortu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            comboBox2.Items.Clear();
            portyCOM = new String[0];
            comboBox2.Text = "COM-port s interfejsem";
            button3.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Thread myThread = new Thread(getOnePortInfo);
            myThread.Start();

            if (comboBox2.Items.Count == 1)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void serialP_zpracovat(byte data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<byte>(serialP_zpracovat), data);
            }
            else
            {
                if (data == 13)
                {
                    int vstup = Convert.ToInt32(strPort[1]) - 48;     // převede ze znaku na ASCII kod, kde '0' je 48
                    if (strPort[0] == '0' && strPort[2] == 'A')
                    {
                        if (textBox2.Text == "") textBox2.Text = ".";
                        int plen = strPortPoc - 3 + textBox2.TextLength - 1;
                        Char[] p1 = new Char[plen];
                        int i = 0;
                        while (strPort[i + 3] != '.')
                        {
                            p1[i] = strPort[i + 3];
                            i++;
                        }
                        int j;
                        for (j = 0; j < textBox2.TextLength; j++)
                        {
                            p1[i + j] = textBox2.Text[j];
                        }
                        i += j;
                        while (i < plen)
                        {
                            p1[i] = strPort[i + 3 - textBox2.TextLength + 1];
                            i++;
                        }
                        Double hodn = Convert.ToDouble(new String(p1));

                        int cil = kamPoslatHodnotu(vstup);
                        // odešle změřenou hodnotu
                        usercontrol[vstup - 1].odeslanoHodnot++;
                        odesilac.inBufferKlav(hodn.ToString()+ textBox3.Text);
                        for (i = 0; i < poKazdeHodn.getpoc(); i++)
                        {
                            //poKazdeHodn
                            //if((int)poKazdeHodn.getzprava(i).Msg==(int)Tkomun.WMessages.WM_KEYDOWN)
                            odesilac.inBufferZprava(poKazdeHodn.getzprava(i));
                        }
                        for (j = 0; j < usercontrol2max; j++)
                        {

                            if (poNHodn[j].numericUpDown1.Value != 0 && usercontrol[vstup - 1].odeslanoHodnot % poNHodn[j].numericUpDown1.Value == 0)
                            {
                                odesilac.inBufferKlav(poNHodn[j].textBox1.Text);
                                for (i = 0; i < poNHodn[j].getPocZprav(); i++)
                                {
                                    //poNHodn
                                    odesilac.inBufferZprava(poNHodn[j].getZprava(i));
                                }
                            }

                        }
                        odesilac.odeslat(cil);
                        listBox1.Items.Add(hodn.ToString()+" ze vstupu "+vstup.ToString());
                    }
                    if (strPort[0] == '9')      // nějaká chyba
                    {
                        if (strPort[2] == '1') labelChyba.Text = "nepřipojené nebo vypnuté měřidlo na vstupu: " + vstup.ToString();
                        if (strPort[2] == '2') labelChyba.Text = "chyba formátu dat došlých z měřidla na vstupu: " + vstup.ToString();
                        if (checkBoxChyboveHlaseni.Checked)
                        {
                            int cil = kamPoslatHodnotu(vstup);
                            odesilac.inBufferKlav("chyba");
                            odesilac.odeslat(cil);
                        }
                    }
                    //listBox1.Items.Add(new String(strPort));
                    strPortPoc = 0;
                }
                else
                {
                    strPort[strPortPoc] = (char)data;
                    strPortPoc++;
                }
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (serialPort1.IsOpen && serialPort1.BytesToRead != 0)
                {
                    int a = serialPort1.ReadByte();
                    serialP_zpracovat((byte)a);
                }
            }
            catch (Exception)
            {
            }
        }

        private int kamPoslatHodnotu(int vstup)
        {
            int result = 0;
            if (usercontrol[vstup - 1].checkBox1.Checked)       // posílat hodnoty do hlavní aplikace
            {
                result = comboBox1.SelectedIndex;
            }
            else if (usercontrol[vstup - 1].checkBox2.Checked)     // poslat hodnoty do aplikace uvedene v usercontrolu
            {
                result = usercontrol[vstup - 1].comboBox1.SelectedIndex;
            }
            return result;
        }
        private void povolitPrvky(bool povol)
        {
            bool enabl = povol;

            label1.Enabled = enabl;
            label3.Enabled = enabl;
            label4.Enabled = enabl;
            label5.Enabled = enabl;
            textBox1.Enabled = enabl;
            textBox2.Enabled = enabl;
            textBox3.Enabled = enabl;
            spustitToolStripMenuItem.Enabled = enabl;
            comboBox1.Enabled = enabl;
            comboBox2.Enabled = enabl;
            checkBox1.Enabled = enabl;
            checkBoxChyboveHlaseni.Enabled = enabl;
            button1.Enabled = enabl;
            button3.Enabled = enabl;
            button4.Enabled = enabl;
            for (int i = 0; i < usercontrol1max; i++)
            {
                usercontrol[i].Enabled = enabl;
            }
            for (int i = 0; i < usercontrol2max; i++)
            {
                poNHodn[i].Enabled = enabl;
            }
        }

        private void spustitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < usercontrol1max; i++) usercontrol[i].odeslanoHodnot = 0;
            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Musíte zadat COM port s interfejsem");
                return;
            }
            bool v = false;
            for (int i = 0; i < usercontrol1max; i++)
            {
                if ((usercontrol[i].checkBox1.Checked && comboBox1.SelectedIndex>=0) ||
                    usercontrol[i].checkBox2.Checked && usercontrol[i].comboBox1.SelectedIndex>=0)
                    v = true;

            }
            if (!v)
            {
                MessageBox.Show("Musíte zvolit cílový program");
                return;
            }
            try
            {
                serialPort1.PortName = portyCOM[comboBox2.SelectedIndex];
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    povolitPrvky(false);
                    tabControl1.SelectedTab = tabPage2;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (checkBox1.Checked)
                {
                    int a = Convert.ToInt32(textBox1.Text);
                    timer1.Interval = a;
                    timer1.Start();
                    button2.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }
       
        private void zastavitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;
            timer1.Stop();
            if (serialPort1.IsOpen) serialPort1.Close();
            if (!serialPort1.IsOpen)
            {
                povolitPrvky(true);
                button2.Enabled = true;
                tabControl1.SelectedTab = tabPage1;
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
            if (serialPort1.IsOpen) serialPort1.Write("A" + (char)13);
            //if (checkBox1.Checked && comPort1.IsOpen) comPort1.Write("A" + (char)13);
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


    }

}
