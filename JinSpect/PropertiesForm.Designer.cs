namespace JinSpect
{
    partial class PropertiesForm
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
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSrc = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.cbList = new System.Windows.Forms.ComboBox();
            this.checkFilter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(72, 102);
            this.btnRedo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(57, 31);
            this.btnRedo.TabIndex = 30;
            this.btnRedo.Text = "다음";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click_1);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(11, 102);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(57, 31);
            this.btnUndo.TabIndex = 28;
            this.btnUndo.Text = "이전";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click_1);
            // 
            // btnSrc
            // 
            this.btnSrc.Location = new System.Drawing.Point(198, 102);
            this.btnSrc.Margin = new System.Windows.Forms.Padding(2);
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(57, 31);
            this.btnSrc.TabIndex = 27;
            this.btnSrc.Text = "원본";
            this.btnSrc.UseVisualStyleBackColor = true;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click_1);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(137, 102);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(57, 31);
            this.btnApply.TabIndex = 26;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // cbList
            // 
            this.cbList.BackColor = System.Drawing.SystemColors.Info;
            this.cbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbList.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbList.FormattingEnabled = true;
            this.cbList.Items.AddRange(new object[] {
            "Color → Mono",
            "Color → HSV",
            "Flip",
            "Pyramid",
            "Resize",
            "Binarization"});
            this.cbList.Location = new System.Drawing.Point(11, 11);
            this.cbList.Margin = new System.Windows.Forms.Padding(2);
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(244, 27);
            this.cbList.TabIndex = 25;
            // 
            // checkFilter
            // 
            this.checkFilter.AutoSize = true;
            this.checkFilter.Location = new System.Drawing.Point(11, 61);
            this.checkFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkFilter.Name = "checkFilter";
            this.checkFilter.Size = new System.Drawing.Size(89, 19);
            this.checkFilter.TabIndex = 29;
            this.checkFilter.Text = "필터적용";
            this.checkFilter.UseVisualStyleBackColor = true;
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 375);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.checkFilter);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PropertiesForm";
            this.Text = "PropertiesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnSrc;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbList;
        private System.Windows.Forms.CheckBox checkFilter;
    }
}

