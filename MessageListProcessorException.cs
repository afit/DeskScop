using System;

namespace LothianProductions.DeskScop.SpamCop {

	public class MessageListProcessorException : ApplicationException {

		public MessageListProcessorException( String message ) : base( message ) {
		}

		public MessageListProcessorException( String message, Exception innerException ) 
			: base( message, innerException ) {
		}
	}
}
