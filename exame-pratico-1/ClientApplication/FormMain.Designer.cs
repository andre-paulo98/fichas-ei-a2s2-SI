namespace ClientApplication
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelEncrypt = new System.Windows.Forms.Panel();
            this.lblVerify = new System.Windows.Forms.Label();
            this.lblSendFile = new System.Windows.Forms.Label();
            this.btnVerifySignature = new System.Windows.Forms.Button();
            this.btnSendFileReceiveSignature = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSecurity = new System.Windows.Forms.Panel();
            this.labelExchangeSymmetricKey = new System.Windows.Forms.Label();
            this.btnExchangeSymmetricKeys = new System.Windows.Forms.Button();
            this.lblExchangeAssymetricKeys = new System.Windows.Forms.Label();
            this.btnExchangeAssymmetricKeys = new System.Windows.Forms.Button();
            this.btnGenerateSecretKey = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelFile = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelConnection = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTCPPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelEncrypt.SuspendLayout();
            this.panelSecurity.SuspendLayout();
            this.panelFile.SuspendLayout();
            this.panelConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(202, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "File to Encrypt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(199, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Encrypt And Sign";
            // 
            // panelEncrypt
            // 
            this.panelEncrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEncrypt.Controls.Add(this.lblVerify);
            this.panelEncrypt.Controls.Add(this.lblSendFile);
            this.panelEncrypt.Controls.Add(this.btnVerifySignature);
            this.panelEncrypt.Controls.Add(this.btnSendFileReceiveSignature);
            this.panelEncrypt.Enabled = false;
            this.panelEncrypt.Location = new System.Drawing.Point(8, 354);
            this.panelEncrypt.Name = "panelEncrypt";
            this.panelEncrypt.Size = new System.Drawing.Size(488, 100);
            this.panelEncrypt.TabIndex = 20;
            // 
            // lblVerify
            // 
            this.lblVerify.AutoSize = true;
            this.lblVerify.Location = new System.Drawing.Point(248, 72);
            this.lblVerify.Name = "lblVerify";
            this.lblVerify.Size = new System.Drawing.Size(38, 13);
            this.lblVerify.TabIndex = 8;
            this.lblVerify.Text = "DONE";
            this.lblVerify.Visible = false;
            // 
            // lblSendFile
            // 
            this.lblSendFile.AutoSize = true;
            this.lblSendFile.Location = new System.Drawing.Point(248, 30);
            this.lblSendFile.Name = "lblSendFile";
            this.lblSendFile.Size = new System.Drawing.Size(38, 13);
            this.lblSendFile.TabIndex = 7;
            this.lblSendFile.Text = "DONE";
            this.lblSendFile.Visible = false;
            // 
            // btnVerifySignature
            // 
            this.btnVerifySignature.Location = new System.Drawing.Point(12, 67);
            this.btnVerifySignature.Name = "btnVerifySignature";
            this.btnVerifySignature.Size = new System.Drawing.Size(214, 23);
            this.btnVerifySignature.TabIndex = 1;
            this.btnVerifySignature.Text = "7) Verify Signature";
            this.btnVerifySignature.UseVisualStyleBackColor = true;
            this.btnVerifySignature.Click += new System.EventHandler(this.btnVerifySignature_Click);
            // 
            // btnSendFileReceiveSignature
            // 
            this.btnSendFileReceiveSignature.Location = new System.Drawing.Point(12, 25);
            this.btnSendFileReceiveSignature.Name = "btnSendFileReceiveSignature";
            this.btnSendFileReceiveSignature.Size = new System.Drawing.Size(214, 23);
            this.btnSendFileReceiveSignature.TabIndex = 0;
            this.btnSendFileReceiveSignature.Text = "6) Send File and Receive Signature";
            this.btnSendFileReceiveSignature.UseVisualStyleBackColor = true;
            this.btnSendFileReceiveSignature.Click += new System.EventHandler(this.btnSendFileReceiveSignature_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(208, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Security Info";
            // 
            // panelSecurity
            // 
            this.panelSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSecurity.Controls.Add(this.labelExchangeSymmetricKey);
            this.panelSecurity.Controls.Add(this.btnExchangeSymmetricKeys);
            this.panelSecurity.Controls.Add(this.lblExchangeAssymetricKeys);
            this.panelSecurity.Controls.Add(this.btnExchangeAssymmetricKeys);
            this.panelSecurity.Controls.Add(this.btnGenerateSecretKey);
            this.panelSecurity.Controls.Add(this.txtPassword);
            this.panelSecurity.Controls.Add(this.label6);
            this.panelSecurity.Enabled = false;
            this.panelSecurity.Location = new System.Drawing.Point(8, 192);
            this.panelSecurity.Name = "panelSecurity";
            this.panelSecurity.Size = new System.Drawing.Size(488, 141);
            this.panelSecurity.TabIndex = 19;
            // 
            // labelExchangeSymmetricKey
            // 
            this.labelExchangeSymmetricKey.AutoSize = true;
            this.labelExchangeSymmetricKey.Location = new System.Drawing.Point(248, 105);
            this.labelExchangeSymmetricKey.Name = "labelExchangeSymmetricKey";
            this.labelExchangeSymmetricKey.Size = new System.Drawing.Size(38, 13);
            this.labelExchangeSymmetricKey.TabIndex = 7;
            this.labelExchangeSymmetricKey.Text = "DONE";
            this.labelExchangeSymmetricKey.Visible = false;
            // 
            // btnExchangeSymmetricKeys
            // 
            this.btnExchangeSymmetricKeys.Location = new System.Drawing.Point(12, 100);
            this.btnExchangeSymmetricKeys.Name = "btnExchangeSymmetricKeys";
            this.btnExchangeSymmetricKeys.Size = new System.Drawing.Size(214, 23);
            this.btnExchangeSymmetricKeys.TabIndex = 6;
            this.btnExchangeSymmetricKeys.Text = "5) Exchange Symmetric Keys";
            this.btnExchangeSymmetricKeys.UseVisualStyleBackColor = true;
            this.btnExchangeSymmetricKeys.Click += new System.EventHandler(this.btnExchangeSymmetricKeys_Click);
            // 
            // lblExchangeAssymetricKeys
            // 
            this.lblExchangeAssymetricKeys.AutoSize = true;
            this.lblExchangeAssymetricKeys.Location = new System.Drawing.Point(248, 72);
            this.lblExchangeAssymetricKeys.Name = "lblExchangeAssymetricKeys";
            this.lblExchangeAssymetricKeys.Size = new System.Drawing.Size(38, 13);
            this.lblExchangeAssymetricKeys.TabIndex = 5;
            this.lblExchangeAssymetricKeys.Text = "DONE";
            this.lblExchangeAssymetricKeys.Visible = false;
            // 
            // btnExchangeAssymmetricKeys
            // 
            this.btnExchangeAssymmetricKeys.Location = new System.Drawing.Point(12, 67);
            this.btnExchangeAssymmetricKeys.Name = "btnExchangeAssymmetricKeys";
            this.btnExchangeAssymmetricKeys.Size = new System.Drawing.Size(214, 23);
            this.btnExchangeAssymmetricKeys.TabIndex = 3;
            this.btnExchangeAssymmetricKeys.Text = "4) Exchange Assymmetric Keys";
            this.btnExchangeAssymmetricKeys.UseVisualStyleBackColor = true;
            this.btnExchangeAssymmetricKeys.Click += new System.EventHandler(this.btnExchangeAssymmetricKeys_Click);
            // 
            // btnGenerateSecretKey
            // 
            this.btnGenerateSecretKey.Location = new System.Drawing.Point(277, 18);
            this.btnGenerateSecretKey.Name = "btnGenerateSecretKey";
            this.btnGenerateSecretKey.Size = new System.Drawing.Size(199, 23);
            this.btnGenerateSecretKey.TabIndex = 2;
            this.btnGenerateSecretKey.Text = "3) Generate Key Based on Password";
            this.btnGenerateSecretKey.UseVisualStyleBackColor = true;
            this.btnGenerateSecretKey.Click += new System.EventHandler(this.btnGenerateSecretKey_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(65, 25);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(203, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Password";
            // 
            // panelFile
            // 
            this.panelFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFile.Controls.Add(this.label8);
            this.panelFile.Controls.Add(this.btnChooseFile);
            this.panelFile.Controls.Add(this.txtFilePath);
            this.panelFile.Location = new System.Drawing.Point(8, 12);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(488, 66);
            this.panelFile.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "File Path";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(393, 25);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(83, 23);
            this.btnChooseFile.TabIndex = 0;
            this.btnChooseFile.Text = "1) Choose File";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.chooseFileBtn_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(10, 28);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(377, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(213, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Network";
            // 
            // panelConnection
            // 
            this.panelConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConnection.Controls.Add(this.btnConnect);
            this.panelConnection.Controls.Add(this.label3);
            this.panelConnection.Controls.Add(this.txtTCPPort);
            this.panelConnection.Controls.Add(this.label2);
            this.panelConnection.Controls.Add(this.txtIPAddress);
            this.panelConnection.Location = new System.Drawing.Point(8, 98);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(488, 68);
            this.panelConnection.TabIndex = 14;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(376, 27);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "2) Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Server TCP Port";
            // 
            // txtTCPPort
            // 
            this.txtTCPPort.Location = new System.Drawing.Point(176, 31);
            this.txtTCPPort.Name = "txtTCPPort";
            this.txtTCPPort.Size = new System.Drawing.Size(125, 20);
            this.txtTCPPort.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server IP Address";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(10, 30);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(157, 20);
            this.txtIPAddress.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 466);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelEncrypt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelSecurity);
            this.Controls.Add(this.panelFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelConnection);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "EI.SI - Practical Exam 1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.panelEncrypt.ResumeLayout(false);
            this.panelEncrypt.PerformLayout();
            this.panelSecurity.ResumeLayout(false);
            this.panelSecurity.PerformLayout();
            this.panelFile.ResumeLayout(false);
            this.panelFile.PerformLayout();
            this.panelConnection.ResumeLayout(false);
            this.panelConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelEncrypt;
        private System.Windows.Forms.Label lblVerify;
        private System.Windows.Forms.Label lblSendFile;
        private System.Windows.Forms.Button btnVerifySignature;
        private System.Windows.Forms.Button btnSendFileReceiveSignature;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelSecurity;
        private System.Windows.Forms.Label labelExchangeSymmetricKey;
        private System.Windows.Forms.Button btnExchangeSymmetricKeys;
        private System.Windows.Forms.Label lblExchangeAssymetricKeys;
        private System.Windows.Forms.Button btnExchangeAssymmetricKeys;
        private System.Windows.Forms.Button btnGenerateSecretKey;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTCPPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

