# DataJuggler.BlazorGallery
Blazor Gallery is now working. 

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


# Important!
If you created the project from Nuget CLI, you must create an Upload folder in wwwroot of this project (next to images)

1. Create a SQL Server Database named BlazorGallery
2. Execute BlazorGalleryDatabase.sql located in the SQL folder of this project.
3. Execute Insert Admin.sql
4. Create a connection string to your BlazorGallery database. 
Tip: DataTier.Net (used to build the datatier for this project) comes with a ConnectionStringBuilder app in the tools folder.
https://github.com/DataJuggler/DataTier.Net

5. Create a user level environment variable named BlazorGalleryConnString and paste in connection string from step 4
6. Create a user level environment variable named BlazorGalleryKeyCode and make up a string for its value.
This keycode is used to create password hashes when an account is created by a user.
7. Go to https://github.com/DataJuggler/BlazorGallery/ and leave a star
8. Go to https://youtube.com/DataJuggler" and subscribe. 
9. Tell a developer you know how easy Blazor Gallery makes it to create a Blazor SQL Server site.

Everything should work if you followed the above steps.

Blazor Gallery Nuget Package was made with Build Copy. 

BuildCopy
https://github.com/DataJuggler/BuildCopy

BuildCopy will copy the files from a Visual Studio solution to an output folder. In this case, the output folder is ProjectTemplates\Working\Templates.
BuildCopy also allows you to set ignore folders, so I do not copy the .vs, .git, .bin, .obj, .templateconfig and a few others. 

Here is a video showing you how to setup this project, build the data tier for Blazor Gallery, and build your own DataTier.Net projects.

How To Create A Nuget Package For A Blazor Site<br>
https://youtu.be/K5WbNKUPDGs

Blazor Gallery was build using DataTier.Net

DataTier.Net
https://github.com/DataJuggler/DataTier.Net
An Entity Framework Alternative That Makes It Simple To Create Stored Procedure Powered Data Tiers

If you think Blazor Gallery is worth the price, please leave a star and / or subscribe to my YouTube channel:
https://youtube.com/DataJuggler

If you have any questions or problems, please create an issue on this projects Git Hub repo.
https://github.com/DataJuggler/BlazorGallery/

Thanks

Corby / Data Juggler
https://datajuggler.com 

