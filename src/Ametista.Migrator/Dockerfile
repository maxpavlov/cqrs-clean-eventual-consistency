FROM microsoft/dotnet:2.2-runtime
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Ametista.Migrator.dll"]