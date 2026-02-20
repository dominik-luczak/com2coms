using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;

namespace com2coms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get a list of serial port names. 
            string[] ports_tmp = SerialPort.GetPortNames();
            Array.Sort(ports_tmp);

            string[] ports = new string[ports_tmp.Length];
            int i = 0, j = 0, Len4Offset = 0;

            foreach (string port in ports_tmp)
            {
                if(port.Length == 4)
                    Len4Offset++;
            }

            i = Len4Offset;
            foreach (string port in ports_tmp)
            {
                if(port.Length == 4)
                {
                    ports[j] = port;
                    j++;
                }
                else
                {
                    ports[i] = port;
                    i++;
                }                
            }

            comboBoxPortName.Items.AddRange(ports);
            comboBoxPortNameOUT1.Items.AddRange(ports);
            comboBoxPortNameOUT2.Items.AddRange(ports);
        }


        private void clearIN_Click(object sender, EventArgs e)
        {
            textBoxIN.Clear();
            textBoxHex.Clear();
        }

        private void open_Click(object sender, EventArgs e)
        {
            int portNuber=0;

            if (open.Text == "OpenALL")
            {
                if(comboBoxPortName.Text!="")portNuber++;
                if(comboBoxPortNameOUT1.Text != "")portNuber++;
                if(comboBoxPortNameOUT2.Text != "")portNuber++;

                if (portNuber <= 1)
                {
                    MessageBox.Show("Two ports are required", "Warning");
                    return;
                }

                try
                {
                    if (!serialPortIN.IsOpen && comboBoxPortName.Text!="")
                    {
                        serialPortIN.BaudRate = int.Parse(comboBoxBaudRate.Text);
                        serialPortIN.PortName = comboBoxPortName.Text;
                        serialPortIN.Open();
                    }
                    if (!serialPortOUT1.IsOpen && comboBoxPortNameOUT1.Text != "")
                    {
                        serialPortOUT1.BaudRate = int.Parse(comboBoxBaudRate.Text);
                        serialPortOUT1.PortName = comboBoxPortNameOUT1.Text;
                        serialPortOUT1.Open();
                    }
                    if (!serialPortOUT2.IsOpen && comboBoxPortNameOUT2.Text != "")
                    {
                        serialPortOUT2.BaudRate = int.Parse(comboBoxBaudRate.Text);
                        serialPortOUT2.PortName = comboBoxPortNameOUT2.Text;
                        serialPortOUT2.Open();
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Wrong PortName. " + ex.Message, "Warning");
                    if (serialPortIN.IsOpen)
                    {
                        serialPortIN.Close();
                    }
                    if (serialPortOUT1.IsOpen)
                    {
                        serialPortOUT1.Close();
                    }
                    if (serialPortOUT2.IsOpen)
                    {
                        serialPortOUT2.Close();
                    }
                    return;
                }
                catch(ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Warning");
                    if (serialPortIN.IsOpen)
                    {
                        serialPortIN.Close();
                    }
                    if (serialPortOUT1.IsOpen)
                    {
                        serialPortOUT1.Close();
                    }
                    if (serialPortOUT2.IsOpen)
                    {
                        serialPortOUT2.Close();
                    }
                    return;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Port is used. " + ex.Message, "Warning");
                    if (serialPortIN.IsOpen)
                    {
                        serialPortIN.Close();
                    }
                    if (serialPortOUT1.IsOpen)
                    {
                        serialPortOUT1.Close();
                    }
                    if (serialPortOUT2.IsOpen)
                    {
                        serialPortOUT2.Close();
                    }
                    return;
                }
            }
            if (open.Text == "CloseALL")
            {
                if (serialPortIN.IsOpen)
                {
                    serialPortIN.Close();
                }
                if (serialPortOUT1.IsOpen)
                {
                    serialPortOUT1.Close();
                }
                if (serialPortOUT2.IsOpen)
                {
                    serialPortOUT2.Close();
                }
            }

            if (open.Text == "CloseALL")
                open.Text = "OpenALL";
            else
                open.Text = "CloseALL";

        }

        private void timerRead_Tick(object sender, EventArgs e)
        {
            if (serialPortIN.IsOpen)
            {
                if (serialPortIN.BytesToRead > 0)
                {
                    byte[] data;
                    int size = serialPortIN.BytesToRead;
                    data = new byte[size];
                    serialPortIN.Read(data, 0, size); //Byte( ReadExisting();

                    if (serialPortOUT1.IsOpen) serialPortOUT1.Write(data, 0, size);
                    if (serialPortOUT2.IsOpen) serialPortOUT2.Write(data, 0, size);
                    //textBoxIN.AppendText("[" + serialPortIN.PortName + "]", Color.Green);
                    textBoxIN.AppendText(Encoding.UTF8.GetString(data, 0, data.Length), Color.Green);
                    textBoxHex.AppendText(ConvertBytesToHex(data), Color.Green);
                }
            }
            if (serialPortOUT1.IsOpen)
            {
                if (serialPortOUT1.BytesToRead > 0)
                {
                    byte[] data;
                    int size = serialPortOUT1.BytesToRead;
                    data = new byte[size];
                    serialPortOUT1.Read(data, 0, size);

                    if (serialPortIN.IsOpen) serialPortIN.Write(data, 0, size);
                    if (serialPortOUT2.IsOpen) serialPortOUT2.Write(data, 0, size);
                    //textBoxIN.AppendText("[" + serialPortOUT1.PortName + "]", Color.Red);
                    textBoxIN.AppendText(Encoding.UTF8.GetString(data, 0, data.Length), Color.Red);
                    textBoxHex.AppendText(ConvertBytesToHex(data), Color.Red);
                }
            }
            if (serialPortOUT2.IsOpen)
            {
                if (serialPortOUT2.BytesToRead > 0)
                {
                    byte[] data;
                    int size = serialPortOUT2.BytesToRead;
                    data = new byte[size];
                    serialPortOUT2.Read(data, 0, size);

                    if (serialPortIN.IsOpen) serialPortIN.Write(data, 0, size);
                    if (serialPortOUT1.IsOpen) serialPortOUT1.Write(data, 0, size);
                    //textBoxIN.AppendText("[" + serialPortOUT2.PortName + "]", Color.Blue);
                    textBoxIN.AppendText(Encoding.UTF8.GetString(data, 0, data.Length), Color.Blue);
                    textBoxHex.AppendText(ConvertBytesToHex(data), Color.Blue);
                }
            }
        }

        public string ConvertBytesToHex(byte[] aByte)
        {
            string hex = "";
            foreach (byte c in aByte)
            {
                //int tmp = c;
                hex += String.Format("{0:X2} ", c );
            }
            return hex;
        }

        public string ConvertStringToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:X2} ", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start("http://luczak.eu");
        }
    }


    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
