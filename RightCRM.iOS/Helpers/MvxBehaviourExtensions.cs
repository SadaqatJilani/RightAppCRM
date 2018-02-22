// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MvxBehaviourExtensions.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   MvxBehaviourExtensions
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views.Gestures;
using UIKit;

namespace RightCRM.iOS.Helpers
{
    public static class MvxBehaviourExtensions
    {
        public static MvxLongPressGestureRecognizerBehaviour LongPress(this UIView view, object param = null)
        {
            var toReturn = new MvxLongPressGestureRecognizerBehaviour(view, param);
            return toReturn;
        }
    }


    public class MvxLongPressGestureRecognizerBehaviour
        : MvxGestureRecognizerBehavior<UILongPressGestureRecognizer>
    {
        readonly object param;
        private readonly UITableView target;
        public bool isLongPress;

        protected override void HandleGesture(UILongPressGestureRecognizer gesture)
        {
            var point = gesture.LocationInView(target);

            var indexPath = target?.IndexPathForRowAtPoint(point);


            var selectedCell = target?.CellAt(indexPath);


            // Long press recognizer fires continuously. This will ensure we fire
            // the command only once. Fire as soon as gesture is recognized as
            // a long press.
            if (gesture.State == UIGestureRecognizerState.Began)
            {
                //FireCommand();
                FireCommand2(indexPath.Row);

                if (selectedCell.Selected == false)
                {
                    target.SelectRow(indexPath, true, UITableViewScrollPosition.None);
                    target.Delegate?.RowSelected(target, indexPath);
                }
                else
                {
                    target.DeselectRow(indexPath, true);
                    target.Delegate?.RowDeselected(target, indexPath);
                }


                if(target.IndexPathsForSelectedRows.Count() > 0)
                {
                    IsLongPress = true;
                }
                else
                {
                    isLongPress = false;
                }
            }
        }

        public MvxLongPressGestureRecognizerBehaviour(UIView target, object param)
        {
            var lp = new UILongPressGestureRecognizer(HandleGesture)
            {
                MinimumPressDuration = 1,
            };

            this.target = target as UITableView;

            this.param = param;

            AddGestureRecognizer(target, lp);
        }

        public bool IsLongPress
        {
            get
            {
                return isLongPress;
            }
            set
            {
                if (value != this.isLongPress)
                {
                    this.isLongPress = value;
                }
            }
        }

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}


        void FireCommand2(object param = null)
        {
            var command = Command;
            if (command != null)
                command.Execute(param);
        }


    }
}
