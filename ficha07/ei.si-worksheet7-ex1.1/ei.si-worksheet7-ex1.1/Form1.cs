using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei.si_worksheet7 {
    public partial class Form1 : Form {
        // The digital certificates should be copied to ./bin/debug directory
        const string fileCertPFX = @"certa.pfx"; // Key Priv + Key Pub
        const string fileCertCER = @"certa.cer"; // Key Pub
        static readonly string pwdfileCertPFX = Properties.Settings.Default.PwdCertPFX; // ei.si

        private byte[] tempCertRaw = null;
        private byte[] tempData = null;


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
            // todo

            textBoxInfo.Text += "Friendly Name: " + cert.FriendlyName + Environment.NewLine;
            textBoxInfo.Text += "Expiration Date: " + cert.GetExpirationDateString() + Environment.NewLine;
            textBoxInfo.Text += "Thumbprint: " + cert.Thumbprint + Environment.NewLine;
            textBoxInfo.Text += "Serial Number: " + cert.SerialNumber + Environment.NewLine;
            textBoxInfo.Text += "Has private Key? : " + cert.HasPrivateKey + Environment.NewLine;
            //textBoxInfo.Text += "Public Key: " + cert.GetPublicKeyString() + Environment.NewLine;

            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += Environment.NewLine;
        }



        private void ButtonOpenPFX_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2(fileCertPFX, pwdfileCertPFX);
            ShowCertificate(cert);
        }

        private void ButtonOpenCER_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2(fileCertCER, pwdfileCertPFX);
            ShowCertificate(cert);
        }



        private void ButtonOpenFromStore_Click(object sender, EventArgs e) {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            /*var certs = store.Certificates;
            for (int i = 0; i < certs.Count; i++) {
                ShowCertificate(certs[i]);
            }*/

            X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(store.Certificates, "Escolha o certificado", 
                "Escolha qual o certificado que quer visualizar", X509SelectionFlag.SingleSelection);

            if(certs.Count == 1) {
                ShowCertificate(certs[0]);
            }

            store.Close();
        }

        private void ButtonAddToStoreCER_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2(fileCertCER);
            ShowCertificate(cert);
            X509Store store = new X509Store(StoreName.AddressBook, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            store.Add(cert);

            store.Close();
        }



        private void ButtonVerifyCert_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2(fileCertCER);
            ShowCertificate(cert);

            MessageBox.Show(cert.Verify() + "");
        }

        private void ButtonVerifyCertChain_Click(object sender, EventArgs e) {

        }



        private void ButtonExportPublicCert_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2(fileCertCER);
            //X509Certificate2 cert = new X509Certificate2(fileCertPFX, pwdfileCertPFX);
            ShowCertificate(cert);

            this.tempCertRaw = cert.Export(X509ContentType.Cert);

            File.WriteAllBytes("temp.cer", this.tempCertRaw);

            textBoxInfo.Text += Convert.ToBase64String(this.tempCertRaw);
        }

        private void ButtonImportPublicCert_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2(File.ReadAllBytes("temp.cer"));
            ShowCertificate(cert);
        }



        private void ButtonExportPrivateCert_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2(fileCertPFX, pwdfileCertPFX, X509KeyStorageFlags.Exportable);
            ShowCertificate(cert);

            this.tempCertRaw = cert.Export(X509ContentType.Pfx, "estouaqui");
            File.WriteAllBytes("temp.pfx", this.tempCertRaw);

            textBoxInfo.Text += Convert.ToBase64String(this.tempCertRaw);
        }

        private void ButtonImportPrivateCert_Click(object sender, EventArgs e) {
            X509Certificate2 cert = new X509Certificate2();
            cert.Import(File.ReadAllBytes("temp.pfx"), "estouaqui", X509KeyStorageFlags.Exportable);

            ShowCertificate(cert);
        }



    }
}
