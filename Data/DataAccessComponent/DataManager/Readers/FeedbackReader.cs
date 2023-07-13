

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class FeedbackReader
    /// <summary>
    /// This class loads a single 'Feedback' object or a list of type <Feedback>.
    /// </summary>
    public class FeedbackReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Feedback' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Feedback' DataObject.</returns>
            public static Feedback Load(DataRow dataRow)
            {
                // Initial Value
                Feedback feedback = new Feedback();

                // Create field Integers
                int createdDatefield = 0;
                int detailsfield = 1;
                int feedbackTypefield = 2;
                int idfield = 3;
                int permissionToEmailfield = 4;
                int respondedfield = 5;
                int respondedByIdfield = 6;
                int respondedDatefield = 7;
                int userIdfield = 8;

                try
                {
                    // Load Each field
                    feedback.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    feedback.Details = DataHelper.ParseString(dataRow.ItemArray[detailsfield]);
                    feedback.FeedbackType = (FeedbackTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[feedbackTypefield], 0);
                    feedback.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    feedback.PermissionToEmail = DataHelper.ParseBoolean(dataRow.ItemArray[permissionToEmailfield], false);
                    feedback.Responded = DataHelper.ParseBoolean(dataRow.ItemArray[respondedfield], false);
                    feedback.RespondedById = DataHelper.ParseInteger(dataRow.ItemArray[respondedByIdfield], 0);
                    feedback.RespondedDate = DataHelper.ParseDate(dataRow.ItemArray[respondedDatefield]);
                    feedback.UserId = DataHelper.ParseInteger(dataRow.ItemArray[userIdfield], 0);
                }
                catch
                {
                }

                // return value
                return feedback;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Feedback' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Feedback Collection.</returns>
            public static List<Feedback> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Feedback> feedbacks = new List<Feedback>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Feedback' from rows
                        Feedback feedback = Load(row);

                        // Add this object to collection
                        feedbacks.Add(feedback);
                    }
                }
                catch
                {
                }

                // return value
                return feedbacks;
            }
            #endregion

        #endregion

    }
    #endregion

}
