FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MarsRoverPhotos.Web/MarsRoverPhotos.Web.csproj", "MarsRoverPhotos.Web/"]
RUN dotnet restore "MarsRoverPhotos.Web/MarsRoverPhotos.Web.csproj"
COPY . .
WORKDIR "/src/MarsRoverPhotos.Web"
RUN dotnet build "MarsRoverPhotos.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MarsRoverPhotos.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

RUN dotnet tool install --global dotnet-ef --version 8.0.0

WORKDIR /src
RUN dotnet ef database update --project MarsRoverPhotos.Data/MarsRoverPhotos.Data.csproj --startup-project MarsRoverPhotos.Web/MarsRoverPhotos.Web.csproj

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarsRoverPhotos.Web.dll"]
