/*
 * 用户： imknown
 * 日期: 2016/10/18 周四
 * 时间: 下午 10:25
 */
using System;

namespace KeyFingerprintLooker.Utils
{
	public static class OsUtils
	{
		public static ProcessType GetProcessType()
		{
			return Environment.Is64BitProcess ? ProcessType.X64 : ProcessType.X86;
		}
		
		public static ProcessType GetOsBit()
		{
			return Environment.Is64BitOperatingSystem ? ProcessType.X64 : ProcessType.X86;
		}
	}
}
