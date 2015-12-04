/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2015/12/3 周四
 * 时间: 上午 11:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using KeyFingerprintLooker.Utils;
using KeyFingerprintLooker.Model;

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
		}
		
		private void Form1_DragEnter(object sender, DragEventArgs e)
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
		
		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			keystore_file_path_txt.Text = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string MyDocumentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			
			string DotAndroidFolderPath = MyDocumentFolderPath.Substring(0, MyDocumentFolderPath.LastIndexOf(@"\"));
			
			keystore_file_path_txt.Text = DotAndroidFolderPath + @"\.android\" + "debug.keystore";
		}

		void Button6Click(object sender, EventArgs e)
		{
			textBox3.Text = string.Empty;
		}

		void Button2Click(object sender, EventArgs e)
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Filter = "秘钥文件(*.keystore;*.jks)|*.keystore;*.jks|所有文件 (*.*)|*.*";
			
			if(DialogResult.OK == openDialog.ShowDialog())
			{
				keystore_file_path_txt.Text = openDialog.FileName;
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			string keystoreFilePath = keystore_file_path_txt.Text;
			
			if(!File.Exists(keystoreFilePath)){
				appendLog("秘钥文件不存在");
				
				return;
			}
			
			bool JavaHomeExist = false;
			string JavaHome = Environment.GetEnvironmentVariable("Java_Home");
			string KeytoolPath = "";
			
			if(Directory.Exists(JavaHome))
			{
				KeytoolPath = JavaHome + @"\bin\keytool.exe";
				
				// 判断环境变量是否有效
				if(File.Exists(KeytoolPath)){
					JavaHomeExist = true;
				}
			}
			
			if(!JavaHomeExist)
			{
				appendLog("环境变量 Java_Home 无效, 请重新配置");
				
				return;
			}
			
			string cmdString = /* surroundInCmd( */ KeytoolPath /* ) */ + " -list -v -keystore " + surroundInCmd(keystore_file_path_txt.Text) + " -storepass " + surroundInCmd(textBox1.Text);
			
			string cmdResult = Command.RunCmd(cmdString);
			
			if(cmdResult.Contains(Password.PASSWORD_ERROR))
			{
				appendLog("密码错误");
				return;
			}
			else if(cmdResult == string.Empty)
			{
				appendLog("环境变量 Java_Home 有误, 可能存在空格");
				return;
			}
			
			appendLog(cmdResult);
			
			try{
				parseResult(cmdResult);
			}
			catch(Exception ex)
			{
				appendLog(ex.StackTrace);
			}
		}
		
		void parseResult(string cmdResult)
		{
			string[] results = Regex.Split(cmdResult,"\r\n",RegexOptions.IgnoreCase);

				string debugInfo =  results[11];
				
				string[] debugInfos = Regex.Split(debugInfo,"\n",RegexOptions.IgnoreCase);
				
				result = new Result();
				
				result.MD5_CAPS_UseColonForSplit = debugInfos[5].Trim();
				result.MD5_CAPS_UseColonForSplit = result.MD5_CAPS_UseColonForSplit.Replace("MD5: ", string.Empty);
				result.MD5_CAPS = result.MD5_CAPS_UseColonForSplit.Replace(":", string.Empty);
				MD5_txt.Text = result.MD5_CAPS_UseColonForSplit;
				
				result.SHA1_CAPS_UseColonForSplit = debugInfos[6].Trim();
				result.SHA1_CAPS_UseColonForSplit = result.SHA1_CAPS_UseColonForSplit.Replace("SHA1: ", string.Empty);
				result.SHA1_CAPS = result.SHA1_CAPS_UseColonForSplit.Replace(":", string.Empty);
				SHA1_txt.Text = result.SHA1_CAPS_UseColonForSplit;
		}
		
		bool UseColonForSplit = true, UseCaps = true;
		
		Password password = new Password();
		Result result = new Result();
		
		void appendLog(string something)
		{
			textBox3.Text = "\r\n" + DateTime.Now.TimeOfDay.ToString() + "\r\n" + something + "\r\n" + textBox3.Text  ;
		}
		
		string surroundInCmd(string something)
		{
			return "\"" +something + "\"";
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			UseColonForSplit = checkBox1.Checked;
			if(UseColonForSplit)
			{
				MD5_txt.Text = result.MD5_CAPS_UseColonForSplit;
				SHA1_txt.Text = result.SHA1_CAPS_UseColonForSplit;
			}
			else
			{
				MD5_txt.Text = result.MD5_CAPS;
				SHA1_txt.Text = result.SHA1_CAPS;
			}
			
			chechUseCapsOrNot();
		}
		
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			chechUseCapsOrNot();
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
			if(radioButton1.Checked)
			{
				textBox1.ReadOnly = true;
				
				textBox1.Text = Password.DEBUG_KEYSTORE_PASSWORD;
			}
		}
		
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			if(radioButton2.Checked)
			{
				textBox1.ReadOnly = false;

				textBox1.Text = password.ReleaseKeyStorePassword;
			}
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			if(radioButton2.Checked)
			{
				password.ReleaseKeyStorePassword = textBox1.Text;
			}
		}
	}
}
