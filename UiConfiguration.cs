using System;

namespace LothianProductions.DeskScop.Forms {

	/// <summary>
	/// Interface for accessing the DeskScop configuration.
	/// Possible implementations could be form, web or XML
	/// based configurations.
	/// </summary>
	public interface UiConfiguration {
	
		String Username {
			get;
		}

		String Uri {
			get;
		}

		String Password {
			get;
		}

		void DisableControls();

		void EnableControls();

	}
}
