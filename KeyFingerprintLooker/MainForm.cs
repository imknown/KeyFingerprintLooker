/*
 * 用户： imknown
 * 日期: 2015/12/3 周四
 * 时间: 上午 11:22
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using KeyFingerprintLooker.Model;
using KeyFingerprintLooker.Utils;

namespace KeyFingerprintLooker
{
	public partial class MainForm : Form
	{
		# region [ static define ]
		public const string VERSION = "0.4 beta";
		
		public const string FILE_TYPE_KEYSTORE = "keystore";
		public const string FILE_TYPE_JKS = "jks";
		public const string FILE_TYPE_APK = "apk";
		public const string FILE_TYPE_RSA = "RSA";
		
		public const string NEWLINE_UNIX_LF = "\n";
		public const string NEWLINE_WINDOWS_CRLF = "\r\n";
		
		public const string KEYTOOL_EXE = "keytool.exe";
		public const string BIN_KEYTOOL_EXE_PATH = @"bin\" + KEYTOOL_EXE;
		
		public const string DEBUG_KEYSTORE = "debug." + FILE_TYPE_KEYSTORE;
		public const string DOT_ANDROID_PATH = @"\.android\";
		public const string DOT_ANDROID_DEBUG_KEYSTORE_PATH = DOT_ANDROID_PATH + DEBUG_KEYSTORE;
		
		public readonly string ENVIRONMENT_VARIABLE_LOCAL_APP_DATA = Environment.GetEnvironmentVariable("LocalAppData");
		public readonly string ENVIRONMENT_VARIABLE_JAVA_HOME = Environment.GetEnvironmentVariable("Java_Home");
		public const string XAMARIN_PROFILE_PATH = @"\Xamarin\Mono for Android\";
		public const string XAMARIN_PROFILE_DEBUG_KEYSTORE_PATH = XAMARIN_PROFILE_PATH + DEBUG_KEYSTORE;
		# endregion
		
		Password MyPassword = new Password();
		bool UseColonForSplit = true, UseCaps = true;
		Result MyResult = new Result();
		
		# region [ init ]
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			MyResult.AliasInfoList = new List<Result.AliasInfo>();
			
			R.SetBestCurrentCulture(this);
			
			InitText();
		}
		
		void InitText() {
			R.InitControl(this, Controls);
			
			InitRuntimeStrings();
			
			initRuntimeResults();
		}
		
		# region [ runtime define ]
		string STRING_FORM_TITLE;
		
		string STRING_ABOUT_APP;
		string STRING_KEYTOOL_FILE_PATH_HINT;
		string STRING_KEYSTORE_FILE_PATH_HINT;
		string STRING_FILE_TYPES;
		
		string STRING_CHECK_FILE_NOT_EXIST;
		string STRING_CHECK_NO_VALID_FILE_FOUND;
		string STRING_KEYSOTRE_OR_APK;
		
		string STRING_CHECK_ERROR_WRONG_PASSWORD;
		string STRING_CHECK_ERROR_BAD_FILE_FORMAT;
		string STRING_CHECK_ERROR_EMPTY_FILE;
		string STRING_CHECK_ERROR_WRONG_PASSWORD_DESC;
		string STRING_CHECK_ERROR_BAD_FILE_FORMAT_DESC;
		string STRING_CHECK_ERROR_EMPTY_FILE_DESC;
		string STRING_CHECK_ERROR_KEYTOOL_PATH_INVALID_OR_HAS_SPACE_DESC;
		
		string STRING_RESULT_YOUR_KEYSTORE_CONTAINS;
		string STRING_RESULT_ENTRY;
		string STRING_RESULT_ENTRIES;
		string STRING_RESULT_ALIAS_NAME;
		string STRING_RESULT_CREATION_DATE;
		string STRING_RESULT_MD5;
		string STRING_RESULT_SHA1;
		string STRING_RESULT_CANNOT_GET_ALIAS_NAME;
		
		string STRING_RESULT_COUNT_ALIASES;
		string STRING_RESULT_COUNT_NONE;
		string STRING_RESULT_COUNT_QUANTIFIER;
		# endregion
		
		void InitRuntimeStrings()
		{
			STRING_FORM_TITLE = R.String(this, Name + R.PROPERTY_TEXT);
			
			STRING_ABOUT_APP = R.String(this, about_txt);
			STRING_KEYTOOL_FILE_PATH_HINT = R.String(this, keytool_file_path_txt, R.PROPERTY_HINT);
			STRING_KEYSTORE_FILE_PATH_HINT = R.String(this, keystore_file_path_txt, R.PROPERTY_HINT);
			STRING_FILE_TYPES = R.String(this, "zzcommon_file_types");
			
			STRING_CHECK_FILE_NOT_EXIST = R.String(this, "zzcommon_check_file_not_exist");
			STRING_CHECK_NO_VALID_FILE_FOUND = R.String(this, "zzcommon_check_no_valid_file_found");
			STRING_KEYSOTRE_OR_APK = R.String(this, "zzcommon_keystore_or_apk");
			
			# region [use GetBestCurrentCulture()]
			STRING_CHECK_ERROR_WRONG_PASSWORD = R.String(this, "zzcommon_check_error_wrong_password", R.GetBestCurrentCulture());
			STRING_CHECK_ERROR_BAD_FILE_FORMAT = R.String(this, "zzcommon_check_error_bad_file_format", R.GetBestCurrentCulture());
			STRING_CHECK_ERROR_EMPTY_FILE = R.String(this, "zzcommon_check_error_empty_file", R.GetBestCurrentCulture());
			# endregion
			
			STRING_CHECK_ERROR_WRONG_PASSWORD_DESC = R.String(this, "zzcommon_check_error_wrong_password_desc");
			STRING_CHECK_ERROR_BAD_FILE_FORMAT_DESC = R.String(this, "zzcommon_check_error_bad_file_format_desc");
			STRING_CHECK_ERROR_EMPTY_FILE_DESC = R.String(this, "zzcommon_check_error_empty_file_desc");
			STRING_CHECK_ERROR_KEYTOOL_PATH_INVALID_OR_HAS_SPACE_DESC = R.String(this, "zzcommon_check_error_keytool_path_invalid_or_has_space_desc");
			
			# region [use GetBestCurrentCulture()]
			STRING_RESULT_YOUR_KEYSTORE_CONTAINS = R.String(this, "zzcommon_result_your_keystore_contains", R.GetBestCurrentCulture());
			STRING_RESULT_ENTRY = R.String(this, "zzcommon_result_entry", R.GetBestCurrentCulture());
			STRING_RESULT_ENTRIES = R.String(this, "zzcommon_result_entries", R.GetBestCurrentCulture());
			STRING_RESULT_ALIAS_NAME = R.String(this, "zzcommon_result_alias_name", R.GetBestCurrentCulture());
			STRING_RESULT_CREATION_DATE = R.String(this, "zzcommon_result_creation_date", R.GetBestCurrentCulture());
			STRING_RESULT_MD5 = R.String(this, "zzcommon_result_md5", R.GetBestCurrentCulture());
			STRING_RESULT_SHA1 = R.String(this, "zzcommon_result_sha1", R.GetBestCurrentCulture());
			# endregion
			STRING_RESULT_CANNOT_GET_ALIAS_NAME = R.String(this, "zzcommon_result_cannot_get_alias_name");
			
			STRING_RESULT_COUNT_ALIASES = R.String(this, "zzcommon_result_count_aliases");
			STRING_RESULT_COUNT_NONE = R.String(this, "zzcommon_result_count_none");
			STRING_RESULT_COUNT_QUANTIFIER = R.String(this, "zzcommon_result_count_quantifier");
		}
		# endregion
		
		void initRuntimeResults()
		{
			Text = STRING_FORM_TITLE;
			
			string processBit = OsUtils.GetProcessType().ToString();
			string osBit = ((int) OsUtils.GetOsBit()).ToString();
			about_txt.Text = string.Format(STRING_ABOUT_APP, new object[]{ VERSION, processBit,  osBit});
			
			Win32Utils.SetCueText(keytool_file_path_txt, STRING_KEYTOOL_FILE_PATH_HINT);
			Win32Utils.SetCueText(keystore_file_path_txt, STRING_KEYSTORE_FILE_PATH_HINT);
			
			calcAliasNameCount();
			
			if(MyResult.AliasInfoList.Count == 1 && string.IsNullOrEmpty(MyResult.AliasInfoList[0].AliasName)) {
				alias_selector_cmb.Items.Clear();
				alias_selector_cmb.Items.Add(STRING_RESULT_CANNOT_GET_ALIAS_NAME);
				alias_selector_cmb.SelectedIndex = 0;
			}
		}
		
		# region [ keytool ]
		void TextBox_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : e.Effect = DragDropEffects.None;
		}
		
		void keytool_file_path_txtDragDrop(object sender, DragEventArgs e)
		{
			keytool_file_path_txt.Text = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
		}
		
		void auto_fetch_keytool_file_path_btnClick(object sender, EventArgs e)
		{
			string path = STRING_CHECK_NO_VALID_FILE_FOUND;
			
			// keytool_file_path_txt.Text = GetKeytoolPath() + BIN_KEYTOOL_EXE;
			
			string installLocationOfJava = FindInstallLocationOfJava();
			if(!string.IsNullOrEmpty(installLocationOfJava))
			{
				string pathTemp = installLocationOfJava + BIN_KEYTOOL_EXE_PATH;
				
				AppendLog(pathTemp);
				
				if(File.Exists(pathTemp))
				{
					path = pathTemp;
				}
			}
			
			keytool_file_path_txt.Text = path;
		}
		
		void browse_keytool_file_path_btnClick(object sender, EventArgs e)
		{
			var openDialog = new OpenFileDialog();
			openDialog.Filter = KEYTOOL_EXE + "|" + KEYTOOL_EXE;
			
			if(DialogResult.OK == openDialog.ShowDialog())
			{
				keytool_file_path_txt.Text = openDialog.FileName;
			}
		}
		
		string FindInstallLocationOfJava()
		{
			string installLocationWant = string.Empty;
			
			var processTypeList = new List<ProcessType> { ProcessType.X86, ProcessType.X64 };
			
			// List<string> InstallLocationList = RegUtil.FindRegKeyFromInstallAppList(ProcessTypeList, "Java");
			List<string> installLocationList = RegUtils.FindRegKeyByJavaSoft(processTypeList, "_");
			
			foreach (string installLocation in installLocationList)
			{
				AppendLog(installLocation);
			}
			
			foreach (string installLocationTemp in installLocationList)
			{
				installLocationWant = installLocationTemp;
				
				break;
			}
			
			return installLocationWant;
		}
		
		[method: Obsolete("Use FindInstallLocationOfJava() instead")]
		string GetKeytoolPath()
		{
			string keytoolPath = string.Empty;
			
			if(Directory.Exists(ENVIRONMENT_VARIABLE_JAVA_HOME))
			{
				keytoolPath = ENVIRONMENT_VARIABLE_JAVA_HOME + BIN_KEYTOOL_EXE_PATH;
				
				// check available
				if(!File.Exists(keytoolPath)){
					keytoolPath = string.Empty;
				}
			}
			
			return keytoolPath;
		}
		# endregion
		
		# region [ keystore ]
		void keystore_file_path_txtDragDrop(object sender, DragEventArgs e)
		{
			keystore_file_path_txt.Text = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
		}
		
		void auto_fetch_keystore_file_path_btnClick(object sender, EventArgs e)
		{
			string path = STRING_CHECK_NO_VALID_FILE_FOUND;
			
			string userProfileFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			
			// string MyDocumentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string personalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string personalProfileFolderPath = personalFolderPath.Substring(0, personalFolderPath.LastIndexOf(@"\", StringComparison.CurrentCulture));
			
			string userProfileFolderlKey = userProfileFolderPath + DOT_ANDROID_DEBUG_KEYSTORE_PATH;
			string personalUserFolderKey = personalProfileFolderPath + DOT_ANDROID_DEBUG_KEYSTORE_PATH;

			string xamarinKey = ENVIRONMENT_VARIABLE_LOCAL_APP_DATA + XAMARIN_PROFILE_DEBUG_KEYSTORE_PATH;
			
			if(File.Exists(userProfileFolderlKey))
			{
				AppendLog(userProfileFolderlKey);
				
				path = userProfileFolderlKey;
			}
			
			if(File.Exists(personalUserFolderKey))
			{
				AppendLog(personalUserFolderKey);
				
				path = personalUserFolderKey;
			}
			
			if(File.Exists(xamarinKey))
			{
				AppendLog(xamarinKey);
				
				if(xamarin_first_chk.Checked)
				{
					path = xamarinKey;
				}
			}
			
			keystore_file_path_txt.Text = path;
		}
		
		void browse_keystore_file_path_btnClick(object sender, EventArgs e)
		{
			var openDialog = new OpenFileDialog();
			
			var args = new object[] {FILE_TYPE_KEYSTORE, FILE_TYPE_JKS, FILE_TYPE_APK, FILE_TYPE_RSA};
			openDialog.Filter = string.Format(STRING_FILE_TYPES, args);
			
			if(DialogResult.OK == openDialog.ShowDialog())
			{
				keystore_file_path_txt.Text = openDialog.FileName;
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
		void calc_fingerprint_btnClick(object sender, EventArgs e)
		{
			if(clear_log_after_recalc_chk.Checked)
			{
				operation_log_txt.Text = string.Empty;
			}
			
			string keytoolFilePath = keytool_file_path_txt.Text;
			
			if(!File.Exists(keytoolFilePath))
			{
				AppendLog(string.Format(STRING_CHECK_FILE_NOT_EXIST, KEYTOOL_EXE));
				
				return;
			}
			
			string keystoreFilePath = keystore_file_path_txt.Text;
			
			if(!File.Exists(keystoreFilePath)){
				AppendLog(string.Format(STRING_CHECK_FILE_NOT_EXIST, STRING_KEYSOTRE_OR_APK));
				
				return;
			}
			
			// bool endsWithKeystore = KeystoreFilePath.EndsWith(FILE_TYPE_KEYSTORE, StringComparison.CurrentCulture);
			// bool endsWithJks = KeystoreFilePath.EndsWith(FILE_TYPE_JKS, StringComparison.CurrentCulture);
			bool endsWithAPK = keystoreFilePath.EndsWith(FILE_TYPE_APK, StringComparison.CurrentCulture);
			bool endsWithRSA = keystoreFilePath.EndsWith(FILE_TYPE_RSA, StringComparison.CurrentCulture);
			
			string cmdString = string.Empty;
			
			if(endsWithAPK)
			{
				string certRsaPath = ZipUtils.UnzipCERT_RSA(keystoreFilePath);

				cmdString = SurroundInCmd(keytoolFilePath) + " -printcert -file " + SurroundInCmd(certRsaPath);
			}
			else if(endsWithRSA)
			{
				cmdString = SurroundInCmd(keytoolFilePath) + " -printcert -file " + SurroundInCmd(keystoreFilePath);
			}
			else
			{
				cmdString = SurroundInCmd(keytoolFilePath) + " -list -v -keystore " + SurroundInCmd(keystoreFilePath) + " -storepass " + SurroundInCmd(password_txt.Text);
			}
			
			string cmdResult = CommandUtils.RunCmd(cmdString);
			
			if(cmdResult.Contains(STRING_CHECK_ERROR_WRONG_PASSWORD))
			{
				AppendLog(STRING_CHECK_ERROR_WRONG_PASSWORD_DESC + NEWLINE_WINDOWS_CRLF + cmdResult);
				return;
			}
			else if(cmdResult.Contains(STRING_CHECK_ERROR_BAD_FILE_FORMAT))
			{
				AppendLog(STRING_CHECK_ERROR_BAD_FILE_FORMAT_DESC + NEWLINE_WINDOWS_CRLF + cmdResult);
				return;
			}
			else if(cmdResult.Contains(STRING_CHECK_ERROR_EMPTY_FILE))
			{
				AppendLog(STRING_CHECK_ERROR_EMPTY_FILE_DESC + NEWLINE_WINDOWS_CRLF + cmdResult);
				return;
			}
			else if(cmdResult == string.Empty
			        || !cmdResult.Contains(STRING_RESULT_SHA1)
			        || !cmdResult.Contains(STRING_RESULT_SHA1))
			{
				AppendLog(STRING_CHECK_ERROR_KEYTOOL_PATH_INVALID_OR_HAS_SPACE_DESC);
				return;
			}
			
			string cmdResultForWindows = cmdResult.Replace(NEWLINE_WINDOWS_CRLF, NEWLINE_UNIX_LF).Replace(NEWLINE_UNIX_LF, NEWLINE_WINDOWS_CRLF);
			AppendLog(cmdResultForWindows);
			
			try
			{
				ParseResult(cmdResult);
			}
			catch(Exception ex)
			{
				AppendLog(ex.ToString());
			}
		}
		
		void ParseResult(string cmdResult)
		{
			MyResult = new Result();
			
			alias_selector_cmb.Items.Clear();
			MyResult.AliasInfoList = new List<Result.AliasInfo>();
			var aliasInfo = new Result.AliasInfo();
			
			var sr = new StringReader(cmdResult);
			string str = string.Empty;
			
			while (sr.Peek() != -1)
			{
				str = sr.ReadLine().Trim();
				
				if(str == string.Empty)
				{
					continue;
				}
				
				if (str.Contains(STRING_RESULT_YOUR_KEYSTORE_CONTAINS))
				{
					// Now no need, because of the anonymous alias from apk/RSA
					
//					str = str.Replace(STRING_RESULT_YOUR_KEYSTORE_CONTAINS, string.Empty)
//						.Replace(STRING_RESULT_ENTRY, string.Empty)
//						.Replace(STRING_RESULT_ENTRIES, string.Empty)
//						.Trim();
//
//					MyResult.AliasCount = int.Parse(str);
				}
				else if(str.Contains(STRING_RESULT_ALIAS_NAME))
				{
					str = str.Replace(STRING_RESULT_ALIAS_NAME, string.Empty).Trim();
					aliasInfo = new Result.AliasInfo();
					aliasInfo.AliasName = str;
				}
				else if(str.Contains(STRING_RESULT_CREATION_DATE))
				{
					str = str.Replace(STRING_RESULT_CREATION_DATE, string.Empty).Trim();
					aliasInfo.CreateDate = str;
				}
				else if(str.Contains(STRING_RESULT_MD5))
				{
					aliasInfo.MD5_CAPS_UseColonForSplit = str.Replace(STRING_RESULT_MD5, string.Empty).Trim();
					aliasInfo.MD5_CAPS = aliasInfo.MD5_CAPS_UseColonForSplit.Replace(":", string.Empty);
					// aliasInfo.MD5_UseColonForSplit = aliasInfo.MD5_CAPS_UseColonForSplit.ToLower();
					// aliasInfo.MD5 = aliasInfo.MD5_CAPS.ToLower();
				}
				else if(str.Contains(STRING_RESULT_SHA1))
				{
					aliasInfo.SHA1_CAPS_UseColonForSplit = str.Replace(STRING_RESULT_SHA1, string.Empty).Trim();
					aliasInfo.SHA1_CAPS = aliasInfo.SHA1_CAPS_UseColonForSplit.Replace(":", string.Empty);
					// aliasInfo.SHA1_UseColonForSplit = aliasInfo.SHA1_CAPS_UseColonForSplit.ToLower();
					// aliasInfo.SHA1 = aliasInfo.SHA1_CAPS.ToLower();
					
					// end this
					MyResult.AliasInfoList.Add(aliasInfo);
					
					string aliasName = aliasInfo.AliasName;
					if(string.IsNullOrEmpty(aliasName))
					{
						aliasName = STRING_RESULT_CANNOT_GET_ALIAS_NAME;
					}
					alias_selector_cmb.Items.Add(aliasName);
				}
			}
			
			sr.Close();
			
			calcAliasNameCount();
			
			alias_selector_cmb.Enabled = (MyResult.AliasInfoList.Count >= 2);
			
			if(MyResult.AliasInfoList.Count >= 1)
			{
				alias_selector_cmb.SelectedIndex = 0;
				colon_for_split_chk.Enabled = true;
				caps_chk.Enabled = true;
			}
		}
		
		void calcAliasNameCount()
		{
			aliased_counter_lbl.Text = MyResult.AliasInfoList.Count + " " + STRING_RESULT_COUNT_QUANTIFIER + STRING_RESULT_COUNT_ALIASES;
		}
		
		void AppendLog(string something)
		{
			string time = DateTime.Now.ToString("T");
			operation_log_txt.Text = time + ", " + something + NEWLINE_WINDOWS_CRLF + operation_log_txt.Text;
		}
		
		string SurroundInCmd(string something)
		{
			return "\"" + something + "\"";
		}
		# endregion
		
		# region [ check ]
		void UseColonForSplitCheckedChanged(object sender, EventArgs e)
		{
			CheckUseColonForSplit();
			CheckUseCapsOrNot();
		}
		
		void UseCapsOrNotCheckedChanged(object sender, EventArgs e)
		{
			CheckUseCapsOrNot();
		}
		
		void CheckUseColonForSplit()
		{
			int selectedIndex = alias_selector_cmb.SelectedIndex;
			
			var aliasInfo = MyResult.AliasInfoList[selectedIndex];
			
			UseColonForSplit = colon_for_split_chk.Checked;
			if(UseColonForSplit)
			{
				MD5_txt.Text = aliasInfo.MD5_CAPS_UseColonForSplit;
				SHA1_txt.Text = aliasInfo.SHA1_CAPS_UseColonForSplit;
			}
			else
			{
				MD5_txt.Text = aliasInfo.MD5_CAPS;
				SHA1_txt.Text = aliasInfo.SHA1_CAPS;
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
		
		# region [i18n]
		void english_united_states_tsmiClick(object sender, EventArgs e)
		{
			TryToChangeLanguage(R.LANGUAGE_EN_US);
		}
		
		void simple_chinese_prc_tsmiClick(object sender, EventArgs e)
		{
			TryToChangeLanguage(R.LANGUAGE_ZH_CN);
		}
		
		void TryToChangeLanguage(string name)
		{
			if(R.GetCurrentCultureName() != name)
			{
				R.SetCurrentCulture(name);
				InitText();
			}
		}
		
		void about_tsmiClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/imknown/KeyFingerprintLooker");
		}
		# endregion
	}
}
