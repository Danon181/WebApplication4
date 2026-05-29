FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["WebApplication4.csproj", "."]
RUN dotnet restore "./WebApplication4.csproj"
COPY . .
RUN dotnet build "./WebApplication4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./WebApplication4.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ← Это ключевая строка для Railway!
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

ENTRYPOINT ["dotnet", "WebApplication4.dll"]