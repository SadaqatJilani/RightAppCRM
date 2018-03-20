// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IListsService.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   IListsService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.Common.Services
{
    public interface IListsService
    {
        Task<IEnumerable<PickerItem>> GetTagsFromList();

        Task<IEnumerable<PickerItem>> GetUsersFromList();

        Task<IEnumerable<PickerItem>> GetAssociationsFromList(int entityID);
    }
}
