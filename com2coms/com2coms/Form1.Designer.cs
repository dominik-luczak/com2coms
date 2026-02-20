namespace com2coms
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
            this.serialPortIN = new System.IO.Ports.SerialPort(this.components);
            this.serialPortOUT2 = new System.IO.Ports.SerialPort(this.components);
            this.serialPortOUT1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPortNameOUT1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPortNameOUT2 = new System.Windows.Forms.ComboBox();
            this.open = new System.Windows.Forms.Button();
            this.clearIN = new System.Windows.Forms.Button();
            this.timerRead = new System.Windows.Forms.Timer(this.components);
            this.textBoxIN = new System.Windows.Forms.RichTextBox();
            this.textBoxHex = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxPortName
            // 
            this.comboBoxPortName.FormattingEnabled = true;
            this.comboBoxPortName.Location = new System.Drawing.Point(832, 131);
            this.comboBoxPortName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new System.Drawing.Size(238, 33);
            this.comboBoxPortName.TabIndex = 0;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(166, 33);
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(238, 33);
            this.comboBoxBaudRate.TabIndex = 1;
            this.comboBoxBaudRate.Text = "9600";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "BaudRate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(670, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "SerialPort 3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(670, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "SerialPort 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(670, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "SerialPort 1";
            // 
            // comboBoxPortNameOUT1
            // 
            this.comboBoxPortNameOUT1.FormattingEnabled = true;
            this.comboBoxPortNameOUT1.Location = new System.Drawing.Point(832, 27);
            this.comboBoxPortNameOUT1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxPortNameOUT1.Name = "comboBoxPortNameOUT1";
            this.comboBoxPortNameOUT1.Size = new System.Drawing.Size(238, 33);
            this.comboBoxPortNameOUT1.TabIndex = 0;
            // 
            // comboBoxPortNameOUT2
            // 
            this.comboBoxPortNameOUT2.FormattingEnabled = true;
            this.comboBoxPortNameOUT2.Location = new System.Drawing.Point(832, 79);
            this.comboBoxPortNameOUT2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxPortNameOUT2.Name = "comboBoxPortNameOUT2";
            this.comboBoxPortNameOUT2.Size = new System.Drawing.Size(238, 33);
            this.comboBoxPortNameOUT2.TabIndex = 0;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(50, 127);
            this.open.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(150, 44);
            this.open.TabIndex = 6;
            this.open.Text = "OpenALL";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // clearIN
            // 
            this.clearIN.Location = new System.Drawing.Point(212, 127);
            this.clearIN.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.clearIN.Name = "clearIN";
            this.clearIN.Size = new System.Drawing.Size(150, 44);
            this.clearIN.TabIndex = 6;
            this.clearIN.Text = "Clear";
            this.clearIN.UseVisualStyleBackColor = true;
            this.clearIN.Click += new System.EventHandler(this.clearIN_Click);
            // 
            // timerRead
            // 
            this.timerRead.Enabled = true;
            this.timerRead.Interval = 5;
            this.timerRead.Tick += new System.EventHandler(this.timerRead_Tick);
            // 
            // textBoxIN
            // 
            this.textBoxIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxIN.Location = new System.Drawing.Point(24, 208);
            this.textBoxIN.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxIN.Name = "textBoxIN";
            this.textBoxIN.Size = new System.Drawing.Size(556, 475);
            this.textBoxIN.TabIndex = 8;
            this.textBoxIN.Text = "";
            // 
            // textBoxHex
            // 
            this.textBoxHex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHex.Location = new System.Drawing.Point(596, 208);
            this.textBoxHex.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxHex.Name = "textBoxHex";
            this.textBoxHex.Size = new System.Drawing.Size(578, 475);
            this.textBoxHex.TabIndex = 8;
            this.textBoxHex.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 177);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "ASCII";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(596, 177);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "HEX";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.Location = new System.Drawing.Point(940, 704);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(237, 25);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Designed by Luczak.eu";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(854, 704);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "v 1.03";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 746);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBoxHex);
            this.Controls.Add(this.textBoxIN);
            this.Controls.Add(this.clearIN);
            this.Controls.Add(this.open);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBaudRate);
            this.Controls.Add(this.comboBoxPortNameOUT2);
            this.Controls.Add(this.comboBoxPortNameOUT1);
            this.Controls.Add(this.comboBoxPortName);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "com2coms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPortIN;
        private System.IO.Ports.SerialPort serialPortOUT2;
        private System.IO.Ports.SerialPort serialPortOUT1;
        private System.Windows.Forms.ComboBox comboBoxPortName;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPortNameOUT1;
        private System.Windows.Forms.ComboBox comboBoxPortNameOUT2;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button clearIN;
        private System.Windows.Forms.Timer timerRead;
        private System.Windows.Forms.RichTextBox textBoxIN;
        private System.Windows.Forms.RichTextBox textBoxHex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
    }
}

