using System;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.Collections;
using System.IO;
using System.Configuration;
using System.Web;

using LothianProductions.Util.Http;

namespace LothianProductions.DeskScop.SpamCop {

	/// <summary>
	/// Processes a message list from SpamCop's web interface.
	/// </summary>
	public class WebMessageListProcessor : MessageListProcessor {

		protected static String HTML_MESSAGE_START = "<input type=\"hidden\" name=\"ids\" value=\"";

		/// <input type="hidden" name="ids" value="12576">
		/// <input type="hidden" name="msgid12576"
		///  value="n-3267%240%24e372ls%240xpb%403tp.1.a9g">
		/// <input type="checkbox" name="checked" value="12576">
		/// <strong>[12576]</strong>
		/// txxa10@aol.com (<strong>Re: my phone number? vzplwbhjs tcuf elvl
		/// <a href="/reportheld?action=preview&message-id=n-3267%240%24e372ls%240xpb%403tp.1.a9g&id=12576">Preview</a>
		/// </strong>)
		/// <dd>Wed, 14 Jan 04 02:39:04 GMT
		///  (Blocked bl.spamcop.net
		/// )
		/// <dt>

		/// <exception cref="LothianProductions.Util.Http.UnauthorizedException"></exception>
		/// <exception cref="LothianProductions.DeskScop.SpamCop.MessageListProcessorException"></exception>
		public MessageList ReadMessageList() {
			
			String content;
			
			try {
				content = HttpHelper.HttpGet(
					// URI
					new Uri( DeskScop.Instance().UiConfiguration.Uri + "/reportheld?action=heldlog" ),
					// Useragent
					"DeskScop " + Application.ProductVersion,
					// Username
					DeskScop.Instance().UiConfiguration.Username,
					// Password
					DeskScop.Instance().UiConfiguration.Password
				);
			} catch (System.Net.WebException e) {
				throw new MessageListProcessorException( "Failed to read message list.", e );
			}

			MessageList list = new MessageList();

			String[] lines = content.Split( '\n' );

			for( int i = 0; i < lines.Length; i++ )
				if( lines[ i ].Length > HTML_MESSAGE_START.Length && lines[ i ].Substring( 0, HTML_MESSAGE_START.Length ) == HTML_MESSAGE_START ) {
					String[] split = lines[ i + 2 ].Split( '\"' );

					String checksum = split[ 1 ];

					String sid =  lines[ i + 4 ].Substring( "<strong>[".Length, lines[ i + 4 ].Length - "<strong>[".Length - "]</strong>".Length );
					int id = Convert.ToInt16( sid );

					String from = lines[ i + 5 ].Substring( 0, lines[ i + 5 ].IndexOf( ' ' ) );
					String subject = lines[ i + 5 ].Substring( lines[ i + 5 ].IndexOf( "<strong>" ) + "<strong>".Length ).Trim();
					// No need to strip out newlines, as they're actually in there...
					// .Replace( "\n", "" ).Replace( "\r", "" );

					int lastHeld = lines[ i + 8 ].LastIndexOf( ")" );
					int firstHeld = lines[ i + 8 ].Substring( 0, lastHeld ).LastIndexOf( "(" );
					String whyHeld = lines[ i + 8 ].Substring( firstHeld + 1, lastHeld - firstHeld - 1 );

					int firstDate = lines[ i + 8 ].IndexOf( "<dd>" );
					String date = lines[ i + 8 ].Substring( firstDate + 4, firstHeld - firstDate - 4 ).Trim();

					DateTime sent;

					try {
						sent = DateTime.ParseExact( date, ConfigurationSettings.AppSettings[ "datePatterns" ].Split( '|' ), DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None );
					} catch (FormatException) {
						// Recover from error by resetting date.
						sent = new DateTime( 1970, 1, 1, 0, 0, 0 );

						/*MessageBox.Show(
                            "An error occurred parsing the sent date \"" + date + "\" for message #" + id + ". The message's date will be reset when it is displayed.\n\n" +
							"You can prevent this error from happening by updating the date parsing patterns in the configuration file.",
							"Failed to parse data",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);*/
					}

					list.Add( new Message( id, from, subject, sent, whyHeld, checksum ) );
				}

			return list;
		}

		/// <exception cref="LothianProductions.Util.Http.UnauthorizedException"></exception>
		/// <exception cref="LothianProductions.DeskScop.SpamCop.MessageListProcessorException"></exception>
		public void ProcessMessageList( MessageList list ) {

			// FIXME weak mechanism joining actions to MessageActions
			String[] actions = new String[] {
				null,		// Do nothing
				"quick",	// Quick - report immediately and trash
				"for-xwl",	// Forward (do not whitelist sender)
				"for",		// Forward (and whitelist sender)
				"rqd",		// Queue for reporting (and move to trash)
				"rq",		// Queue for reporting (do not trash)
				"del"		// Delete
			};

			for( int i = 1; i < actions.Length; i++ ) {
				IList messages = list.GetMessagesByAction( (MessageAction) i );

				if( messages.Count == 0 )
					continue;

				String mesglist = "";

				foreach( Message message in messages ) {
					// Build POST string from messages to act upon.
					mesglist += "&ids=" + message.Id + "&msgid" + message.Id + "=" + HttpUtility.UrlEncode( message.Checksum ) + "&checked=" + message.Id;

					// Remove processed messages.
					list.Remove( message );
				}

				// FIXME potential bug with POST request too long?
				String post = "subaction=" + actions[ i ] + "&action=logaction" + mesglist;
				System.Console.WriteLine( post );

				try {
					using( StreamWriter writer = File.CreateText( "DeskScop_log_" + DateTime.Now.Ticks + ".html" ) ) {
						writer.Write( HttpHelper.HttpPost( 
							// URI
							new Uri( DeskScop.Instance().UiConfiguration.Uri + "/reportheld" ),
							// Message
							post,
							// Useragent
							"DeskScop " + Application.ProductVersion,
							// Username
							DeskScop.Instance().UiConfiguration.Username,
							// Password
							DeskScop.Instance().UiConfiguration.Password
						) );
					}
				} catch (System.Net.WebException e) {
					throw new MessageListProcessorException( "Failed to process message list.", e );
				}
			}
		}

	}
}
