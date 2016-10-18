/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2016/10/18 周四
 * 时间: 下午 10:25
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace KeyFingerprintLooker.Utils
{
	public class OsUtil
	{
		public static ProcessType GetProcessType()
		{
			ProcessType ProcessType = ProcessType.Unknown;
			
			if(Environment.Is64BitProcess)
			{
				ProcessType = ProcessType.X64;
			}
			else
			{
				ProcessType = ProcessType.X86;
			}
			
			return ProcessType;
		}
		
		public static ProcessType GetOsBit()
		{
			ProcessType ProcessType = ProcessType.Unknown;
			
			if(Environment.Is64BitOperatingSystem)
			{
				ProcessType = ProcessType.X64;
			}
			else
			{
				ProcessType = ProcessType.X86;
			}
			
			return ProcessType;
		}
	}
}
