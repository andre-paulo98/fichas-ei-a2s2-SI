using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EI.SI;

namespace ei_si_worksheet3 {
    public partial class Form2 : Form {

        byte[] key, iv;
        public Form2() {

            InitializeComponent();
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e) {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                key = aes.Key;
                iv = aes.IV;
                using (SymmetricsSI symmetrics = new SymmetricsSI(aes)) {
                    textBoxEncryptedText.Text = Convert.ToBase64String(symmetrics.Encrypt(Encoding.UTF8.GetBytes(textBoxTextToEncrypt.Text)));
                }
            }
        }


        private void ButtonDecrypt_Click(object sender, EventArgs e) {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                aes.Key = key;
                aes.IV = iv;
                using (SymmetricsSI symmetrics = new SymmetricsSI(aes)) {
                    textBoxDecryptedText.Text = Encoding.UTF8.GetString(symmetrics.Decrypt(Convert.FromBase64String(textBoxEncryptedText.Text)));
                }
            }
            
        }
    }
}
