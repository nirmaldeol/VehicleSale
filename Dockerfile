FROM microsoft/aspnetcore-build  
ARG source  
RUN echo "source: $source"  
WORKDIR /app  
COPY ${source:-/build} .  
EXPOSE 80  
ENTRYPOINT ["dotnet", "carvecho.dll"]  