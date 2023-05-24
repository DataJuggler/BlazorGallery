# DataJuggler.BlazorGallery
Blazor Gallery is now live https://blazorgallery.com

News

v1.1.9
5.17.2023: I added a Terms of Service component and a user must accept the Terms of Service
or they are sent to Google.

5.10.2023 - New video published

How To Create A Complete Blazor SQL Server Project In 5 Minutes
https://youtu.be/yQz1dqYiy2g

I learned this week how to create a Nuget package for a Blazor site. Never again will I have to delete
Weather Forecast and Counter pages.

Instructions to run this project:

To Install Via Nuget and DOT NET CLI 

    dotnet new install DataJuggler.BlazorGallery
    dotnet new DataJuggler.BlazorGallery

or

Clone this project from GitHub https://github.com/DataJuggler/BlazorGallery

1. Create a SQL Server Database named BlazorGallery
2. Execute BlazorGalleryDatabase.sql located in the SQL folder of this project.
3. Execute Insert Admin.sql
4. Create a connection string to your BlazorGallery database. 
Tip: DataTier.Net (used to build the datatier for this project) comes with a ConnectionStringBuilder app
in the tools folder.
https://github.com/DataJuggler/DataTier.Net

5. Create a system level environment variable named BlazorGalleryConnString and paste 
in the connection string from step 4.
6. Create a system level environment variable named BlazorGalleryKeyCode and 
make up a string for its value. This keycode is used to create password hashes 
when an account is created by a user.
7. Create a system level environment variable named BlazorGalleryURL
and set its value to https://localhost:44330 or the domain name if you are publishing.
8. Go to https://github.com/DataJuggler/BlazorGallery/ and leave a star
9. Go to https://youtube.com/DataJuggler" and subscribe. 
10. Tell a developer you know how easy Blazor Gallery makes it to create a Blazor SQL
Server image galleries.

Everything should work if you followed the above steps.

# Routing
Routing has been completed. 

Blazor Gallery Nuget Package was made with help from Build Copy. 

BuildCopy
https://github.com/DataJuggler/BuildCopy

BuildCopy will copy the files from a Visual Studio solution to an output folder. In this case, the output folder is ProjectTemplates\Working\Templates.
BuildCopy also allows you to set ignore folders, so I do not copy the .vs, .git, .bin, .obj, .templateconfig and a few others. 

Here is a video showing you how to setup this project, build the data tier for Blazor Gallery, and build your own DataTier.Net projects.

How To Create A Nuget Package For A Blazor Site<br>
https://youtu.be/K5WbNKUPDGs

Blazor Gallery was built using DataTier.Net

DataTier.Net
https://github.com/DataJuggler/DataTier.Net
An Entity Framework Alternative That Makes It Simple To Create Stored Procedure Powered Data Tiers

If you have any questions or problems, please create an issue on this projects Git Hub repo.
https://github.com/DataJuggler/BlazorGallery/

Thanks

Corby / Data Juggler
https://datajuggler.com 

