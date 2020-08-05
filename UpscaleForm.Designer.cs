namespace shellUpscaler
{
    partial class UpscaleForm
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
            this.modelCombox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tilesizeCombox = new System.Windows.Forms.ComboBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // modelCombox
            // 
            this.modelCombox.FormattingEnabled = true;
            this.modelCombox.Location = new System.Drawing.Point(171, 65);
            this.modelCombox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.modelCombox.Name = "modelCombox";
            this.modelCombox.Size = new System.Drawing.Size(300, 24);
            this.modelCombox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upscale Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ESRGAN Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tile Size:";
            // 
            // tilesizeCombox
            // 
            this.tilesizeCombox.FormattingEnabled = true;
            this.tilesizeCombox.Items.AddRange(new object[] {
            "768",
            "512",
            "384",
            "256",
            "192",
            "128"});
            this.tilesizeCombox.Location = new System.Drawing.Point(171, 97);
            this.tilesizeCombox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tilesizeCombox.Name = "tilesizeCombox";
            this.tilesizeCombox.Size = new System.Drawing.Size(300, 24);
            this.tilesizeCombox.TabIndex = 3;
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.runBtn.Location = new System.Drawing.Point(12, 299);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(460, 50);
            this.runBtn.TabIndex = 5;
            this.runBtn.Text = "Run ESRGAN";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // UpscaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tilesizeCombox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modelCombox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UpscaleForm";
            this.Text = "ShellUpscaler";
            this.Load += new System.EventHandler(this.UpscaleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox modelCombox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tilesizeCombox;
        private System.Windows.Forms.Button runBtn;
    }
}

