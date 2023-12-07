FROM mcr.microsoft.com/mssql/server:2022-latest
EXPOSE 1433
USER root
# Create a config directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Bundle config source
COPY ./Scripts /usr/config
COPY ./entrypoint.sh /usr/config
COPY ./configure-db.sh /usr/config

# Grant permissions for to our scripts to be executable
RUN chmod +x /usr/config/entrypoint.sh
RUN chmod +x /usr/config/configure-db.sh

ENTRYPOINT ["./entrypoint.sh"]