namespace QLTikiMini
{
    partial class FormCreateAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnNbh = new System.Windows.Forms.Button();
            this.btnKh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Account";
            // 
            // btnNbh
            // 
            this.btnNbh.Location = new System.Drawing.Point(64, 108);
            this.btnNbh.Name = "btnNbh";
            this.btnNbh.Size = new System.Drawing.Size(75, 45);
            this.btnNbh.TabIndex = 1;
            this.btnNbh.Text = "NBH";
            this.btnNbh.UseVisualStyleBackColor = true;
            this.btnNbh.Click += new System.EventHandler(this.btnNbh_Click);
            // 
            // btnKh
            // 
            this.btnKh.Location = new System.Drawing.Point(145, 108);
            this.btnKh.Name = "btnKh";
            this.btnKh.Size = new System.Drawing.Size(75, 45);
            this.btnKh.TabIndex = 2;
            this.btnKh.Text = "KH";
            this.btnKh.UseVisualStyleBackColor = true;
            this.btnKh.Click += new System.EventHandler(this.btnKh_Click);
            // 
            // FormCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnKh);
            this.Controls.Add(this.btnNbh);
            this.Controls.Add(this.label1);
            this.Name = "FormCreateAccount";
            this.Text = "FormCreateAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNbh;
        private System.Windows.Forms.Button btnKh;
    }
}