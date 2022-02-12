# Hair Salon Manager

Hairdresser Manager is a RESTful API built using .NET 5 and Entity Framework Core. The architecture and design of the project is based on the Clean Architecture (sometimes it's been cited as onion or hexadecimal architecture).

## Used technologies and libraries

- .NET 5
- Entity framework core
- Identity
- Automapper
- Swagger

## Setup on containers

### Prerequisites

You will need the following tools:

- [docker](https://www.docker.com/get-started)
- [docker-compose](https://docs.docker.com/compose/install/)

### Setup

clone the repository and run this command at main repository folder:

```bash
docker-compose up
```

and wait before everything gets done.

## Setup on your machine

### Prerequisites

You will need the following tools:

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [MSSQL server engine](https://www.microsoft.com/en-US/sql-server/sql-server-downloads)

### Setup

Follow these steps to get your development environment set up:

1. Clone the repository
2. Set connection string to the database in appsettings.json in src/WebApi project
3. At the root directory, restore required packages by running:
   ```
   dotnet restore
   ```
4. Next, build the solution by running:
   ```
   dotnet build
   ```
5. Next, launch the app by running:
   ```
   dotnet run
   ```

## Usage

When your application is up you can view the api in swagger by entering swagger on

- [http://localhost:8080/swagger](http://localhost:8080/swagger) if the app is running in containers
- [http://localhost:5000/swagger](http://localhost:5000/swagger) if the app is running on your local machine

## License

[MIT](https://choosealicense.com/licenses/mit/)
