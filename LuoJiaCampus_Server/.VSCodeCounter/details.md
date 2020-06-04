# Details

Date : 2020-06-03 18:25:17

Directory /Users/thomas/Desktop/LuoJiaCampus/LuoJiaCampus_Server

Total : 57 files,  48186 codes, 507 comments, 174 blanks, all 48867 lines

[summary](results.md)

## Files
| filename | language | code | comment | blank | total |
| :--- | :--- | ---: | ---: | ---: | ---: |
| [Controllers/AuthenticateController.cs](/Controllers/AuthenticateController.cs) | C# | 80 | 14 | 18 | 112 |
| [Controllers/CourseTableController.cs](/Controllers/CourseTableController.cs) | C# | 61 | 5 | 12 | 78 |
| [Controllers/NewsController.cs](/Controllers/NewsController.cs) | C# | 25 | 1 | 3 | 29 |
| [Controllers/UserInfoController.cs](/Controllers/UserInfoController.cs) | C# | 38 | 3 | 3 | 44 |
| [Crawler/CourseTableCrawler.cs](/Crawler/CourseTableCrawler.cs) | C# | 74 | 53 | 9 | 136 |
| [Crawler/JwCrawler.cs](/Crawler/JwCrawler.cs) | C# | 188 | 329 | 26 | 543 |
| [Crawler/StudentInfoCrawler.cs](/Crawler/StudentInfoCrawler.cs) | C# | 46 | 48 | 5 | 99 |
| [Crawler/encrypt.js](/Crawler/encrypt.js) | JavaScript | 518 | 2 | 8 | 528 |
| [LuoJiaCampus_Server.csproj](/LuoJiaCampus_Server.csproj) | XML | 16 | 0 | 5 | 21 |
| [Models/Comment.cs](/Models/Comment.cs) | C# | 17 | 0 | 4 | 21 |
| [Models/Course.cs](/Models/Course.cs) | C# | 14 | 0 | 6 | 20 |
| [Models/CourseScore.cs](/Models/CourseScore.cs) | C# | 12 | 0 | 1 | 13 |
| [Models/News.cs](/Models/News.cs) | C# | 20 | 0 | 4 | 24 |
| [Models/ScoreForm.cs](/Models/ScoreForm.cs) | C# | 8 | 0 | 5 | 13 |
| [Models/User.cs](/Models/User.cs) | C# | 19 | 0 | 0 | 19 |
| [ORM/ServerDBContext.cs](/ORM/ServerDBContext.cs) | C# | 13 | 0 | 4 | 17 |
| [Program.cs](/Program.cs) | C# | 24 | 0 | 3 | 27 |
| [Properties/launchSettings.json](/Properties/launchSettings.json) | JSON | 30 | 0 | 1 | 31 |
| [Startup.cs](/Startup.cs) | C# | 63 | 11 | 12 | 86 |
| [ToolClass/Constants.cs](/ToolClass/Constants.cs) | C# | 5 | 0 | 0 | 5 |
| [ToolClass/DecodeJwt.cs](/ToolClass/DecodeJwt.cs) | C# | 19 | 1 | 2 | 22 |
| [ToolClass/encryptPwd.cs](/ToolClass/encryptPwd.cs) | C# | 17 | 0 | 2 | 19 |
| [appsettings.Development.json](/appsettings.Development.json) | JSON | 9 | 0 | 1 | 10 |
| [appsettings.json](/appsettings.json) | JSON | 13 | 0 | 1 | 14 |
| [bin/Debug/netcoreapp3.1/LuoJiaCampus_Server.deps.json](/bin/Debug/netcoreapp3.1/LuoJiaCampus_Server.deps.json) | JSON | 5,038 | 0 | 0 | 5,038 |
| [bin/Debug/netcoreapp3.1/LuoJiaCampus_Server.runtimeconfig.dev.json](/bin/Debug/netcoreapp3.1/LuoJiaCampus_Server.runtimeconfig.dev.json) | JSON | 8 | 0 | 0 | 8 |
| [bin/Debug/netcoreapp3.1/LuoJiaCampus_Server.runtimeconfig.json](/bin/Debug/netcoreapp3.1/LuoJiaCampus_Server.runtimeconfig.json) | JSON | 12 | 0 | 0 | 12 |
| [bin/Debug/netcoreapp3.1/Properties/launchSettings.json](/bin/Debug/netcoreapp3.1/Properties/launchSettings.json) | JSON | 30 | 0 | 1 | 31 |
| [bin/Debug/netcoreapp3.1/appsettings.Development.json](/bin/Debug/netcoreapp3.1/appsettings.Development.json) | JSON | 9 | 0 | 1 | 10 |
| [bin/Debug/netcoreapp3.1/appsettings.json](/bin/Debug/netcoreapp3.1/appsettings.json) | JSON | 13 | 0 | 1 | 14 |
| [bin/Debug/netcoreapp3.1/publish/LuoJiaCampus_Server.deps.json](/bin/Debug/netcoreapp3.1/publish/LuoJiaCampus_Server.deps.json) | JSON | 5,038 | 0 | 0 | 5,038 |
| [bin/Debug/netcoreapp3.1/publish/LuoJiaCampus_Server.runtimeconfig.json](/bin/Debug/netcoreapp3.1/publish/LuoJiaCampus_Server.runtimeconfig.json) | JSON | 12 | 0 | 0 | 12 |
| [bin/Debug/netcoreapp3.1/publish/appsettings.Development.json](/bin/Debug/netcoreapp3.1/publish/appsettings.Development.json) | JSON | 9 | 0 | 1 | 10 |
| [bin/Debug/netcoreapp3.1/publish/appsettings.json](/bin/Debug/netcoreapp3.1/publish/appsettings.json) | JSON | 13 | 0 | 1 | 14 |
| [bin/Release/netcoreapp3.1/LuoJiaCampus_Server.deps.json](/bin/Release/netcoreapp3.1/LuoJiaCampus_Server.deps.json) | JSON | 5,038 | 0 | 0 | 5,038 |
| [bin/Release/netcoreapp3.1/LuoJiaCampus_Server.runtimeconfig.dev.json](/bin/Release/netcoreapp3.1/LuoJiaCampus_Server.runtimeconfig.dev.json) | JSON | 8 | 0 | 0 | 8 |
| [bin/Release/netcoreapp3.1/LuoJiaCampus_Server.runtimeconfig.json](/bin/Release/netcoreapp3.1/LuoJiaCampus_Server.runtimeconfig.json) | JSON | 12 | 0 | 0 | 12 |
| [bin/Release/netcoreapp3.1/Properties/launchSettings.json](/bin/Release/netcoreapp3.1/Properties/launchSettings.json) | JSON | 30 | 0 | 1 | 31 |
| [bin/Release/netcoreapp3.1/appsettings.Development.json](/bin/Release/netcoreapp3.1/appsettings.Development.json) | JSON | 9 | 0 | 1 | 10 |
| [bin/Release/netcoreapp3.1/appsettings.json](/bin/Release/netcoreapp3.1/appsettings.json) | JSON | 13 | 0 | 1 | 14 |
| [bin/Release/netcoreapp3.1/publish/Crawler/encrypt.js](/bin/Release/netcoreapp3.1/publish/Crawler/encrypt.js) | JavaScript | 518 | 2 | 8 | 528 |
| [bin/Release/netcoreapp3.1/publish/LuoJiaCampus_Server.deps.json](/bin/Release/netcoreapp3.1/publish/LuoJiaCampus_Server.deps.json) | JSON | 5,038 | 0 | 0 | 5,038 |
| [bin/Release/netcoreapp3.1/publish/LuoJiaCampus_Server.runtimeconfig.json](/bin/Release/netcoreapp3.1/publish/LuoJiaCampus_Server.runtimeconfig.json) | JSON | 12 | 0 | 0 | 12 |
| [bin/Release/netcoreapp3.1/publish/appsettings.Development.json](/bin/Release/netcoreapp3.1/publish/appsettings.Development.json) | JSON | 9 | 0 | 1 | 10 |
| [bin/Release/netcoreapp3.1/publish/appsettings.json](/bin/Release/netcoreapp3.1/publish/appsettings.json) | JSON | 13 | 0 | 1 | 14 |
| [obj/Debug/netcoreapp3.1/.NETCoreApp,Version=v3.1.AssemblyAttributes.cs](/obj/Debug/netcoreapp3.1/.NETCoreApp,Version=v3.1.AssemblyAttributes.cs) | C# | 3 | 1 | 1 | 5 |
| [obj/Debug/netcoreapp3.1/LuoJiaCampus_Server.AssemblyInfo.cs](/obj/Debug/netcoreapp3.1/LuoJiaCampus_Server.AssemblyInfo.cs) | C# | 9 | 10 | 5 | 24 |
| [obj/Debug/netcoreapp3.1/LuoJiaCampus_Server.MvcApplicationPartsAssemblyInfo.cs](/obj/Debug/netcoreapp3.1/LuoJiaCampus_Server.MvcApplicationPartsAssemblyInfo.cs) | C# | 4 | 9 | 5 | 18 |
| [obj/Debug/netcoreapp3.1/project.razor.json](/obj/Debug/netcoreapp3.1/project.razor.json) | JSON | 20,614 | 0 | 0 | 20,614 |
| [obj/Debug/netcoreapp3.1/staticwebassets/LuoJiaCampus_Server.StaticWebAssets.xml](/obj/Debug/netcoreapp3.1/staticwebassets/LuoJiaCampus_Server.StaticWebAssets.xml) | XML | 1 | 0 | 0 | 1 |
| [obj/LuoJiaCampus_Server.csproj.nuget.dgspec.json](/obj/LuoJiaCampus_Server.csproj.nuget.dgspec.json) | JSON | 99 | 0 | 0 | 99 |
| [obj/LuoJiaCampus_Server.csproj.nuget.g.props](/obj/LuoJiaCampus_Server.csproj.nuget.g.props) | XML | 15 | 0 | 0 | 15 |
| [obj/LuoJiaCampus_Server.csproj.nuget.g.targets](/obj/LuoJiaCampus_Server.csproj.nuget.g.targets) | XML | 6 | 0 | 0 | 6 |
| [obj/Release/netcoreapp3.1/LuoJiaCampus_Server.AssemblyInfo.cs](/obj/Release/netcoreapp3.1/LuoJiaCampus_Server.AssemblyInfo.cs) | C# | 9 | 9 | 5 | 23 |
| [obj/Release/netcoreapp3.1/LuoJiaCampus_Server.MvcApplicationPartsAssemblyInfo.cs](/obj/Release/netcoreapp3.1/LuoJiaCampus_Server.MvcApplicationPartsAssemblyInfo.cs) | C# | 4 | 9 | 5 | 18 |
| [obj/Release/netcoreapp3.1/staticwebassets/LuoJiaCampus_Server.StaticWebAssets.xml](/obj/Release/netcoreapp3.1/staticwebassets/LuoJiaCampus_Server.StaticWebAssets.xml) | XML | 1 | 0 | 0 | 1 |
| [obj/project.assets.json](/obj/project.assets.json) | JSON | 5,210 | 0 | 0 | 5,210 |

[summary](results.md)