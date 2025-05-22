using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaticRegister
{
    public partial class ChangeCurrent : Form
    {
        public static String textDialog = "Are you sure you want to change the current key?\t\t";

        public ChangeCurrent()
        {
            InitializeComponent();

            timer1.Start();
        }

        private void ChangeCurrent_Load(object sender, EventArgs e)
        {
            textBox1.Text = Encoding.ASCII.GetString(Encryption.key);
        }

        private void cacnelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (Random.dialog(textDialog, "Change current key") == DialogResult.Yes) {
                changeCurrentKey();
            }
        }

        private void changeCurrentKey() {
            String text = Encryption.Decrypt(Random.readFile(Main.infoFile));

            Encryption.key = Random.stringToByte(textBox1.Text);

            //WRITE TEXT
            Random.writeFile(Main.infoFile, Encryption.Encrypt(text));

            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Text = Random.generateRandom();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 32)
            {
                changeButton.Enabled = true;
            }
            else {
                changeButton.Enabled = false;
            }
        }
    }
}
