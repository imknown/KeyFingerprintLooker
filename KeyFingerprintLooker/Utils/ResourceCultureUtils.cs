/*
 * 用户： imknown
 * 日期: 2016/10/21
 * 时间: 1:25
 */
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace KeyFingerprintLooker.Utils
{
	/// <summary>
	/// thx to:
	/// http://blog.csdn.net/huangxinfeng/article/details/5544430
	/// http://www.cnblogs.com/xiashengwang/archive/2011/12/23/2578786.html
	/// </summary>
	public static class R
	{
		public const string PROPERTY_TEXT = ".Text";
		public const string PROPERTY_HINT = ".Hint";
		
		public const string LANGUAGE_EN_US = "en-US";
		public const string LANGUAGE_ZH_CN = "zh-CN";
		public const string LANGUAGE_JA_JP = "ja-JP";
		
		public readonly static CultureInfo CI_DEFAULT = new CultureInfo(LANGUAGE_EN_US);
		
		static bool _currentUICultureAvailable;

		public static string String(Form form, Control control)
		{
			return String(form, control, PROPERTY_TEXT);
		}
		
		public static string String(Form form, Control control, string propertySuffix)
		{
			return String(form, control.Name + propertySuffix);
		}
		
		public static string String(Form form, ToolStripItem toolStripItem)
		{
			return String(form, toolStripItem, PROPERTY_TEXT);
		}

		public static string String(Form form, ToolStripItem toolStripItem, string propertySuffix)
		{
			return String(form, toolStripItem.Name + propertySuffix);
		}
		
		public static string String(Form form, string id)
		{
			CultureInfo ci = Thread.CurrentThread.CurrentCulture;
			return String(form, id, ci);
		}
		
		public static string String(Form form, string id, CultureInfo ci)
		{
			string strCurLanguage = "";
			
			try
			{
				var rm = new ResourceManager(form.GetType().FullName, Assembly.GetExecutingAssembly());
				strCurLanguage = rm.GetString(id, ci);
			}
			catch
			{
				strCurLanguage = "No id: " + id + ", please add.";
			}
			
			return strCurLanguage;
		}
		
		public static void SetCurrentCulture(string name)
		{
			var ci = new CultureInfo(name);
			
			SetCurrentCulture(ci);
		}
		
		public static void SetCurrentCulture(CultureInfo ci)
		{
			Thread.CurrentThread.CurrentCulture = ci;
		}
		
		public static void SetBestCurrentCulture(Form form)
		{
			_currentUICultureAvailable = IsCurrentUICultureAvailable(form);
			
			if(!_currentUICultureAvailable)
			{
				SetCurrentCulture(CI_DEFAULT);
			}
		}
		
		public static CultureInfo GetBestCurrentCulture()
		{
			CultureInfo ci = GetCurrentUICulture();
			
			if(!_currentUICultureAvailable)
			{
				ci = CI_DEFAULT;
			}
			
			return ci;
		}
		
		public static bool IsCurrentUICultureAvailable(Form form)
		{
			bool available = true;
			
			CultureInfo ci = GetCurrentUICulture();
			
			string language = String(form, "zzcommon_language", ci);
			
			if(string.IsNullOrEmpty(language))
			{
				available = false;
			}
			
			return available;
		}
		
		public static CultureInfo GetCurrentUICulture()
		{
			return Thread.CurrentThread.CurrentUICulture;
		}
		
		public static string GetCurrentUICultureName()
		{
			return GetCurrentUICulture().Name;
		}
		
		public static CultureInfo GetCurrentCulture()
		{
			return Thread.CurrentThread.CurrentCulture;
		}
		
		public static string GetCurrentCultureName()
		{
			return GetCurrentCulture().Name;
		}
		
		public static void InitControl(Form form, Control.ControlCollection controls)
		{
			foreach (Control control in controls)
			{
				if(control is TextBox || control is ComboBox)
				{
					continue;
				}
				
				var menuStrip = control as MenuStrip;
				if (menuStrip != null)
				{
					dododo(form, menuStrip.Items);
				}
				
				control.Text = String(form, control);
				
				if (control.HasChildren)
				{
					InitControl(form, control.Controls);
				}
			}
		}
		
		static void dododo(Form form, ToolStripItemCollection items)
		{
			foreach (ToolStripMenuItem item in items)
			{
				item.Text = String(form, item);
				
				if(item.HasDropDownItems)
				{
					dododo(form, item.DropDownItems);
				}
			}
		}
	}
}
