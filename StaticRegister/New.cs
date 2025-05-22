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
    public partial class New : Form
    {
        public New()
        {
            InitializeComponent();
        }

        private void New_Load(object sender, EventArgs e)
        {
            textBox1.Text = Encoding.ASCII.GetString(Encryption.key);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
