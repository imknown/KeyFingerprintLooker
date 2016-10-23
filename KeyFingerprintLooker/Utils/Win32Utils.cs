﻿/*
 * User: imknown
 * Date: 10/23/2016
 * Time: 2:00 PM
 */
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KeyFingerprintLooker.Utils
{
	/// <summary>
	/// thx to http://www.cnblogs.com/qingci/archive/2012/10/15/2724373.html
	/// </summary>
	public static class Win32Utils
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		[DllImport("user32.dll")]
		static extern bool SendMessage(IntPtr hwnd, int msg, int wParam, StringBuilder lParam);

		[DllImport("user32.dll")]
		static extern bool GetComboBoxInfo(IntPtr hwnd, ref COMBOBOXINFO pcbi);

		[StructLayout(LayoutKind.Sequential)]
		struct COMBOBOXINFO
		{
			public int cbSize;
			public RECT rcItem;
			public RECT rcButton;
			public IntPtr stateButton;
			public IntPtr hwndCombo;
			public IntPtr hwndItem;
			public IntPtr hwndList;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		const int EM_SETCUEBANNER = 0x1501;
		const int EM_GETCUEBANNER = 0x1502;

		public static void SetCueText(Control control, string text)
		{
			if (control is ComboBox)
			{
				COMBOBOXINFO info = GetComboBoxInfo(control);
				SendMessage(info.hwndItem, EM_SETCUEBANNER, 0, text);
			}
			else
			{
				SendMessage(control.Handle, EM_SETCUEBANNER, 0, text);
			}
		}

		private static COMBOBOXINFO GetComboBoxInfo(Control control)
		{
			var info = new COMBOBOXINFO();
			// a combobox is made up of three controls, a button, a list and textbox;
			// we want the textbox
			info.cbSize = Marshal.SizeOf(info);
			GetComboBoxInfo(control.Handle, ref info);
			return info;
		}

		public static string GetCueText(Control control)
		{
			var builder = new StringBuilder();
			if (control is ComboBox)
			{
				var info = new COMBOBOXINFO();
				// a combobox is made up of two controls, a list and textbox;
				// we want the textbox
				info.cbSize = Marshal.SizeOf(info);
				GetComboBoxInfo(control.Handle, ref info);
				SendMessage(info.hwndItem, EM_GETCUEBANNER, 0, builder);
			}
			else
			{
				SendMessage(control.Handle, EM_GETCUEBANNER, 0, builder);
			}
			
			return builder.ToString();
		}
	}
}
