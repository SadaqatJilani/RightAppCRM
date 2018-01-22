// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RightCRM.iOS.Views
{
    [Register ("CreateNewBusView")]
    partial class CreateNewBusView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        RightCRM.iOS.BtnUniversal btnCreateBusiness { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAccountName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAccountType { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAnnualRevenue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtBusinessNTN { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtBusinessWebsite { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCampaignMedia { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCampaignName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCampaignSrc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCompanySize { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtIndustry { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCreateBusiness != null) {
                btnCreateBusiness.Dispose ();
                btnCreateBusiness = null;
            }

            if (txtAccountName != null) {
                txtAccountName.Dispose ();
                txtAccountName = null;
            }

            if (txtAccountType != null) {
                txtAccountType.Dispose ();
                txtAccountType = null;
            }

            if (txtAnnualRevenue != null) {
                txtAnnualRevenue.Dispose ();
                txtAnnualRevenue = null;
            }

            if (txtBusinessNTN != null) {
                txtBusinessNTN.Dispose ();
                txtBusinessNTN = null;
            }

            if (txtBusinessWebsite != null) {
                txtBusinessWebsite.Dispose ();
                txtBusinessWebsite = null;
            }

            if (txtCampaignMedia != null) {
                txtCampaignMedia.Dispose ();
                txtCampaignMedia = null;
            }

            if (txtCampaignName != null) {
                txtCampaignName.Dispose ();
                txtCampaignName = null;
            }

            if (txtCampaignSrc != null) {
                txtCampaignSrc.Dispose ();
                txtCampaignSrc = null;
            }

            if (txtCompanySize != null) {
                txtCompanySize.Dispose ();
                txtCompanySize = null;
            }

            if (txtIndustry != null) {
                txtIndustry.Dispose ();
                txtIndustry = null;
            }
        }
    }
}