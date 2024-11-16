FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
ENV DockerHOME=/app
WORKDIR $DockerHOME
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

RUN dotnet tool install --global dotnet-ef --version 8.0.0

ENV PATH="${PATH}:/root/.dotnet/tools"

COPY . $DockerHOME 

RUN dotnet restore

RUN dotnet build -c $BUILD_CONFIGURATION -o $DockerHOME/build

RUN dotnet ef database update --project /src/MarsRoverPhotos.Data/MarsRoverPhotos.Data.csproj --startup-project /src/MarsRoverPhotos.Web/MarsRoverPhotos.Web.csproj

RUN mkdir -p /app/build && cp /src/MarsRoverPhotos.Web/app.db /app/build/app.db

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish .

COPY --from=build /app/build/app.db .

ENTRYPOINT ["dotnet", "MarsRoverPhotos.Web.dll"]

