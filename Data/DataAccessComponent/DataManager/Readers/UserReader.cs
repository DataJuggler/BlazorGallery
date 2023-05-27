

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class UserReader
    /// <summary>
    /// This class loads a single 'User' object or a list of type <User>.
    /// </summary>
    public class UserReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'User' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'User' DataObject.</returns>
            public static User Load(DataRow dataRow)
            {
                // Initial Value
                User user = new User();

                // Create field Integers
                int acceptedTermsOfServiceDatefield = 0;
                int activefield = 1;
                int createdDatefield = 2;
                int emailAddressfield = 3;
                int emailVerifiedfield = 4;
                int idfield = 5;
                int isAdminfield = 6;
                int lastLoginDatefield = 7;
                int namefield = 8;
                int passwordHashfield = 9;
                int profileVisibilityfield = 10;
                int storageUsedfield = 11;
                int totalLoginsfield = 12;
                int userNamefield = 13;

                try
                {
                    // Load Each field
                    user.AcceptedTermsOfServiceDate = DataHelper.ParseDate(dataRow.ItemArray[acceptedTermsOfServiceDatefield]);
                    user.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    user.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    user.EmailAddress = DataHelper.ParseString(dataRow.ItemArray[emailAddressfield]);
                    user.EmailVerified = DataHelper.ParseBoolean(dataRow.ItemArray[emailVerifiedfield], false);
                    user.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    user.IsAdmin = DataHelper.ParseBoolean(dataRow.ItemArray[isAdminfield], false);
                    user.LastLoginDate = DataHelper.ParseDate(dataRow.ItemArray[lastLoginDatefield]);
                    user.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    user.PasswordHash = DataHelper.ParseString(dataRow.ItemArray[passwordHashfield]);
                    user.ProfileVisibility = (ProfileVisibilityEnum) DataHelper.ParseInteger(dataRow.ItemArray[profileVisibilityfield], 0);
                    user.StorageUsed = DataHelper.ParseInteger(dataRow.ItemArray[storageUsedfield], 0);
                    user.TotalLogins = DataHelper.ParseInteger(dataRow.ItemArray[totalLoginsfield], 0);
                    user.UserName = DataHelper.ParseString(dataRow.ItemArray[userNamefield]);
                }
                catch
                {
                }

                // return value
                return user;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'User' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A User Collection.</returns>
            public static List<User> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<User> users = new List<User>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'User' from rows
                        User user = Load(row);

                        // Add this object to collection
                        users.Add(user);
                    }
                }
                catch
                {
                }

                // return value
                return users;
            }
            #endregion

        #endregion

    }
    #endregion

}
