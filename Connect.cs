using System;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;

using Extensibility;

namespace LothianProductions.DeskScop.Outlook {

	#region Read me for Add-in installation and setup information.
	// When run, the Add-in wizard prepared the registry for the Add-in.
	// At a later time, if the Add-in becomes unavailable for reasons such as:
	//   1) You moved this project to a computer other than which is was originally created on.
	//   2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
	//   3) Registry corruption.
	// you will need to re-register the Add-in by building the MyAddin21Setup project 
	// by right clicking the project in the Solution Explorer, then choosing install.
	#endregion
	
	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("09E07E48-1BDD-40EE-A398-99407B5555D5"), ProgId("EmailIntegration2.Connect")]
	public class Connect : Object, Extensibility.IDTExtensibility2 {
		/// <summary>
		///		Implements the constructor for the Add-in object.
		///		Place your initialization code within this method.
		/// </summary>
		public Connect() {
		}

		/// <summary>
		///      Implements the OnConnection method of the IDTExtensibility2 interface.
		///      Receives notification that the Add-in is being loaded.
		/// </summary>
		/// <param term='application'>
		///      Root object of the host application.
		/// </param>
		/// <param term='connectMode'>
		///      Describes how the Add-in is being loaded.
		/// </param>
		/// <param term='addInInst'>
		///      Object representing this Add-in.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom) {		
			applicationObject = (Microsoft.Office.Interop.Outlook.Application)application;
			addInInstance = addInInst;
			if(connectMode != ext_ConnectMode.ext_cm_Startup) {
				OnStartupComplete(ref custom);
			}
		}

		/// <summary>
		///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
		///     Receives notification that the Add-in is being unloaded.
		/// </summary>
		/// <param term='disconnectMode'>
		///      Describes how the Add-in is being unloaded.
		/// </param>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom) {
			if(disconnectMode != ext_DisconnectMode.ext_dm_HostShutdown) {
				OnBeginShutdown(ref custom);
			}
			applicationObject = null;
		}

		/// <summary>
		///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		///      Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref System.Array custom) {
		}

		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref System.Array custom) {
			activeExplorer = (Explorer)applicationObject.GetType().InvokeMember("ActiveExplorer",BindingFlags.GetProperty,null,applicationObject,null);
			CommandBars currentBars = (CommandBars)activeExplorer.GetType().InvokeMember("CommandBars",BindingFlags.GetProperty,null,activeExplorer,null);
			try {
				btnLaunchPaperless = (CommandBarButton)currentBars["Standard"].Controls["Lovetts Paperless"];
				btnLaunchPaperless.Caption = "Lovetts Paperless";
				btnLaunchPaperless.Style = MsoButtonStyle.msoButtonIconAndCaption;
				btnLaunchPaperless.FaceId = 610;
				btnLaunchPaperless.Tag = "Paperless";
			} catch {
				btnLaunchPaperless = (CommandBarButton)currentBars["Standard"].Controls.Add( 1, missingVal, missingVal, missingVal, missingVal );
				btnLaunchPaperless.Caption = "Lovetts Paperless";
				btnLaunchPaperless.Style = MsoButtonStyle.msoButtonIconAndCaption;
				btnLaunchPaperless.FaceId = 610;
				btnLaunchPaperless.Tag = "Paperless";
			}
			btnLaunchPaperless.Visible = true;
				// Rig-up the Click event for the new CommandBarButton type.
			btnLaunchPaperless.Click += new _CommandBarButtonEvents_ClickEventHandler( btnLaunchPaperless_Click );
		}

		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom) {
			CommandBars currentBars = applicationObject.ActiveExplorer().CommandBars;
			try {
				currentBars["Standard"].Controls["Lovetts Paperless"].Delete( missingVal );
			} catch {
				Debug.WriteLine( "Unable to remove button for Paperless from host application");
			}
		}
		
		private Microsoft.Office.Interop.Outlook.Application applicationObject;
		private Explorer activeExplorer;
		private object addInInstance;
		private CommandBarButton btnLaunchPaperless;
		private System.Reflection.Missing missingVal =  System.Reflection.Missing.Value;

		private void btnLaunchPaperless_Click (CommandBarButton Ctrl, ref bool CancelDefault) {
			System.Diagnostics.Debug.WriteLine("In button click handler");
			Microsoft.Office.Interop.Outlook.MAPIFolder currentFolder = applicationObject.ActiveExplorer().CurrentFolder;
			if ( currentFolder.DefaultItemType == OlItemType.olMailItem ) {
				Selection sel = activeExplorer.Selection;
				MailItem item = null;
				foreach( Object s in sel ) {
					item = (MailItem)s;
				}
				if ( item != null ) {
					//SafeMailItem safe_item = new SafeMailItemClass();
					//safe_item.Item = item;
			
				}
			}
		}
	}
}