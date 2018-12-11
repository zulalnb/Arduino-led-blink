using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace lednet1
{
    public partial class Form1 : Form
    {
        string[] portlar = SerialPort.GetPortNames();
        bool LEDDurum = false;
        
        public Form1()
        {
            InitializeComponent();

            //serialPort1 = new SerialPort();
            //serialPort1.PortName = "COM3";
            //serialPort1.BaudRate = 9600;
            //serialPort1.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
            
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
            labelleddurum.Visible = true;
            labelleddurum.Text = "LED Yanıyor...";
            buttonOn.Enabled = false;
            buttonOff.Enabled = true;
            LEDDurum = true;
            pictureBoxled.Image = Image.FromFile("C:/Users/istanbul/Desktop/Bullet-green.png");
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            serialPort1.Write("0");
            labelleddurum.Visible = true;
            labelleddurum.Text = "LED Söndü...";
            buttonOn.Enabled = true;
            buttonOff.Enabled = false;
            LEDDurum = false;
            pictureBoxled.Image = Image.FromFile("C:/Users/istanbul/Desktop/buttonson.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string port in portlar)
            {
                comboBox1.Items.Add(port);
                comboBox1.SelectedIndex = 0;
            }
            comboBox2.Items.Add("4800");
            comboBox2.Items.Add("9600");
            comboBox2.SelectedIndex=2;
            labelbagdurum.Visible = true;
            labelbagdurum.Text = "Bağlantı Kapalı!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                if (comboBox1.Text == "") return;
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt16(comboBox2.Text);
                try
                {
                    serialPort1.Open();
                    labelbagdurum.ForeColor = Color.Green;
                    labelbagdurum.Text = "Bağlantı Açık!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw;
                }
            }
            else
            {
                labelbagdurum.Text = "Bağlantı Kurulu!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
            labelbagdurum.Visible = true;
            labelbagdurum.Text="Bağlantı Kapalı!";
        }
    }
}

            //serialPort1.PortName = comboBox1.Text;
            //serialPort1.Open();
            //labelbagdurum.Visible = true;
            //labelbagdurum.Text = "Bağlantı Açık!";           