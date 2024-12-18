# MSACCESSREST
Building a REST API with MSSACCESS, Dapper, and EntityFrameWork.jet

We have a restricted lab which has VSCODE installed, and VisualStudio with no Databases.
VS2022 installs about 35GB of Stuff which are mostly noise, but it is required for some things.

Process as Follows:
1) Create a New Project in VSCODE!!!! for RESTAPIS from command line which creates a weather API. Dont Touch that for now as its helpful.
2) Install REST.Client in VSCODE, and Start Visual Studio with Weather.Controller.
3) Create Weather.http in VSCODE and Try Gets from weather. GET http://localhost/yourweather/api/location. This should work. Now you know you have a working api.
4) Install Dapper
5) Install MS Entity Framework, Design, Tools, Relational.
6) Install EntityFramework.Jet
7) Use MSAccess Sample DB for Students which saves you a LOT OF TIME....
5) Let Jet Model the Database via Reverse Engineering and output to MSACCESSMODELS using the -o statement.
6) Copy the WeatherController.cs to StudentController.cs, and GuardianController.cs
7) Delete Everything out of Weather, and Guardian.
8) Use the Samples as attached... and WALA working product.

9) Snapshot of Installed Versions, and Features included in ROOT of this project.
