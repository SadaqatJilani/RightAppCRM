﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ApiConfig.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   ApiConfig
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using RightCRM.Common;

namespace RightCRM.DataAccess.Config
{
    public static class ApiConfig
    {
        /// <summary>
        /// The shared API key.
        /// </summary>
        public static string SharedApiKey = "95925a94-bd18-4e7e-ae52-731832f63c57";

        public static string GetUserSessionId()
        {
            return $"{SharedConfig.RightApiAuthenticationRoot}Individuals/login";
        }

        public static string GetBusinessDetails()
        {
            return $"{SharedConfig.RightApiAuthenticationRoot}Businesses/getbusinessprofile";
        }

        public static string RegisterNewBusiness()
        {
            return $"{SharedConfig.RightApiAuthenticationRoot}registrations/businessaccount";
        }

        public static string GetAllBusinesses()
        {
            return $"{SharedConfig.RightCrmApiRoot}Businesses/businesslist";
        }

        public static string GetUserProfile(string username)
        {
            return $"{SharedConfig.RightCrmApiRoot}GetUserProfile/{username}";
        }

        public static string GetAllNotes()
        {
            return $"{SharedConfig.RightCrmApiRoot}Notes/getallnotes";
        }

        public static string SaveNewNote()
        {
            return $"{SharedConfig.RightCrmApiRoot}Notes/savenote";
        }

        public static string AddTagsToLead()
        {
            return $"{SharedConfig.RightCrmApiRoot}Leads/saveleads";
        }

        public static string GetList()
        {
            return $"{SharedConfig.RightCrmApiRoot}Lists/getlist";
        }

        public static string GetUsers()
        {
            return $"{SharedConfig.RightCrmApiRoot}Individuals/userlist";
        }

        public static string SaveSearch()
        {
            return $"{SharedConfig.RightCrmApiRoot}Businesses/savesearch";
        }

        public static string LoadSavedSearches()
        {
            return $"{SharedConfig.RightCrmApiRoot}Businesses/loadsavedsearches";
        }

        //Businesses/loadsavedsearches

        //Lists/getlist

        //Notes/getallnotes

    }
}
