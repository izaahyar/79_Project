1. yang harus di Instal Nuget Packages :
- SDK Version: 5.0.201
- Kendo.for.AspNet.Core yang saya gunakan (2019.1.115) 
- Microsoft.AspNetCore.App (2.2.0)
- Microsoft.AspNetCore.Razor.Design (2.2.0)
- Microsoft.EntityFramework.Analyzers (2.2.4)
- Microsoft.EntityFramework.Design (2.2.4)
- Microsoft.EntityFramework.SqlServer (2.2.4)
- Microsoft.NETCore.App (2.2.0)
2. Untuk Scafolding DbContext 
Masuk Ke Tools -> Nuget Package Manager -> Package Manager Console Lalu jalan kan scafolding berikut : 
Scaffold-DbContext "Server=DESKTOP-OLC72DS;Database=DB_79;UID=**;password=**;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -f
3. Pastikan dalam keadaan online karena ada beberapa jquery CDN

 