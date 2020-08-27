namespace shellUpscaler
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if(disposing && (components != null))
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
        private void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.label1 = new System.Windows.Forms.Label();
            this.regBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.unregBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.esrganPathTbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uninstallEsrganBtn = new System.Windows.Forms.Button();
            this.installEsrganBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Setup";
            // 
            // regBtn
            // 
            this.regBtn.Location = new System.Drawing.Point(166, 50);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(100, 23);
            this.regBtn.TabIndex = 3;
            this.regBtn.Text = "Register";
            this.regBtn.UseVisualStyleBackColor = true;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Shell Integration:";
            // 
            // unregBtn
            // 
            this.unregBtn.Location = new System.Drawing.Point(272, 50);
            this.unregBtn.Name = "unregBtn";
            this.unregBtn.Size = new System.Drawing.Size(100, 23);
            this.unregBtn.TabIndex = 5;
            this.unregBtn.Text = "Unregister";
            this.unregBtn.UseVisualStyleBackColor = true;
            this.unregBtn.Click += new System.EventHandler(this.unregBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ESRGAN Path:";
            // 
            // esrganPathTbox
            // 
            this.esrganPathTbox.Location = new System.Drawing.Point(166, 82);
            this.esrganPathTbox.Name = "esrganPathTbox";
            this.esrganPathTbox.Size = new System.Drawing.Size(206, 20);
            this.esrganPathTbox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Install/Uninstall Scripts:";
            // 
            // uninstallEsrganBtn
            // 
            this.uninstallEsrganBtn.Location = new System.Drawing.Point(272, 110);
            this.uninstallEsrganBtn.Name = "uninstallEsrganBtn";
            this.uninstallEsrganBtn.Size = new System.Drawing.Size(100, 23);
            this.uninstallEsrganBtn.TabIndex = 10;
            this.uninstallEsrganBtn.Text = "Uninstall";
            this.uninstallEsrganBtn.UseVisualStyleBackColor = true;
            this.uninstallEsrganBtn.Click += new System.EventHandler(this.uninstallEsrganBtn_Click);
            // 
            // installEsrganBtn
            // 
            this.installEsrganBtn.Location = new System.Drawing.Point(166, 110);
            this.installEsrganBtn.Name = "installEsrganBtn";
            this.installEsrganBtn.Size = new System.Drawing.Size(100, 23);
            this.installEsrganBtn.TabIndex = 9;
            this.installEsrganBtn.Text = "Install";
            this.installEsrganBtn.UseVisualStyleBackColor = true;
            this.installEsrganBtn.Click += new System.EventHandler(this.installEsrganBtn_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 144);
            this.Controls.Add(this.uninstallEsrganBtn);
            this.Controls.Add(this.installEsrganBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.esrganPathTbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.unregBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regBtn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.Text = "ShellUpscaler Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button unregBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox esrganPathTbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button uninstallEsrganBtn;
        private System.Windows.Forms.Button installEsrganBtn;
    }
}