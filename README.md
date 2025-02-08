# Memo 🛹🎧

A Web application that creates and saves playlists and songs, letting you look up for them later, edit them when needed, and deleting them. A personal project to learn about .NET MVC.

## Stack 📚

- ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
- ASP.NET MVC
- ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
- Entity Framework
- ![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
- Ajax

## Requirements 💻

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- A code editor, like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Installation and configuration ⚙

1. Clone the repository:
   ```sh
   git clone https://github.com/cauaojordao/Memo.git
   ```
3. Restore the dependencies:
   ```sh
   dotnet restore
   ```
4. Configure the databank:
   - Edit the file `appsettings.json` with your string connection.
   - Do the migrations:
     ```sh
     dotnet ef database update
     ```
5. Run it:
   ```sh
   dotnet run
   ```
6. Acess the web application at `http://localhost:xxxx`.

## Funcionalities 🚀

- ✅ Create playlists
- ✅ Create songs for the playlists 
- ✅ Read playlists details
- ✅ Read songs details
- ✅ Update playlists songs, name and cover
- ✅ Update songs names, authors and urls
- ✅ Delete playlists
- ✅ Delete songs for the playlists
