namespace ProJaru
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.měřeníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spustitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zastavitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interfejsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přečteníIdentifikacenázvuInterfejsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přečteníSériovéhoČíslaInterfejsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonZastavitMereni = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelChyba = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxChyboveHlaseni = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.ReadTimeout = 500;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.měřeníToolStripMenuItem,
            this.interfejsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // měřeníToolStripMenuItem
            // 
            this.měřeníToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spustitToolStripMenuItem,
            this.zastavitToolStripMenuItem});
            this.měřeníToolStripMenuItem.Name = "měřeníToolStripMenuItem";
            this.měřeníToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.měřeníToolStripMenuItem.Text = "Měření";
            // 
            // spustitToolStripMenuItem
            // 
            this.spustitToolStripMenuItem.Name = "spustitToolStripMenuItem";
            this.spustitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.spustitToolStripMenuItem.Text = "Spustit";
            this.spustitToolStripMenuItem.Click += new System.EventHandler(this.spustitToolStripMenuItem_Click);
            // 
            // zastavitToolStripMenuItem
            // 
            this.zastavitToolStripMenuItem.Name = "zastavitToolStripMenuItem";
            this.zastavitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.zastavitToolStripMenuItem.Text = "Zastavit";
            this.zastavitToolStripMenuItem.Click += new System.EventHandler(this.zastavitToolStripMenuItem_Click);
            // 
            // interfejsToolStripMenuItem
            // 
            this.interfejsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přečteníIdentifikacenázvuInterfejsuToolStripMenuItem,
            this.přečteníSériovéhoČíslaInterfejsuToolStripMenuItem,
            this.přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem});
            this.interfejsToolStripMenuItem.Name = "interfejsToolStripMenuItem";
            this.interfejsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.interfejsToolStripMenuItem.Text = "Interfejs";
            // 
            // přečteníIdentifikacenázvuInterfejsuToolStripMenuItem
            // 
            this.přečteníIdentifikacenázvuInterfejsuToolStripMenuItem.Name = "přečteníIdentifikacenázvuInterfejsuToolStripMenuItem";
            this.přečteníIdentifikacenázvuInterfejsuToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.přečteníIdentifikacenázvuInterfejsuToolStripMenuItem.Text = "přečtení identifikace (názvu) interfejsu";
            this.přečteníIdentifikacenázvuInterfejsuToolStripMenuItem.Click += new System.EventHandler(this.přečteníIdentifikacenázvuInterfejsuToolStripMenuItem_Click);
            // 
            // přečteníSériovéhoČíslaInterfejsuToolStripMenuItem
            // 
            this.přečteníSériovéhoČíslaInterfejsuToolStripMenuItem.Name = "přečteníSériovéhoČíslaInterfejsuToolStripMenuItem";
            this.přečteníSériovéhoČíslaInterfejsuToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.přečteníSériovéhoČíslaInterfejsuToolStripMenuItem.Text = "přečtení sériového čísla interfejsu";
            this.přečteníSériovéhoČíslaInterfejsuToolStripMenuItem.Click += new System.EventHandler(this.přečteníSériovéhoČíslaInterfejsuToolStripMenuItem_Click);
            // 
            // přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem
            // 
            this.přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem.Name = "přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem";
            this.přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem.Text = "přečtení čísla verze firmware interfejsu";
            this.přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem.Click += new System.EventHandler(this.přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.buttonZastavitMereni);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.labelChyba);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(831, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Měření";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Změřené hodnoty:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(275, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(202, 225);
            this.listBox1.TabIndex = 3;
            // 
            // buttonZastavitMereni
            // 
            this.buttonZastavitMereni.Location = new System.Drawing.Point(103, 22);
            this.buttonZastavitMereni.Name = "buttonZastavitMereni";
            this.buttonZastavitMereni.Size = new System.Drawing.Size(96, 23);
            this.buttonZastavitMereni.TabIndex = 2;
            this.buttonZastavitMereni.Text = "Zastavit měření";
            this.buttonZastavitMereni.UseVisualStyleBackColor = true;
            this.buttonZastavitMereni.Click += new System.EventHandler(this.zastavitToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Měř !";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.timer1_Tick);
            // 
            // labelChyba
            // 
            this.labelChyba.AutoSize = true;
            this.labelChyba.Location = new System.Drawing.Point(19, 64);
            this.labelChyba.Name = "labelChyba";
            this.labelChyba.Size = new System.Drawing.Size(86, 13);
            this.labelChyba.TabIndex = 0;
            this.labelChyba.Text = "Chybová hláška:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(831, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nastavení";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxChyboveHlaseni);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(465, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 209);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Formátování";
            // 
            // checkBoxChyboveHlaseni
            // 
            this.checkBoxChyboveHlaseni.AutoSize = true;
            this.checkBoxChyboveHlaseni.Location = new System.Drawing.Point(6, 44);
            this.checkBoxChyboveHlaseni.Name = "checkBoxChyboveHlaseni";
            this.checkBoxChyboveHlaseni.Size = new System.Drawing.Size(106, 17);
            this.checkBoxChyboveHlaseni.TabIndex = 19;
            this.checkBoxChyboveHlaseni.Text = "Chybové hlášení";
            this.checkBoxChyboveHlaseni.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Přečíst hodnoty každých";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "1000";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(255, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "nic";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Znak oddělovače desetiných míst: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "milisekund";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(255, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = ",";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "text: ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(255, 120);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(93, 20);
            this.textBox3.TabIndex = 14;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Po každé hodnotě odeslat klávesovou zkratku: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 55);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Volba interfejsu";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(356, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(368, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Aktualizovat";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(6, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 266);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volba aplikace";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(356, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aktualizovat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(300, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 100);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Zjišťuji dostupné interfejsy";
            this.label6.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(548, 253);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem měřeníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spustitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zastavitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interfejsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přečteníIdentifikacenázvuInterfejsuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přečteníSériovéhoČíslaInterfejsuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přečteníČíslaVerzeFirmwareInterfejsuToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonZastavitMereni;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelChyba;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxChyboveHlaseni;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

