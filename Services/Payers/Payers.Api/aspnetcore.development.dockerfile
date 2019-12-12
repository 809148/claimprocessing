# Microsoft has a new "Hub" location for images that 
# can be used for ASP.NET Core 2+
# FROM mcr.microsoft.com/dotnet/core/sdk:2.2

# FROM microsoft/dotnet:2.2-sdk

# LABEL author="rajshekhar jagadi"

# ENV DOTNET_USE_POLLING_FILE_WATCHER=1
# ENV ASPNETCORE_URLS=http://*:5000

# EXPOSE 5000

# WORKDIR /var/www/aspnetcoreapp

# CMD ["/bin/bash", "-c", "dotnet restore && dotnet watch run"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
## Can be Debug or Release.
#ARG BUILD_CONFIG=Debug
#ARG BUILDER_VERSION=0.0.1
LABEL maintainer=rajshekhar.jagadi@cognizant.com 
## Will be the path mapped to the external volume.
ARG BUILD_LOCATION=/app/Services/Payers/Payers.Api/out
ENV NUGET_XMLDOC_MODE skip
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /app
#COPY *.csproj .
COPY ["Services/Payers/Payers.Api/Payers.Api.csproj", "Services/Payers/Payers.Api/"]
COPY ["Services/Payers/Payers.Infrastructure/Payers.Infrastructure.csproj", "Services/Payers/Payers.Infrastructure/"]
COPY ["Services/Payers/Payers.Domain/Payers.Domain.csproj", "Services/Payers/Payers.Domain/"]
COPY ["Services/Shared/Shared.Domain/Shared.Domain.csproj", "Services/Shared/Shared.Domain/"]
RUN dotnet restore "Services/Payers/Payers.Api/Payers.Api.csproj"

#COPY . /app
COPY . . 
WORKDIR "/app/Services/Payers/Payers.Api"
RUN dotnet publish --output /app/Services/Payers/Payers.Api/out --configuration Debug








# Build the image:
# docker build -f aspnetcore.development.dockerfile -t [yourDockerHubID]/dotnet:1.0.0 .
# docker build -f aspnetcore.development.dockerfile -t cdepoc.azurecr.io/payersapi:v3.0 .
# Option 1
# Start PostgreSQL and ASP.NET Core (link ASP.NET core to ProgreSQL container with legacy linking)
 
# docker run -d --name my-postgres -e POSTGRES_PASSWORD=password postgres
# docker run -d -p 5000:5000 --link my-postgres:postgres [yourDockerHubID]/dotnet:1.0.0

# Option 2: Create a custom bridge network and add containers into it

# docker network create --driver bridge isolated_network
# docker run -d --net=isolated_network --name postgres -e POSTGRES_PASSWORD=password postgres
# docker run -d --net=isolated_network --name aspnetcoreapp -p 5000:5000 [yourDockerHubID]/dotnet:1.0.0