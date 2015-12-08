/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2015/12/7 周一
 * 时间: 下午 7:08
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using ICSharpCode.SharpZipLib.Zip;

namespace KeyFingerprintLooker.Utils
{
	/// <summary>
	/// Description of ZipUtil.
	/// </summary>
	public class ZipUtil
	{
		public const string DIR_WHERE_CERT_RSA_IN = "META-INF";
		public const string CERT_RSA = "CERT.RSA";
		
		public static string UnzipCERT_RSA(string apkFileName)
		{
			string targetDirectory = apkFileName + @".unzip\";
			string fileFilter = CERT_RSA;
			
			FastZip fastzip = new FastZip();
			fastzip.CreateEmptyDirectories = true;
			fastzip.ExtractZip(apkFileName, targetDirectory, fileFilter);
			
			string CertRsaPath = targetDirectory + DIR_WHERE_CERT_RSA_IN + "\\" + CERT_RSA;
			
			return CertRsaPath;
		}
	}
}
