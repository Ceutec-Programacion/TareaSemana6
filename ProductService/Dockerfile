# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app .

EXPOSE 5001

ENTRYPOINT ["dotnet", "ProductService.dll"]
