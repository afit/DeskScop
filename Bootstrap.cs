using System;
using System.Windows.Forms;
using System.Configuration;

using LothianProductions.DeskScop.Forms;

namespace LothianProductions.DeskScop {

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	public class Bootstrap {

		[STAThread]
		public static void Main() {

			// Start load of main form.
			MainForm main = new MainForm();

			try {
				DeskScop.Instance().UiConfiguration = main;
			} catch (ConfigurationException) {
				// User will have already been warned, exit safely.
				return;
			}

			// Show main form.
			main.Show();

			// Pass form onto main thread.
			Application.Run( main );
		}

	}
}
