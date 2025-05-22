using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace StaticRegister
{
    public partial class ChangeMain : Form
    {
        public static String dialogText = "Are you sure you want to change the main key?\t\t\t";
        public static TextBox mainTextBox;
        
        public ChangeMain()
        {
            InitializeComponent();

            //SET PASSWORD CHARACTER
            textBox1.PasswordChar = '\u25CF';

            timer1.Start();
        }

        private void ChangeMain_Load(object sender, EventArgs e)
        {
            textBox1.Text = mainTextBox.Text;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            changeMainKey();
        }

        private void changeMainKey() {
            if (Random.dialog(dialogText, "Change main key") == DialogResult.Yes)
            {
                String encryptedText = Encryption.Encrypt(textBox1.Text);
                Random.writeFile(Main.infoFile, Random.insertNewLine(encryptedText, 30));
                mainTextBox.Text = textBox1.Text;

                Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.CapsLock)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                changeButton.Enabled = true;
            }
            else {
                changeButton.Enabled = false;
            }
        }
    }
}
