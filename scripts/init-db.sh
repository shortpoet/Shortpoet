#!/bin/bash
set -e

# this throws bad substitution error
# also weird that there was no way to source colors file
# might be because it's run from another script
# was because this image uses ubuntu or something that uses bash not sh
dir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"
filename=$(basename ${BASH_SOURCE[0]})
# filename=docker-entrypoint-db.sh

echo -e "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
echo -e "${filename} script has been executed"

# /opt/mssql/bin/sqlservr

echo -e "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

until /opt/mssql-tools/bin/sqlcmd -S mssql -U sa -P ${MSSQL_PASSWORD} -d master -i $dir/setup.sql; do
  >&2 echo -e "Mssql is unavailable - sleeping"
  sleep 2
done
echo -e "Ending init process test - now"
  
>&2 echo -e "Mssql is up - executing command sql startup command"

sqlpackage  \
  /a:Import \
    /SourceFile:'/usr/config/ShortpoetDb.bacpac' \
    /TargetServerName:'mssql' \
    /TargetDatabaseName:ShortpoetDb \
    /tu:'sa' /tp:'Passw@rd' \
    /tec:false
