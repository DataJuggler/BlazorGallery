# DataJuggler.BlazorGallery
BlazorGallery is a working SQL Server C# Blazor image gallery project and Nuget package, that can be setup in about 5 to 10 minutes.

# Live Demo
Blazor Gallery is now live https://blazorgallery.com

# Screenshot
<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/BlazorGalleryScreenShot.png height=480 width=886 />

# News

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

# Routing
Routing has been completed. You can now share public galleries with a url such as:
https://blazorgallery.com/Gallery/User/Folder

If the folder is not specified, the Home folder for that UserName is shown if it exists. 

# Feature Requests
What features would you like to see in a portfolio site? 

Here are a few ideas I have thought of. Feel free to reach out here or in a video comment and describe your idea.

# In Progress

I am about to start working on Public Galleries - Such as Main that are not specific to one user. This will be shown on the main screen to anyone not logged and / or
logged in users. The plan is to allow everyone some time on the main screen. Liked and commented images are allowed to expire slower.

# My THoughts 

1. Add video
2. Add ability for people to comment, like, follow, etc. other users.
3. Add ability to block users.
4. For now the Gallery routing is kind of limited, because I impersonate the owner of the gallery in ViewOnlyMode. From here I need to add the
   ability for logged in users to be able to view other galleries, and retain they are logged in, so a user can like, comment, etc.
5. Contests - I recently bought a domain antcontest.com, which is a play on contestant. People could create contests for best AI Image Gallery
6. Access To Premium Galleries (maybe) - If people wanted to sell access to a gallery for a certain number of credits.

Those are just a few ideas.
   
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

