using System;

namespace LothianProductions.DeskScop.SpamCop {

	/// <summary>
	/// Interface for an object that can read and process a list
	/// of SpamCop's held messages. Implementations could include
	/// readers that use POP3, IMAP, or HTTP.
	/// </summary>

	public interface MessageListProcessor {

		/// <exception cref="LothianProductions.DeskScop.SpamCop.MessageListProcessorException">
		/// Thrown on failure of the processor.</exception>
		MessageList ReadMessageList();

		/// <exception cref="LothianProductions.DeskScop.SpamCop.MessageListProcessorException">
		/// Thrown on failure of the processor.</exception>
		void ProcessMessageList( MessageList list );

	}
}
