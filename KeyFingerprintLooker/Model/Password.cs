/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2015/12/4 周五
 * 时间: 上午 9:49
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace KeyFingerprintLooker.Model
{
	/// <summary>
	/// Description of Password.
	/// </summary>
	public class Password
	{
		public const string DEBUG_KEYSTORE_PASSWORD = "android";
		public const string PASSWORD_ERROR = "Keystore was tampered with, or password was incorrect";
		public const string BAD_FILE_ERROR = "密钥库文件存在, 但为空";
		
		private string _ReleaseKeyStorePassword = DEBUG_KEYSTORE_PASSWORD;
		public string ReleaseKeyStorePassword
		{
			get
			{
				return _ReleaseKeyStorePassword;
			}
			
			set
			{
				_ReleaseKeyStorePassword = value;
			}
		}
	}
}
