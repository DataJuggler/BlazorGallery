

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

    #region class ImageLikeMethods
    /// <summary>
    /// This class contains methods for modifying a 'ImageLike' object.
    /// </summary>
    public class ImageLikeMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ImageLikeMethods' object.
        /// </summary>
        public ImageLikeMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteImageLike(ImageLike)
            /// <summary>
            /// This method deletes a 'ImageLike' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ImageLike' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteImageLike(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteImageLikeStoredProcedure deleteImageLikeProc = null;

                    // verify the first parameters is a(n) 'ImageLike'.
                    if (parameters[0].ObjectValue as ImageLike != null)
                    {
                        // Create ImageLike
                        ImageLike imageLike = (ImageLike) parameters[0].ObjectValue;

                        // verify imageLike exists
                        if(imageLike != null)
                        {
                            // Now create deleteImageLikeProc from ImageLikeWriter
                            // The DataWriter converts the 'ImageLike'
                            // to the SqlParameter[] array needed to delete a 'ImageLike'.
                            deleteImageLikeProc = ImageLikeWriter.CreateDeleteImageLikeStoredProcedure(imageLike);
                        }
                    }

                    // Verify deleteImageLikeProc exists
                    if(deleteImageLikeProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ImageLikeManager.DeleteImageLike(deleteImageLikeProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
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

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ImageLike' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ImageLike' to delete.
            /// <returns>A PolymorphicObject object with all  'ImageLikes' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ImageLike> imageLikeList =  null;

                // Create FetchAll StoredProcedure
                FetchAllImageLikesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ImageLikeParameter
                    // Declare Parameter
                    ImageLike paramImageLike = null;

                    // verify the first parameters is a(n) 'ImageLike'.
                    if (parameters[0].ObjectValue as ImageLike != null)
                    {
                        // Get ImageLikeParameter
                        paramImageLike = (ImageLike) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllImageLikesProc from ImageLikeWriter
                    fetchAllProc = ImageLikeWriter.CreateFetchAllImageLikesStoredProcedure(paramImageLike);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    imageLikeList = this.DataManager.ImageLikeManager.FetchAllImageLikes(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(imageLikeList != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = imageLikeList;
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

            #region FindImageLike(ImageLike)
            /// <summary>
            /// This method finds a 'ImageLike' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ImageLike' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindImageLike(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ImageLike imageLike = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindImageLikeStoredProcedure findImageLikeProc = null;

                    // verify the first parameters is a 'ImageLike'.
                    if (parameters[0].ObjectValue as ImageLike != null)
                    {
                        // Get ImageLikeParameter
                        ImageLike paramImageLike = (ImageLike) parameters[0].ObjectValue;

                        // verify paramImageLike exists
                        if(paramImageLike != null)
                        {
                            // Now create findImageLikeProc from ImageLikeWriter
                            // The DataWriter converts the 'ImageLike'
                            // to the SqlParameter[] array needed to find a 'ImageLike'.
                            findImageLikeProc = ImageLikeWriter.CreateFindImageLikeStoredProcedure(paramImageLike);
                        }

                        // Verify findImageLikeProc exists
                        if(findImageLikeProc != null)
                        {
                            // Execute Find Stored Procedure
                            imageLike = this.DataManager.ImageLikeManager.FindImageLike(findImageLikeProc, dataConnector);

                            // if dataObject exists
                            if(imageLike != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = imageLike;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertImageLike (ImageLike)
            /// <summary>
            /// This method inserts a 'ImageLike' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ImageLike' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertImageLike(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ImageLike imageLike = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertImageLikeStoredProcedure insertImageLikeProc = null;

                    // verify the first parameters is a(n) 'ImageLike'.
                    if (parameters[0].ObjectValue as ImageLike != null)
                    {
                        // Create ImageLike Parameter
                        imageLike = (ImageLike) parameters[0].ObjectValue;

                        // verify imageLike exists
                        if(imageLike != null)
                        {
                            // Now create insertImageLikeProc from ImageLikeWriter
                            // The DataWriter converts the 'ImageLike'
                            // to the SqlParameter[] array needed to insert a 'ImageLike'.
                            insertImageLikeProc = ImageLikeWriter.CreateInsertImageLikeStoredProcedure(imageLike);
                        }

                        // Verify insertImageLikeProc exists
                        if(insertImageLikeProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ImageLikeManager.InsertImageLike(insertImageLikeProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateImageLike (ImageLike)
            /// <summary>
            /// This method updates a 'ImageLike' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ImageLike' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateImageLike(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ImageLike imageLike = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateImageLikeStoredProcedure updateImageLikeProc = null;

                    // verify the first parameters is a(n) 'ImageLike'.
                    if (parameters[0].ObjectValue as ImageLike != null)
                    {
                        // Create ImageLike Parameter
                        imageLike = (ImageLike) parameters[0].ObjectValue;

                        // verify imageLike exists
                        if(imageLike != null)
                        {
                            // Now create updateImageLikeProc from ImageLikeWriter
                            // The DataWriter converts the 'ImageLike'
                            // to the SqlParameter[] array needed to update a 'ImageLike'.
                            updateImageLikeProc = ImageLikeWriter.CreateUpdateImageLikeStoredProcedure(imageLike);
                        }

                        // Verify updateImageLikeProc exists
                        if(updateImageLikeProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ImageLikeManager.UpdateImageLike(updateImageLikeProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
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
