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
    public partial class Main : Form
    {
        public static String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Static Register 2018\Register";
        public static String infoFile = path + @"\storage";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //SET PASSWORD CHARACTER
            textBox1.PasswordChar = '\u25CF';

            //SET TEXT
            textBox1.Text = getPAS();
        }

        public static String getPAS() {
            String text = Encryption.Decrypt(Random.readFile(infoFile));

            return text;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeMain changeMain = new ChangeMain();
            ChangeMain.mainTextBox = textBox1;
            changeMain.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeCurrent changeCurrent = new ChangeCurrent();
            changeCurrent.ShowDialog();
        }
    }
}
