/*
 * 用户： imknown
 * 日期: 2015/12/6 周日
 * 时间: 下午 9:09
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
	public static class RegUtil
	{
		#region [ FromInstallAppList ]
		[method: Obsolete("Use FindRegKeyByJavaSoft() instead")]
		public static List<string> FindRegKeyFromInstallAppList(List<ProcessType> ProcessTypeList, string whichToFound)
		{
			#region [ 初始化 ]
			RegistryKey lmKey, CurrentVersionUninstallKey, WOW64UninstallKey;

			lmKey = Registry.LocalMachine;

			CurrentVersionUninstallKey = lmKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\");
			WOW64UninstallKey = lmKey.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\");

			var CurrentVersionProgramKeys = new string[0];
			var WOW64ProgramKeys = new string[0];
			
			if(ProcessTypeList.Contains(ProcessType.X64))
			{
				CurrentVersionProgramKeys = CurrentVersionUninstallKey.GetSubKeyNames();
			}
			
			if(ProcessTypeList.Contains(ProcessType.X86))
			{
				WOW64ProgramKeys = WOW64UninstallKey.GetSubKeyNames();
			}
			#endregion
			
			List<string> CurrentVersionInstallLocationList = FindInstallLocationFromInstallAppList(CurrentVersionUninstallKey, CurrentVersionProgramKeys, whichToFound);
			List<string> WOW64InstallLocationList = FindInstallLocationFromInstallAppList(WOW64UninstallKey, WOW64ProgramKeys, whichToFound);
			
			var InstallLocationList = new List<string>();
			InstallLocationList.AddRange(CurrentVersionInstallLocationList);
			InstallLocationList.AddRange(WOW64InstallLocationList);
			
			CurrentVersionUninstallKey.Close();
			WOW64UninstallKey.Close();
			lmKey.Close();
			
			return InstallLocationList;
		}

		[method: Obsolete("Use FindInstallLocationByJavaSoft() instead")]
		private static List<string> FindInstallLocationFromInstallAppList(RegistryKey UninstallKey, string[] ProgramKeys, string whichToFound)
		{
			var InstallLocationList = new List<string>();
			
			foreach (string keyName in ProgramKeys)
			{
				RegistryKey programKey = UninstallKey.OpenSubKey(keyName);

				var DisplayName = (string) programKey.GetValue("DisplayName");
				var InstallLocation = (string) programKey.GetValue("InstallLocation");

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
		
		public static List<string> FindRegKeyByJavaSoft(List<ProcessType> ProcessTypeList, string whichToFound)
		{
			#region [ 初始化 ]
			RegistryKey lmKey;
			RegistryKey CurrentVersionJavaSoftKey; // '64bit OS' run 'x64 program' to find 'x64 Java', OR '32bit OS' run 'x86 program' to find 'x86 Java'
			RegistryKey WOW64JavaSoftKey; // '64bit OS' run 'x64 program' to find 'x86 Java'

			RegistryKey Imx86PrgFindx64Key; 
			RegistryKey x86PrgFindx64JavaSoftKey; // '64bit OS' run 'x86 program' to find 'x64 Java'

			lmKey = Registry.LocalMachine;
			CurrentVersionJavaSoftKey = lmKey.OpenSubKey(@"SOFTWARE\JavaSoft\");
			WOW64JavaSoftKey = lmKey.OpenSubKey(@"SOFTWARE\WOW6432Node\JavaSoft\");
			
			Imx86PrgFindx64Key = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine,  RegistryView.Registry64);
			x86PrgFindx64JavaSoftKey= Imx86PrgFindx64Key.OpenSubKey(@"SOFTWARE\JavaSoft\"); 
			
			var CurrentVersionJavaKeys = new string[0];
			var WOW64JavaKeys = new string[0];
			var x86PrgFindx64JavaKey = new string[0];
			
			var InstallLocationList = new List<string>();
			
			// shun 'x64 java' duplicate
			// Here are only 'x86 java', if there are...
			// Why wrote this if statement here first?
			// Because anyone may want to use 'x64 java' first.
			if(OsUtil.GetProcessType() == ProcessType.X86 && x86PrgFindx64JavaSoftKey != null)
			{
				x86PrgFindx64JavaKey = x86PrgFindx64JavaSoftKey.GetSubKeyNames();
				List<string> x86PrgFindx64VersionInstallLocationList = FindInstallLocationByJavaSoft(x86PrgFindx64JavaSoftKey, x86PrgFindx64JavaKey, whichToFound);
				InstallLocationList.AddRange(x86PrgFindx64VersionInstallLocationList);
			}
			
			// Maybe 'x64 java' or 'x86 java' here.
			// And this bases on the OS bit.
			if(CurrentVersionJavaSoftKey != null)
			{
				CurrentVersionJavaKeys = CurrentVersionJavaSoftKey.GetSubKeyNames();
				List<string> CurrentVersionInstallLocationList = FindInstallLocationByJavaSoft(CurrentVersionJavaSoftKey, CurrentVersionJavaKeys, whichToFound);
				InstallLocationList.AddRange(CurrentVersionInstallLocationList);
			}

			// shun 'x86 java' duplicate.
			// Here are only 'x86 java', if there are...
			if(OsUtil.GetProcessType() == ProcessType.X64 && WOW64JavaSoftKey != null)
			{
				WOW64JavaKeys = WOW64JavaSoftKey.GetSubKeyNames();
				List<string> WOW64InstallLocationList = FindInstallLocationByJavaSoft(WOW64JavaSoftKey, WOW64JavaKeys, whichToFound);
				InstallLocationList.AddRange(WOW64InstallLocationList);
			}
			#endregion
			
			lmKey.Close();
			
			return InstallLocationList;
		}
		
		/// <summary>
		/// Thanks: https://github.com/Redth/Android.Signature.Tool
		/// </summary>
		/// <param name="JavaSoftKey"></param>
		/// <param name="JavaKeys"></param>
		/// <param name="whichToFound"></param>
		/// <returns></returns>
		private static List<string> FindInstallLocationByJavaSoft(RegistryKey JavaSoftKey, string[] JavaKeys, string whichToFound)
		{
			var InstallLocationList = new List<string>();
			
			foreach (string keyName in JavaKeys)
			{
				if(keyName == JDK_FULL || keyName == JRE_FULL)
				{
					RegistryKey JavaTypesKey = JavaSoftKey.OpenSubKey(keyName);
					
					string[] JavaTypesSubKeyNames = JavaTypesKey.GetSubKeyNames();
					
					foreach(string JavaTypesSubKeyName in JavaTypesSubKeyNames)
					{
						RegistryKey JavaVersionsKey = JavaTypesKey.OpenSubKey(JavaTypesSubKeyName);
						
						string JavaHome = (string) JavaVersionsKey.GetValue("JavaHome");
						
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
	}
}
