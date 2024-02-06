FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MiguelGuedelha.ReverseProxy/MiguelGuedelha.ReverseProxy.csproj", "MiguelGuedelha.ReverseProxy/"]
RUN dotnet restore "MiguelGuedelha.ReverseProxy/MiguelGuedelha.ReverseProxy.csproj"
COPY . .
WORKDIR "/src/MiguelGuedelha.ReverseProxy"
RUN dotnet build "MiguelGuedelha.ReverseProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiguelGuedelha.ReverseProxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiguelGuedelha.ReverseProxy.dll"]
