using System;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

using LothianProductions.DeskScop.Forms;
using LothianProductions.DeskScop.SpamCop;
using LothianProductions.Util.Http;

namespace LothianProductions.DeskScop {

	/// <summary>
	/// Core DeskScop object.
	/// </summary>
	public class DeskScop {

		protected static DeskScop mInstance;

		/// <exception cref="System.Configuration.ConfigurationException">Thrown when application configuration is absent.</exception>
		public static DeskScop Instance() {
			lock( typeof( DeskScop ) ) {
				if( mInstance == null )
					mInstance = new DeskScop();
			}

			return mInstance;
		}

		protected UiConfiguration mUiConfiguration;
		protected MessageList mMessages;

		protected MessageListProcessor mProcessor;

		// FIXME fix datagrid action alias

		// FIXME inform user how many messages were record or processed

		// FIXME preview mode

		// FIXME status bar on bad auth

		// FIXME search

		// FIXME updating multiple



		/// <exception cref="System.Configuration.ConfigurationException">Thrown when application configuration is absent.</exception>
		protected DeskScop() {
			if( ConfigurationManager.AppSettings.Count == 0 ) {
				MessageBox.Show(
					"DeskScop couldn't start as it is missing its configuration file. Check that the DeskScop.exe.config file is in the same folder as the DeskScop executable.",
					"DeskScop is misconfigured",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				throw new ConfigurationErrorsException( "Couldn't find configuration." );
			}

			// Get empty constructor for message list processor class.
			mProcessor = (MessageListProcessor) Activator.CreateInstance(
				null, ConfigurationManager.AppSettings[ "messageListProcessor" ]
			).Unwrap();
		}

		public UiConfiguration UiConfiguration {
			get{ return mUiConfiguration; }
			set{ mUiConfiguration = value; }
		}

		public MessageList Messages {
			get{ return mMessages; }
			set{ mMessages = value; }
		}

		public void Read( DataGrid grid ) {
			UiConfiguration.DisableControls();

			try {
				Messages = mProcessor.ReadMessageList();
			} catch (MessageListProcessorException e) {
				Messages = new MessageList();
				MessageBox.Show(
					"The application failed to read the message list using the " + mProcessor.GetType().Name + " processor.\n\n" + e.ToString(),
					"Failed to read messages",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			} catch (UnauthorizedException) {
				Messages = new MessageList();
				MessageBox.Show(
					"DeskScop couldn't read your message list as the server refused your username or password.\n\nPlease ensure that they are correct!",
					"Failed to read messages",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
				);
			}

			MessageListRenderer.RenderMessageList( Messages, grid );

			if( Messages.Count > 0 )
				UiConfiguration.EnableControls();
		}

		public void Process( DataGrid grid ) {
			UiConfiguration.DisableControls();

			try {
				mProcessor.ProcessMessageList( Messages );
			} catch (MessageListProcessorException e) {
				MessageBox.Show(
					"The application failed to process the message list using the " + mProcessor.GetType().Name + " processor.\n\n" + e.ToString(),
					"Fail to process messages",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			} catch (UnauthorizedException) {
				MessageBox.Show(
					"DeskScop couldn't process your message list as the server refused your username or password.\n\nPlease ensure that they are correct!",
					"Failed to read messages",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
				);
			}

			MessageListRenderer.RenderMessageList( Messages, grid );

			if( Messages.Count > 0 )
				UiConfiguration.EnableControls();
		}
	}
}
