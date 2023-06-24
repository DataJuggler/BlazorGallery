# DataJuggler.BlazorGallery
BlazorGallery is a working SQL Server C# Blazor image gallery project and Nuget package, that can be setup in about 5 to 10 minutes.

# Live Demo
Blazor Gallery is now live https://blazorgallery.com

# Screenshot
<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/BlazorGalleryScreenShot2.png height=480 width=886 />

# New Video
[![Blazor Gallery Deserves A Star Video](https://img.youtube.com/vi/HAMgeaCuvHY/0.jpg)](https://www.youtube.com/watch?v=HAMgeaCuvHY)

# Instructions to run this project:

To Install Via Nuget and DOT NET CLI, navigate to the folder you wish to create your project in

    cd c:\Projects\BlazorGallery
    dotnet new install DataJuggler.BlazorGallery
    dotnet new DataJuggler.BlazorGallery

or

Clone this project from GitHub https://github.com/DataJuggler/BlazorGallery

# Setup Instructions

1. Create a SQL Server Database named BlazorGallery
2. Execute BlazorGalleryDatabase.sql located in the SQL folder of this project.
3. Execute Insert Admin.sql located in the SQL folder of this project.
4. Create a connection string to your BlazorGallery database.<br>
Tip: DataTier.Net (used to build the datatier for this project) comes with a ConnectionStringBuilder app
in the tools folder, or install the release version and Connection String Builder is installed also.
https://github.com/DataJuggler/DataTier.Net

5. Create a system level environment variable named BlazorGalleryConnString and paste 
in the connection string from step 4.
6. Create a system level environment variable named BlazorGalleryKeyCode and 
make up a string for its value. This keycode is used to create password hashes 
when an account is created by a user.
7. Create a system level environment variable named BlazorGalleryURL
and set its value to https://localhost:44330 or the domain name if you are publishing.
8. Go to https://github.com/DataJuggler/BlazorGallery/ and leave a star
9. Go to https://youtube.com/DataJuggler and subscribe. 
10. Tell a developer you know how easy Blazor Gallery makes it to create a Blazor SQL
Server image galleries.
11. Tell a graphics designer, photographer or 3D artist about Blazor Gallery.

# Infamous Last Words

Everything should work if you followed the above steps.

# News

1.4.1
6.24.2023: Sign Out now clears the GalleryOwner and SelectedFolder from MainLayout, which prevents
the folders from showing after you sign out.

1.4.0
6.24.2023: I created a MainGalleryComponent, MainGalleryImageViewer, Gallery page and the database
has a new view MainGalleryView and two new stored procedures MainGalleryView_FetchAll and 
MainGalleryView_FetchMostRecent. I also refactored how the Index and Gallery pages work, so that the
LoggedInUser stays logged in, even when viewing another user's galleries. Also, there is now a button to
go back to the User's Galleries while viewing the MainGallery if there is a logged in user.

1.3.7
6.17.2023: A new user needs to be shown the Email Verification component during the signup
process for the live site (if Admin.RequireEmailVerification is true).

1.3.6
6.17.2023: Fixed the Terms of Service component where a new user could not upload.

1.3.5
6.17.2023: Previous publish had the incorrect version number.

1.3.4
6.17.2023: Terms of Service Component was not replacing the ParentMainLayout object
which had the accepted terms of service date.

1.3.3
6.17.2023: I added a slide show feature to the FullScreenImageViewer and MainLayout.                      

v1.3.2
6.15.2023: I added a copy direct link button to the FullScreenImageViewer component.

v1.3.0
6.7.2023: My first attempt for fixing BlazorGallery to run without EmailVerification didn't work.
Now this is fixed, and after the user accepts the terms of service, ParentMainLayout.LoggedInUser
is replaced. This fixes the upload button not showing up.

v1.2.9
6.6.2023: I realized when I added Email Verification, I made the app stop working for people
who did not have Azure Email Service setup and configured. To fix this, I added a new property
to the Admin table 'EmailVerificationRequired'. This value is set to 0 in Insert Admin.sql unless you
change it. This allows people to test in Visual Studio without wiring up Email Verification.

v1.2.7
6.3.2023: I have finished adding Email verification using Azure Email Service.
The way I wrote this, if you want to implement Email Verification Required, set an Environment
Variable named BlazorGalleryEmail to the connection string of your Azure Email Service domain.
If you don't set this environment variable, you can test in Visual Studio without email verification
required.

v1.2.5
5.31.2023: I have added numerous features including, but not limited to:    
    1. You can now rename folders by double clicking
    2. I changed the logo and images to a dark theme. 
    3. Redid the layout to be fixed, so things do not jump around when the Copy URL button is clicked.

v1.2.0:
5.27.2023: I added a View Full Screen button to each image and created a FullScreenImageViewer component.
It is not actually full screen, but in ViewImage mode, only the selected image is shown.
I also added a field for Image.LikesCount and User.ProfileVisibility. These two fields are not shown 
yet, but i did create a component that prompts a user if they wish to show their profile publicly.
My plan is to create a public gallery and all images are allocated a certain amount of time on the main screen. The more likes an image
gets, the longer it gets to stay.  The Nuget package and database scripts have also been updated.

v.1.1.2
5.19.2023: I added a Copy button to each folder. Now you can copy URL's and share URL's publicly for posting on social media.

v1.1.9
5.17.2023: I added a Terms of Service component and a user must accept the Terms of Service
or they are sent to Google.

5.10.2023 - New video published

How To Create A Complete Blazor SQL Server Project In 5 Minutes
https://youtu.be/yQz1dqYiy2g

I learned this week how to create a Nuget package for a Blazor site. Never again will I have to delete
Weather Forecast and Counter pages.

# Routing
Routing has been completed. You can now share public galleries with a url such as:
https://blazorgallery.com/Gallery/User/Folder

If the folder is not specified, the Home folder for that UserName is shown if it exists. 

# Feature Requests
What features would you like to see in a portfolio site? 

Here are a few ideas I have thought of. Feel free to reach out here or in a video comment and describe your idea.

# In Progress 6.18.2023

I plan on implementing Forgot Password and CHange Password this week, unless I find a job.

# Possible Feature Requests Coming

1. Add video
2. Add ability for people to comment, like, follow, etc. other users.
3. Add ability to block users.
4. For now the Gallery routing is kind of limited, because I impersonate the owner of the gallery in ViewOnlyMode. From here I need to add the
   ability for logged in users to be able to view other galleries, and retain they are logged in, so a user can like, comment, etc.
5. Contests - I recently bought a domain antcontest.com, which is a play on contestant. I may create a contest for best AI Image Gallery to kick it off.
6. Access To Premium Galleries (maybe) - If people wanted to sell access to a gallery for a certain number of credits.
7. Water Mark Images - If users want to share images, but prevent people from making copies

Those are just a few ideas, please let me know yours.

# Completed Features

6.17.2023: Slide Show Feature for a folder, the previous and next buttons show dynamically and allow scrolling through a gallery (folder).
6.15.2023: Copy Direct Link To Image
6.3.2023: Added Email Verification using Azure Email Communication Services
5.31.2023: Renaming folders
5.27.2023: Created a Full Screen Image Viewer component
Early June: Deleting of images from the database and file system when a folder is deleted.
   
# How I Built The Nuget Package

Blazor Gallery Nuget Package was made with help from Build Copy. 

BuildCopy
https://github.com/DataJuggler/BuildCopy

BuildCopy will copy the files from a Visual Studio solution to an output folder. In this case, the output folder is ProjectTemplates\Working\Templates.
BuildCopy also allows you to set ignore folders, so I do not copy the .vs, .git, .bin, .obj, .templateconfig and a few others. 

Here is a video showing you how to setup this project, build the data tier for Blazor Gallery, and build your own DataTier.Net projects.

How To Create A Nuget Package For A Blazor Site<br>
https://youtu.be/K5WbNKUPDGs

# Blazor Gallery Data Tier Uses All Stored Procedures

Blazor Gallery was built using DataTier.Net

DataTier.Net
https://github.com/DataJuggler/DataTier.Net
An Entity Framework Alternative That Makes It Simple To Create Stored Procedure Powered Data Tiers

If you have any questions or problems, please create an issue on this projects Git Hub repo.
https://github.com/DataJuggler/BlazorGallery/

Thanks

Corby / Data Juggler
https://datajuggler.com 

