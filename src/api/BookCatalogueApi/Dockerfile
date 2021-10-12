#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM microsoft/aspnetcore
WORKDIR /app
COPY . .



ENV ASPNETCORE_ENVIRONMENT=lab



EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "BookCatalogueApi.dll"]