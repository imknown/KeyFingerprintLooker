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
	public class RegUtil
	{
		#region [ FromInstallAppList ]
		[method: Obsolete("Use FindRegKeyByJavaSoft() instead")]
		public static List<String> FindRegKeyFromInstallAppList(List<ProcessType> ProcessTypeList, string whichToFound)
		{
			#region [ 初始化 ]
			RegistryKey lmKey, CurrentVersionUninstallKey, WOW64UninstallKey;

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
			
			List<String> CurrentVersionInstallLocationList = FindInstallLocationFromInstallAppList(CurrentVersionUninstallKey, CurrentVersionProgramKeys, whichToFound);
			List<String> WOW64InstallLocationList = FindInstallLocationFromInstallAppList(WOW64UninstallKey, WOW64ProgramKeys, whichToFound);
			
			List<String> InstallLocationList = new List<String>();
			InstallLocationList.AddRange(CurrentVersionInstallLocationList);
			InstallLocationList.AddRange(WOW64InstallLocationList);
			
			CurrentVersionUninstallKey.Close();
			WOW64UninstallKey.Close();
			lmKey.Close();
			
			return InstallLocationList;
		}

		[method: Obsolete("Use FindInstallLocationByJavaSoft() instead")]
		private static List<String> FindInstallLocationFromInstallAppList(RegistryKey UninstallKey, string[] ProgramKeys, string whichToFound)
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
		
		#endregion
		
		#region [ ByJavaSoft ]
		
		public const string JDK_FULL = "Java Development Kit";
		public const string JRE_FULL = "Java Runtime Environment";
		
		public static List<String> FindRegKeyByJavaSoft(List<ProcessType> ProcessTypeList, string whichToFound)
		{
			#region [ 初始化 ]
			RegistryKey lmKey, CurrentVersionJavaSoftKey, WOW64JavaSoftKey;

			lmKey = Registry.LocalMachine;

			CurrentVersionJavaSoftKey = lmKey.OpenSubKey(@"SOFTWARE\JavaSoft\");
			WOW64JavaSoftKey = lmKey.OpenSubKey(@"SOFTWARE\WOW6432Node\JavaSoft\");
			
			string[] CurrentVersionJavaKeys = new String[0];
			string[] WOW64JavaKeys = new String[0];
			
			if(ProcessTypeList.Contains(ProcessType.X64))
			{
				CurrentVersionJavaKeys = CurrentVersionJavaSoftKey.GetSubKeyNames();
			}
			
			if(ProcessTypeList.Contains(ProcessType.X86))
			{
				WOW64JavaKeys = WOW64JavaSoftKey.GetSubKeyNames();
			}
			
			#endregion
			
			List<String> CurrentVersionInstallLocationList = FindInstallLocationByJavaSoft(CurrentVersionJavaSoftKey, CurrentVersionJavaKeys, whichToFound);
			List<String> WOW64InstallLocationList = FindInstallLocationByJavaSoft(WOW64JavaSoftKey, WOW64JavaKeys, whichToFound);
			
			List<String> InstallLocationList = new List<String>();
			InstallLocationList.AddRange(CurrentVersionInstallLocationList);
			InstallLocationList.AddRange(WOW64InstallLocationList);
			
			lmKey.Close();
			
			return InstallLocationList;
		}
		
		private static List<String> FindInstallLocationByJavaSoft(RegistryKey JavaSoftKey, string[] JavaKeys, string whichToFound)
		{
			List<String> InstallLocationList = new List<String>();
			
			foreach (string keyName in JavaKeys)
			{
				if(keyName == JDK_FULL || keyName == JRE_FULL)
				{
					RegistryKey JavaTypesKey = JavaSoftKey.OpenSubKey(keyName);
					
					string[] JavaTypesSubKeyNames = JavaTypesKey.GetSubKeyNames();
					
					foreach(String JavaTypesSubKeyName in JavaTypesSubKeyNames)
					{
						RegistryKey JavaVersionsKey = JavaTypesKey.OpenSubKey(JavaTypesSubKeyName);
						
						String JavaHome = (String) JavaVersionsKey.GetValue("JavaHome");
						
						if(!string.IsNullOrEmpty(JavaHome) && JavaTypesSubKeyName.Contains(whichToFound))
						{
							InstallLocationList.Add(JavaHome + "\\");
						}
						
						JavaVersionsKey.Close();
					}
					
					JavaTypesKey.Close();
				}
			}
			
			JavaSoftKey.Close();
			
			return InstallLocationList;
		}
		#endregion
		
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
