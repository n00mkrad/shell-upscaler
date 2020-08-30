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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpscaleForm));
            this.modelCombox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tilesizeCombox = new System.Windows.Forms.ComboBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.modeCombox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.overwriteCombox = new System.Windows.Forms.ComboBox();
            this.outputFormatCombox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.alphaCbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // modelCombox
            // 
            this.modelCombox.FormattingEnabled = true;
            this.modelCombox.Location = new System.Drawing.Point(128, 80);
            this.modelCombox.Name = "modelCombox";
            this.modelCombox.Size = new System.Drawing.Size(244, 21);
            this.modelCombox.TabIndex = 0;
            this.modelCombox.SelectedIndexChanged += new System.EventHandler(this.modelCombox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upscale Image Or Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ESRGAN Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tile Size (HR):";
            // 
            // tilesizeCombox
            // 
            this.tilesizeCombox.FormattingEnabled = true;
            this.tilesizeCombox.Items.AddRange(new object[] {
            "1024",
            "768",
            "512",
            "384",
            "256",
            "192",
            "128"});
            this.tilesizeCombox.Location = new System.Drawing.Point(128, 106);
            this.tilesizeCombox.Name = "tilesizeCombox";
            this.tilesizeCombox.Size = new System.Drawing.Size(244, 21);
            this.tilesizeCombox.TabIndex = 3;
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.runBtn.Location = new System.Drawing.Point(11, 238);
            this.runBtn.Margin = new System.Windows.Forms.Padding(2);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(362, 41);
            this.runBtn.TabIndex = 5;
            this.runBtn.Text = "Run ESRGAN";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // modeCombox
            // 
            this.modeCombox.FormattingEnabled = true;
            this.modeCombox.Items.AddRange(new object[] {
            "Upscale This Image",
            "Upscale All Images In This Folder"});
            this.modeCombox.Location = new System.Drawing.Point(128, 53);
            this.modeCombox.Name = "modeCombox";
            this.modeCombox.Size = new System.Drawing.Size(244, 21);
            this.modeCombox.TabIndex = 6;
            this.modeCombox.SelectedIndexChanged += new System.EventHandler(this.modeCombox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Overwrite Images:";
            // 
            // overwriteCombox
            // 
            this.overwriteCombox.FormattingEnabled = true;
            this.overwriteCombox.Items.AddRange(new object[] {
            "No - Add Suffix To Upscaled Images",
            "Yes - Overwrite Source Files"});
            this.overwriteCombox.Location = new System.Drawing.Point(128, 133);
            this.overwriteCombox.Name = "overwriteCombox";
            this.overwriteCombox.Size = new System.Drawing.Size(244, 21);
            this.overwriteCombox.TabIndex = 9;
            // 
            // outputFormatCombox
            // 
            this.outputFormatCombox.FormattingEnabled = true;
            this.outputFormatCombox.Items.AddRange(new object[] {
            "PNG",
            "Same As Input Image",
            "JPEG - High",
            "JPEG - Medium",
            "WEBP - High (Slower, but better than JPEG)",
            "WEBP - Medium (Slower, but better than JPEG)"});
            this.outputFormatCombox.Location = new System.Drawing.Point(128, 160);
            this.outputFormatCombox.Name = "outputFormatCombox";
            this.outputFormatCombox.Size = new System.Drawing.Size(244, 21);
            this.outputFormatCombox.TabIndex = 11;
            this.outputFormatCombox.SelectedIndexChanged += new System.EventHandler(this.outputFormatCombox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Output Format:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Enable Alpha:";
            // 
            // alphaCbox
            // 
            this.alphaCbox.AutoSize = true;
            this.alphaCbox.Location = new System.Drawing.Point(128, 190);
            this.alphaCbox.Name = "alphaCbox";
            this.alphaCbox.Size = new System.Drawing.Size(15, 14);
            this.alphaCbox.TabIndex = 13;
            this.alphaCbox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(149, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Use only when needed, takes twice as long.";
            // 
            // UpscaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 291);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.alphaCbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.outputFormatCombox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.overwriteCombox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.modeCombox);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tilesizeCombox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modelCombox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.ComboBox modeCombox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox overwriteCombox;
        private System.Windows.Forms.ComboBox outputFormatCombox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox alphaCbox;
        private System.Windows.Forms.Label label8;
    }
}

