#!/usr/bin/env bash

start_time="$(date -u +%s)"

run_sql() {
  sqlcmd -S localhost -U SA -P '<YourStrong@Passw0rd>' -Q "$1"
}
pw=$(pass -c1 Azure/ShortpoetServer)
start_docker() {
  sudo docker pull --platform='linux/amd64' mcr.microsoft.com/mssql/server:2022-latest
  sudo docker run \
    --platform='linux/amd64' \
    -e "ACCEPT_EULA=Y" \
    -e "MSSQL_SA_PASSWORD=$pw" \
    -p 1433:1433 \
    --name sql1 \
    --hostname sql1 \
    -d \
    mcr.microsoft.com/mssql/server:2022-latest
}

docker-compose up -d --remove-orphans

start_docker

docker exec -it sql1 bash -c "/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '$pw' -Q 'CREATE DATABASE ShortpoetServer'"
docker exec -it mssql bash -c "/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Passw@rd' -Q 'select @@VERSION'"
# this command exported the db to a bacpac file
docker exec -it mssql bash -c "sqlpackage /a:export /scs:\"Server=shortpoetserver.database.windows.net;Database=ShortpoetDb;User Id=ShortpoetDbUser;Password=$pw;\" /tf:/usr/config/ShortpoetDb.bacpac"
# this command imported the db from the bacpac file
docker exec -it mssql bash -c "sqlpackage  /a:Import /SourceFile:'/usr/config/ShortpoetDb.bacpac' /TargetServerName:'mssql' /TargetDatabaseName:ShortpoetDb /tu:'sa' /tp:'Passw@rd' /tec:false"

docker exec -it mssql bash 

 /a:Import /SourceFile:"file.bacpac" /TargetServerName:".\SQLEXPRESS" /TargetDatabaseName:CopyOfAzureDb