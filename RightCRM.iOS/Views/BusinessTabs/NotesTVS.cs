using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace RightCRM.iOS.Views
{
    internal class NotesTVS : MvxTableViewSource
    {
        public NotesTVS(UITableView notesTableView) : base(notesTableView)
        {
          //  this.notesTableView = notesTableView;
            //notesTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (NotesCell)tableView.DequeueReusableCell(NotesCell.Key);

            return cell;
        }

    }
}