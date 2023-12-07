#!/bin/bash

# Wait 60 seconds for SQL Server to start up by ensuring that 
# calling SQLCMD does not return an error code, which will ensure that sqlcmd is accessible

DBSTATUS=1
ERRCODE=0
i=0

# Aguarde 60 segundos para que o SQL Server seja inicializado
while [[ $DBSTATUS -gt 0 ]] && [[ $i -lt 60 ]] && [[ $ERRCODE -eq 0 ]]; do
	i=$i+1
	DBSTATUS=$(/opt/mssql-tools/bin/sqlcmd -h -1 -t 1 -U sa -P $MSSQL_SA_PASSWORD -Q "SET NOCOUNT ON; Select SUM(state) from sys.databases")
	ERRCODE=$?
	echo 'DBSTATUS: ' + $DBSTATUS
	echo 'ERRCODE: ' + $ERRCODE
	sleep 1
done

i=0
ERRCODE_EXIST=0
DBEXISTS=""

# Verifica se já existe uma base de dados MyFinance, caso não exista será criado.
while [[ $DBEXISTS == "" ]] && [[ $i -lt 60 ]] && [[ $ERRCODE_EXIST -eq 0 ]]; do
	i=$i+1

	if [[ $DBSTATUS -eq 0 ]] && [[ $ERRCODE -eq 0 ]]; then 
		DBEXISTS=$(/opt/mssql-tools/bin/sqlcmd -h -1 -t 1 -U sa -P $MSSQL_SA_PASSWORD -Q "SET NOCOUNT ON; Select name from sys.databases where name = 'MyFinance'")
		ERRCODE_EXIST=$?
	fi

	echo 'DBEXISTS: ' + $DBEXISTS
	echo 'ERRCODE_EXIST: ' + $ERRCODE_EXIST

	if [[ $DBEXISTS == "MyFinance" ]] && [[ $ERRCODE_EXIST -eq 0 ]]; then 
		echo "Database exists"
		break
	else
		/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -i CREATE_DATA_BASE.sql
	fi

	sleep 1

done
