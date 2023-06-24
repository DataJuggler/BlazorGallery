

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class MainGalleryViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'MainGalleryView' object.
    /// </summary>
    public class MainGalleryViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'MainGalleryViewMethods' object.
        /// </summary>
        public MainGalleryViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'MainGalleryView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'MainGalleryView' to delete.
            /// <returns>A PolymorphicObject object with all  'MainGalleryViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<MainGalleryView> mainGalleryViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllMainGalleryViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get MainGalleryViewParameter
                    // Declare Parameter
                    MainGalleryView paramMainGalleryView = null;

                    // verify the first parameters is a(n) 'MainGalleryView'.
                    if (parameters[0].ObjectValue as MainGalleryView != null)
                    {
                        // Get MainGalleryViewParameter
                        paramMainGalleryView = (MainGalleryView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllMainGalleryViewsProc from MainGalleryViewWriter
                    fetchAllProc = MainGalleryViewWriter.CreateFetchAllMainGalleryViewsStoredProcedure(paramMainGalleryView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    mainGalleryViewListCollection = this.DataManager.MainGalleryViewManager.FetchAllMainGalleryViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(mainGalleryViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = mainGalleryViewListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
