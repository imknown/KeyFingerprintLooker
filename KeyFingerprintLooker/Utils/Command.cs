/*
 * 由SharpDevelop创建。
 * 用户： imknown
 * 日期: 2015/12/3 周四
 * 时间: 下午 12:59
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Diagnostics;
using System.IO;

namespace KeyFingerprintLooker.Utils
{
	/// <summary>
	/// Description of Command.
	/// </summary>
	public class Command
	{
		public static string RunCmd(string command)
		{
			Process p = new Process();

			p.StartInfo.FileName = "cmd.exe";           //设定程序名
			p.StartInfo.Arguments = "/c " + command;    //设定程式执行参数
			p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
			p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
			p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
			p.StartInfo.RedirectStandardError = false;   //重定向错误输出
			p.StartInfo.CreateNoWindow = true;          //设置不显示窗口
			p.Start();   //启动
			
			//p.StandardInput.WriteLine(command);       //也可以用这种方式输入要执行的命令
			//p.StandardInput.WriteLine("exit");        //不过要记得加上Exit要不然下一行程式执行的时候会当机
			
			return p.StandardOutput.ReadToEnd();        //从输出流取得命令执行结果
		}
	}
}
