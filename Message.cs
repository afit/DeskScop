using System;

namespace LothianProductions.DeskScop.SpamCop {

	public enum MessageAction :int {
		None = 0,
		Quick,
		Forward,
		ForwardWhitelist,
		QueueTrash,
		Queue,
		Delete
	};

	/// <summary>
	/// Represents a message.
	/// </summary>
	public class Message {

		public static MessageAction MessageActionStringLookup( String action ) {
			switch( action ) {
				case "None":
					return MessageAction.None;
				case "Quick":
					return MessageAction.Quick;
				case "Forward":
					return MessageAction.Forward;
				case "ForwardWhitelist":
					return MessageAction.ForwardWhitelist;
				case "QueueTrash":
					return MessageAction.QueueTrash;
				case "Queue":
					return MessageAction.Queue;
			}

			return MessageAction.Delete;
		}

		protected int mId;
		protected String mFrom;
		protected String mSubject;
		protected DateTime mDateSent;
		protected String mWhyHeld;
		protected String mChecksum;
		protected MessageAction mAction;

		public Message( int id, String from, String subject, DateTime dateSent, String whyHeld, String checksum ) {
			mId = id;
			mFrom = from;
			mSubject = subject;
			mDateSent = dateSent;
			mWhyHeld = whyHeld;
			mChecksum = checksum;
		}

		public int Id {
			get{ return mId; }
		}

		public String From {
			get{ return mFrom; }
		}

		public String Subject {
			get{ return mSubject; }
		}

		public DateTime DateSent {
			get{ return mDateSent; }
		}

		public String WhyHeld {
			get{ return mWhyHeld; }
		}

		public String Checksum {
			get{ return mChecksum; }
		}

		public MessageAction Action {
			get{ return mAction; }
			set{ mAction = value; }
		}

	}
}
