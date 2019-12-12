FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
## Can be Debug or Release.
ARG BUILD_CONFIG=Debug
ARG BUILDER_VERSION=0.0.1
LABEL maintainer=rajshekhar.jagadi@cognizant.com \
    Name=webapp-build-${BUILD_CONFIG} \
    Version=${BUILDER_VERSION}
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