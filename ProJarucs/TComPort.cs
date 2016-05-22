using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace ProJaru
{
    class TComPort : SerialPort
    {
        IntPtr hwndAplikace;
        String[] portnames;
        Char[] strPort;
        int strPortPoc;
        int WM_SERIALHODN;
        System.Windows.Forms.Timer timer;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr /*HandleRef*/ hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern int RegisterWindowMessage(string lpProcName);

        public TComPort(IntPtr hwnd)
        {
            WM_SERIALHODN = RegisterWindowMessage("WM_SERIALHODN");
            hwndAplikace = hwnd;
            strPort = new Char[13];
            timer = new System.Windows.Forms.Timer();
            DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
            loadComPorty();
        }

        public String[] loadComPorty()
        {
            portnames = GetPortNames();
            String[] result=new String[portnames.Length];
            //detekceCOM = true;
            this.ReadTimeout = 200;
            foreach(String port in portnames)
            {
                this.PortName = port;
                this.Open();
                this.WriteLine("I" + (char)13);
                try
                {
                }
                catch (TimeoutException)
                {
                }
                catch (Exception)
                {
                }
            }
            return portnames;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (IsOpen && ReadBufferSize != 0)
                {
                    int a = ReadByte();
                    if (a == 13)
                    {
                        Int32 typHodn = 0;
                        IntPtr hodn = IntPtr.Zero;

                        if (strPort[0] == '0')
                        {
                            // odesilani správně změřené hodnoty
                            typHodn += Convert.ToInt32(strPort[1]);     // číslo vstupu

                            String q = new String(strPort, 4, 8);
                            try
                            {
                                Double d = Convert.ToDouble(q);
                                d *= (double)TComPort.Konst.koefHodn;
                                hodn = (IntPtr)d;

                            }
                            catch (Exception)
                            {
                                hodn = IntPtr.Zero;
                            }
                        }
                        if (strPort[0] == '9')
                        {
                            hodn = (IntPtr)Convert.ToInt32(strPort[2]);
                        }
                        // odeslat WM_zprávu hlavní aplikaci
                        SendMessage(hwndAplikace, WM_SERIALHODN, (IntPtr)typHodn, hodn);
                        strPortPoc = 0;
                    }
                    else
                    {
                        if (a == '.')
                        {
                            strPort[strPortPoc] = ',';
                        }
                        else
                        {
                            strPort[strPortPoc] = (char)a;
                        }
                        strPortPoc++;
                    }
                    //serialP_zpracovat((byte)a);
                }
            }
            catch (Exception)
            {

            }
        }
        /*
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

                        int cil = comboBox1.SelectedIndex;
                        // odešle změřenou hodnotu
                        if (!detekceCOM)
                        {
                            odeslanoHodnot++;
                            odesilac.inBufferKlav(new String(p1) + textBox3.Text);
                            for (i = 0; i < poKazdeHodn.getpoc(); i++)
                            {
                                //poKazdeHodn
                                //if((int)poKazdeHodn.getzprava(i).Msg==(int)Tkomun.WMessages.WM_KEYDOWN)
                                odesilac.inBufferZprava(poKazdeHodn.getzprava(i));
                            }
                            for(j=0;j<usercontrol2max;j++)
                            {

                                if (poNHodn[j].numericUpDown1.Value != 0 && odeslanoHodnot % poNHodn[j].numericUpDown1.Value == 0)
                                {
                                    odesilac.inBufferKlav(poNHodn[j].textBox1.Text);
                                    for (i = 0; i < poNHodn[j].getPocZprav() ; i++)
                                    {
                                        //poNHodn
                                        odesilac.inBufferZprava(poNHodn[j].getZprava(i));
                                    }
                                }

                            }
                            odesilac.odeslat(cil);
                        }

                    }

                    if (detekceCOM)
                    {
                        comboBox1.Items.Add(new String(strPort));
                        serialPort1.Close();
                        detekceCOM = false;
                    }else listBox1.Items.Add(new String(strPort));
                    
                    strPortPoc = 0;
                }
                else
                {
                    strPort[strPortPoc] = (char)data;
                    strPortPoc++;
                }
            }
        }
        //*/
        public enum Konst : int
        {
            koefHodn = 10000000,
            HS_hodn1 = 1,
            HS_hodn2 = 2,
            HS_hodn3 = 3,
            HS_hodn4 = 4,
            HS_chyba1 = 5,

        }
    }
}
