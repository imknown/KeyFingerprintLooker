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
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

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
			
			bool ok = false;
			string JavaHome = Environment.GetEnvironmentVariable("Java_Home");
			string KeytoolPath = "";
			
			if(Directory.Exists(JavaHome))
			{
				KeytoolPath = JavaHome + @"\bin\keytool.exe";
				
				// 判断环境变量是否有效
				if(File.Exists(KeytoolPath)){
					ok = true;
				}
			}
			
			if(!ok)
			{
				appendLog("环境变量 Java_Home 无效, 请重新配置");
				
				return;
			}
			
			string cmdString = KeytoolPath + " -list -v -keystore " + "\"" + keystore_file_path_txt.Text + "\"" + " -storepass android";
			
			string result = Command.RunCmd(cmdString);
			
			appendLog(result);
			
			try{
				string[] results = Regex.Split(result,"\r\n",RegexOptions.IgnoreCase);

				string debugInfo =  results[11];
				
				string[] debugInfos = Regex.Split(debugInfo,"\n",RegexOptions.IgnoreCase);
				
				MD5_CAPS_UseColonForSplit = debugInfos[5].Trim();
				MD5_CAPS_UseColonForSplit = MD5_CAPS_UseColonForSplit.Replace("MD5: ", string.Empty);
				MD5_CAPS = MD5_CAPS_UseColonForSplit.Replace(":", string.Empty);
				MD5_txt.Text = MD5_CAPS_UseColonForSplit;
				
				SHA1_CAPS_UseColonForSplit = debugInfos[6].Trim();
				SHA1_CAPS_UseColonForSplit = SHA1_CAPS_UseColonForSplit.Replace("SHA1: ", string.Empty);
				SHA1_CAPS = SHA1_CAPS_UseColonForSplit.Replace(":", string.Empty);
				SHA1_txt.Text = SHA1_CAPS_UseColonForSplit;
			}
			catch(Exception ex)
			{
				appendLog(ex.StackTrace);
			}
		}
		
		string MD5_CAPS, SHA1_CAPS;
		string MD5_CAPS_UseColonForSplit, SHA1_CAPS_UseColonForSplit;
		
		bool UseColonForSplit = true, UseCaps = true;
		
		void appendLog(string something)
		{
			textBox3.Text = "\r\n" + DateTime.Now.TimeOfDay.ToString() + "\r\n" + something + "\r\n" + textBox3.Text  ;
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			UseColonForSplit = checkBox1.Checked;
			if(UseColonForSplit)
			{
				MD5_txt.Text = MD5_CAPS_UseColonForSplit;
				SHA1_txt.Text = SHA1_CAPS_UseColonForSplit;
			}
			else
			{
				MD5_txt.Text = MD5_CAPS;
				SHA1_txt.Text = SHA1_CAPS;
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
	}
}
