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
using System.IO;

namespace ei_si_worksheet4 {
    public partial class Form1 : Form {

        public const string FILENAME_PUBLIC_KEY = "publicKey.xml";
        public const string FILENAME_PUBLIC_PRIVATE_KEY = "privateAndPublic.xml";

        public Form1() {
            InitializeComponent();
        }


        private void ButtonGererateKeys_Click(object sender, EventArgs e) {
            try {
                using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider()) {
                    textboxPublicKey.Text = algorithm.ToXmlString(false); // false = only public key
                    textboxBothKeys.Text = algorithm.ToXmlString(true); // true = both private and public
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
                throw;
            }

        }

        private void ButtonSavePublicKey_Click(object sender, EventArgs e) {
            File.WriteAllText(FILENAME_PUBLIC_KEY, textboxPublicKey.Text);
            MessageBox.Show($"Public key exported to '{FILENAME_PUBLIC_KEY}'");
        }

        private void ButtonSaveKeys_Click(object sender, EventArgs e) {
            File.WriteAllText(FILENAME_PUBLIC_PRIVATE_KEY, textboxBothKeys.Text);
            MessageBox.Show($"Private and Public keys exported to '{FILENAME_PUBLIC_PRIVATE_KEY}'");
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e) {
            byte[] plainText, cipheredData;
            string publicKey;


            try {
                plainText = Encoding.UTF8.GetBytes(textboxSymmetricKey.Text);

                using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider()) {
                    publicKey = File.ReadAllText(FILENAME_PUBLIC_KEY);
                    algorithm.FromXmlString(publicKey);

                    cipheredData = algorithm.Encrypt(plainText, true); // true = OAEP padding

                    textboxSymmetricKeyEncrypted.Text = Convert.ToBase64String(cipheredData);
                    textboxBitSize.Text = cipheredData.Length * 8 + "";

                }
            } catch (CryptographicException ex) {
                MessageBox.Show($"CryptographicException: {ex.Message}");
                throw;
            }

        }

        private void ButtonDecrypt_Click(object sender, EventArgs e) {
            byte[] cipherData = Convert.FromBase64String(textboxSymmetricKeyEncrypted.Text);
            byte[] plainText;

            try {
                using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider()) {
                    algorithm.FromXmlString(File.ReadAllText(FILENAME_PUBLIC_PRIVATE_KEY));

                    plainText = algorithm.Decrypt(cipherData, true);

                    textboxSymmetricKeyDecrypted.Text = Encoding.UTF8.GetString(plainText);
                }
            } catch (CryptographicException ex) {
                MessageBox.Show($"Error while decrypting text: {ex.Message}");
                throw;
            }
        }
    }
}
