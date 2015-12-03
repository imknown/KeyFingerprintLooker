/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2015/12/3 周四
 * 时间: 上午 11:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace KeyFingerprintLooker
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.keystore_file_path_txt = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SHA1_txt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.MD5_txt = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// keystore_file_path_txt
			// 
			this.keystore_file_path_txt.AllowDrop = true;
			this.keystore_file_path_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.keystore_file_path_txt.Location = new System.Drawing.Point(6, 20);
			this.keystore_file_path_txt.Name = "keystore_file_path_txt";
			this.keystore_file_path_txt.Size = new System.Drawing.Size(309, 21);
			this.keystore_file_path_txt.TabIndex = 0;
			this.keystore_file_path_txt.Text = "请指定 秘钥文件 路径, 支持拖拽";
			this.keystore_file_path_txt.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.keystore_file_path_txt.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 47);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "自动寻找";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(87, 47);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "浏览...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Controls.Add(this.checkBox3);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.keystore_file_path_txt);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(485, 81);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "源";
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(244, 21);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(86, 24);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "冒号分隔";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// SHA1_txt
			// 
			this.SHA1_txt.AllowDrop = true;
			this.SHA1_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SHA1_txt.Location = new System.Drawing.Point(73, 80);
			this.SHA1_txt.Name = "SHA1_txt";
			this.SHA1_txt.ReadOnly = true;
			this.SHA1_txt.Size = new System.Drawing.Size(319, 21);
			this.SHA1_txt.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(37, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "SHA1";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(398, 78);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 10;
			this.button5.Text = "复制";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(7, 107);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(466, 233);
			this.textBox3.TabIndex = 13;
			this.textBox3.Text = "\r\n无日志";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(398, 20);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "计算指纹";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.Location = new System.Drawing.Point(398, 346);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 11;
			this.button6.Text = "清空";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// MD5_txt
			// 
			this.MD5_txt.AllowDrop = true;
			this.MD5_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MD5_txt.Location = new System.Drawing.Point(73, 51);
			this.MD5_txt.Name = "MD5_txt";
			this.MD5_txt.ReadOnly = true;
			this.MD5_txt.Size = new System.Drawing.Size(319, 21);
			this.MD5_txt.TabIndex = 15;
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.Location = new System.Drawing.Point(398, 49);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 16;
			this.button7.Text = "复制";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(37, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 23);
			this.label3.TabIndex = 14;
			this.label3.Text = "MD5";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.MD5_txt);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.SHA1_txt);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(12, 99);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(485, 375);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "结果";
			// 
			// checkBox2
			// 
			this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(336, 21);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(56, 24);
			this.checkBox2.TabIndex = 17;
			this.checkBox2.Text = "大写";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// textBox1
			// 
			this.textBox1.AllowDrop = true;
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(319, 20);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(160, 21);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "android";
			// 
			// checkBox3
			// 
			this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox3.Checked = true;
			this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox3.Enabled = false;
			this.checkBox3.Location = new System.Drawing.Point(402, 49);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(77, 24);
			this.checkBox3.TabIndex = 4;
			this.checkBox3.Text = "明文密码";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(260, 48);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(65, 24);
			this.radioButton1.TabIndex = 5;
			this.radioButton1.Text = "Debug";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.radioButton2.Location = new System.Drawing.Point(331, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(65, 24);
			this.radioButton2.TabIndex = 6;
			this.radioButton2.Text = "Release";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 486);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(525, 525);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "密钥指纹获取器";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox MD5_txt;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox SHA1_txt;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox keystore_file_path_txt;
	}
}
