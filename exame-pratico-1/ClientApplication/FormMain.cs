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
using System.Net;
using System.Net.Sockets;
using EI.SI;
using System.IO;

namespace ClientApplication
{
    public partial class FormMain : Form
    {

        private string FILE = "";
        private string KEY = "";

        IPEndPoint serverEndPoint;
        TcpClient client = null;
        NetworkStream netStream = null;
        ProtocolSI protocol = null;
        AesCryptoServiceProvider aes = null;
        SymmetricsSI symmetricsSI = null;
        RSACryptoServiceProvider rsaClient = null;
        RSACryptoServiceProvider rsaServer = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void chooseFileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.ExecutablePath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FILE = openFileDialog1.FileName;
                txtFilePath.Text = FILE;
                panelSecurity.Enabled = true;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try {
                IPAddress ip = IPAddress.Parse(txtIPAddress.Text);
                int port = int.Parse(txtTCPPort.Text);

                rsaClient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();

                aes = new AesCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(aes);


                protocol = new ProtocolSI();

                serverEndPoint = new IPEndPoint(ip, port);

                client = new TcpClient();

                client.Connect(serverEndPoint);

                netStream = client.GetStream();
            } catch (Exception ex) {
                MessageBox.Show("ERROR: " + ex.Message);
                throw;
            }
        }

        private void btnGenerateSecretKey_Click(object sender, EventArgs e)
        {
           
        }

        private void btnExchangeAssymmetricKeys_Click(object sender, EventArgs e)
        {
            try {
                // enviar a chave publica
                var msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaClient.ToXmlString(false));
                netStream.Write(msg, 0, msg.Length);

                // receber a chave publica do servidor
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                rsaServer.FromXmlString(protocol.GetStringFromData());

                lblExchangeAssymetricKeys.Visible = true;
            } catch (Exception ex) {
                MessageBox.Show("ERROR: " + ex.Message);
                throw;
            }
        }

        private void btnExchangeSymmetricKeys_Click(object sender, EventArgs e)
        {
            try {
                var msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, rsaServer.Encrypt(aes.Key, true));
                netStream.Write(msg, 0, msg.Length);

                // Receive ack
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);


                // Send iv...
                msg = protocol.Make(ProtocolSICmdType.IV, aes.IV);
                netStream.Write(msg, 0, msg.Length);

                // Receive ack
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                panelEncrypt.Enabled = true;
                labelExchangeSymmetricKey.Visible = true;
            } catch (Exception ex) {
                MessageBox.Show("ERROR: " + ex.Message);
                throw;
            }
        }


        byte[] encryptedData;

        private void btnSendFileReceiveSignature_Click(object sender, EventArgs e)
        {
            try {
                encryptedData = symmetricsSI.Encrypt(File.ReadAllBytes(FILE));
                var msg = protocol.Make(ProtocolSICmdType.DATA, encryptedData);
                netStream.Write(msg, 0, msg.Length);

                lblSendFile.Visible = true;
            } catch (Exception ex) {
                MessageBox.Show("ERROR: " + ex.Message);
                throw;
            }


        }

        private void btnVerifySignature_Click(object sender, EventArgs e)
        {
            try {
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                var signature = symmetricsSI.Decrypt(protocol.GetData());

                bool status = rsaServer.VerifyData(File.ReadAllBytes(FILE), new SHA256CryptoServiceProvider(), signature);
                MessageBox.Show(status ? "Assinatura é válida" : "Assinatura não é válida");
                lblVerify.Visible = true;
            } catch (Exception ex) {
                MessageBox.Show("ERROR: " + ex.Message);
                throw;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aes != null)
                aes.Dispose();
            if (rsaClient != null)
                rsaClient.Dispose();
            if (rsaServer != null)
                rsaServer.Dispose();
            if (netStream != null)
                netStream.Dispose();
            if (client != null)
                client.Close();
        }
    }
}
