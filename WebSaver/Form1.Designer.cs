namespace WebSaver
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btSave = new System.Windows.Forms.Button();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.lbState = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(37, 361);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbResponse
            // 
            this.tbResponse.Location = new System.Drawing.Point(12, 71);
            this.tbResponse.Multiline = true;
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.Size = new System.Drawing.Size(556, 273);
            this.tbResponse.TabIndex = 1;
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Location = new System.Drawing.Point(12, 9);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(29, 12);
            this.lbState.TabIndex = 2;
            this.lbState.Text = "就绪";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(12, 34);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(556, 21);
            this.tbUrl.TabIndex = 3;
            this.tbUrl.Text = "输入乡镇页面网址";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 427);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.tbResponse);
            this.Controls.Add(this.btSave);
            this.Name = "Form1";
            this.Text = "WebSaver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbResponse;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.TextBox tbUrl;
    }
}

