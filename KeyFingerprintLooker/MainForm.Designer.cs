/*
 * 用户： imknown
 * 日期: 2015/12/3 周四
 * 时间: 上午 11:22
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
			this.source_gpb = new System.Windows.Forms.GroupBox();
			this.xamarin_first_chk = new System.Windows.Forms.CheckBox();
			this.auto_fetch_keytool_file_path_btn = new System.Windows.Forms.Button();
			this.keytool_file_path_lbl = new System.Windows.Forms.Label();
			this.browse_keytool_file_path_btn = new System.Windows.Forms.Button();
			this.keytool_file_path_txt = new System.Windows.Forms.TextBox();
			this.keystore_file_path_lbl = new System.Windows.Forms.Label();
			this.password_lbl = new System.Windows.Forms.Label();
			this.keystore_file_type_release_rdbtn = new System.Windows.Forms.RadioButton();
			this.keystore_file_type_debug_rdbtn = new System.Windows.Forms.RadioButton();
			this.password_txt = new System.Windows.Forms.TextBox();
			this.colon_for_split_chk = new System.Windows.Forms.CheckBox();
			this.SHA1_txt = new System.Windows.Forms.TextBox();
			this.sha1_lbl = new System.Windows.Forms.Label();
			this.copy_SHA1_btn = new System.Windows.Forms.Button();
			this.operation_log_txt = new System.Windows.Forms.TextBox();
			this.calc_fingerprint_btn = new System.Windows.Forms.Button();
			this.clear_log_btn = new System.Windows.Forms.Button();
			this.MD5_txt = new System.Windows.Forms.TextBox();
			this.copy_MD5_btn = new System.Windows.Forms.Button();
			this.md5_lbl = new System.Windows.Forms.Label();
			this.result_gpb = new System.Windows.Forms.GroupBox();
			this.not_wrap_content_chk = new System.Windows.Forms.CheckBox();
			this.about_txt = new System.Windows.Forms.Label();
			this.clear_log_after_recalc_chk = new System.Windows.Forms.CheckBox();
			this.alias_selector_cmb = new System.Windows.Forms.ComboBox();
			this.caps_chk = new System.Windows.Forms.CheckBox();
			this.aliased_counter_lbl = new System.Windows.Forms.Label();
			this.main_ms = new System.Windows.Forms.MenuStrip();
			this.file_tsmi = new System.Windows.Forms.ToolStripMenuItem();
			this.view_tsmi = new System.Windows.Forms.ToolStripMenuItem();
			this.language_tsmi = new System.Windows.Forms.ToolStripMenuItem();
			this.english_united_states_tsmi = new System.Windows.Forms.ToolStripMenuItem();
			this.simple_chinese_prc_tsmi = new System.Windows.Forms.ToolStripMenuItem();
			this.about_tsmi = new System.Windows.Forms.ToolStripMenuItem();
			this.source_gpb.SuspendLayout();
			this.result_gpb.SuspendLayout();
			this.main_ms.SuspendLayout();
			this.SuspendLayout();
			// 
			// keystore_file_path_txt
			// 
			this.keystore_file_path_txt.AllowDrop = true;
			this.keystore_file_path_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.keystore_file_path_txt.Location = new System.Drawing.Point(157, 55);
			this.keystore_file_path_txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.keystore_file_path_txt.Name = "keystore_file_path_txt";
			this.keystore_file_path_txt.Size = new System.Drawing.Size(431, 25);
			this.keystore_file_path_txt.TabIndex = 3;
			this.keystore_file_path_txt.DragDrop += new System.Windows.Forms.DragEventHandler(this.keystore_file_path_txtDragDrop);
			this.keystore_file_path_txt.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
			// 
			// auto_fetch_keystore_file_path_btn
			// 
			this.auto_fetch_keystore_file_path_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.auto_fetch_keystore_file_path_btn.Location = new System.Drawing.Point(596, 54);
			this.auto_fetch_keystore_file_path_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.auto_fetch_keystore_file_path_btn.Name = "auto_fetch_keystore_file_path_btn";
			this.auto_fetch_keystore_file_path_btn.Size = new System.Drawing.Size(90, 28);
			this.auto_fetch_keystore_file_path_btn.TabIndex = 4;
			this.auto_fetch_keystore_file_path_btn.Text = "auto fetch";
			this.auto_fetch_keystore_file_path_btn.UseVisualStyleBackColor = true;
			this.auto_fetch_keystore_file_path_btn.Click += new System.EventHandler(this.auto_fetch_keystore_file_path_btnClick);
			// 
			// browse_keystore_file_path_btn
			// 
			this.browse_keystore_file_path_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browse_keystore_file_path_btn.Location = new System.Drawing.Point(694, 54);
			this.browse_keystore_file_path_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.browse_keystore_file_path_btn.Name = "browse_keystore_file_path_btn";
			this.browse_keystore_file_path_btn.Size = new System.Drawing.Size(90, 28);
			this.browse_keystore_file_path_btn.TabIndex = 5;
			this.browse_keystore_file_path_btn.Text = "browse...";
			this.browse_keystore_file_path_btn.UseVisualStyleBackColor = true;
			this.browse_keystore_file_path_btn.Click += new System.EventHandler(this.browse_keystore_file_path_btnClick);
			// 
			// source_gpb
			// 
			this.source_gpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.source_gpb.Controls.Add(this.xamarin_first_chk);
			this.source_gpb.Controls.Add(this.auto_fetch_keytool_file_path_btn);
			this.source_gpb.Controls.Add(this.keytool_file_path_lbl);
			this.source_gpb.Controls.Add(this.browse_keytool_file_path_btn);
			this.source_gpb.Controls.Add(this.keytool_file_path_txt);
			this.source_gpb.Controls.Add(this.keystore_file_path_lbl);
			this.source_gpb.Controls.Add(this.password_lbl);
			this.source_gpb.Controls.Add(this.keystore_file_type_release_rdbtn);
			this.source_gpb.Controls.Add(this.keystore_file_type_debug_rdbtn);
			this.source_gpb.Controls.Add(this.password_txt);
			this.source_gpb.Controls.Add(this.keystore_file_path_txt);
			this.source_gpb.Controls.Add(this.browse_keystore_file_path_btn);
			this.source_gpb.Controls.Add(this.auto_fetch_keystore_file_path_btn);
			this.source_gpb.Location = new System.Drawing.Point(13, 27);
			this.source_gpb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.source_gpb.Name = "source_gpb";
			this.source_gpb.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.source_gpb.Size = new System.Drawing.Size(792, 159);
			this.source_gpb.TabIndex = 12;
			this.source_gpb.TabStop = false;
			this.source_gpb.Text = "source";
			// 
			// xamarin_first_chk
			// 
			this.xamarin_first_chk.Location = new System.Drawing.Point(157, 86);
			this.xamarin_first_chk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.xamarin_first_chk.Name = "xamarin_first_chk";
			this.xamarin_first_chk.Size = new System.Drawing.Size(429, 26);
			this.xamarin_first_chk.TabIndex = 6;
			this.xamarin_first_chk.Text = "fetch Xamarin Debug Key first";
			this.xamarin_first_chk.UseVisualStyleBackColor = true;
			// 
			// auto_fetch_keytool_file_path_btn
			// 
			this.auto_fetch_keytool_file_path_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.auto_fetch_keytool_file_path_btn.Location = new System.Drawing.Point(596, 23);
			this.auto_fetch_keytool_file_path_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.auto_fetch_keytool_file_path_btn.Name = "auto_fetch_keytool_file_path_btn";
			this.auto_fetch_keytool_file_path_btn.Size = new System.Drawing.Size(90, 28);
			this.auto_fetch_keytool_file_path_btn.TabIndex = 1;
			this.auto_fetch_keytool_file_path_btn.Text = "auto fetch";
			this.auto_fetch_keytool_file_path_btn.UseVisualStyleBackColor = true;
			this.auto_fetch_keytool_file_path_btn.Click += new System.EventHandler(this.auto_fetch_keytool_file_path_btnClick);
			// 
			// keytool_file_path_lbl
			// 
			this.keytool_file_path_lbl.Location = new System.Drawing.Point(8, 18);
			this.keytool_file_path_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.keytool_file_path_lbl.Name = "keytool_file_path_lbl";
			this.keytool_file_path_lbl.Size = new System.Drawing.Size(141, 36);
			this.keytool_file_path_lbl.TabIndex = 23;
			this.keytool_file_path_lbl.Text = "keytool.exe location";
			this.keytool_file_path_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// browse_keytool_file_path_btn
			// 
			this.browse_keytool_file_path_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browse_keytool_file_path_btn.Location = new System.Drawing.Point(694, 23);
			this.browse_keytool_file_path_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.browse_keytool_file_path_btn.Name = "browse_keytool_file_path_btn";
			this.browse_keytool_file_path_btn.Size = new System.Drawing.Size(90, 28);
			this.browse_keytool_file_path_btn.TabIndex = 2;
			this.browse_keytool_file_path_btn.Text = "browse...";
			this.browse_keytool_file_path_btn.UseVisualStyleBackColor = true;
			this.browse_keytool_file_path_btn.Click += new System.EventHandler(this.browse_keytool_file_path_btnClick);
			// 
			// keytool_file_path_txt
			// 
			this.keytool_file_path_txt.AllowDrop = true;
			this.keytool_file_path_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.keytool_file_path_txt.Location = new System.Drawing.Point(157, 24);
			this.keytool_file_path_txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.keytool_file_path_txt.Name = "keytool_file_path_txt";
			this.keytool_file_path_txt.Size = new System.Drawing.Size(431, 25);
			this.keytool_file_path_txt.TabIndex = 0;
			this.keytool_file_path_txt.DragDrop += new System.Windows.Forms.DragEventHandler(this.keytool_file_path_txtDragDrop);
			this.keytool_file_path_txt.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
			// 
			// keystore_file_path_lbl
			// 
			this.keystore_file_path_lbl.Location = new System.Drawing.Point(8, 49);
			this.keystore_file_path_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.keystore_file_path_lbl.Name = "keystore_file_path_lbl";
			this.keystore_file_path_lbl.Size = new System.Drawing.Size(141, 36);
			this.keystore_file_path_lbl.TabIndex = 21;
			this.keystore_file_path_lbl.Text = "key or apk location";
			this.keystore_file_path_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// password_lbl
			// 
			this.password_lbl.Location = new System.Drawing.Point(8, 112);
			this.password_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.password_lbl.Name = "password_lbl";
			this.password_lbl.Size = new System.Drawing.Size(141, 36);
			this.password_lbl.TabIndex = 20;
			this.password_lbl.Text = "key password";
			this.password_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// keystore_file_type_release_rdbtn
			// 
			this.keystore_file_type_release_rdbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.keystore_file_type_release_rdbtn.Location = new System.Drawing.Point(694, 112);
			this.keystore_file_type_release_rdbtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.keystore_file_type_release_rdbtn.Name = "keystore_file_type_release_rdbtn";
			this.keystore_file_type_release_rdbtn.Size = new System.Drawing.Size(90, 38);
			this.keystore_file_type_release_rdbtn.TabIndex = 9;
			this.keystore_file_type_release_rdbtn.Text = "Release";
			this.keystore_file_type_release_rdbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keystore_file_type_release_rdbtn.UseVisualStyleBackColor = true;
			this.keystore_file_type_release_rdbtn.CheckedChanged += new System.EventHandler(this.keystore_file_type_release_rdbtnCheckedChanged);
			// 
			// keystore_file_type_debug_rdbtn
			// 
			this.keystore_file_type_debug_rdbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.keystore_file_type_debug_rdbtn.Checked = true;
			this.keystore_file_type_debug_rdbtn.Location = new System.Drawing.Point(596, 112);
			this.keystore_file_type_debug_rdbtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.keystore_file_type_debug_rdbtn.Name = "keystore_file_type_debug_rdbtn";
			this.keystore_file_type_debug_rdbtn.Size = new System.Drawing.Size(90, 38);
			this.keystore_file_type_debug_rdbtn.TabIndex = 8;
			this.keystore_file_type_debug_rdbtn.TabStop = true;
			this.keystore_file_type_debug_rdbtn.Text = "Debug";
			this.keystore_file_type_debug_rdbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keystore_file_type_debug_rdbtn.UseVisualStyleBackColor = true;
			this.keystore_file_type_debug_rdbtn.CheckedChanged += new System.EventHandler(this.keystore_file_type_debug_rdbtnCheckedChanged);
			// 
			// password_txt
			// 
			this.password_txt.AllowDrop = true;
			this.password_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.password_txt.Location = new System.Drawing.Point(157, 118);
			this.password_txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.password_txt.Name = "password_txt";
			this.password_txt.ReadOnly = true;
			this.password_txt.Size = new System.Drawing.Size(431, 25);
			this.password_txt.TabIndex = 7;
			this.password_txt.Text = "android";
			this.password_txt.TextChanged += new System.EventHandler(this.password_txtTextChanged);
			// 
			// colon_for_split_chk
			// 
			this.colon_for_split_chk.Checked = true;
			this.colon_for_split_chk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.colon_for_split_chk.Enabled = false;
			this.colon_for_split_chk.Location = new System.Drawing.Point(155, 119);
			this.colon_for_split_chk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.colon_for_split_chk.Name = "colon_for_split_chk";
			this.colon_for_split_chk.Size = new System.Drawing.Size(135, 26);
			this.colon_for_split_chk.TabIndex = 16;
			this.colon_for_split_chk.Text = "split with colon";
			this.colon_for_split_chk.UseVisualStyleBackColor = true;
			this.colon_for_split_chk.CheckedChanged += new System.EventHandler(this.UseColonForSplitCheckedChanged);
			// 
			// SHA1_txt
			// 
			this.SHA1_txt.AllowDrop = true;
			this.SHA1_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.SHA1_txt.Location = new System.Drawing.Point(155, 88);
			this.SHA1_txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.SHA1_txt.Name = "SHA1_txt";
			this.SHA1_txt.ReadOnly = true;
			this.SHA1_txt.Size = new System.Drawing.Size(431, 25);
			this.SHA1_txt.TabIndex = 14;
			// 
			// sha1_lbl
			// 
			this.sha1_lbl.Location = new System.Drawing.Point(6, 82);
			this.sha1_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.sha1_lbl.Name = "sha1_lbl";
			this.sha1_lbl.Size = new System.Drawing.Size(141, 36);
			this.sha1_lbl.TabIndex = 5;
			this.sha1_lbl.Text = "SHA1";
			this.sha1_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// copy_SHA1_btn
			// 
			this.copy_SHA1_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.copy_SHA1_btn.Location = new System.Drawing.Point(594, 86);
			this.copy_SHA1_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.copy_SHA1_btn.Name = "copy_SHA1_btn";
			this.copy_SHA1_btn.Size = new System.Drawing.Size(190, 28);
			this.copy_SHA1_btn.TabIndex = 15;
			this.copy_SHA1_btn.Text = "copy";
			this.copy_SHA1_btn.UseVisualStyleBackColor = true;
			this.copy_SHA1_btn.Click += new System.EventHandler(this.copy_SHA1_btnClick);
			// 
			// operation_log_txt
			// 
			this.operation_log_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.operation_log_txt.Location = new System.Drawing.Point(8, 151);
			this.operation_log_txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.operation_log_txt.Multiline = true;
			this.operation_log_txt.Name = "operation_log_txt";
			this.operation_log_txt.ReadOnly = true;
			this.operation_log_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.operation_log_txt.Size = new System.Drawing.Size(776, 136);
			this.operation_log_txt.TabIndex = 18;
			this.operation_log_txt.Text = "no log";
			// 
			// calc_fingerprint_btn
			// 
			this.calc_fingerprint_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.calc_fingerprint_btn.Location = new System.Drawing.Point(594, 24);
			this.calc_fingerprint_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.calc_fingerprint_btn.Name = "calc_fingerprint_btn";
			this.calc_fingerprint_btn.Size = new System.Drawing.Size(190, 28);
			this.calc_fingerprint_btn.TabIndex = 11;
			this.calc_fingerprint_btn.Text = "calc fingerprint";
			this.calc_fingerprint_btn.UseVisualStyleBackColor = true;
			this.calc_fingerprint_btn.Click += new System.EventHandler(this.calc_fingerprint_btnClick);
			// 
			// clear_log_btn
			// 
			this.clear_log_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clear_log_btn.Location = new System.Drawing.Point(691, 293);
			this.clear_log_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.clear_log_btn.Name = "clear_log_btn";
			this.clear_log_btn.Size = new System.Drawing.Size(93, 28);
			this.clear_log_btn.TabIndex = 21;
			this.clear_log_btn.Text = "clear log";
			this.clear_log_btn.UseVisualStyleBackColor = true;
			this.clear_log_btn.Click += new System.EventHandler(this.clear_log_btnClick);
			// 
			// MD5_txt
			// 
			this.MD5_txt.AllowDrop = true;
			this.MD5_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.MD5_txt.Location = new System.Drawing.Point(155, 57);
			this.MD5_txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MD5_txt.Name = "MD5_txt";
			this.MD5_txt.ReadOnly = true;
			this.MD5_txt.Size = new System.Drawing.Size(431, 25);
			this.MD5_txt.TabIndex = 12;
			// 
			// copy_MD5_btn
			// 
			this.copy_MD5_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.copy_MD5_btn.Location = new System.Drawing.Point(594, 55);
			this.copy_MD5_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.copy_MD5_btn.Name = "copy_MD5_btn";
			this.copy_MD5_btn.Size = new System.Drawing.Size(190, 28);
			this.copy_MD5_btn.TabIndex = 13;
			this.copy_MD5_btn.Text = "copy";
			this.copy_MD5_btn.UseVisualStyleBackColor = true;
			this.copy_MD5_btn.Click += new System.EventHandler(this.copy_MD5_btnClick);
			// 
			// md5_lbl
			// 
			this.md5_lbl.Location = new System.Drawing.Point(6, 51);
			this.md5_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.md5_lbl.Name = "md5_lbl";
			this.md5_lbl.Size = new System.Drawing.Size(141, 36);
			this.md5_lbl.TabIndex = 14;
			this.md5_lbl.Text = "MD5";
			this.md5_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// result_gpb
			// 
			this.result_gpb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.result_gpb.Controls.Add(this.not_wrap_content_chk);
			this.result_gpb.Controls.Add(this.about_txt);
			this.result_gpb.Controls.Add(this.clear_log_after_recalc_chk);
			this.result_gpb.Controls.Add(this.alias_selector_cmb);
			this.result_gpb.Controls.Add(this.caps_chk);
			this.result_gpb.Controls.Add(this.aliased_counter_lbl);
			this.result_gpb.Controls.Add(this.md5_lbl);
			this.result_gpb.Controls.Add(this.copy_MD5_btn);
			this.result_gpb.Controls.Add(this.MD5_txt);
			this.result_gpb.Controls.Add(this.clear_log_btn);
			this.result_gpb.Controls.Add(this.calc_fingerprint_btn);
			this.result_gpb.Controls.Add(this.operation_log_txt);
			this.result_gpb.Controls.Add(this.copy_SHA1_btn);
			this.result_gpb.Controls.Add(this.sha1_lbl);
			this.result_gpb.Controls.Add(this.SHA1_txt);
			this.result_gpb.Controls.Add(this.colon_for_split_chk);
			this.result_gpb.Location = new System.Drawing.Point(13, 192);
			this.result_gpb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.result_gpb.Name = "result_gpb";
			this.result_gpb.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.result_gpb.Size = new System.Drawing.Size(790, 327);
			this.result_gpb.TabIndex = 11;
			this.result_gpb.TabStop = false;
			this.result_gpb.Text = "result";
			// 
			// not_wrap_content_chk
			// 
			this.not_wrap_content_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.not_wrap_content_chk.Checked = true;
			this.not_wrap_content_chk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.not_wrap_content_chk.Location = new System.Drawing.Point(566, 295);
			this.not_wrap_content_chk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.not_wrap_content_chk.Name = "not_wrap_content_chk";
			this.not_wrap_content_chk.Size = new System.Drawing.Size(117, 26);
			this.not_wrap_content_chk.TabIndex = 20;
			this.not_wrap_content_chk.Text = "wrap content";
			this.not_wrap_content_chk.UseVisualStyleBackColor = true;
			this.not_wrap_content_chk.CheckedChanged += new System.EventHandler(this.not_wrap_content_chkCheckedChanged);
			// 
			// about_txt
			// 
			this.about_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.about_txt.Location = new System.Drawing.Point(8, 294);
			this.about_txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.about_txt.Name = "about_txt";
			this.about_txt.Size = new System.Drawing.Size(219, 26);
			this.about_txt.TabIndex = 24;
			this.about_txt.Text = "{0}, {1} mode, {2}bit OS";
			this.about_txt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// clear_log_after_recalc_chk
			// 
			this.clear_log_after_recalc_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clear_log_after_recalc_chk.Checked = true;
			this.clear_log_after_recalc_chk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clear_log_after_recalc_chk.Location = new System.Drawing.Point(370, 295);
			this.clear_log_after_recalc_chk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.clear_log_after_recalc_chk.Name = "clear_log_after_recalc_chk";
			this.clear_log_after_recalc_chk.Size = new System.Drawing.Size(188, 26);
			this.clear_log_after_recalc_chk.TabIndex = 19;
			this.clear_log_after_recalc_chk.Text = "clear log after recalc";
			this.clear_log_after_recalc_chk.UseVisualStyleBackColor = true;
			// 
			// alias_selector_cmb
			// 
			this.alias_selector_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.alias_selector_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.alias_selector_cmb.Enabled = false;
			this.alias_selector_cmb.FormattingEnabled = true;
			this.alias_selector_cmb.Location = new System.Drawing.Point(155, 24);
			this.alias_selector_cmb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.alias_selector_cmb.Name = "alias_selector_cmb";
			this.alias_selector_cmb.Size = new System.Drawing.Size(431, 27);
			this.alias_selector_cmb.TabIndex = 10;
			this.alias_selector_cmb.SelectedIndexChanged += new System.EventHandler(this.alias_selector_cmbSelectedIndexChanged);
			// 
			// caps_chk
			// 
			this.caps_chk.Checked = true;
			this.caps_chk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.caps_chk.Enabled = false;
			this.caps_chk.Location = new System.Drawing.Point(298, 119);
			this.caps_chk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.caps_chk.Name = "caps_chk";
			this.caps_chk.Size = new System.Drawing.Size(149, 26);
			this.caps_chk.TabIndex = 17;
			this.caps_chk.Text = "capitals";
			this.caps_chk.UseVisualStyleBackColor = true;
			this.caps_chk.CheckedChanged += new System.EventHandler(this.UseCapsOrNotCheckedChanged);
			// 
			// aliased_counter_lbl
			// 
			this.aliased_counter_lbl.Location = new System.Drawing.Point(6, 18);
			this.aliased_counter_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.aliased_counter_lbl.Name = "aliased_counter_lbl";
			this.aliased_counter_lbl.Size = new System.Drawing.Size(141, 36);
			this.aliased_counter_lbl.TabIndex = 14;
			this.aliased_counter_lbl.Text = "0 aliased";
			this.aliased_counter_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// main_ms
			// 
			this.main_ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.file_tsmi,
			this.view_tsmi,
			this.about_tsmi});
			this.main_ms.Location = new System.Drawing.Point(0, 0);
			this.main_ms.Name = "main_ms";
			this.main_ms.Size = new System.Drawing.Size(818, 25);
			this.main_ms.TabIndex = 13;
			this.main_ms.Text = "menuStrip1";
			// 
			// file_tsmi
			// 
			this.file_tsmi.Name = "file_tsmi";
			this.file_tsmi.Size = new System.Drawing.Size(39, 21);
			this.file_tsmi.Text = "&File";
			// 
			// view_tsmi
			// 
			this.view_tsmi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.language_tsmi});
			this.view_tsmi.Name = "view_tsmi";
			this.view_tsmi.Size = new System.Drawing.Size(47, 21);
			this.view_tsmi.Text = "&View";
			// 
			// language_tsmi
			// 
			this.language_tsmi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.english_united_states_tsmi,
			this.simple_chinese_prc_tsmi});
			this.language_tsmi.Name = "language_tsmi";
			this.language_tsmi.Size = new System.Drawing.Size(133, 22);
			this.language_tsmi.Text = "&Language";
			// 
			// english_united_states_tsmi
			// 
			this.english_united_states_tsmi.Name = "english_united_states_tsmi";
			this.english_united_states_tsmi.Size = new System.Drawing.Size(206, 22);
			this.english_united_states_tsmi.Text = "English (&United States)";
			this.english_united_states_tsmi.Click += new System.EventHandler(this.english_united_states_tsmiClick);
			// 
			// simple_chinese_prc_tsmi
			// 
			this.simple_chinese_prc_tsmi.Name = "simple_chinese_prc_tsmi";
			this.simple_chinese_prc_tsmi.Size = new System.Drawing.Size(206, 22);
			this.simple_chinese_prc_tsmi.Text = "大陆简体中文 (&P)";
			this.simple_chinese_prc_tsmi.Click += new System.EventHandler(this.simple_chinese_prc_tsmiClick);
			// 
			// about_tsmi
			// 
			this.about_tsmi.Name = "about_tsmi";
			this.about_tsmi.Size = new System.Drawing.Size(55, 21);
			this.about_tsmi.Text = "&About";
			this.about_tsmi.Click += new System.EventHandler(this.about_tsmiClick);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 531);
			this.Controls.Add(this.source_gpb);
			this.Controls.Add(this.result_gpb);
			this.Controls.Add(this.main_ms);
			this.Font = new System.Drawing.Font("微软雅黑", 9.75F);
			this.MainMenuStrip = this.main_ms;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MinimumSize = new System.Drawing.Size(834, 570);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KeyFingerprintLooker";
			this.source_gpb.ResumeLayout(false);
			this.source_gpb.PerformLayout();
			this.result_gpb.ResumeLayout(false);
			this.result_gpb.PerformLayout();
			this.main_ms.ResumeLayout(false);
			this.main_ms.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.CheckBox not_wrap_content_chk;
		private System.Windows.Forms.Label about_txt;
		private System.Windows.Forms.CheckBox xamarin_first_chk;
		private System.Windows.Forms.Button browse_keytool_file_path_btn;
		private System.Windows.Forms.Button auto_fetch_keytool_file_path_btn;
		private System.Windows.Forms.Label keystore_file_path_lbl;
		private System.Windows.Forms.TextBox keytool_file_path_txt;
		private System.Windows.Forms.Label keytool_file_path_lbl;
		private System.Windows.Forms.Label password_lbl;
		private System.Windows.Forms.CheckBox clear_log_after_recalc_chk;
		private System.Windows.Forms.Label aliased_counter_lbl;
		private System.Windows.Forms.ComboBox alias_selector_cmb;
		private System.Windows.Forms.RadioButton keystore_file_type_debug_rdbtn;
		private System.Windows.Forms.RadioButton keystore_file_type_release_rdbtn;
		private System.Windows.Forms.TextBox password_txt;
		private System.Windows.Forms.CheckBox caps_chk;
		private System.Windows.Forms.TextBox MD5_txt;
		private System.Windows.Forms.Button copy_MD5_btn;
		private System.Windows.Forms.Label md5_lbl;
		private System.Windows.Forms.TextBox operation_log_txt;
		private System.Windows.Forms.Button clear_log_btn;
		private System.Windows.Forms.GroupBox source_gpb;
		private System.Windows.Forms.GroupBox result_gpb;
		private System.Windows.Forms.Button copy_SHA1_btn;
		private System.Windows.Forms.TextBox SHA1_txt;
		private System.Windows.Forms.CheckBox colon_for_split_chk;
		private System.Windows.Forms.Label sha1_lbl;
		private System.Windows.Forms.Button calc_fingerprint_btn;
		private System.Windows.Forms.Button browse_keystore_file_path_btn;
		private System.Windows.Forms.Button auto_fetch_keystore_file_path_btn;
		private System.Windows.Forms.TextBox keystore_file_path_txt;
		private System.Windows.Forms.MenuStrip main_ms;
		private System.Windows.Forms.ToolStripMenuItem file_tsmi;
		private System.Windows.Forms.ToolStripMenuItem view_tsmi;
		private System.Windows.Forms.ToolStripMenuItem about_tsmi;
		private System.Windows.Forms.ToolStripMenuItem language_tsmi;
		private System.Windows.Forms.ToolStripMenuItem english_united_states_tsmi;
		private System.Windows.Forms.ToolStripMenuItem simple_chinese_prc_tsmi;
	}
}
