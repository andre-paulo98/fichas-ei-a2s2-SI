using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercicio1 {
    public partial class Form1 : Form {

        private const string FILENAME_SOURCE = "security.jpg";
        private const string FILENAME_DESTINATION = "bak_security.jpg";
        private const int N_BYTES = 20480;

        public Form1() {
            InitializeComponent();
        }

        private void ButtonCopyImage_Click(object sender, EventArgs e) {

            byte[] buffer = new byte[N_BYTES];
            int bytesRead = 0, totalBytes = 0;

            FileStream fsRead = null, fsWrite = null;
            try {

                fsRead = new FileStream(FILENAME_SOURCE, FileMode.Open);
                fsWrite = new FileStream(FILENAME_DESTINATION, FileMode.Create);

                while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0) {
                    fsWrite.Write(buffer, 0, bytesRead);
                    totalBytes += bytesRead;
                }

                MessageBox.Show($"File copied: {totalBytes} bytes.");


            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
                throw;
            } finally {
                if(fsRead != null) 
                    fsRead.Close();
                if (fsWrite != null) 
                    fsWrite.Close();
            }
        }
    }
}
