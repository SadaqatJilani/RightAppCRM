using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using RightCRM.Core.Models;

namespace RightCRM.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
		protected BaseViewModel()
        {
            MenuItems = new List<MenuModel>();
        }

        private List<MenuModel> menuItems;
        public  List<MenuModel> MenuItems
        {
            get { return menuItems; }
            set {SetProperty(ref menuItems, value);}
        }

        public string Title
        {
            get;
            set;
        }

        public bool IsBusy
        {
            get;
            set;
        }


    }
}
