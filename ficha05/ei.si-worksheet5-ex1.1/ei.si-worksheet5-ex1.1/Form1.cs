using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ei.si.worksheet5 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            
        }

        private void ButtonMD5ComputeHash_Click(object sender, EventArgs e) {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                textBoxHashBytes.Text = BitConverter.ToString(md5.ComputeHash(GetDataFromTextBox()));
                MessageBox.Show($"Hash size = {md5.HashSize}");
            }

            /*
             * 
            var data = GetDataFromTextBox();
            byte[] hash = null;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                hash = md5.ComputeHash(data);
                textBoxHashBytes.Text = BitConverter.ToString(hash);
            }
             */
        }

        private void ButtonSHA1ComputeHash_Click(object sender, EventArgs e) {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) {
                textBoxHashBytes.Text = BitConverter.ToString(sha1.ComputeHash(GetDataFromTextBox()));
                MessageBox.Show($"Hash size = {sha1.HashSize}");
            }
        }

        private void ButtonSHA256ComputeHash_Click(object sender, EventArgs e) {
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider()) {
                textBoxHashBytes.Text = BitConverter.ToString(sha256.ComputeHash(GetDataFromTextBox()));
                MessageBox.Show($"Hash size = {sha256.HashSize}");
            }
        }

        private void ButtonSHA512ComputeHash_Click(object sender, EventArgs e) {
            using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider()) {
                textBoxHashBytes.Text = BitConverter.ToString(sha512.ComputeHash(GetDataFromTextBox()));
                MessageBox.Show($"Hash size = {sha512.HashSize}");
            }
        }

        private byte[] GetDataFromTextBox() {
            return Encoding.UTF8.GetBytes(textBoxDataToHash.Text);
        }
    }
}
