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

        SHA256CryptoServiceProvider sha256;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void ButtonTransformFirstBlock_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxFirstInputData.Text);

            sha256 = new SHA256CryptoServiceProvider();
            sha256.TransformBlock(data, 0, data.Length, null, 0);
        }

        private void ButtonTransformNextBlock_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxNextInputData.Text);

            sha256.TransformBlock(data, 0, data.Length, null, 0);
        }

        private void ButtonTransformFinalBlock_Click(object sender, EventArgs e) {
            byte[] data = Encoding.UTF8.GetBytes(textBoxLastInputData.Text);

            sha256.TransformFinalBlock(data, 0, data.Length);

            textBoxHashBytes.Text = BitConverter.ToString(sha256.Hash);

            if(textBoxHashBytes.Text != BitConverter.ToString(ComputeHashTest())) {
                MessageBox.Show("Error!");
            } else {
                MessageBox.Show("Hash identicos");
            }

            sha256.Dispose();

        }

        private byte[] ComputeHashTest() {
            string data = String.Concat(textBoxFirstInputData.Text, textBoxNextInputData.Text, textBoxLastInputData.Text);
            byte[] output;
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider()) {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            }
        }
    }
}
