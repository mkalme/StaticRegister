using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StaticRegister
{
    class Random
    {
        private const string errorText = "There was an error.\t\t\t\t\t";

        public static void create()
        {
            //CREATE DIRECTORY
            Directory.CreateDirectory(Main.path);

            //CREATE INFO FILE
            createFile(Main.infoFile, insertNewLine(Encryption.Encrypt(" "), 30));
        }

        public static byte[] stringToByte(String text) {
            byte[] bytes = null;
            try
            {
                bytes = Encoding.ASCII.GetBytes(text);
            }
            catch
            {
                errorMessage(errorText, "Error");
            }
            return bytes;
        }

        public static String byteToHex(byte[] byteArray)
        {
            String text = "";
            try
            {
                text = BitConverter.ToString(byteArray).Replace("-", " ");
            }
            catch
            {
                errorMessage(errorText, "Error");
            }
            return text;
        }

        public static byte[] hexToByte(String text)
        {
            text = text.Replace(" ", "").Replace("-", "").Replace("\n", "");
            byte[] byteArray = null;
            try
            {
                byteArray = Enumerable.Range(0, text.Length / 2).Select(x => Convert.ToByte(text.Substring(x * 2, 2), 16)).ToArray();
            }
            catch
            {
                errorMessage(errorText, "Error");
            }

            return byteArray;
        }

        public static byte[] byteSubstring(byte[] byteArray, int index, int endIndex)
        {
            int length = endIndex - index;
            byte[] array = new byte[length];

            try
            {
                for (int i = 0; i < length; i++)
                {
                    array[i] = byteArray[index + i];
                }
            }
            catch
            {
                errorMessage(errorText, "Error");
            }

            return array;
        }

        public static byte[] byteSubstringAll(byte[] byteArray, int index)
        {
            int length = byteArray.Length - index;
            byte[] array = new byte[length];

            try
            {
                for (int i = 0; i < length; i++)
                {
                    array[i] = byteArray[index + i];
                }
            }
            catch
            {
                errorMessage(errorText, "Error");
            }

            return array;
        }

        public static String insertNewLine(String text, int newLineEvery)
        {
            return Regex.Replace(text, ".{" + (newLineEvery * 3) + "}", "$0\n");
        }

        public static DialogResult dialog(String text, String title)
        {
            DialogResult dialogResult = MessageBox.Show(text, title, MessageBoxButtons.YesNo);
            return dialogResult;
        }

        public static void errorMessage(String text, String title)
        {
            MessageBox.Show(text, title,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }

        public static void createFile(String path, String text)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(text);
                }
            }
        }

        public static void writeFile(String path, String text)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(text);
            }
        }

        public static String readFile(String filePath)
        {
            String text = "";
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    text += s + "\n";
                }
            }

            return text.Remove(text.Length - 1); ;
        }

        public static String generateRandom() {
            String characters = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
            String text = "";

            System.Random rand = new System.Random();

            for (int i = 0; i < 32; i++) {
                text += characters[rand.Next(characters.Length)];
            }

            return text;
        }
    }
}
