using Android.Runtime;
using RightCRM.Core.ViewModels;
using Android.Views;
using Android.OS;
using MvvmCross.Droid.Shared.Attributes;

namespace RightCRM.Droid.Fragments
{
	[MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("xplatformmenus.droid.fragments.HelpFeedbackFragment")]
    public class HelpFeedbackFragment : BaseFragment<HelpAndFeedbackViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_helpfeedback;
    }
}