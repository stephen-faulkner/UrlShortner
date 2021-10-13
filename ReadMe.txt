A brief URL shortener written in C# and using a MS SQL database to store url records.

A backup of the database has been included along scripts to create the database from scratch. The scripts are listed in the order they should be created.
The current database connection runs off of localhost, change this in web.config if creating the databse on a different machine.

There is an issue in Visual Studio with committing all of the contents of the bin folder to Github, if you receive the error "Could not find a part of the path '..\bin\roslyn\csc.exe', run the command 'Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r' in the package manager console to install the necessary files.


***Improvements***
Better exception handling should be added.
UI design could be improved on.
Add url redirects so only the homepage and urlshortner redirects work.

