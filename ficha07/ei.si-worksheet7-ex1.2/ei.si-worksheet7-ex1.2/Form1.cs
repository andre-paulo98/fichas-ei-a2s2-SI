using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;    // Mandatory to add the reference to System.Security DLL
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei.si_worksheet7 {
    public partial class Form1 : Form {
        // The digital certificates should be copied to ./bin/debug directory
        const string fileCertPFX = @"certa.pfx";
        const string fileCertCER = @"certa.cer";
        static readonly string pwdfileCertPFX = Properties.Settings.Default.PwdCertPFX;

        private byte[] tempDigitalSignature = null;
        private byte[] tempEnvelope = null;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }



        /// <summary>
        /// Show digital certificate info in the textbox
        /// </summary>
        /// <param name="cert">digital certificate</param>
        private void ShowCertificate(X509Certificate2 cert) {
            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += "Subject: " + cert.Subject + Environment.NewLine;
            textBoxInfo.Text += "FriendlyName: " + cert.FriendlyName + Environment.NewLine;
            textBoxInfo.Text += "Thumbprint: " + cert.Thumbprint + Environment.NewLine;
            textBoxInfo.Text += "SerialNumber: " + cert.SerialNumber + Environment.NewLine;
            textBoxInfo.Text += "HasPrivateKey: " + cert.HasPrivateKey + Environment.NewLine;
            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += Environment.NewLine;
        }




        private void ButtonSignatureWithData_Click(object sender, EventArgs e) {
            if(textBoxInfo.Text.Length <= 0) {
                MessageBox.Show("Data is empty!!");
                return;
            }

            byte[] data = Encoding.UTF8.GetBytes(textBoxInfo.Text);
            X509Certificate2 cert = new X509Certificate2(fileCertPFX, pwdfileCertPFX);

            ContentInfo contentInfo = new ContentInfo(data);

            SignedCms signedCms = new SignedCms(contentInfo, false);
            CmsSigner cmsSigner = new CmsSigner(cert);

            signedCms.ComputeSignature(cmsSigner);
            tempDigitalSignature = signedCms.Encode();

            textBoxInfo.Text += Environment.NewLine + Convert.ToBase64String(tempDigitalSignature) + Environment.NewLine;
        }

        private void ButtonVerifySignatureWithData_Click(object sender, EventArgs e) {
            SignedCms signedCms = new SignedCms();
            try {
                signedCms.Decode(tempDigitalSignature);
                signedCms.CheckSignature(true);

                string data = Encoding.UTF8.GetString(signedCms.ContentInfo.Content);

                MessageBox.Show("Assinatura Válida." + Environment.NewLine + data);
            } catch (Exception) {
                MessageBox.Show("Assinatura Inválida!");
                throw;
            }
        }



        private void ButtonSignatureWithoutData_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxInfo.Text);
            X509Certificate2 cert = new X509Certificate2(fileCertPFX, pwdfileCertPFX);
            
            ContentInfo contentInfo = new ContentInfo(data);
            CmsSigner cmsSigner = new CmsSigner(cert);
            SignedCms signedCms = new SignedCms(contentInfo, true); // true = detached

            signedCms.ComputeSignature(cmsSigner);

            this.tempDigitalSignature = signedCms.Encode(); // msg no formato PCKS7 só com a assinatura pq está dettached

            //textBoxInfo.Text += Environment.NewLine + Convert.ToBase64String(tempDigitalSignature) + Environment.NewLine;
        }

        private void ButtonVerifySignatureWithoutData_Click(object sender, EventArgs e) {
            ContentInfo contentInfo = new ContentInfo(Encoding.UTF8.GetBytes(textBoxInfo.Text));
            SignedCms signedCms = new SignedCms(contentInfo, true);

            try {
                signedCms.Decode(this.tempDigitalSignature);
                signedCms.CheckSignature(false); // false = integridade + autenticação
                                                 // true = integridade

                MessageBox.Show("Valid signature");
            } catch (Exception ex) {
                MessageBox.Show("Invalid Signature");
            }
        }



        private void ButtonEncryptWithCER_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxInfo.Text);
            ContentInfo contentInfo = new ContentInfo(data);

            X509Certificate2 cert = new X509Certificate2(fileCertCER);

            CmsRecipient cmsRecipient = new CmsRecipient(cert);

            EnvelopedCms envelopedCms = new EnvelopedCms(contentInfo);

            envelopedCms.Encrypt(cmsRecipient);
            this.tempEnvelope = envelopedCms.Encode();

            MessageBox.Show(Convert.ToBase64String(this.tempEnvelope));
        }

        private void ButtonDecryptFromPFX_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2(fileCertPFX, pwdfileCertPFX);
            try {
                EnvelopedCms envelopedCms = new EnvelopedCms();
                envelopedCms.Decode(tempEnvelope);

                envelopedCms.Decrypt(new X509Certificate2Collection(cert));
                string data = Encoding.UTF8.GetString(envelopedCms.ContentInfo.Content);
                MessageBox.Show(data);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }



        private void ButtonEncryptWithStore_Click(object sender, EventArgs e) {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(store.Certificates, "Certificates", "Choose one certificate...", X509SelectionFlag.SingleSelection);
            store.Close();

            if(certs.Count == 1) {
                //ShowCertificate(certs[0]);
                byte[] data = Encoding.UTF8.GetBytes(textBoxInfo.Text);
                ContentInfo contentInfo = new ContentInfo(data);

                CmsRecipient cmsRecipient = new CmsRecipient(certs[0]);

                EnvelopedCms envelopedCms = new EnvelopedCms(contentInfo);

                envelopedCms.Encrypt(cmsRecipient);
                this.tempEnvelope = envelopedCms.Encode();

                MessageBox.Show("Data encrypted" + Environment.NewLine + Convert.ToBase64String(this.tempEnvelope));
            } else {
                MessageBox.Show("No certificate selected");
            }
        }

        private void ButtonDecryptFromStore_Click(object sender, EventArgs e) {
            EnvelopedCms envelopedCms = new EnvelopedCms();
            try {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);

                X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(store.Certificates, "Certificates", "Choose one certificate...", X509SelectionFlag.SingleSelection);
                store.Close();
                if(certs.Count == 1) {
                    envelopedCms.Decode(tempEnvelope);
                    envelopedCms.Decrypt(certs);

                    MessageBox.Show("Message decrypted!" + Environment.NewLine + Encoding.UTF8.GetString(envelopedCms.ContentInfo.Content));
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }



        private void ButtonEncryptAndSign_Click(object sender, EventArgs e) {

        }

        private void ButtonVerifyAndDecrypt_Click(object sender, EventArgs e) {

        }
    }
}
