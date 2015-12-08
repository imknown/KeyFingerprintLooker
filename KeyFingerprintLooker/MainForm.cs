/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2015/12/3 周四
 * 时间: 上午 11:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using KeyFingerprintLooker.Model;
using KeyFingerprintLooker.Utils;

namespace KeyFingerprintLooker
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			// 
			
			ProcessType Type = RegUtil.GetProcessType();
			about_txt.Text += ", " + Type.ToString() + " 模式";
		}
		
		private string FindInstallLocationOfJava()
		{
			string InstallLocationWant = string.Empty;
			
			List<ProcessType> ProcessTypeList = new List<ProcessType> { ProcessType.X86 };
			
			ProcessType Type = RegUtil.GetProcessType();
			if(Type == ProcessType.X64)
			{
				ProcessTypeList.Add(ProcessType.X64);
				
				AppendLog(ProcessType.X64.ToString() + "模式");
			}
			else
			{
				AppendLog(ProcessType.X86.ToString() + "模式");
			}
			
			List<String> InstallLocationList = RegUtil.FindRegKey(ProcessTypeList, "Java");
			
			foreach (string InstallLocation in InstallLocationList)
			{
				AppendLog(InstallLocation);
			}
			
			foreach (string InstallLocationTemp in InstallLocationList)
			{
				InstallLocationWant = InstallLocationTemp;
				
				break;
			}
			
			return InstallLocationWant;
		}
		
		private void TextBox_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		
		private void keytool_file_path_txtDragDrop(object sender, DragEventArgs e)
		{
			keystore_file_path_txt.Text = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			String Path = "未找到有效的文件";
			
			// keytool_file_path_txt.Text = GetKeytoolPath();
			
			string InstallLocationOfJava = FindInstallLocationOfJava();
			if(!string.IsNullOrEmpty(InstallLocationOfJava))
			{
				Path = InstallLocationOfJava + @"bin\" + KEYTOOL_EXE;
			}
			
			keytool_file_path_txt.Text = Path;
		}
		
		public const string KEYTOOL_EXE = "keytool.exe";
		
		void Button8Click(object sender, EventArgs e)
		{
			OpenFileDialog OpenDialog = new OpenFileDialog();
			OpenDialog.Filter = KEYTOOL_EXE + "|" + KEYTOOL_EXE;
			
			if(DialogResult.OK == OpenDialog.ShowDialog())
			{
				keytool_file_path_txt.Text = OpenDialog.FileName;
			}
		}
		
		# region [ 秘钥文件 ]
		
		void Keystore_file_path_txtTextChanged(object sender, EventArgs e)
		{
			if(keystore_file_path_txt.Text == string.Empty)
			{
				keystore_file_path_txt.Text = "请指定 秘钥文件 路径, 支持拖拽";
			}
		}
		
		private void Keystore_file_path_txtDragDrop(object sender, DragEventArgs e)
		{
			keystore_file_path_txt.Text = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			String Path = "未找到有效的文件";
			
			string MyDocumentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string DotAndroidFolderPath = MyDocumentFolderPath.Substring(0, MyDocumentFolderPath.LastIndexOf(@"\"));
			string GoogleOfficialKey = DotAndroidFolderPath + @"\.android\" + "debug.keystore";

			string XamarinUnofficialKey = Environment.GetEnvironmentVariable("LocalAppData") + @"\Xamarin\Mono for Android\debug.keystore";
			
			if(File.Exists(XamarinUnofficialKey))
			{
				AppendLog(XamarinUnofficialKey);
				
				Path = XamarinUnofficialKey;
			}
			
			if((!xamarin_first_chk.Checked || !File.Exists(XamarinUnofficialKey)) && File.Exists(GoogleOfficialKey))
			{
				AppendLog(GoogleOfficialKey);
				
				Path = GoogleOfficialKey;
			}
			
			keystore_file_path_txt.Text = Path;
		}

		void Button6Click(object sender, EventArgs e)
		{
			operation_log_txt.Text = string.Empty;
		}
		
		public const string FILE_TYPE_KEYSTORE = "keystore";
		public const string FILE_TYPE_JKS = "jks";
		public const string FILE_TYPE_APK = "APK";
		public const string FILE_TYPE_RSA = "RSA";

		void Button2Click(object sender, EventArgs e)
		{
			OpenFileDialog OpenDialog = new OpenFileDialog();
			
			string[] Objs = new String[] {FILE_TYPE_KEYSTORE, FILE_TYPE_JKS, FILE_TYPE_APK, FILE_TYPE_RSA};
			OpenDialog.Filter = string.Format("密钥文件|*.{0};*.{1}|应用|*.{2}|APK 包内证书|*.{3}|所有文件|*.*", Objs);
			
			if(DialogResult.OK == OpenDialog.ShowDialog())
			{
				keystore_file_path_txt.Text = OpenDialog.FileName;
			}
		}
		
		# endregion
		
		
		
		void Button3Click(object sender, EventArgs e)
		{
			if(checkBox4.Checked)
			{
				operation_log_txt.Text = string.Empty;
			}
			
			string KeytoolFilePath = keytool_file_path_txt.Text;
			
			if(!File.Exists(KeytoolFilePath))
			{
				AppendLog("keytool.exe 文件不存在");
				
				return;
			}
			
			string KeystoreFilePath = keystore_file_path_txt.Text;
			
			if(!File.Exists(KeystoreFilePath)){
				AppendLog("密钥文件不存在");
				
				return;
			}
			
			bool EndsWithKeystore = KeystoreFilePath.EndsWith(FILE_TYPE_KEYSTORE, true, System.Globalization.CultureInfo.CurrentCulture);
			bool EndsWithJks = KeystoreFilePath.EndsWith(FILE_TYPE_JKS, true, System.Globalization.CultureInfo.CurrentCulture);
			bool EndsWithAPK = KeystoreFilePath.EndsWith(FILE_TYPE_APK, true, System.Globalization.CultureInfo.CurrentCulture);
			bool EndsWithRSA = KeystoreFilePath.EndsWith(FILE_TYPE_RSA, true, System.Globalization.CultureInfo.CurrentCulture);
			
			string CmdString = string.Empty;
			
			if(EndsWithAPK)
			{
				string CertRsaPath = ZipUtil.UnzipCERT_RSA(KeystoreFilePath);

				CmdString = surroundInCmd(KeytoolFilePath) + " -printcert -file " + surroundInCmd(CertRsaPath);
			}
			else if(EndsWithRSA)
			{
				CmdString = surroundInCmd(KeytoolFilePath) + " -printcert -file " + surroundInCmd(KeystoreFilePath);
			}
			else
			{
				CmdString = surroundInCmd(KeytoolFilePath) + " -list -v -keystore " + surroundInCmd(KeystoreFilePath) + " -storepass " + surroundInCmd(password_txt.Text);
			}
			
			string CmdResult = CommandUtil.RunCmd(CmdString);
			
			if(CmdResult.Contains(Password.PASSWORD_ERROR))
			{
				AppendLog("密码错误");
				return;
			}
			else if(CmdResult.Contains(Password.BAD_FORMAT_FILE_ERROR))
			{
				AppendLog("密钥文件格式有误");
				return;
			}
			else if(CmdResult.Contains(Password.BAD_EMPTY_FILE_ERROR))
			{
				AppendLog("密钥文件内容为空");
				return;
			}
			else if(CmdResult == string.Empty)
			{
				AppendLog("keytool.exe 文件路径有误, 或者存在空格");
				return;
			}
			
			String CmdResultForWindows = CmdResult.Replace("\r\n", "\n").Replace("\n", "\r\n");
			AppendLog(CmdResultForWindows);
			
			try
			{
				parseResult(CmdResult);
			}
			catch(Exception ex)
			{
				AppendLog(ex.ToString());
			}
		}
		
		[method: Obsolete("Use FindInstallLocationOfJava() instead")]
		string GetKeytoolPath()
		{
			string KeytoolPath = "";
			string JavaHome = Environment.GetEnvironmentVariable("Java_Home");
			
			if(Directory.Exists(JavaHome))
			{
				KeytoolPath = JavaHome + @"\bin\keytool.exe";
				
				// 判断环境变量是否有效
				if(!File.Exists(KeytoolPath)){
					KeytoolPath = string.Empty;
				}
			}
			
			return KeytoolPath;
		}
		
		void parseResult(string CmdResult)
		{
			Result = new Result();
			
			alias_selector_cmb.Items.Clear();
			Result.AliasInfoList = new List<AliasInfo>();
			AliasInfo AliasInfo = new AliasInfo();
			
			StringReader sr = new StringReader(CmdResult);
			string str = string.Empty;
			
			while (sr.Peek() != -1)
			{
				str = sr.ReadLine().Trim();
				
				if(str == string.Empty)
				{
					continue;
				}
				
				if (str.Contains("您的密钥库包含"))
				{
					Result.AliasCount =  str.Replace("您的密钥库包含 ", string.Empty).Replace(" 个条目", string.Empty );
				}
				else if(str.Contains("别名: "))
				{
					str = str.Replace("别名: ", string.Empty);
					AliasInfo = new AliasInfo();
					AliasInfo.AliasName = str;
				}
				else if(str.Contains("创建日期:"))
				{
					str = str.Replace("创建日期: ", string.Empty);
					AliasInfo.CreateDate = str;
				}
				else if(str.Contains("MD5:"))
				{
					AliasInfo.MD5_CAPS_UseColonForSplit = str.Replace("MD5: ", string.Empty);
					AliasInfo.MD5_CAPS = AliasInfo.MD5_CAPS_UseColonForSplit.Replace(":", string.Empty);
				}
				else if(str.Contains("SHA1:"))
				{
					AliasInfo.SHA1_CAPS_UseColonForSplit = str.Replace("SHA1: ", string.Empty);
					AliasInfo.SHA1_CAPS = AliasInfo.SHA1_CAPS_UseColonForSplit.Replace(":", string.Empty);
					
					Result.AliasInfoList.Add(AliasInfo);
					alias_selector_cmb.Items.Add(AliasInfo.AliasName);
				}
			}
			
			sr.Close();
			label1.Text = Result.AliasCount + " 个别名";
			
			if(int.Parse(Result.AliasCount) <= 1)
			{
				alias_selector_cmb.Enabled = false;
			}
			else
			{
				alias_selector_cmb.Enabled = true;
			}
			
			alias_selector_cmb.SelectedIndex = 0;
		}
		
		Password password = new Password();
		bool UseColonForSplit = true, UseCaps = true;
		Result Result = new Result();
		
		void AppendLog(string something)
		{
			operation_log_txt.Text = "\r\n" + DateTime.Now.TimeOfDay.ToString() + "\r\n" + something + "\r\n" + operation_log_txt.Text  ;
		}
		
		string surroundInCmd(string something)
		{
			return "\"" + something + "\"";
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			int SelectedIndex = alias_selector_cmb.SelectedIndex;
			
			AliasInfo AliasInfo = Result.AliasInfoList[SelectedIndex];
			
			chechUseColonForSplit();
			
			chechUseCapsOrNot();
		}
		
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			chechUseCapsOrNot();
		}
		
		void chechUseColonForSplit()
		{
			int SelectedIndex = alias_selector_cmb.SelectedIndex;
			
			AliasInfo AliasInfo = Result.AliasInfoList[SelectedIndex];
			
			UseColonForSplit = checkBox1.Checked;
			if(UseColonForSplit)
			{
				MD5_txt.Text = AliasInfo.MD5_CAPS_UseColonForSplit;
				SHA1_txt.Text = AliasInfo.SHA1_CAPS_UseColonForSplit;
			}
			else
			{
				MD5_txt.Text = AliasInfo.MD5_CAPS;
				SHA1_txt.Text = AliasInfo.SHA1_CAPS;
			}
		}

		void chechUseCapsOrNot()
		{
			UseCaps = checkBox2.Checked;
			if(UseCaps)
			{
				MD5_txt.Text = MD5_txt.Text.ToUpper();
				SHA1_txt.Text = SHA1_txt.Text.ToUpper();
			}
			else
			{
				MD5_txt.Text = MD5_txt.Text.ToLower();
				SHA1_txt.Text = SHA1_txt.Text.ToLower();
			}
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(MD5_txt.Text);
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(SHA1_txt.Text);
		}
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			if(keystore_file_type_debug_rdbtn.Checked)
			{
				password_txt.ReadOnly = true;
				auto_fetch_keystore_file_path_btn.Enabled = true;
				
				password_txt.Text = Password.DEBUG_KEYSTORE_PASSWORD;
			}
		}
		
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			if(keystore_file_type_release_rdbtn.Checked)
			{
				password_txt.ReadOnly = false;
				auto_fetch_keystore_file_path_btn.Enabled = false;
				
				password_txt.Text = password.ReleaseKeyStorePassword;
			}
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			if(keystore_file_type_release_rdbtn.Checked)
			{
				password.ReleaseKeyStorePassword = password_txt.Text;
			}
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			chechUseColonForSplit();
			chechUseCapsOrNot();
		}
		
		void Not_wrap_content_chkCheckedChanged(object sender, EventArgs e)
		{
			if(not_wrap_content_chk.Checked)
			{
				operation_log_txt.WordWrap = true;
				operation_log_txt.ScrollBars = ScrollBars.Vertical;
			}
			else
			{
				operation_log_txt.WordWrap = false;
				operation_log_txt.ScrollBars = ScrollBars.Both;
			}
		}
	}
}
