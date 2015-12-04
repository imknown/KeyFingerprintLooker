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
using System.Collections;
using System.Collections.Generic;

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
			OpenFileDialog OpenDialog = new OpenFileDialog();
			OpenDialog.Filter = "秘钥文件(*.keystore;*.jks)|*.keystore;*.jks|所有文件 (*.*)|*.*";
			
			if(DialogResult.OK == OpenDialog.ShowDialog())
			{
				keystore_file_path_txt.Text = OpenDialog.FileName;
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			if(checkBox4.Checked)
			{
				textBox3.Text = string.Empty;
			}
			
			string KeystoreFilePath = keystore_file_path_txt.Text;
			
			if(!File.Exists(KeystoreFilePath)){
				AppendLog("秘钥文件不存在");
				
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
				AppendLog("环境变量 Java_Home 无效, 请重新配置");
				
				return;
			}
			
			string CmdString = /* surroundInCmd( */ KeytoolPath /* ) */ + " -list -v -keystore " + surroundInCmd(keystore_file_path_txt.Text) + " -storepass " + surroundInCmd(textBox1.Text);
			
			string CmdResult = Command.RunCmd(CmdString);
			
			if(CmdResult.Contains(Password.PASSWORD_ERROR))
			{
				AppendLog("密码错误");
				return;
			}
			else if(CmdResult == string.Empty)
			{
				AppendLog("环境变量 Java_Home 有误, 可能存在空格");
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
				AppendLog(ex.StackTrace);
			}
		}
		
		void parseResult(string CmdResult)
		{
			Result = new Result();
			
			comboBox1.Items.Clear();
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
					comboBox1.Items.Add(AliasInfo.AliasName);
				}
			}
			
			sr.Close();
			label1.Text = Result.AliasCount + " 个别名";
			comboBox1.SelectedIndex = 0;
		}
		
		Password password = new Password();
		bool UseColonForSplit = true, UseCaps = true;
		Result Result = new Result();
		
		void AppendLog(string something)
		{
			textBox3.Text = "\r\n" + DateTime.Now.TimeOfDay.ToString() + "\r\n" + something + "\r\n" + textBox3.Text  ;
		}
		
		string surroundInCmd(string something)
		{
			return "\"" +something + "\"";
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			int SelectedIndex = comboBox1.SelectedIndex;
			
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
			int SelectedIndex = comboBox1.SelectedIndex;
			
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
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			chechUseColonForSplit();
			chechUseCapsOrNot();
		}
	}
}
