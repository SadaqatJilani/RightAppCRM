// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="PickerItem.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   PickerItem
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Common.Models
{
    public class PickerItem
    {
        public string DisplayName { get; set; }
        public int? Value { get; set; }

		public override string ToString()
		{
            return DisplayName;
		}
	}
}
