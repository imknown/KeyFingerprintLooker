/*
 * 用户： imknown
 * 日期: 2015/12/4 周五
 * 时间: 上午 9:49
 */
using System;

namespace KeyFingerprintLooker.Model
{
	public class Password
	{
		public const string DEBUG_KEYSTORE_PASSWORD = "android";
		
		string _ReleaseKeyStorePassword = DEBUG_KEYSTORE_PASSWORD;
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
