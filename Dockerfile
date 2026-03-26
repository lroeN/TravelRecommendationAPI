FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["travel-recommendation-api/travel-recommendation-api.csproj", "travel-recommendation-api/"]
RUN dotnet restore "travel-recommendation-api/travel-recommendation-api.csproj"
COPY . .
WORKDIR "/src/travel-recommendation-api"
RUN dotnet build "./travel-recommendation-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./travel-recommendation-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "travel-recommendation-api.dll"]
