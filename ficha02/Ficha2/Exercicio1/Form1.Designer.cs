﻿namespace Exercicio1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonCopyImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCopyImage
            // 
            this.buttonCopyImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopyImage.Location = new System.Drawing.Point(12, 12);
            this.buttonCopyImage.Name = "buttonCopyImage";
            this.buttonCopyImage.Size = new System.Drawing.Size(211, 79);
            this.buttonCopyImage.TabIndex = 0;
            this.buttonCopyImage.Text = "Copy Image";
            this.buttonCopyImage.UseVisualStyleBackColor = true;
            this.buttonCopyImage.Click += new System.EventHandler(this.ButtonCopyImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 103);
            this.Controls.Add(this.buttonCopyImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Copy Image";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCopyImage;
    }
}

