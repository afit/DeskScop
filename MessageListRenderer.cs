using System;
using System.Data;
using System.Windows.Forms;

using LothianProductions.Util;

namespace LothianProductions.DeskScop.SpamCop {

	/// <summary>
	/// Provides static methods for rendering message
	/// lists to various controls.
	/// </summary>
	public class MessageListRenderer {

		public static void RenderMessageList( MessageList list, DataGrid control ) {

			DataTable table = new DataTable("HeldMessages");

			// Action
			DataColumn column = new DataColumn();
			column.DataType = System.Type.GetType("System.Int32");
			column.ColumnName = "Action";
			column.ReadOnly = false;
			table.Columns.Add( column );

			// From
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "From";
			column.ReadOnly = true;
			table.Columns.Add( column );

			// Subject
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "Subject";
			column.ReadOnly = true;
			table.Columns.Add( column );

			// Sent date
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.DateTime");
			column.ColumnName = "Sent";
			column.ReadOnly = true;
			table.Columns.Add( column );

			// Why held
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "Why Held";
			column.ReadOnly = true;
			table.Columns.Add( column );

			// Id
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.Int32");
			column.ColumnName = "Message ID";
			column.ReadOnly = true;
			// Make property unique for sanity checking.
			column.Unique = true;
			table.Columns.Add( column );

			// Add Id as primary key
			table.PrimaryKey = new DataColumn[] { column };

			foreach( Message message in list.GetUnderlyingValues() ) {			
				DataRow row = table.NewRow();

				row[ "Action" ] = message.Action;
				row[ "Message ID" ] = message.Id;
				row[ "From" ] = message.From;
				row[ "Sent" ] = message.DateSent;
				row[ "Subject" ] = message.Subject;
				row[ "Why Held" ] = message.WhyHeld;

				table.Rows.Add( row );
			}

			// Preserve sort on rerendering.
			if( control.DataSource != null )
				table.DefaultView.Sort = ((DataSet) control.DataSource).Tables[ "HeldMessages" ].DefaultView.Sort;

			DataSet dset = new DataSet();
			dset.Tables.Add( table );

			control.SetDataBinding( dset, "HeldMessages" );
		}

	}
}
