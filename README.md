# Mars Rover Photos

[![Build Docker Image](https://github.com/TheLe0/mars-rover-photos/actions/workflows/docker-build.yml/badge.svg?branch=main&event=push)](https://github.com/TheLe0/mars-rover-photos/actions/workflows/docker-build.yml) [![Unit Tests](https://github.com/TheLe0/mars-rover-photos/actions/workflows/unit-tests.yml/badge.svg?branch=main&event=push)](https://github.com/TheLe0/mars-rover-photos/actions/workflows/unit-tests.yml) [![Publish on Docker Hub](https://github.com/TheLe0/mars-rover-photos/actions/workflows/docker-publish.yml/badge.svg?branch=main&event=release)](https://github.com/TheLe0/mars-rover-photos/actions/workflows/docker-publish.yml)

Mars Rover Photos is a web application that retrieves photos from the Mars rover using the NASA API. The app allows users to specify dates to view images taken by the mars rover on this [file](https://github.com/TheLe0/mars-rover-photos/blob/main/src/MarsRoverPhotos.Web/wwwroot/dates.txt). The data is loaded during the database migration process, where it is seeded into the SQLite database. Once the migration is complete, all the data can be viewed on the web page.

![image](https://github.com/user-attachments/assets/b047737f-3cb4-4b7f-aeb1-2eb8edc558f6)

## Configuration

There are three ways to run the application:

* Locally on your machine
* In a Docker container (by building the image locally)
* In a Docker container (by pulling the image from Docker Hub)

### Run locally

You need to have installed on your machine the .NET 8 version runtime.

And run the commands on your terminal:

```bash
dotnet restore
dotnet build --no-restore
dotnet run
```

### Run on a Docker container (by building the image locally)

You just need to have installed Docker on your machine.

```bash
docker build . --file Dockerfile --tag <YOUR-IMAGE-NAME>:<VERSION>
docker run -p 5000:8080 <YOUR-IMAGE-NAME>:<VERSION>
```
>Note: You can replace 'YOUR-IMAGE-NAME' and 'VERSION' with your preferred image name and version values.

### Run on a Docker container (by pulling the image from Docker Hub)

You just need to have installed Docker on your machine.

```bash
docker push thele0/mars-rover-photos:<TAGNAME>
docker run -p 5000:8080 thele0/mars-rover-photos:<TAGNAME>
```
>Note: You can replace 'TAGNAME' with your preferred image name and version values.
