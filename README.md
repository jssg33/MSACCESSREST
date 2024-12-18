# MSACCESSREST
Building a REST API with MSSACCESS, Dapper, and EntityFrameWork.jet

We have a restricted lab which has VSCODE installed, and VisualStudio with no Databases.
VS2022 installs about 35GB of Stuff which are mostly noise, but it is required for some things.

Process as Follows:
1) Create a New Project in VSCODE!!!! for RESTAPIS from command line which creates a weather API. Dont Touch that for now as its helpful.
2) THE VSCODE Project for this will create a Program.cs for Weather App, and a Weather Controller under ./Controllers/. Do not touch them for now. They dont hurt, and add the SWAGGER tools you need.
3) Install REST.Client in VSCODE, and Start Visual Studio with Weather.Controller. [Both VSCODE and VS2022 SHOULD BE RUNNING WITH VSCODE NOW THE CLIENT] [VS THE SERVER]
4) Create Weather.http in VSCODE and Try Gets from weather. GET http://localhost/yourweather/api/location. This should work. Now you know you have a working api.
5) Install Dapper
6) Install MS Entity Framework, Design, Tools, Relational.
7) Install EntityFramework.Jet
8) Use MSAccess Sample DB for Students which saves you a LOT OF TIME....
9) Create a Connection to your MSACCESS Database in VisualStudio via DBMapper tool. When you select this DB this should give you a working connection string like the one below. This can be moved to your AppSettings.JSON but
    for speed purposes do something like this.
10)Let Jet Model the Database via Reverse Engineering and output to MSACCESSMODELS using the -o statement.
dotnet ef dbcontext scaffold "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\stritzj\Documents\Database2.accdb" EntityFrameworkCore.Jet -o MODELSACCESS 
11) Create a New Controller (WITHOUT ENTITY FRAMEWORK!!!! AS JET DOESNT WORK FOR SOMEREASON) But you will need a Controller for MSSACCESSCONTROLLER.CS. It will ask you to select the Model you want to add to the controller.
You are going to go through this process for each table you need a REST API.
12) Copy the WeatherController.cs to StudentController.cs, and GuardianController.cs
13) Delete Everything out of Weather, and Guardian.
14) Use the Samples as attached... and WALA working product.
15) Snapshot of Installed Versions, and Features included in ROOT of this project.

16) WARNING---> THIS IS A REVERSE ENGINEERED DATABASE(DB FIRST MODEL).
17) YOU WIlL SEE VERY COMPLICATED CODE FIRST EXAMPLES WHICH LITERALLY BUILD DYNAMIC SQL STATEMENTS... THIS IS WAAAAAAY TOO COMPLICATED FOR HUMANS.
18) THE MODELS REPRESENT THE DATABASE ENTITY DESIGN. THATS IT.
19) THE DB CONTEXT IS CREATED AUTOMATICALLY WITH THE CONNECTION STRING. ITS INCLUDED BY DEFAULT IN THE MODELS DIRECTORY IN THE SAME NAMESPACE.
20) THE CONTROLLERS BUILD THE REST APIS AND WILL AUTOMATICALLY MAP TO THE SAME NAMES SPACE AS WEATHER(WHY YOU DONT WANT TO TOUCH IT). THINK OF IT AS A DIAGNOSTIC
21) FOR YOUR APP.

21) THATS IT... YOU DONT NEED DTOS, INTERFACES, OR SERVICES... ALL THE LOGIC IS AT THE CONTROLLER LEVEL IN THE DB FIRST MODEL.

22) TRAINING-> THIS GUYS FIRST THREE VIDEOS ARE VERY GOOD. CHECK HIM OUT AND MAKE SURE TO LIKE.
23) https://youtu.be/CLVJVA9cTuU?si=diUKcKq1SoLVvMvb 
