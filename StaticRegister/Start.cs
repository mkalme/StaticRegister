using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StaticRegister
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            //SET PASSWORD CHARACTER
            textBox1.PasswordChar = '\u25CF';

            checkIfNew();
        }

        private void checkIfNew() {
            if (!File.Exists(Main.infoFile))
            {
                createNew();
            }
        }

        private void createNew() {
            //CREATE KEY
            Encryption.key = Random.stringToByte(Random.generateRandom());

            //CREATE
            Random.create();

            //OPEN NEW
            New newForm = new New();

            //HIDE
            Hide();

            //OPEN FORM
            newForm.ShowDialog();

            //OPEN MAIN FORM
            Main mainForm = new Main();
            mainForm.ShowDialog();

            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            Encryption.key = Random.stringToByte(textBox1.Text);

            Hide();

            mainForm.ShowDialog();

            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.CapsLock)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
