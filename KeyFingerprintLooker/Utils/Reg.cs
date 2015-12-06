/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2015/12/6 周日
 * 时间: 下午 9:09
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

using Microsoft.Win32;

namespace KeyFingerprintLooker.Utils
{
	public enum ProcessType
	{
		X64 = 64,
		X86 = 32,
		Unknown = -1
	};
	
	/// <summary>
	/// Description of Reg.
	/// </summary>
	public class Reg
	{
		public static List<String> FindRegKey(List<ProcessType> ProcessTypeList, string whichToFound)
		{
			#region [ 初始化 ]
			RegistryKey lmKey, x86UninstallKey, x64UninstallKey;

			lmKey = Registry.LocalMachine;

			x64UninstallKey = lmKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\");
			x86UninstallKey = lmKey.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\");

			string[] x64ProgramKeys = new String[0];
			string[] x86ProgramKeys = new String[0];
			
			if(ProcessTypeList.Contains(ProcessType.X64))
			{
				x64ProgramKeys = x64UninstallKey.GetSubKeyNames();
			}
			
			if(ProcessTypeList.Contains(ProcessType.X86))
			{
				x86ProgramKeys = x86UninstallKey.GetSubKeyNames();
			}
			
			#endregion
			
			List<String> x64InstallLocationList = FindInstallLocation(x64UninstallKey, x64ProgramKeys, whichToFound);
			List<String> x86InstallLocationList = FindInstallLocation(x86UninstallKey, x86ProgramKeys, whichToFound);
			
			List<String> InstallLocationList = new List<String>();
			InstallLocationList.AddRange(x64InstallLocationList);
			InstallLocationList.AddRange(x86InstallLocationList);
			
			x64UninstallKey.Close();
			x86UninstallKey.Close();
			lmKey.Close();
			
			return InstallLocationList;
		}

		private static List<String> FindInstallLocation(RegistryKey UninstallKey, string[] ProgramKeys, string whichToFound)
		{
			List<String> InstallLocationList = new List<String>();
			
			foreach (string keyName in ProgramKeys)
			{
				RegistryKey programKey = UninstallKey.OpenSubKey(keyName);

				String DisplayName = (String) programKey.GetValue("DisplayName");
				String InstallLocation = (String) programKey.GetValue("InstallLocation");

				programKey.Close();
				
				if(DisplayName != null && DisplayName.Contains(whichToFound) && InstallLocation != string.Empty)
				{
					InstallLocationList.Add(InstallLocation);
				}
			}
			
			return InstallLocationList;
		}
		
		public static ProcessType GetProcessType()
		{
			ProcessType ProcessType = ProcessType.Unknown;
			
			if (IntPtr.Size == 4)
			{
				ProcessType = ProcessType.X86;
			}
			else if (IntPtr.Size == 8)
			{
				ProcessType = ProcessType.X64;
			}
			
			return ProcessType;
		}
	}
}
