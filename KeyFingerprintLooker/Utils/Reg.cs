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
			RegistryKey lmKey, WOW64UninstallKey, CurrentVersionUninstallKey;

			lmKey = Registry.LocalMachine;

			CurrentVersionUninstallKey = lmKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\");
			WOW64UninstallKey = lmKey.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\");

			string[] CurrentVersionProgramKeys = new String[0];
			string[] WOW64ProgramKeys = new String[0];
			
			if(ProcessTypeList.Contains(ProcessType.X64))
			{
				CurrentVersionProgramKeys = CurrentVersionUninstallKey.GetSubKeyNames();
			}
			
			if(ProcessTypeList.Contains(ProcessType.X86))
			{
				WOW64ProgramKeys = WOW64UninstallKey.GetSubKeyNames();
			}
			
			#endregion
			
			List<String> CurrentVersionInstallLocationList = FindInstallLocation(CurrentVersionUninstallKey, CurrentVersionProgramKeys, whichToFound);
			List<String> WOW64InstallLocationList = FindInstallLocation(WOW64UninstallKey, WOW64ProgramKeys, whichToFound);
			
			List<String> InstallLocationList = new List<String>();
			InstallLocationList.AddRange(CurrentVersionInstallLocationList);
			InstallLocationList.AddRange(WOW64InstallLocationList);
			
			CurrentVersionUninstallKey.Close();
			WOW64UninstallKey.Close();
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
