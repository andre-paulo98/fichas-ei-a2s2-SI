using System;
using System.IO;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using EI.SI;
using System.Text;

namespace ei_si_worksheet4 {
    public partial class Form1 : Form {
        public const string FILENAME_PUBLIC_PRIVATE_KEY = "PrivatePublicKey.xml";
        public const string FILENAME_PUBLIC_KEY = "PublicKey.xml";

        byte[] iv;
        byte[] ivEncrypted;
        byte[] secretKey;
        byte[] secretKeyEncrypted;

        public Form1() {
            InitializeComponent();
        }

        private void ButtonGenerateKeys_Click(object sender, EventArgs e) {
            using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider()) {
                tbPublicKey.Text = algorithm.ToXmlString(false);
                tbBothKeys.Text = algorithm.ToXmlString(true);
            }
        }

        private void ButtonImportKeys_Click(object sender, EventArgs e) {
            using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider()) {
                if (File.Exists(FILENAME_PUBLIC_PRIVATE_KEY)) {
                    algorithm.FromXmlString(File.ReadAllText(FILENAME_PUBLIC_PRIVATE_KEY));
                    tbPublicKey.Text = algorithm.ToXmlString(false);
                    tbBothKeys.Text = algorithm.ToXmlString(true);
                }
            }
        }

        private void ButtonSavePublicKey_Click(object sender, EventArgs e) {
            File.WriteAllText(FILENAME_PUBLIC_KEY, tbPublicKey.Text);
            MessageBox.Show("File Saved!");
        }

        private void ButtonSaveKeys_Click(object sender, EventArgs e) {
            File.WriteAllText(FILENAME_PUBLIC_PRIVATE_KEY, tbBothKeys.Text);
            MessageBox.Show("File Saved!");
        }

        private void ButtonGenerateSymmetricKey_Click(object sender, EventArgs e) {
            using (AesCryptoServiceProvider symmetricAlg = new AesCryptoServiceProvider()) {
                using (RSACryptoServiceProvider assymetricAlg = new RSACryptoServiceProvider()) {
                    assymetricAlg.FromXmlString(tbBothKeys.Text); //poderia tb ler só a publica
                    secretKeyEncrypted = assymetricAlg.Encrypt(symmetricAlg.Key, true);
                    secretKey = symmetricAlg.Key;
                    ivEncrypted = assymetricAlg.Encrypt(symmetricAlg.IV, true);
                    iv = symmetricAlg.IV;

                    textBoxSymmetricKey.Text = Convert.ToBase64String(secretKey);
                    tbSymmetricKeyEncrypted.Text = Convert.ToBase64String(secretKeyEncrypted);
                    tbBitSize.Text = (secretKeyEncrypted.Length * 8).ToString();
                }
            }
        }

        private void ButtonEncryptFile_Click(object sender, EventArgs e) {
            string filenameOriginal = "";
            byte[] fileClearContent = null;
            byte[] fileEncryptedContent = null;
            SymmetricsSI symmetrics = null;

            using (OpenFileDialog openFile = new OpenFileDialog()) {
                if (openFile.ShowDialog() == DialogResult.OK) {
                    filenameOriginal = openFile.FileName;
                    //MessageBox.Show(filenameOriginal);

                    fileClearContent = File.ReadAllBytes(filenameOriginal);
                    using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                        aes.Key = secretKey;
                        aes.IV = iv;
                        symmetrics = new SymmetricsSI(aes);
                        fileEncryptedContent = symmetrics.Encrypt(fileClearContent);
                    }
                    //Save Assymetric keys
                    File.WriteAllText(FILENAME_PUBLIC_KEY, tbPublicKey.Text);
                    File.WriteAllText(FILENAME_PUBLIC_PRIVATE_KEY, tbBothKeys.Text);

                    //Save symmetric components BUT encrypted (key + IV)
                    File.WriteAllBytes(@"EncryptedFile.txt", fileEncryptedContent);
                    File.WriteAllBytes(@"EncriptedSecretKey.txt", secretKeyEncrypted);
                    File.WriteAllBytes(@"EncriptedIV.txt", ivEncrypted);

                    MessageBox.Show("File Encrypted and components saved");
                }
            }

            //if (fileClearContent != null)
            //{
            //    //cifrar o ficheiro com um algoritmo simétrico
            //}
        }

        private void buttonDecryptFile_Click(object sender, EventArgs e) {
            //open all files
            byte[] encryptedFileContent = File.ReadAllBytes("EncryptedFile.txt");
            byte[] encryptedSecretKey = File.ReadAllBytes("EncriptedSecretKey.txt");
            byte[] encryptedIV = File.ReadAllBytes("EncriptedIV.txt");
            string privateAndPublicKey = File.ReadAllText(FILENAME_PUBLIC_PRIVATE_KEY);
            SymmetricsSI symmetricSI = null;

            using (RSACryptoServiceProvider assymetricAlg = new RSACryptoServiceProvider()) {
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                    assymetricAlg.FromXmlString(privateAndPublicKey);

                    byte[] secretKey = assymetricAlg.Decrypt(encryptedSecretKey, true);
                    byte[] iv = assymetricAlg.Decrypt(encryptedIV, true);

                    aes.Key = secretKey;
                    aes.IV = iv;

                    symmetricSI = new SymmetricsSI(aes);

                    File.WriteAllBytes("Decrypted.txt", symmetricSI.Decrypt(encryptedFileContent));

                }
            }
            MessageBox.Show("File Descrypted");
        }
    }
}
