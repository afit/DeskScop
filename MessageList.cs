using System;
using System.Collections;

namespace LothianProductions.DeskScop.SpamCop {

	/// <summary>
	/// Represents a list of messages.
	/// </summary>
	public class MessageList {

		protected Hashtable mMessages = new Hashtable();

		public void Add( Message message ) {
			mMessages.Add( message.Id, message );
		}

		public void Remove( Message message ) {
			mMessages.Remove( message.Id );
		}

		public int Count {
			get{ return mMessages.Count; }
		}

		public Message this[ int id ] {
			get{ return (Message) mMessages[ id ]; }
		}

		public IList GetMessagesByAction( MessageAction action ) {
			IList list = new ArrayList();

			foreach( Message message in mMessages.Values )
				if( message.Action == action )
					list.Add( message );

			return list;
		}

		public ICollection GetUnderlyingValues() {
			return mMessages.Values;
		}

	}
}
