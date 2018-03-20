// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ListsService.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   ListsService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.Common.Services;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.Services
{
    public class ListsService : IListsService
    {
        readonly IUserFacade userFacade;
        readonly IBusinessFacade businessFacade;

        public ListsService(IUserFacade userFacade, IBusinessFacade businessFacade)
        {
            this.businessFacade = businessFacade;
            this.userFacade = userFacade;
        }

        public async Task<IEnumerable<PickerItem>> GetAssociationsFromList(int entityID)
        {
            var busUserList = new List<PickerItem>
            {
                new PickerItem() { DisplayName = "Select Business Contact", Value = null }
            };

            var res = await businessFacade.GetAssociations(entityID, true);

            if (res == null || (bool)!res?.business?.AssociationsArray?.Any())
                return busUserList;
            
            for (int i = 0; i < res?.business?.AssociationsArray?.Count(); i++)
            {
                var tagItem = new PickerItem
                {
                    DisplayName = res?.business?.AssociationsArray?.ElementAt(i).usrname,
                    Value = res?.business?.AssociationsArray?.ElementAt(i).usrid
                };

                busUserList.Add(tagItem);
            }

            return busUserList;
        }

        public async Task<IEnumerable<PickerItem>> GetTagsFromList()
        {
            var tagList = new List<PickerItem>
            {
                new PickerItem() { DisplayName = "Select Tag", Value = null }
            };

            var res = await businessFacade.GetTagsFromList("ctag");

            if (res == null || !res.Any())
                return tagList;


            for (int i = 0; i < res.Count(); i++)
            {
                var tagItem = new PickerItem
                {
                    DisplayName = res.ElementAt(i).list,
                    Value = i + 1
                };

                tagList.Add(tagItem);
            }

            return tagList;
        }

        public async Task<IEnumerable<PickerItem>> GetUsersFromList()
        {
            var tagList = new List<PickerItem>
            {
                new PickerItem() { DisplayName = "Select User to Assign Tag", Value = null }
            };

            var res = await userFacade.GetSubUsers(new DataAccess.Model.Users.GetSubUsersRequestModel()
            {
                page_no = 1
            });

            if (res == null || !res.Any())
                return tagList;


            for (int i = 0; i < res.Count(); i++)
            {
                var tagItem = new PickerItem
                {
                    DisplayName = res.ElementAt(i).usrname,
                    Value = res.ElementAt(i).usrid.GetValueOrDefault()
                };

                tagList.Add(tagItem);
            }

            return tagList;
        }
    }
}
