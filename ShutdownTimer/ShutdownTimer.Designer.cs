namespace ShutdownTimer
{
    partial class ShutdownTimer
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShutdownTimer));
            this.btnSetShutdown = new System.Windows.Forms.Button();
            this.btnCancelShutdown = new System.Windows.Forms.Button();
            this.txtTimeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTimeRemaining = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSetShutdown
            // 
            this.btnSetShutdown.Location = new System.Drawing.Point(20, 90);
            this.btnSetShutdown.Name = "btnSetShutdown";
            this.btnSetShutdown.Size = new System.Drawing.Size(90, 30);
            this.btnSetShutdown.TabIndex = 0;
            this.btnSetShutdown.Text = "종료예약";
            this.btnSetShutdown.UseVisualStyleBackColor = true;
            this.btnSetShutdown.Click += new System.EventHandler(this.btnSetShutdown_Click);
            // 
            // btnCancelShutdown
            // 
            this.btnCancelShutdown.Location = new System.Drawing.Point(130, 90);
            this.btnCancelShutdown.Name = "btnCancelShutdown";
            this.btnCancelShutdown.Size = new System.Drawing.Size(90, 30);
            this.btnCancelShutdown.TabIndex = 1;
            this.btnCancelShutdown.Text = "예약취소";
            this.btnCancelShutdown.UseVisualStyleBackColor = true;
            this.btnCancelShutdown.Click += new System.EventHandler(this.btnCancelShutdown_Click);
            // 
            // txtTimeInput
            // 
            this.txtTimeInput.Font = new System.Drawing.Font("굴림", 9F);
            this.txtTimeInput.Location = new System.Drawing.Point(120, 44);
            this.txtTimeInput.Name = "txtTimeInput";
            this.txtTimeInput.Size = new System.Drawing.Size(100, 21);
            this.txtTimeInput.TabIndex = 2;
            this.txtTimeInput.TextChanged += new System.EventHandler(this.txtTimeInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F);
            this.label1.Location = new System.Drawing.Point(20, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "예약 시간 (분):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTimeRemaining
            // 
            this.labelTimeRemaining.AutoSize = true;
            this.labelTimeRemaining.Location = new System.Drawing.Point(20, 20);
            this.labelTimeRemaining.Name = "labelTimeRemaining";
            this.labelTimeRemaining.Size = new System.Drawing.Size(17, 12);
            this.labelTimeRemaining.TabIndex = 4;
            this.labelTimeRemaining.Text = "   ";
            // 
            // ShutdownTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 141);
            this.Controls.Add(this.labelTimeRemaining);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimeInput);
            this.Controls.Add(this.btnCancelShutdown);
            this.Controls.Add(this.btnSetShutdown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShutdownTimer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShutdownTimer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShutdownTimer_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetShutdown;
        private System.Windows.Forms.Button btnCancelShutdown;
        private System.Windows.Forms.TextBox txtTimeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTimeRemaining;
    }
}

