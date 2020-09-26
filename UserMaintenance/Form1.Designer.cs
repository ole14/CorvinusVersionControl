namespace UserMaintenance
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.textFullName = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btSTF = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(242, 212);
            this.listBox1.TabIndex = 0;
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.Location = new System.Drawing.Point(261, 16);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(35, 13);
            this.lbFullName.TabIndex = 1;
            this.lbFullName.Text = "label1";
            // 
            // textFullName
            // 
            this.textFullName.Location = new System.Drawing.Point(337, 13);
            this.textFullName.Name = "textFullName";
            this.textFullName.Size = new System.Drawing.Size(143, 20);
            this.textFullName.TabIndex = 3;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(337, 38);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(144, 23);
            this.btAdd.TabIndex = 5;
            this.btAdd.Text = "button1";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btSTF
            // 
            this.btSTF.Location = new System.Drawing.Point(261, 110);
            this.btSTF.Name = "btSTF";
            this.btSTF.Size = new System.Drawing.Size(219, 23);
            this.btSTF.TabIndex = 6;
            this.btSTF.Text = "button1";
            this.btSTF.UseVisualStyleBackColor = true;
            this.btSTF.Click += new System.EventHandler(this.btSTF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 239);
            this.Controls.Add(this.btSTF);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.textFullName);
            this.Controls.Add(this.lbFullName);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.TextBox textFullName;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btSTF;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

