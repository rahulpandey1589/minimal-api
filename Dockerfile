FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["minimal_api.csproj", "minimal-api/"]
RUN dotnet restore "minimal-api/minimal_api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "minimal_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "minimal_api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "minimal_api.dll"]
