FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch
ARG WEBAPP_VERSION=0.0.1
LABEL maintainer=rajshekhar.jagadi@cognizant.com \
    Name=webapp \
    Version=${WEBAPP_VERSION}
ARG URL_PORT
WORKDIR /app/Services/Payers/Payers.Api/out
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_URLS http://*:${URL_PORT}
ENTRYPOINT [ "dotnet", "Payers.Api.dll" ]

#link reference
#https://medium.com/@Likhitd/asp-net-core-and-mysql-with-docker-part-2-ee7fba1fc508
## Build builder image
#docker build -f .\Services\Payers\Payers.Api\Docker\Build.dockerfile -t webapp:Build --build-arg BUILD_CONFIG=Debug . 


# Build prod image
#docker build -f .\Services\Payers\Payers.Api\Docker\App.dockerfile -t webapp:0.1 --build-arg URL_PORT=7909 . 


# Create a container to copy dlls to appbuild
#docker create --name webapp.builder -v appbuild:/app/Services/Payers/Payers.Api/out webapp:Build


# Test that the dlls have been copied to appbuild by creating a simple bash container with the volume attached
#docker run --name bash -v appbuild:/app/Services/Payers/Payers.Api/out --workdir /app/Services/Payers/Payers.Api/out bash ls


# Run the application
# docker run --name webapp.test -v appbuild:/app/Services/Payers/Payers.Api/out -p 5000:7909 -d webapp:0.1

# Check the logs to see if app is running
# docker logs webapp.test


#steps for mysql
#docker run --name payersdb -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql/mysql-server:5.7

#run and connect to mysql (payersdb)
#docker exec -it payersdb mysql -u root -p 
#Enter password: my-secret-pw
#mysql show databases;

# Stop and remove the container created previously.
# docker stop payersdb; docker rm payersdb;
# Create a db volume
# docker volume create dbvol
# Start the container
# Let us also forward the MySQL server port 3306 to the host so that the host can connect using MYSQL_USER credentials to the db from localhost:3306.
# docker run --name cdepocdbsrv -e MYSQL_RANDOM_ROOT_PASSWORD=yes -e PAYERS_DB_NAME=payers -e MYSQL_USER=user_name_1 -e MYSQL_PASSWORD=my-secret-pw -v dbvol:/var/lib/mysql -p 3307:3307 -d mysql/mysql-server:5.7
#docker run --name mybash --link db -it bash