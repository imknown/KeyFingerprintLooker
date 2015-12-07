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
			this.auto_fetch_keystore_file_path_btn = new System.Windows.Forms.Button();
			this.browse_keystore_file_path_btn = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.xamarin_first_chk = new System.Windows.Forms.CheckBox();
			this.auto_fetch_keytool_file_path_btn = new System.Windows.Forms.Button();
			this.browse_keytool_file_path_btn = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.keytool_file_path_txt = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.keystore_file_type_release_rdbtn = new System.Windows.Forms.RadioButton();
			this.keystore_file_type_debug_rdbtn = new System.Windows.Forms.RadioButton();
			this.password_txt = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SHA1_txt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.copy_SHA1_btn = new System.Windows.Forms.Button();
			this.operation_log_txt = new System.Windows.Forms.TextBox();
			this.get_fingerprint_btn = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.MD5_txt = new System.Windows.Forms.TextBox();
			this.copy_MD5_btn = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.not_wrap_content_chk = new System.Windows.Forms.CheckBox();
			this.about_txt = new System.Windows.Forms.Label();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// keystore_file_path_txt
			// 
			this.keystore_file_path_txt.AllowDrop = true;
			this.keystore_file_path_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.keystore_file_path_txt.Location = new System.Drawing.Point(126, 47);
			this.keystore_file_path_txt.Name = "keystore_file_path_txt";
			this.keystore_file_path_txt.Size = new System.Drawing.Size(416, 21);
			this.keystore_file_path_txt.TabIndex = 1;
			this.keystore_file_path_txt.Text = "请指定 秘钥文件 路径, 支持拖拽";
			this.keystore_file_path_txt.TextChanged += new System.EventHandler(this.Keystore_file_path_txtTextChanged);
			this.keystore_file_path_txt.DragDrop += new System.Windows.Forms.DragEventHandler(this.Keystore_file_path_txtDragDrop);
			this.keystore_file_path_txt.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
			// 
			// auto_fetch_keystore_file_path_btn
			// 
			this.auto_fetch_keystore_file_path_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.auto_fetch_keystore_file_path_btn.Location = new System.Drawing.Point(548, 45);
			this.auto_fetch_keystore_file_path_btn.Name = "auto_fetch_keystore_file_path_btn";
			this.auto_fetch_keystore_file_path_btn.Size = new System.Drawing.Size(75, 23);
			this.auto_fetch_keystore_file_path_btn.TabIndex = 5;
			this.auto_fetch_keystore_file_path_btn.Text = "自动寻找";
			this.auto_fetch_keystore_file_path_btn.UseVisualStyleBackColor = true;
			this.auto_fetch_keystore_file_path_btn.Click += new System.EventHandler(this.Button1Click);
			// 
			// browse_keystore_file_path_btn
			// 
			this.browse_keystore_file_path_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browse_keystore_file_path_btn.Location = new System.Drawing.Point(629, 45);
			this.browse_keystore_file_path_btn.Name = "browse_keystore_file_path_btn";
			this.browse_keystore_file_path_btn.Size = new System.Drawing.Size(75, 23);
			this.browse_keystore_file_path_btn.TabIndex = 6;
			this.browse_keystore_file_path_btn.Text = "浏览...";
			this.browse_keystore_file_path_btn.UseVisualStyleBackColor = true;
			this.browse_keystore_file_path_btn.Click += new System.EventHandler(this.Button2Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.xamarin_first_chk);
			this.groupBox2.Controls.Add(this.auto_fetch_keytool_file_path_btn);
			this.groupBox2.Controls.Add(this.browse_keytool_file_path_btn);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.keytool_file_path_txt);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.keystore_file_type_release_rdbtn);
			this.groupBox2.Controls.Add(this.keystore_file_type_debug_rdbtn);
			this.groupBox2.Controls.Add(this.password_txt);
			this.groupBox2.Controls.Add(this.keystore_file_path_txt);
			this.groupBox2.Controls.Add(this.auto_fetch_keystore_file_path_btn);
			this.groupBox2.Controls.Add(this.browse_keystore_file_path_btn);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(710, 139);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "源";
			// 
			// xamarin_first_chk
			// 
			this.xamarin_first_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.xamarin_first_chk.Checked = true;
			this.xamarin_first_chk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.xamarin_first_chk.Location = new System.Drawing.Point(356, 75);
			this.xamarin_first_chk.Name = "xamarin_first_chk";
			this.xamarin_first_chk.Size = new System.Drawing.Size(186, 24);
			this.xamarin_first_chk.TabIndex = 20;
			this.xamarin_first_chk.Text = "优先查找 Xamarin Debug Key";
			this.xamarin_first_chk.UseVisualStyleBackColor = true;
			// 
			// auto_fetch_keytool_file_path_btn
			// 
			this.auto_fetch_keytool_file_path_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.auto_fetch_keytool_file_path_btn.Location = new System.Drawing.Point(548, 20);
			this.auto_fetch_keytool_file_path_btn.Name = "auto_fetch_keytool_file_path_btn";
			this.auto_fetch_keytool_file_path_btn.Size = new System.Drawing.Size(75, 23);
			this.auto_fetch_keytool_file_path_btn.TabIndex = 3;
			this.auto_fetch_keytool_file_path_btn.Text = "自动寻找";
			this.auto_fetch_keytool_file_path_btn.UseVisualStyleBackColor = true;
			this.auto_fetch_keytool_file_path_btn.Click += new System.EventHandler(this.Button4Click);
			// 
			// browse_keytool_file_path_btn
			// 
			this.browse_keytool_file_path_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browse_keytool_file_path_btn.Location = new System.Drawing.Point(629, 20);
			this.browse_keytool_file_path_btn.Name = "browse_keytool_file_path_btn";
			this.browse_keytool_file_path_btn.Size = new System.Drawing.Size(75, 23);
			this.browse_keytool_file_path_btn.TabIndex = 4;
			this.browse_keytool_file_path_btn.Text = "浏览...";
			this.browse_keytool_file_path_btn.UseVisualStyleBackColor = true;
			this.browse_keytool_file_path_btn.Click += new System.EventHandler(this.Button8Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 23);
			this.label6.TabIndex = 23;
			this.label6.Text = "keytool.exe 地址";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// keytool_file_path_txt
			// 
			this.keytool_file_path_txt.AllowDrop = true;
			this.keytool_file_path_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.keytool_file_path_txt.Location = new System.Drawing.Point(126, 20);
			this.keytool_file_path_txt.Name = "keytool_file_path_txt";
			this.keytool_file_path_txt.Size = new System.Drawing.Size(416, 21);
			this.keytool_file_path_txt.TabIndex = 0;
			this.keytool_file_path_txt.Text = "请指定 keytool.exe 路径, 支持拖拽";
			this.keytool_file_path_txt.DragDrop += new System.Windows.Forms.DragEventHandler(this.keytool_file_path_txtDragDrop);
			this.keytool_file_path_txt.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(114, 23);
			this.label5.TabIndex = 21;
			this.label5.Text = "密钥地址";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 23);
			this.label4.TabIndex = 20;
			this.label4.Text = "密钥密码";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// keystore_file_type_release_rdbtn
			// 
			this.keystore_file_type_release_rdbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.keystore_file_type_release_rdbtn.Location = new System.Drawing.Point(629, 102);
			this.keystore_file_type_release_rdbtn.Name = "keystore_file_type_release_rdbtn";
			this.keystore_file_type_release_rdbtn.Size = new System.Drawing.Size(75, 24);
			this.keystore_file_type_release_rdbtn.TabIndex = 8;
			this.keystore_file_type_release_rdbtn.Text = "Release";
			this.keystore_file_type_release_rdbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keystore_file_type_release_rdbtn.UseVisualStyleBackColor = true;
			this.keystore_file_type_release_rdbtn.CheckedChanged += new System.EventHandler(this.RadioButton2CheckedChanged);
			// 
			// keystore_file_type_debug_rdbtn
			// 
			this.keystore_file_type_debug_rdbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.keystore_file_type_debug_rdbtn.Checked = true;
			this.keystore_file_type_debug_rdbtn.Location = new System.Drawing.Point(548, 102);
			this.keystore_file_type_debug_rdbtn.Name = "keystore_file_type_debug_rdbtn";
			this.keystore_file_type_debug_rdbtn.Size = new System.Drawing.Size(75, 24);
			this.keystore_file_type_debug_rdbtn.TabIndex = 7;
			this.keystore_file_type_debug_rdbtn.TabStop = true;
			this.keystore_file_type_debug_rdbtn.Text = "Debug";
			this.keystore_file_type_debug_rdbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keystore_file_type_debug_rdbtn.UseVisualStyleBackColor = true;
			this.keystore_file_type_debug_rdbtn.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
			// 
			// password_txt
			// 
			this.password_txt.AllowDrop = true;
			this.password_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.password_txt.Location = new System.Drawing.Point(126, 105);
			this.password_txt.Name = "password_txt";
			this.password_txt.ReadOnly = true;
			this.password_txt.Size = new System.Drawing.Size(416, 21);
			this.password_txt.TabIndex = 2;
			this.password_txt.Text = "android";
			this.password_txt.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(497, 21);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(72, 24);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "冒号分隔";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// SHA1_txt
			// 
			this.SHA1_txt.AllowDrop = true;
			this.SHA1_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SHA1_txt.Location = new System.Drawing.Point(238, 80);
			this.SHA1_txt.Name = "SHA1_txt";
			this.SHA1_txt.ReadOnly = true;
			this.SHA1_txt.Size = new System.Drawing.Size(385, 21);
			this.SHA1_txt.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(202, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "SHA1";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// copy_SHA1_btn
			// 
			this.copy_SHA1_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.copy_SHA1_btn.Location = new System.Drawing.Point(629, 78);
			this.copy_SHA1_btn.Name = "copy_SHA1_btn";
			this.copy_SHA1_btn.Size = new System.Drawing.Size(75, 23);
			this.copy_SHA1_btn.TabIndex = 10;
			this.copy_SHA1_btn.Text = "复制";
			this.copy_SHA1_btn.UseVisualStyleBackColor = true;
			this.copy_SHA1_btn.Click += new System.EventHandler(this.Button5Click);
			// 
			// operation_log_txt
			// 
			this.operation_log_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.operation_log_txt.Location = new System.Drawing.Point(6, 107);
			this.operation_log_txt.Multiline = true;
			this.operation_log_txt.Name = "operation_log_txt";
			this.operation_log_txt.ReadOnly = true;
			this.operation_log_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.operation_log_txt.Size = new System.Drawing.Size(698, 339);
			this.operation_log_txt.TabIndex = 13;
			this.operation_log_txt.Text = "\r\n无日志";
			// 
			// get_fingerprint_btn
			// 
			this.get_fingerprint_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.get_fingerprint_btn.Location = new System.Drawing.Point(629, 21);
			this.get_fingerprint_btn.Name = "get_fingerprint_btn";
			this.get_fingerprint_btn.Size = new System.Drawing.Size(75, 23);
			this.get_fingerprint_btn.TabIndex = 9;
			this.get_fingerprint_btn.Text = "计算指纹";
			this.get_fingerprint_btn.UseVisualStyleBackColor = true;
			this.get_fingerprint_btn.Click += new System.EventHandler(this.Button3Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.Location = new System.Drawing.Point(629, 452);
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
			this.MD5_txt.Location = new System.Drawing.Point(238, 51);
			this.MD5_txt.Name = "MD5_txt";
			this.MD5_txt.ReadOnly = true;
			this.MD5_txt.Size = new System.Drawing.Size(385, 21);
			this.MD5_txt.TabIndex = 15;
			// 
			// copy_MD5_btn
			// 
			this.copy_MD5_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.copy_MD5_btn.Location = new System.Drawing.Point(629, 49);
			this.copy_MD5_btn.Name = "copy_MD5_btn";
			this.copy_MD5_btn.Size = new System.Drawing.Size(75, 23);
			this.copy_MD5_btn.TabIndex = 16;
			this.copy_MD5_btn.Text = "复制";
			this.copy_MD5_btn.UseVisualStyleBackColor = true;
			this.copy_MD5_btn.Click += new System.EventHandler(this.Button7Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(202, 51);
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
			this.groupBox1.Controls.Add(this.not_wrap_content_chk);
			this.groupBox1.Controls.Add(this.about_txt);
			this.groupBox1.Controls.Add(this.checkBox4);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.copy_MD5_btn);
			this.groupBox1.Controls.Add(this.MD5_txt);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.get_fingerprint_btn);
			this.groupBox1.Controls.Add(this.operation_log_txt);
			this.groupBox1.Controls.Add(this.copy_SHA1_btn);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.SHA1_txt);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(12, 157);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(710, 481);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "结果";
			// 
			// not_wrap_content_chk
			// 
			this.not_wrap_content_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.not_wrap_content_chk.Checked = true;
			this.not_wrap_content_chk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.not_wrap_content_chk.Location = new System.Drawing.Point(386, 453);
			this.not_wrap_content_chk.Name = "not_wrap_content_chk";
			this.not_wrap_content_chk.Size = new System.Drawing.Size(83, 24);
			this.not_wrap_content_chk.TabIndex = 25;
			this.not_wrap_content_chk.Text = "自动换行";
			this.not_wrap_content_chk.UseVisualStyleBackColor = true;
			this.not_wrap_content_chk.CheckedChanged += new System.EventHandler(this.Not_wrap_content_chkCheckedChanged);
			// 
			// about_txt
			// 
			this.about_txt.Location = new System.Drawing.Point(6, 452);
			this.about_txt.Name = "about_txt";
			this.about_txt.Size = new System.Drawing.Size(142, 23);
			this.about_txt.TabIndex = 24;
			this.about_txt.Text = "0.2 beta";
			this.about_txt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBox4
			// 
			this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox4.Checked = true;
			this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox4.Location = new System.Drawing.Point(475, 453);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(148, 24);
			this.checkBox4.TabIndex = 19;
			this.checkBox4.Text = "重新计算后, 清空日志";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(238, 23);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(253, 20);
			this.comboBox1.TabIndex = 18;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(575, 21);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(48, 24);
			this.checkBox2.TabIndex = 17;
			this.checkBox2.Text = "大写";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(136, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "别名";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(734, 650);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(750, 600);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "密钥指纹获取器";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox not_wrap_content_chk;
		private System.Windows.Forms.Label about_txt;
		private System.Windows.Forms.CheckBox xamarin_first_chk;
		private System.Windows.Forms.Button browse_keytool_file_path_btn;
		private System.Windows.Forms.Button auto_fetch_keytool_file_path_btn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox keytool_file_path_txt;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.RadioButton keystore_file_type_debug_rdbtn;
		private System.Windows.Forms.RadioButton keystore_file_type_release_rdbtn;
		private System.Windows.Forms.TextBox password_txt;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox MD5_txt;
		private System.Windows.Forms.Button copy_MD5_btn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox operation_log_txt;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button copy_SHA1_btn;
		private System.Windows.Forms.TextBox SHA1_txt;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button get_fingerprint_btn;
		private System.Windows.Forms.Button browse_keystore_file_path_btn;
		private System.Windows.Forms.Button auto_fetch_keystore_file_path_btn;
		private System.Windows.Forms.TextBox keystore_file_path_txt;
	}
}
