namespace wf05_login
{
    partial class FrmMain
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
            this.ID = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.TxtPW = new System.Windows.Forms.TextBox();
            this.PW = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(34, 42);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(41, 12);
            this.ID.TabIndex = 0;
            this.ID.Text = "아이디";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(105, 38);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(149, 21);
            this.TxtID.TabIndex = 1;
            this.TxtID.TextChanged += new System.EventHandler(this.TxtID_TextChanged);
            // 
            // TxtPW
            // 
            this.TxtPW.Location = new System.Drawing.Point(105, 78);
            this.TxtPW.Name = "TxtPW";
            this.TxtPW.Size = new System.Drawing.Size(149, 21);
            this.TxtPW.TabIndex = 3;
            this.TxtPW.TextChanged += new System.EventHandler(this.TxtPW_TextChanged);
            // 
            // PW
            // 
            this.PW.AutoSize = true;
            this.PW.Location = new System.Drawing.Point(34, 82);
            this.PW.Name = "PW";
            this.PW.Size = new System.Drawing.Size(53, 12);
            this.PW.TabIndex = 2;
            this.PW.Text = "비밀번호";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(179, 128);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 4;
            this.Login.Text = "로그인";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Progress
            // 
            this.Progress.AutoSize = true;
            this.Progress.Location = new System.Drawing.Point(177, 174);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(0, 12);
            this.Progress.TabIndex = 5;
            this.Progress.Click += new System.EventHandler(this.Progress_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 198);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.TxtPW);
            this.Controls.Add(this.PW);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.ID);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.TextBox TxtPW;
        private System.Windows.Forms.Label PW;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Label Progress;
    }
}

