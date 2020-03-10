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

namespace ei_si_worksheet3 {
    public partial class Form1 : Form {

        byte[] key, iv, cipherData;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void ButtonEncrypt_Click(object sender, EventArgs e) {
            AesCryptoServiceProvider aes = null;
            try {
                string input = textBoxTextToEncrypt.Text;
                aes = new AesCryptoServiceProvider();


                textBoxEncryptedText.Text = Encrypt(input, aes);
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            } finally {
                if (aes != null)
                    aes.Dispose();
            }
        }

        private string Encrypt(string plainText, SymmetricAlgorithm algorithm) {
            byte[] encodedPlainText = Encoding.UTF8.GetBytes(plainText);

            using (algorithm) {
                this.key = algorithm.Key;
                this.iv = algorithm.IV;
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, algorithm.CreateEncryptor(), CryptoStreamMode.Write)) {


                        cs.Write(encodedPlainText, 0, encodedPlainText.Length);
                        
                    }
                    this.cipherData = ms.ToArray();
                }
               
            }
            //return Encoding.UTF8.GetString(this.cipherData);
            return Convert.ToBase64String(this.cipherData);
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e) {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {

                textBoxDecryptedText.Text = Decrypt(aes);

            }
        }

        private string Decrypt(SymmetricAlgorithm algorithm) {
            byte[] encodedPlainText = new byte[cipherData.Length];
            int bytesRead = 0;
            using (algorithm) {
                algorithm.Key = this.key;
                algorithm.IV = this.iv;
                using (MemoryStream ms = new MemoryStream(this.cipherData)) {
                    using (CryptoStream cs = new CryptoStream(ms, algorithm.CreateDecryptor(), CryptoStreamMode.Read)) {
                        

                        bytesRead = cs.Read(encodedPlainText, 0, encodedPlainText.Length);

                    }
                    Array.Resize(ref encodedPlainText, bytesRead);
                }
                
            }
            

            
            return Encoding.UTF8.GetString(encodedPlainText);
        }
    }
}
