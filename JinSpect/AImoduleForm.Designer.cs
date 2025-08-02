namespace JinSpect
{
    partial class AImoduleForm
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
            this.txtAIModelPath = new System.Windows.Forms.TextBox();
            this.cbEngineList = new System.Windows.Forms.ComboBox();
            this.btnSelAIModel = new System.Windows.Forms.Button();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.btnInspAI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAIModelPath
            // 
            this.txtAIModelPath.Location = new System.Drawing.Point(14, 15);
            this.txtAIModelPath.Name = "txtAIModelPath";
            this.txtAIModelPath.ReadOnly = true;
            this.txtAIModelPath.Size = new System.Drawing.Size(239, 25);
            this.txtAIModelPath.TabIndex = 8;
            // 
            // cbEngineList
            // 
            this.cbEngineList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineList.DropDownWidth = 298;
            this.cbEngineList.FormattingEnabled = true;
            this.cbEngineList.Items.AddRange(new object[] {
            "IAD",
            "DET",
            "SEG"});
            this.cbEngineList.Location = new System.Drawing.Point(14, 53);
            this.cbEngineList.Margin = new System.Windows.Forms.Padding(2);
            this.cbEngineList.Name = "cbEngineList";
            this.cbEngineList.Size = new System.Drawing.Size(239, 23);
            this.cbEngineList.TabIndex = 12;
            // 
            // btnSelAIModel
            // 
            this.btnSelAIModel.Location = new System.Drawing.Point(14, 89);
            this.btnSelAIModel.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelAIModel.Name = "btnSelAIModel";
            this.btnSelAIModel.Size = new System.Drawing.Size(87, 35);
            this.btnSelAIModel.TabIndex = 9;
            this.btnSelAIModel.Text = "AI모델 선택";
            this.btnSelAIModel.UseVisualStyleBackColor = true;
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Location = new System.Drawing.Point(109, 89);
            this.btnLoadModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(74, 36);
            this.btnLoadModel.TabIndex = 10;
            this.btnLoadModel.Text = "모델 로딩";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            // 
            // btnInspAI
            // 
            this.btnInspAI.Location = new System.Drawing.Point(192, 89);
            this.btnInspAI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInspAI.Name = "btnInspAI";
            this.btnInspAI.Size = new System.Drawing.Size(61, 35);
            this.btnInspAI.TabIndex = 11;
            this.btnInspAI.Text = "AI 검사";
            this.btnInspAI.UseVisualStyleBackColor = true;
            // 
            // AImoduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 375);
            this.Controls.Add(this.btnInspAI);
            this.Controls.Add(this.btnLoadModel);
            this.Controls.Add(this.btnSelAIModel);
            this.Controls.Add(this.cbEngineList);
            this.Controls.Add(this.txtAIModelPath);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AImoduleForm";
            this.Text = "AImoduleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAIModelPath;
        private System.Windows.Forms.ComboBox cbEngineList;
        private System.Windows.Forms.Button btnSelAIModel;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Button btnInspAI;
    }
}