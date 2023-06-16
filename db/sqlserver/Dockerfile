FROM mcr.microsoft.com/mssql/server
USER root
COPY init.sql .
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh
ENTRYPOINT ["./entrypoint.sh"]
