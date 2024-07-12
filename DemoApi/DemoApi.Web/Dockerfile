FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["DemoApi/DemoApi.csproj", "DemoApi/"]
RUN dotnet restore "DemoApi/DemoApi.csproj"
COPY . .
WORKDIR "/src/DemoApi"
RUN dotnet build "DemoApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "DemoApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final


EXPOSE 8080
EXPOSE 8081

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoApi.dll"]
