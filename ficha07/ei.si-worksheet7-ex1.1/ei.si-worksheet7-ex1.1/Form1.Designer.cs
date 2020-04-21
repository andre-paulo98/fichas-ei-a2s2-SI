namespace ei.si_worksheet7
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonImportPrivateCert = new System.Windows.Forms.Button();
            this.buttonImportPublicCert = new System.Windows.Forms.Button();
            this.buttonExportPrivateCert = new System.Windows.Forms.Button();
            this.buttonExportPublicCert = new System.Windows.Forms.Button();
            this.buttonAddToStoreCER = new System.Windows.Forms.Button();
            this.buttonVerifyCertChain = new System.Windows.Forms.Button();
            this.buttonVerifyCert = new System.Windows.Forms.Button();
            this.buttonOpenFromStore = new System.Windows.Forms.Button();
            this.buttonOpenCER = new System.Windows.Forms.Button();
            this.buttonOpenPFX = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonImportPrivateCert
            // 
            this.buttonImportPrivateCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImportPrivateCert.Location = new System.Drawing.Point(1118, 63);
            this.buttonImportPrivateCert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonImportPrivateCert.Name = "buttonImportPrivateCert";
            this.buttonImportPrivateCert.Size = new System.Drawing.Size(259, 33);
            this.buttonImportPrivateCert.TabIndex = 26;
            this.buttonImportPrivateCert.Text = "9) Import Private (.pfx)";
            this.buttonImportPrivateCert.UseVisualStyleBackColor = true;
            this.buttonImportPrivateCert.Click += new System.EventHandler(this.ButtonImportPrivateCert_Click);
            // 
            // buttonImportPublicCert
            // 
            this.buttonImportPublicCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImportPublicCert.Location = new System.Drawing.Point(832, 63);
            this.buttonImportPublicCert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonImportPublicCert.Name = "buttonImportPublicCert";
            this.buttonImportPublicCert.Size = new System.Drawing.Size(275, 33);
            this.buttonImportPublicCert.TabIndex = 27;
            this.buttonImportPublicCert.Text = "7) Import Public (.cer)";
            this.buttonImportPublicCert.UseVisualStyleBackColor = true;
            this.buttonImportPublicCert.Click += new System.EventHandler(this.ButtonImportPublicCert_Click);
            // 
            // buttonExportPrivateCert
            // 
            this.buttonExportPrivateCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportPrivateCert.Location = new System.Drawing.Point(1118, 22);
            this.buttonExportPrivateCert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExportPrivateCert.Name = "buttonExportPrivateCert";
            this.buttonExportPrivateCert.Size = new System.Drawing.Size(259, 33);
            this.buttonExportPrivateCert.TabIndex = 24;
            this.buttonExportPrivateCert.Text = "8) Export Private (.pfx)";
            this.buttonExportPrivateCert.UseVisualStyleBackColor = true;
            this.buttonExportPrivateCert.Click += new System.EventHandler(this.ButtonExportPrivateCert_Click);
            // 
            // buttonExportPublicCert
            // 
            this.buttonExportPublicCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportPublicCert.Location = new System.Drawing.Point(832, 22);
            this.buttonExportPublicCert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExportPublicCert.Name = "buttonExportPublicCert";
            this.buttonExportPublicCert.Size = new System.Drawing.Size(275, 33);
            this.buttonExportPublicCert.TabIndex = 25;
            this.buttonExportPublicCert.Text = "6) Export Public (.cer)";
            this.buttonExportPublicCert.UseVisualStyleBackColor = true;
            this.buttonExportPublicCert.Click += new System.EventHandler(this.ButtonExportPublicCert_Click);
            // 
            // buttonAddToStoreCER
            // 
            this.buttonAddToStoreCER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddToStoreCER.Location = new System.Drawing.Point(266, 63);
            this.buttonAddToStoreCER.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddToStoreCER.Name = "buttonAddToStoreCER";
            this.buttonAddToStoreCER.Size = new System.Drawing.Size(269, 33);
            this.buttonAddToStoreCER.TabIndex = 22;
            this.buttonAddToStoreCER.Text = "4) Add to Store (.cer)";
            this.buttonAddToStoreCER.UseVisualStyleBackColor = true;
            this.buttonAddToStoreCER.Click += new System.EventHandler(this.ButtonAddToStoreCER_Click);
            // 
            // buttonVerifyCertChain
            // 
            this.buttonVerifyCertChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerifyCertChain.Location = new System.Drawing.Point(543, 63);
            this.buttonVerifyCertChain.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVerifyCertChain.Name = "buttonVerifyCertChain";
            this.buttonVerifyCertChain.Size = new System.Drawing.Size(281, 33);
            this.buttonVerifyCertChain.TabIndex = 23;
            this.buttonVerifyCertChain.Text = "[Extra] Verify (Chain)";
            this.buttonVerifyCertChain.UseVisualStyleBackColor = true;
            this.buttonVerifyCertChain.Click += new System.EventHandler(this.ButtonVerifyCertChain_Click);
            // 
            // buttonVerifyCert
            // 
            this.buttonVerifyCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerifyCert.Location = new System.Drawing.Point(543, 22);
            this.buttonVerifyCert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVerifyCert.Name = "buttonVerifyCert";
            this.buttonVerifyCert.Size = new System.Drawing.Size(281, 33);
            this.buttonVerifyCert.TabIndex = 21;
            this.buttonVerifyCert.Text = "5) Verify (Normal)";
            this.buttonVerifyCert.UseVisualStyleBackColor = true;
            this.buttonVerifyCert.Click += new System.EventHandler(this.ButtonVerifyCert_Click);
            // 
            // buttonOpenFromStore
            // 
            this.buttonOpenFromStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenFromStore.Location = new System.Drawing.Point(266, 22);
            this.buttonOpenFromStore.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenFromStore.Name = "buttonOpenFromStore";
            this.buttonOpenFromStore.Size = new System.Drawing.Size(269, 33);
            this.buttonOpenFromStore.TabIndex = 20;
            this.buttonOpenFromStore.Text = "3) Open from Store";
            this.buttonOpenFromStore.UseVisualStyleBackColor = true;
            this.buttonOpenFromStore.Click += new System.EventHandler(this.ButtonOpenFromStore_Click);
            // 
            // buttonOpenCER
            // 
            this.buttonOpenCER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenCER.Location = new System.Drawing.Point(13, 63);
            this.buttonOpenCER.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenCER.Name = "buttonOpenCER";
            this.buttonOpenCER.Size = new System.Drawing.Size(245, 33);
            this.buttonOpenCER.TabIndex = 19;
            this.buttonOpenCER.Text = "2) Open File .CER";
            this.buttonOpenCER.UseVisualStyleBackColor = true;
            this.buttonOpenCER.Click += new System.EventHandler(this.ButtonOpenCER_Click);
            // 
            // buttonOpenPFX
            // 
            this.buttonOpenPFX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenPFX.Location = new System.Drawing.Point(13, 22);
            this.buttonOpenPFX.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenPFX.Name = "buttonOpenPFX";
            this.buttonOpenPFX.Size = new System.Drawing.Size(245, 33);
            this.buttonOpenPFX.TabIndex = 18;
            this.buttonOpenPFX.Text = "1) Open File .PFX";
            this.buttonOpenPFX.UseVisualStyleBackColor = true;
            this.buttonOpenPFX.Click += new System.EventHandler(this.ButtonOpenPFX_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(13, 104);
            this.textBoxInfo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInfo.Size = new System.Drawing.Size(1364, 552);
            this.textBoxInfo.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 669);
            this.Controls.Add(this.buttonImportPrivateCert);
            this.Controls.Add(this.buttonImportPublicCert);
            this.Controls.Add(this.buttonExportPrivateCert);
            this.Controls.Add(this.buttonExportPublicCert);
            this.Controls.Add(this.buttonAddToStoreCER);
            this.Controls.Add(this.buttonVerifyCertChain);
            this.Controls.Add(this.buttonVerifyCert);
            this.Controls.Add(this.buttonOpenFromStore);
            this.Controls.Add(this.buttonOpenCER);
            this.Controls.Add(this.buttonOpenPFX);
            this.Controls.Add(this.textBoxInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Manage Digital Certificates";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImportPrivateCert;
        private System.Windows.Forms.Button buttonImportPublicCert;
        private System.Windows.Forms.Button buttonExportPrivateCert;
        private System.Windows.Forms.Button buttonExportPublicCert;
        private System.Windows.Forms.Button buttonAddToStoreCER;
        private System.Windows.Forms.Button buttonVerifyCertChain;
        private System.Windows.Forms.Button buttonVerifyCert;
        private System.Windows.Forms.Button buttonOpenFromStore;
        private System.Windows.Forms.Button buttonOpenCER;
        private System.Windows.Forms.Button buttonOpenPFX;
        private System.Windows.Forms.TextBox textBoxInfo;
    }
}

