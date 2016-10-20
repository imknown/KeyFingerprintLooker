/*
 * 用户： imknown
 * 日期: 2015/12/3 周四
 * 时间: 上午 11:22
 */
using System;
using System.Collections.Generic;
using System.Globalization;
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
		public const string VERSION = "0.3.1 beta";
		
		public const string KEYTOOL_EXE = "keytool.exe";
		public const string DEBUG_KEYSTORE = "debug.keystore";
		public const string DOT_ANDROID_PATH = @"\.android\";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			about_txt.Text = VERSION + ", " + OsUtil.GetProcessType() + " 模式, " + (int) OsUtil.GetOsBit() + "位 系统";
		}
		
		# region [ keytool ]
		void TextBox_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : e.Effect = DragDropEffects.None;
		}
		
		void keytool_file_path_txtDragDrop(object sender, DragEventArgs e)
		{
			keystore_file_path_txt.Text = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
		}
		
		void keytool_file_path_txtTextChanged(object sender, EventArgs e)
		{
			if(keytool_file_path_txt.Text == string.Empty)
			{
				keytool_file_path_txt.Text = "请指定 keytool.exe 路径, 支持拖拽";
			}
		}
		
		void auto_fetch_keytool_file_path_btnClick(object sender, EventArgs e)
		{
			string Path = "未找到有效的文件";
			
			// keytool_file_path_txt.Text = GetKeytoolPath() + @"bin\" + KEYTOOL_EXE;
			
			string InstallLocationOfJava = FindInstallLocationOfJava();
			if(!string.IsNullOrEmpty(InstallLocationOfJava))
			{
				string PathTemp = InstallLocationOfJava + @"bin\" + KEYTOOL_EXE;
				
				AppendLog(PathTemp);
				
				if(File.Exists(PathTemp))
				{
					Path = PathTemp;
				}
			}
			
			
			keytool_file_path_txt.Text = Path;
		}
		
		void browse_keytool_file_path_btnClick(object sender, EventArgs e)
		{
			var OpenDialog = new OpenFileDialog();
			OpenDialog.Filter = KEYTOOL_EXE + "|" + KEYTOOL_EXE;
			
			if(DialogResult.OK == OpenDialog.ShowDialog())
			{
				keytool_file_path_txt.Text = OpenDialog.FileName;
			}
		}
		
		string FindInstallLocationOfJava()
		{
			string InstallLocationWant = string.Empty;
			
			var ProcessTypeList = new List<ProcessType> { ProcessType.X86, ProcessType.X64 };
			
			// List<string> InstallLocationList = RegUtil.FindRegKeyFromInstallAppList(ProcessTypeList, "Java");
			List<string> InstallLocationList = RegUtil.FindRegKeyByJavaSoft(ProcessTypeList, "_");
			
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
		# endregion
		
		# region [ keystore ]
		void keystore_file_path_txtDragDrop(object sender, DragEventArgs e)
		{
			keystore_file_path_txt.Text = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
		}
		
		void keystore_file_path_txtTextChanged(object sender, EventArgs e)
		{
			if(keystore_file_path_txt.Text == string.Empty)
			{
				keystore_file_path_txt.Text = "请指定密钥文件或APK路径, 支持拖拽";
			}
		}
		
		void auto_fetch_keystore_file_path_btnClick(object sender, EventArgs e)
		{
			string Path = "未找到有效的文件";
			
			string UserProfileFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			
			// string MyDocumentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string PersonalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string PersonalProfileFolderPath = PersonalFolderPath.Substring(0, PersonalFolderPath.LastIndexOf(@"\", StringComparison.CurrentCulture));
			
			string UserProfileFolderlKey = UserProfileFolderPath + DOT_ANDROID_PATH + DEBUG_KEYSTORE;
			string PersonalUserFolderKey = PersonalProfileFolderPath + DOT_ANDROID_PATH + DEBUG_KEYSTORE;

			string XamarinKey = Environment.GetEnvironmentVariable("LocalAppData") + @"\Xamarin\Mono for Android\" + DEBUG_KEYSTORE;
			
			if(File.Exists(UserProfileFolderlKey))
			{
				AppendLog(UserProfileFolderlKey);
				
				Path = UserProfileFolderlKey;
			}
			
			if(File.Exists(PersonalUserFolderKey))
			{
				AppendLog(PersonalUserFolderKey);
				
				Path = PersonalUserFolderKey;
			}
			
			if( File.Exists(XamarinKey))
			{
				AppendLog(XamarinKey);
				
				if(xamarin_first_chk.Checked)
				{
					Path = XamarinKey;
				}
			}
			
			keystore_file_path_txt.Text = Path;
		}
		
		void browse_keystore_file_path_btnClick(object sender, EventArgs e)
		{
			var OpenDialog = new OpenFileDialog();
			
			var Objs = new string[] {FILE_TYPE_KEYSTORE, FILE_TYPE_JKS, FILE_TYPE_APK, FILE_TYPE_RSA};
			OpenDialog.Filter = string.Format("密钥文件, APK 包内证书, 应用|*.{0}; *.{1}; *.{2}; *.{3}|所有文件|*.*", Objs);
			
			if(DialogResult.OK == OpenDialog.ShowDialog())
			{
				keystore_file_path_txt.Text = OpenDialog.FileName;
			}
		}
		# endregion
		
		# region [ password ]
		void password_txtTextChanged(object sender, EventArgs e)
		{
			if(keystore_file_type_release_rdbtn.Checked)
			{
				MyPassword.ReleaseKeyStorePassword = password_txt.Text;
			}
		}
		
		void keystore_file_type_debug_rdbtnCheckedChanged(object sender, EventArgs e)
		{
			if(keystore_file_type_debug_rdbtn.Checked)
			{
				password_txt.ReadOnly = true;
				auto_fetch_keystore_file_path_btn.Enabled = true;
				
				password_txt.Text = Password.DEBUG_KEYSTORE_PASSWORD;
			}
		}
		
		void keystore_file_type_release_rdbtnCheckedChanged(object sender, EventArgs e)
		{
			if(keystore_file_type_release_rdbtn.Checked)
			{
				password_txt.ReadOnly = false;
				auto_fetch_keystore_file_path_btn.Enabled = false;
				
				password_txt.Text = MyPassword.ReleaseKeyStorePassword;
			}
		}
		# endregion
		
		# region [ calc ]
		public const string FILE_TYPE_KEYSTORE = "keystore";
		public const string FILE_TYPE_JKS = "jks";
		public const string FILE_TYPE_APK = "apk";
		public const string FILE_TYPE_RSA = "RSA";
		
		void calc_fingerprint_btnClick(object sender, EventArgs e)
		{
			if(clear_log_after_recalc_chk.Checked)
			{
				operation_log_txt.Text = string.Empty;
			}
			
			string KeytoolFilePath = keytool_file_path_txt.Text;
			
			if(!File.Exists(KeytoolFilePath))
			{
				AppendLog(KEYTOOL_EXE + " 文件不存在");
				
				return;
			}
			
			string KeystoreFilePath = keystore_file_path_txt.Text;
			
			if(!File.Exists(KeystoreFilePath)){
				AppendLog("密钥文件不存在");
				
				return;
			}
			
			// bool EndsWithKeystore = KeystoreFilePath.EndsWith(FILE_TYPE_KEYSTORE, StringComparison.CurrentCulture);
			// bool EndsWithJks = KeystoreFilePath.EndsWith(FILE_TYPE_JKS, StringComparison.CurrentCulture);
			bool EndsWithAPK = KeystoreFilePath.EndsWith(FILE_TYPE_APK, StringComparison.CurrentCulture);
			bool EndsWithRSA = KeystoreFilePath.EndsWith(FILE_TYPE_RSA, StringComparison.CurrentCulture);
			
			string CmdString = string.Empty;
			
			if(EndsWithAPK)
			{
				string CertRsaPath = ZipUtil.UnzipCERT_RSA(KeystoreFilePath);

				CmdString = SurroundInCmd(KeytoolFilePath) + " -printcert -file " + SurroundInCmd(CertRsaPath);
			}
			else if(EndsWithRSA)
			{
				CmdString = SurroundInCmd(KeytoolFilePath) + " -printcert -file " + SurroundInCmd(KeystoreFilePath);
			}
			else
			{
				CmdString = SurroundInCmd(KeytoolFilePath) + " -list -v -keystore " + SurroundInCmd(KeystoreFilePath) + " -storepass " + SurroundInCmd(password_txt.Text);
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
			
			string CmdResultForWindows = CmdResult.Replace("\r\n", "\n").Replace("\n", "\r\n");
			AppendLog(CmdResultForWindows);
			
			try
			{
				ParseResult(CmdResult);
			}
			catch(Exception ex)
			{
				AppendLog(ex.ToString());
			}
		}
		
		void ParseResult(string CmdResult)
		{
			MyResult = new Result();
			
			alias_selector_cmb.Items.Clear();
			MyResult.AliasInfoList = new List<AliasInfo>();
			var AliasInfo = new AliasInfo();
			
			var sr = new StringReader(CmdResult);
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
					MyResult.AliasCount =  str.Replace("您的密钥库包含 ", string.Empty).Replace(" 个条目", string.Empty );
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
					
					MyResult.AliasInfoList.Add(AliasInfo);
					
					string AliasName = AliasInfo.AliasName;
					if(string.IsNullOrEmpty(AliasInfo.AliasName))
					{
						AliasName = "未找到别名";
					}
					alias_selector_cmb.Items.Add(AliasName);
				}
			}
			
			sr.Close();
			
			bool hasNoAliasCount = string.IsNullOrEmpty(MyResult.AliasCount);
			string AliasCount = "无";
			if(!hasNoAliasCount) {
				AliasCount = MyResult.AliasCount + "个";
			}
			alias_counter_lbl.Text = AliasCount + "别名";
			
			if(hasNoAliasCount || int.Parse(MyResult.AliasCount) <= 1)
			{
				alias_selector_cmb.Enabled = false;
			}
			else
			{
				alias_selector_cmb.Enabled = true;
			}
			
			alias_selector_cmb.SelectedIndex = 0;
			
			colon_for_split_chk.Enabled = true;
			caps_chk.Enabled = true;
		}
		
		Password MyPassword = new Password();
		bool UseColonForSplit = true, UseCaps = true;
		Result MyResult = new Result();
		
		void AppendLog(string something)
		{
			string time = DateTime.Now.ToString("T");
			operation_log_txt.Text = time + ", " + something + "\r\n" + operation_log_txt.Text;
		}
		
		string SurroundInCmd(string something)
		{
			return "\"" + something + "\"";
		}
		# endregion
		
		# region [ check ]
		void UseColonForSplitCheckedChanged(object sender, EventArgs e)
		{
			int SelectedIndex = alias_selector_cmb.SelectedIndex;
			
			AliasInfo AliasInfo = MyResult.AliasInfoList[SelectedIndex];
			
			CheckUseColonForSplit();
			
			CheckUseCapsOrNot();
		}
		
		void UseCapsOrNotCheckedChanged(object sender, EventArgs e)
		{
			CheckUseCapsOrNot();
		}
		
		void CheckUseColonForSplit()
		{
			int SelectedIndex = alias_selector_cmb.SelectedIndex;
			
			AliasInfo AliasInfo = MyResult.AliasInfoList[SelectedIndex];
			
			UseColonForSplit = colon_for_split_chk.Checked;
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

		void CheckUseCapsOrNot()
		{
			UseCaps = caps_chk.Checked;
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
		# endregion
		
		# region [ result ]
		void alias_selector_cmbSelectedIndexChanged(object sender, EventArgs e)
		{
			CheckUseColonForSplit();
			CheckUseCapsOrNot();
		}
		
		void copy_MD5_btnClick(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(MD5_txt.Text);
		}
		
		void copy_SHA1_btnClick(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(SHA1_txt.Text);
		}
		# endregion
		
		# region [ control ]
		void not_wrap_content_chkCheckedChanged(object sender, EventArgs e)
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
		
		void clear_log_btnClick(object sender, EventArgs e)
		{
			operation_log_txt.Text = string.Empty;
		}
		# endregion
	}
}
