
FROM microsoft/aspnetcore:2.0
LABEL Name=carvecho Version=1.0.0 
ARG source=.
WORKDIR /app
EXPOSE 9000
COPY $source .
ENTRYPOINT dotnet carvecho.dll
