/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2015/12/4 周五
 * 时间: 上午 9:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

using System.Collections.Generic;

namespace KeyFingerprintLooker.Model
{
	/// <summary>
	/// Description of Result.
	/// </summary>
	public class Result
	{
		/// <summary>
		/// 别名
		/// </summary>
		public List<string> AliasNameList {get; set;}
		
		public string MD5_CAPS {get; set;}
		
		public string SHA1_CAPS {get; set;}
		
		public string MD5_CAPS_UseColonForSplit {get; set;}
		
		public string SHA1_CAPS_UseColonForSplit {get; set;}
		
		/// <summary>
		/// 创建时间
		/// </summary>
		public string CreateDate {get; set;}
		
		/// <summary>
		/// 有效期 开始日期
		/// </summary>
		public string ValidityDateFrom {get; set;}
		
		/// <summary>
		/// 有效期 截止日期
		/// </summary>
		public string ValidityDateTo {get; set;}
		
		/// <summary>
		/// 算法
		/// </summary>
		public string Algorithm {get; set;}
		
		/// <summary>
		/// 算法版本
		/// </summary>
		public string AlgorithmVersion {get; set;}
	}
}
