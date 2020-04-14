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

namespace ei.si.worksheet6 {
    public partial class Form1 : Form {

        private string publicKey;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void ButtonSignHash_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
            byte[] hash = null, signature = null;

            // calcular o hash value a partir do data
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider()) {
                hash = sha256.ComputeHash(data);
            }


            // make signature -- algoritmo assimétrico (RSA)
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                publicKey = rsa.ToXmlString(false);
                signature = rsa.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));
            }

            //show
            textBoxMessageDigest.Text = BitConverter.ToString(hash);
            textBoxMessageDigestBits.Text = hash.Length * 8 + "";

            textBoxDigitalSignature.Text = Convert.ToBase64String(signature);
            textBoxDigitalSignatureBits.Text = signature.Length * 8 + "";

        }

        private void ButtonSignData_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
            byte[] signature = null;


            // make signature -- algoritmo assimétrico (RSA)
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                publicKey = rsa.ToXmlString(false);
                signature = rsa.SignData(data, new SHA256CryptoServiceProvider());
            }

            //show
            textBoxMessageDigest.Text = "";
            textBoxMessageDigestBits.Text = "";

            textBoxDigitalSignature.Text = Convert.ToBase64String(signature);
            textBoxDigitalSignatureBits.Text = signature.Length * 8 + "";
        }

        private void ButtonVerifyHash_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
            byte[] signature = Convert.FromBase64String(textBoxDigitalSignature.Text);

            // calcular a hash
            byte[] hash = null;
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider()) {
                hash = sha256.ComputeHash(data);
            }

            bool status = false;
            // verificar a assinatura
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                rsa.FromXmlString(publicKey);

                status = rsa.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256"), signature);
            }

            MessageBox.Show($"Assinatura digital válida = {status}");
        }

        private void ButtonVerifyData_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
            byte[] signature = Convert.FromBase64String(textBoxDigitalSignature.Text);

            bool status = false;

            // make signature -- algoritmo assimétrico (RSA)
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                rsa.FromXmlString(publicKey);
                status = rsa.VerifyData(data, new SHA256CryptoServiceProvider(), signature);
            }

            //show
            MessageBox.Show($"Validação dos dados = {status}");
        }


    }
}
