namespace Snake
{
	partial class Yard
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
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lblGameOver = new System.Windows.Forms.Label();
			this.lblScore = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSize = new System.Windows.Forms.TextBox();
			this.txtSnake = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 20;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lblGameOver
			// 
			this.lblGameOver.AutoSize = true;
			this.lblGameOver.BackColor = System.Drawing.Color.Transparent;
			this.lblGameOver.Font = new System.Drawing.Font("仿宋", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblGameOver.ForeColor = System.Drawing.Color.Red;
			this.lblGameOver.Location = new System.Drawing.Point(155, 216);
			this.lblGameOver.Name = "lblGameOver";
			this.lblGameOver.Size = new System.Drawing.Size(284, 64);
			this.lblGameOver.TabIndex = 0;
			this.lblGameOver.Text = "游戏结束";
			this.lblGameOver.Visible = false;
			// 
			// lblScore
			// 
			this.lblScore.AutoSize = true;
			this.lblScore.BackColor = System.Drawing.Color.Transparent;
			this.lblScore.Font = new System.Drawing.Font("仿宋", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblScore.ForeColor = System.Drawing.Color.Red;
			this.lblScore.Location = new System.Drawing.Point(12, 9);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(82, 24);
			this.lblScore.TabIndex = 0;
			this.lblScore.Text = "Score:";
			this.lblScore.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtRate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(42, 47);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(498, 133);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "设置速度";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(6, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(472, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "请不要尝试输入除数字以外字符!(1000代表1秒刷新一次,最小为1,\r\n              最大不要超过9位数)";
			// 
			// txtRate
			// 
			this.txtRate.Location = new System.Drawing.Point(149, 33);
			this.txtRate.Name = "txtRate";
			this.txtRate.Size = new System.Drawing.Size(291, 26);
			this.txtRate.TabIndex = 1;
			this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(71, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "输入速度:";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(252, 425);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "开  始";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtSize);
			this.groupBox2.Controls.Add(this.txtSnake);
			this.groupBox2.Location = new System.Drawing.Point(42, 228);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(498, 123);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "自定义你的小蛇";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(36, 77);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "初始长度:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(36, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "蛇躯显示:";
			// 
			// txtSize
			// 
			this.txtSize.Location = new System.Drawing.Point(124, 74);
			this.txtSize.Name = "txtSize";
			this.txtSize.Size = new System.Drawing.Size(316, 26);
			this.txtSize.TabIndex = 1;
			this.txtSize.TextChanged += new System.EventHandler(this.txtSize_TextChanged);
			this.txtSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
			// 
			// txtSnake
			// 
			this.txtSnake.Location = new System.Drawing.Point(124, 30);
			this.txtSnake.Name = "txtSnake";
			this.txtSnake.Size = new System.Drawing.Size(316, 26);
			this.txtSnake.TabIndex = 0;
			// 
			// Yard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(187)))), ((int)(((byte)(244)))));
			this.ClientSize = new System.Drawing.Size(584, 561);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lblGameOver);
			this.Controls.Add(this.lblScore);
			this.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Yard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "K键重新开始,P键暂停";
			this.Load += new System.EventHandler(this.Yard_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Yard_KeyPress);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.Label lblGameOver;
		public System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtRate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSize;
		private System.Windows.Forms.TextBox txtSnake;
	}
}

