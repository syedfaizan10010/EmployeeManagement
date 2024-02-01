Employee Management Project using dotNet 8.0
.Net SDK -> https://dotnet.microsoft.com/en-us/download/dotnet/8.0
Packages needs to be installed:
EntityFramework -> dotnet add package Microsoft.EntityFrameworkCore --version 8.0.1 //Version can be specified based on latest available
EntityFramework Tool -> dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.1 //Version can be specified based on latest available
EntityFramework Sql Server -> dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.1 //Version can be specified based on latest available

Replace Connection string in appSettings.Json:
    "connMSSQL": "Server=.;Database=DotnetCRUD;Trusted_Connection=True;TrustServerCertificate=True;"
Use your own Server name in place of .
