﻿namespace JinSpect.Property
{
    partial class PyramidProp
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUP = new System.Windows.Forms.RadioButton();
            this.btnDown = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnUP
            // 
            this.btnUP.AutoSize = true;
            this.btnUP.Location = new System.Drawing.Point(27, 23);
            this.btnUP.Margin = new System.Windows.Forms.Padding(4);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(54, 22);
            this.btnUP.TabIndex = 0;
            this.btnUP.TabStop = true;
            this.btnUP.Text = "Up";
            this.btnUP.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.AutoSize = true;
            this.btnDown.Location = new System.Drawing.Point(27, 53);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(79, 22);
            this.btnDown.TabIndex = 0;
            this.btnDown.TabStop = true;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // PyramidProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUP);
            this.Name = "PyramidProp";
            this.Size = new System.Drawing.Size(220, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btnUP;
        private System.Windows.Forms.RadioButton btnDown;
    }
}
