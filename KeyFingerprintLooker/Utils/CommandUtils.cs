/*
 * 用户： imknown
 * 日期: 2015/12/3 周四
 * 时间: 下午 12:59
 */
using System;
using System.Diagnostics;

namespace KeyFingerprintLooker.Utils
{
	/// <summary>
	/// Description of Command.
	/// </summary>
	public static class CommandUtils
	{
		public static string RunCmd(string command)
		{
			var p = new Process();

			p.StartInfo.FileName = "cmd.exe";           //设定程序名
			// p.StartInfo.Arguments = "/c " + command;    //设定程式执行参数
			p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
			p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
			p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
			p.StartInfo.RedirectStandardError = true;   //重定向错误输出
			p.StartInfo.CreateNoWindow = true;          //设置不显示窗口
			p.Start();
			
			p.StandardInput.WriteLine(command);       //也可以用这种方式输入要执行的命令
			p.StandardInput.WriteLine("exit");        //不过要记得加上Exit要不然下一行程式执行的时候会当机
			
			p.StandardInput.AutoFlush = true;   //启动
			
			string output = p.StandardOutput.ReadToEnd();
			
			p.WaitForExit();//等待程序执行完退出进程
			p.Close();

			return output;        //从输出流取得命令执行结果
		}
	}
}
