FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY HairdresserManager.Api/*.csproj ./HairdresserManager.Api/
COPY HairdresserManager.Shared/*.csproj ./HairdresserManager.Shared/
RUN dotnet restore HairdresserManager.Api/

# Copy everything else and build
COPY HairdresserManager.Api/. ./HairdresserManager.Api/.
COPY HairdresserManager.Shared/. ./HairdresserManager.Shared/.
RUN dotnet publish HairdresserManager.Api/*.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "HairdresserManager.Api.dll"]
