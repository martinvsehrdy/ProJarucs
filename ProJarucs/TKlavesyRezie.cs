using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProJaru
{
    class TKlavesyRezie:IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            bool handled = false;
            //if( poKazdeHodn!=null && poKazdeHodn.enabled ) listBox2.Items.Add(m.Msg);
            // Listen for operating system messages.
            {
                if (m.Msg == (int)Tkomun.WMessages.WM_KEYDOWN)
                {
                    // zjistuje klavesy poKazdyH
                    if (enabled)
                    {
                        addzprava(m);
                        if (myButton.Text == "") myButton.Text = getStr(getpoc() - 1);
                        else myButton.Text = myButton.Text + " + " + getStr(getpoc() - 1);
                        handled = true;
                        enabled = false;
                    }
                }
                /*if (m.Msg == (int)Tkomun.EMessages.EM_GETSEL || m.Msg == (int)Tkomun.EMessages.EM_LINEFROMCHAR)
                {
                    if (enabled)
                    {
                        addzprava(m);
                        handled = true;
                    }
                }*/
                if (m.Msg == (int)Tkomun.WMessages.WM_CHAR || m.Msg == (int)Tkomun.WMessages.WM_KEYUP)
                {
                    // poKazdyH
                    if (enabled)
                    {
                        //klavesyUp();
                        handled = true;
                        enabled = false;
                    }

                }/*/
                if (m.Msg == (int)Tkomun.WMessages.WM_CHAR)
                {
                    // zjistuje klavesy poKazdyH
                    if (enabled)
                    {
                        addzprava(m);
                        if (myButton.Text == "") myButton.Text = getStr(getpoc() - 1);
                        else myButton.Text = myButton.Text + " + " + getStr(getpoc() - 1);
                        handled = true;
                        enabled = false;
                    }
                }//*/
            }
            return handled;
            
        }

        const int pocZpr = 30;
        Message[] zpravy;
        int poc;
        public bool enabled;
        Button myButton;

        public TKlavesyRezie()
        {
            myButton = null;
            zpravy=new Message[pocZpr];
            reset();
            enabled = false;
        }

        public TKlavesyRezie(Button inButton)
        {
            myButton = inButton;
            zpravy = new Message[pocZpr];
            reset();
            enabled = false;
        }
        public TKlavesyRezie(TKlavesyRezie inKlavesy)
        {

            zpravy = new Message[pocZpr];
            reset();
            enabled = false;
            for (int i = 0; i < pocZpr; i++)
            {
                zpravy[i] = inKlavesy.getzprava(i);
            }
        }

        public void reset()//poc:=0;
        {
            poc=0;
        }

        public void addzprava(Message zprava)
        {
            if(poc>pocZpr) return;
            if( 0<poc && zpravy[poc].WParam==zpravy[poc-1].WParam) return;
            if ((int)zprava.WParam == 13)
            {
                zpravy[poc] = zprava;
                poc++;
                zprava.WParam = (IntPtr)10;
            }
            zpravy[poc]=zprava;
            poc++;
        }

        public bool isEnabled()
        {
            return enabled;
        }

        public int getpoc()
        {
            return poc;
        }

        public Message getzprava(int i)
        {
            if( 0<=i && i<poc ) return zpravy[i];
            return new Message();
        }

        public string getStr(int i)
        {
            string result="Nic";
            if( 48<=(int)zpravy[i].WParam && (int)zpravy[i].WParam<=57 )
            {
                int a=(int)zpravy[i].WParam-48;
                result=a.ToString();         //0..9
            }else
            if( 65<=(int)zpravy[i].WParam && (int)zpravy[i].WParam<=90 )
            {
                int a=(int)zpravy[i].WParam;
                result = new String((char)a, 1);
                //result[0] = (char)a;                 // A..Z
            }else
            if( 96<=(int)zpravy[i].WParam && (int)zpravy[i].WParam<=105 )
            {
                int a=(int)zpravy[i].WParam-0x60;
                result="Num"+a.ToString();
            }else
            if(112<=(int)zpravy[i].WParam && (int)zpravy[i].WParam<=123 )
            {
                int a=(int)zpravy[i].WParam-111;
                result="F"+a.ToString();
            }else
            switch((int)zpravy[i].WParam)
            {
                case 8:
                    result="Backspace";
                    break;
                case 9:
                    result="Tab";
                    break;
                case 10:
                    result = "Enter";
                    break;
                case 12:
                    result="clear";
                    break;
                case 13:
                    result="Enter";
                    break;
                case 16:
                    result="Shift";
                    break;
                case 17:
                    result="Ctrl";
                    break;
                case 18:
                    result="Alt";
                    break;
                case 19:
                    result="Pause";
                    break;
                case 27:
                    result="Esc";
                    break;
                case 32:
                    result="Space";
                    break;
                case 33:
                    result="PageUp";
                    break;
                case 34:
                    result="PageDown";
                    break;
                case 35:
                    result="End";
                    break;
                case 36:
                    result="Home";
                    break;
                case 37:
                    result="<-";
                    break;
                case 38:
                    result="^";
                    break;
                case 39:
                    result="->";
                    break;
                case 40:
                    result="|";
                    break;
                case 45:
                    result="Ins";
                    break;
                case 46:
                    result="Del";
                    break;
                default:
                    int a=(int)zpravy[i].WParam;
                    result="["+a.ToString()+"]";
                    break;
            }

            return result;
        }

        public void klavesyUp()
        {
            int pompoc=poc;

            for (int i = pompoc; i >= 0; i--)
            {
                if (zpravy[i].Msg == (int)Tkomun.WMessages.WM_KEYDOWN && poc <= pocZpr)
                {
                    Message pomzprava = zpravy[i];
                    pomzprava.Msg = (int)Tkomun.WMessages.WM_KEYUP;
                    addzprava(pomzprava);
                }
            }
        }

    }
}
