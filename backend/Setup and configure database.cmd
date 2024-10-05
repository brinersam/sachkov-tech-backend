docker-compose up -d
dotnet-ef database drop -f -c WriteDbContext -p .\src\Issues\SachkovTech.Issues.Infrastructure\ -s .\src\SachkovTech.Web\
dotnet-ef database drop -f -c FilesWriteDbContext -p .\src\Files\SachkovTech.Files.Infrastructure\ -s .\src\SachkovTech.Web\

dotnet-ef migrations remove -c WriteDbContext -p .\src\Issues\SachkovTech.Issues.Infrastructure\ -s .\src\SachkovTech.Web\
dotnet-ef migrations remove -c FilesWriteDbContext -p .\src\Files\SachkovTech.Files.Infrastructure\ -s .\src\SachkovTech.Web\

dotnet-ef migrations add init -c WriteDbContext -p .\src\Issues\SachkovTech.Issues.Infrastructure\ -s .\src\SachkovTech.Web\
dotnet-ef migrations add init -c FilesWriteDbContext -p .\src\Files\SachkovTech.Files.Infrastructure\ -s .\src\SachkovTech.Web\

dotnet-ef database update -c WriteDbContext -p .\src\Issues\SachkovTech.Issues.Infrastructure\ -s .\src\SachkovTech.Web\
dotnet-ef database update -c FilesWriteDbContext -p .\src\Files\SachkovTech.Files.Infrastructure\ -s .\src\SachkovTech.Web\

pause