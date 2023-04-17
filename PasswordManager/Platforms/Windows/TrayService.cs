using Hardcodet.Wpf.TaskbarNotification.Interop;
using PasswordManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Platforms.Windows
{
	public class TrayService : ITrayService
	{
		WindowsTrayIcon tray;

		public Action ClickHandler { get; set; }

		public void Initialize()
		{
			tray = new WindowsTrayIcon("Platforms/Windows/trayicon.ico");
			tray.LeftClick = () =>
			{
				WindowExtensions.BringToFront();
				ClickHandler?.Invoke();
			};
		}
	}
}
