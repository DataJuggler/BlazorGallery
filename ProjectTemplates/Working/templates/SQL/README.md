# DataJuggler.BlazorGallery
Blazor Gallery is a work in progress. I learned this week how to create a Blazor Website as a Nuget package, and I wrote a program to help me with
the CI / CD called BuildCopy.

BuildCopy
https://github.com/DataJuggler/BuildCopy

BuildCopy will copy the files from a Visual Studio solution to an output folder. In this case, the output folder is ProjectTemplates\Working\Templates.
BuildCopy also allows you to set ignore folders, so I do not copy the .vs, .git, .bin, .obj, .templateconfig and a few others. 

I am building the data tier now in a video. If you want to follow along, clone this project and create a SQL Server database named BlazorGallery.
Then execute the BlazorGalleryDatabase.sql script to create the tables and stored procedures.

After executing the above sql script, execute Insert Admin.