Instructions


--------------------------------------------------
Push on git

git add .
git config --global user.email "*******"
git commit -m "*******"
git branch -m main
git push -u origin main
--------------------------------------------------

Create project

Пред этим зайти в папку
dotnet new sln
dotnet new avalonia.mvvm -n "Название проекта"
dotnet sln add "Название проекта"

--------------------------------------------------
Using

listbox
textbox
combobox
--------------------------------------------------
https://docs.avaloniaui.net/docs/styling/styles
https://learn.microsoft.com/ru-ru/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli - Как подключать базу данных
PM> Scaffold-DbContext "Server=PC-232-06\SQLEXPRESS;Database=KRUCHININ06;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
