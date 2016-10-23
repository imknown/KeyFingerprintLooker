/*
 * 用户： imknown
 * 日期: 2015/12/4 周五
 * 时间: 上午 9:27
 */
using System;

using System.Collections.Generic;

namespace KeyFingerprintLooker.Model
{
	public class Result
	{
		public const string AliasInfosSplitter = "\n\r\n\n\r\n*******************************************\r\n*******************************************\n\n\r\n";
		public const string AliasInfosSplitterReplacer = "====\r\n";
		
		public int AliasCount {get; set;}
		
		public List<AliasInfo> AliasInfoList {get; set;}
		
		public class AliasInfo
		{
			public string AliasName {get; set;}
			
			public string MD5_CAPS_UseColonForSplit {get; set;}
			public string MD5_CAPS {get; set;}
			public string MD5_UseColonForSplit {get; set;}
			public string MD5 {get; set;}
			
			public string SHA1_CAPS_UseColonForSplit {get; set;}
			public string SHA1_CAPS {get; set;}
			public string SHA1_UseColonForSplit {get; set;}
			public string SHA1 {get; set;}
			
			public string CreateDate {get; set;}
			
			public string ValidityDateFrom {get; set;}
			
			public string ValidityDateTo {get; set;}
			
			public string Algorithm {get; set;}
			
			public string AlgorithmVersion {get; set;}
		}
	}
}
