FROM mcr.microsoft.com/mssql/server:2022-latest
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=${SA_PASSWORD}
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433
WORKDIR /src
COPY script.sql ./script.sql
RUN /opt/mssql/bin/sqlservr --accept-eula &
RUN sleep 30  # Increase sleep time if needed
RUN /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P ${SA_PASSWORD} -i script.sql

